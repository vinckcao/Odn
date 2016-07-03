using Odn.Configuration;
using Odn.Configuration.Startup;
using Odn.Dependency;
using Odn.Dependency.Installers;
using Odn.Infrastructure;
using Odn.Modules;
using Odn.Reflection;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Odn
{
    public class OdnBootstrapper : IDisposable
    {
        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        private IOdnModuleManager _moduleManager;

        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; private set; }

        public OdnBootstrapper()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void Initialize()
        {
            var config = ConfigurationManager.GetSection("OdnConfig") as OdnConfig;

            var container = InitializeIocContainer(config, false);

            Singleton<IIocContainer>.Instance.RegisterWithInstance<OdnConfig>(config);//在IocContainer中注册OdnConfig

            InitializeIocManager(container, false);

            //容器注册
            RegisterDependencies();

            //到这里容器开始工作
            IocManager.IocContainer.Install(new OdnCoreInstaller());

            IocManager.Resolve<OdnStartupConfiguration>().Initialize();

            //初始化各个项目中的Module
            _moduleManager = IocManager.Resolve<IOdnModuleManager>();
            _moduleManager.InitializeModules();
        }

        /// <summary>
        /// 初始化IocContainer
        /// </summary>
        /// <param name="forceRecreate"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IIocContainer InitializeIocContainer(OdnConfig config, bool forceRecreate = false)
        {
            if (Singleton<IIocContainer>.Instance == null || forceRecreate)
            {
                Singleton<IIocContainer>.Instance = Activator.CreateInstance(config.IocContainerType) as IIocContainer;
            }
            return Singleton<IIocContainer>.Instance;
        }

        /// <summary>
        /// 初始化IocManager并注册进IocContainer
        /// </summary>
        /// <param name="forceRecreate"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IIocManager InitializeIocManager(IIocContainer container, bool forceRecreate = false)
        {
            if (Singleton<IIocManager>.Instance == null || forceRecreate)
            {
                Singleton<IIocManager>.Instance = new IocManager(container);

                container.RegisterWithInstance(Singleton<IIocManager>.Instance);//注册IocManager
            }
            return Singleton<IIocManager>.Instance;
        }

        protected virtual void RegisterDependencies()
        {
            //dependencies
            //var typeFinder = new TypeFinder();

            //builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            //builder.Update(container);

            //register dependencies provided by other assemblies
            //builder = new ContainerBuilder();
            //var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            //var drInstances = new List<IDependencyRegistrar>();
            //foreach (var drType in drTypes)
            //    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            ////sort
            //drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            //foreach (var dependencyRegistrar in drInstances)
            //    dependencyRegistrar.Register(builder, typeFinder, config);
            //builder.Update(container);

            //set dependency resolver
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// Disposes the ABP system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            if (_moduleManager != null)
            {
                _moduleManager.ShutdownModules();
            }
        }
    }
}
