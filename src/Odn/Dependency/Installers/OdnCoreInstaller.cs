using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Odn.Configuration.Startup;
using Odn.Modules;
using Odn.Reflection;

namespace Odn.Dependency.Installers
{
    internal class OdnCoreInstaller : IWindsorInstaller
    {public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //Component.For<IUnitOfWorkDefaultOptions, UnitOfWorkDefaultOptions>().ImplementedBy<UnitOfWorkDefaultOptions>().LifestyleSingleton(),
                //Component.For<INavigationConfiguration, NavigationConfiguration>().ImplementedBy<NavigationConfiguration>().LifestyleSingleton(),
                //Component.For<ILocalizationConfiguration, LocalizationConfiguration>().ImplementedBy<LocalizationConfiguration>().LifestyleSingleton(),
                //Component.For<IAuthorizationConfiguration, AuthorizationConfiguration>().ImplementedBy<AuthorizationConfiguration>().LifestyleSingleton(),
                //Component.For<IFeatureConfiguration, FeatureConfiguration>().ImplementedBy<FeatureConfiguration>().LifestyleSingleton(),
                //Component.For<ISettingsConfiguration, SettingsConfiguration>().ImplementedBy<SettingsConfiguration>().LifestyleSingleton(),
                //Component.For<IModuleConfigurations, ModuleConfigurations>().ImplementedBy<ModuleConfigurations>().LifestyleSingleton(),
                //Component.For<IEventBusConfiguration, EventBusConfiguration>().ImplementedBy<EventBusConfiguration>().LifestyleSingleton(),
                //Component.For<IMultiTenancyConfig, MultiTenancyConfig>().ImplementedBy<MultiTenancyConfig>().LifestyleSingleton(),
                //Component.For<ICachingConfiguration, CachingConfiguration>().ImplementedBy<CachingConfiguration>().LifestyleSingleton(),
                //Component.For<IAuditingConfiguration, AuditingConfiguration>().ImplementedBy<AuditingConfiguration>().LifestyleSingleton(),
                //Component.For<IAbpStartupConfiguration, AbpStartupConfiguration>().ImplementedBy<AbpStartupConfiguration>().LifestyleSingleton(),
                Component.For<ITypeFinder>().ImplementedBy<TypeFinder>().LifestyleSingleton(),
                Component.For<IModuleFinder>().ImplementedBy<DefaultModuleFinder>().LifestyleTransient(),
                Component.For<IOdnModuleManager>().ImplementedBy<OdnModuleManager>().LifestyleSingleton()
                //Component.For<ILocalizationManager, LocalizationManager>().ImplementedBy<LocalizationManager>().LifestyleSingleton()
                );
        }
    }
}
