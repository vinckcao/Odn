using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;

namespace Odn.Configuration.Startup
{
    public class OdnStartupConfiguration : DictionayBasedConfig, IOdnStartupConfiguration
    {
        public IIocManager IocManager { get; private set; }

        public IModuleConfigurations Modules { get; private set; }

        public ISettingsConfiguration Settings { get; private set; }

        public void Initialize()
        {
            //Localization = IocManager.Resolve<ILocalizationConfiguration>();
            Modules = IocManager.Resolve<IModuleConfigurations>();
            //Features = IocManager.Resolve<IFeatureConfiguration>();
            //Navigation = IocManager.Resolve<INavigationConfiguration>();
            //Authorization = IocManager.Resolve<IAuthorizationConfiguration>();
            Settings = IocManager.Resolve<ISettingsConfiguration>();
            //UnitOfWork = IocManager.Resolve<IUnitOfWorkDefaultOptions>();
            //EventBus = IocManager.Resolve<IEventBusConfiguration>();
            //MultiTenancy = IocManager.Resolve<IMultiTenancyConfig>();
            //Auditing = IocManager.Resolve<IAuditingConfiguration>();
            //Caching = IocManager.Resolve<ICachingConfiguration>();
        }
    }
}
