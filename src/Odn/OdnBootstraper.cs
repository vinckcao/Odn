using Odn.Dependency;
using Odn.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency.Installers;
using Odn.Reflection;

namespace Odn
{
    public class OdnBootstrapper : IDisposable
    {
        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; private set; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        private IOdnModuleManager _moduleManager;

        ///// <summary>
        ///// Creates a new <see /> instance.
        ///// </summary>
        ///// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        //public OdnBootstrapper(IIocManager iocManager)
        //{
        //    IocManager = iocManager;
        //}

        public OdnBootstrapper()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        public virtual void Initialize()
        {
            //容器注册
            RegisterDependencies();

            //到这里容器开始工作
            IocManager.IocContainer.Install(new OdnCoreInstaller());

            //IocManager.Resolve<AbpStartupConfiguration>().Initialize();

            //初始化各个项目中的Module
            _moduleManager = IocManager.Resolve<IOdnModuleManager>();
            _moduleManager.InitializeModules();
        }

        protected virtual void RegisterDependencies()
        {
            IocManager = new IocManager();
            //var builder = new ContainerBuilder();
            //var container = builder.Build();
            ////this._containerManager = new ContainerManager(container);

            ////we create new instance of ContainerBuilder
            ////because Build() or Update() method can only be called once on a ContainerBuilder.

            ////dependencies
            //var typeFinder = new TypeFinder();
            //builder = new ContainerBuilder();
            ////builder.RegisterInstance(config).As<NopConfig>().SingleInstance();
            ////builder.RegisterInstance(this).As<IEngine>().SingleInstance();

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
