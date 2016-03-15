using Odn.Dependency;
using Odn.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Creates a new <see cref="AbpBootstrapper"/> instance.
        /// </summary>
        public OdnBootstrapper()
            //: this(Dependency.IocManager.Instance)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpBootstrapper"/> instance.
        /// </summary>
        /// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        public OdnBootstrapper(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        public virtual void Initialize()
        {
            //IocManager.IocContainer.Install(new AbpCoreInstaller());

            //IocManager.Resolve<AbpStartupConfiguration>().Initialize();

            _moduleManager = IocManager.Resolve<IOdnModuleManager>();
            _moduleManager.InitializeModules();
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
