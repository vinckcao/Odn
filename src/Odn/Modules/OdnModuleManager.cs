using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Odn.Dependency;

namespace Odn.Modules
{
    /// <summary>
    /// This class is used to manage modules.
    /// </summary>
    internal class OdnModuleManager : IOdnModuleManager
    {
        public NLog.ILogger Logger = LogManager.GetLogger("Odn.Modules.OdnModuleManager");

        private readonly AbpModuleCollection _modules;

        private readonly IIocManager _iocManager;
        private readonly IModuleFinder _moduleFinder;

        public OdnModuleManager(IIocManager iocManager, IModuleFinder moduleFinder)
        {
            _modules = new AbpModuleCollection();
            _iocManager = iocManager;
            _moduleFinder = moduleFinder;
            //Logger = NullLogger.Instance;
        }

        public virtual void InitializeModules()
        {
            LoadAll();

            var sortedModules = _modules.GetSortedModuleListByDependency();

            sortedModules.ForEach(module => module.Instance.PreInitialize());
            sortedModules.ForEach(module => module.Instance.Initialize());
            sortedModules.ForEach(module => module.Instance.PostInitialize());
        }

        public virtual void ShutdownModules()
        {
            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.Reverse();
            sortedModules.ForEach(sm => sm.Instance.Shutdown());
        }

        private void LoadAll()
        {
            Logger.Debug("Loading Abp modules...");

            var moduleTypes = AddMissingDependedModules(_moduleFinder.FindAll());
            Logger.Debug("Found " + moduleTypes.Count + " ABP modules in total.");

            //Register to IOC container.
            foreach (var moduleType in moduleTypes)
            {
                if (!OdnModule.IsOdnModule(moduleType))
                {
                    throw new OdnInitializationException("This type is not an ABP module: " + moduleType.AssemblyQualifiedName);
                }

                if (!_iocManager.IsRegistered(moduleType))
                {
                    _iocManager.Register(moduleType);
                }
            }

            //Add to module collection
            foreach (var moduleType in moduleTypes)
            {
                var moduleObject = (OdnModule)_iocManager.Resolve(moduleType);

                moduleObject.IocManager = _iocManager;
                //moduleObject.Configuration = _iocManager.Resolve<IAbpStartupConfiguration>();

                _modules.Add(new AbpModuleInfo(moduleObject));

                Logger.Debug("Loaded module: " + moduleType.AssemblyQualifiedName);
            }

            //AbpKernelModule must be the first module
            var startupModuleIndex = _modules.FindIndex(m => m.Type == typeof(AbpKernelModule));
            if (startupModuleIndex > 0)
            {
                var startupModule = _modules[startupModuleIndex];
                _modules.RemoveAt(startupModuleIndex);
                _modules.Insert(0, startupModule);
            }

            SetDependencies();

            Logger.Debug("{0} modules loaded.", _modules.Count);
        }

        private void SetDependencies()
        {
            foreach (var moduleInfo in _modules)
            {
                //Set dependencies according to assembly dependency
                foreach (var referencedAssemblyName in moduleInfo.Assembly.GetReferencedAssemblies())
                {
                    var referencedAssembly = Assembly.Load(referencedAssemblyName);
                    var dependedModuleList = _modules.Where(m => m.Assembly == referencedAssembly).ToList();
                    if (dependedModuleList.Count > 0)
                    {
                        moduleInfo.Dependencies.AddRange(dependedModuleList);
                    }
                }

                //Set dependencies for defined DependsOnAttribute attribute(s).
                foreach (var dependedModuleType in OdnModule.FindDependedModuleTypes(moduleInfo.Type))
                {
                    var dependedModuleInfo = _modules.FirstOrDefault(m => m.Type == dependedModuleType);
                    if (dependedModuleInfo == null)
                    {
                        throw new OdnInitializationException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + moduleInfo.Type.AssemblyQualifiedName);
                    }

                    if ((moduleInfo.Dependencies.FirstOrDefault(dm => dm.Type == dependedModuleType) == null))
                    {
                        moduleInfo.Dependencies.Add(dependedModuleInfo);
                    }
                }
            }
        }

        private static ICollection<Type> AddMissingDependedModules(ICollection<Type> allModules)
        {
            var initialModules = allModules.ToList();
            foreach (var module in initialModules)
            {
                FillDependedModules(module, allModules);
            }

            return allModules;
        }

        private static void FillDependedModules(Type module, ICollection<Type> allModules)
        {
            foreach (var dependedModule in OdnModule.FindDependedModuleTypes(module))
            {
                if (!allModules.Contains(dependedModule))
                {
                    allModules.Add(dependedModule);
                    FillDependedModules(dependedModule, allModules);
                }
            }
        }
    }
}
