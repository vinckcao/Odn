using NLog;
using Odn.Configuration.Startup;
using Odn.Logging;
using Odn.Modules;
using Odn.Reflection;

namespace Odn.Dependency.Installers
{
    internal class OdnCoreInstaller : IOdnInstaller
    {
        public void Install(IIocContainer container)
        {
            container.RegisterWithInstance<ILogger>(LogManager.GetLogger(OdnLoggerNames.FrameworkLoggerName), DependencyLifeStyle.Singleton);

            container.Register<IOdnStartupConfiguration, OdnStartupConfiguration, OdnStartupConfiguration>(DependencyLifeStyle.Singleton);
            container.Register<ISettingsConfiguration, SettingsConfiguration, SettingsConfiguration>(DependencyLifeStyle.Singleton);
            container.Register<IModuleConfigurations, ModuleConfigurations, ModuleConfigurations>(DependencyLifeStyle.Singleton);

            container.Register<ITypeFinder, TypeFinder, TypeFinder>(DependencyLifeStyle.Singleton);
            container.Register<IOdnModuleManager, OdnModuleManager, OdnModuleManager>(DependencyLifeStyle.Singleton);
            container.Register<IModuleFinder, DefaultModuleFinder, DefaultModuleFinder>(DependencyLifeStyle.Singleton);


            //Component.For<IUnitOfWorkDefaultOptions, UnitOfWorkDefaultOptions>().ImplementedBy<UnitOfWorkDefaultOptions>().LifestyleSingleton(),
            //    Component.For<INavigationConfiguration, NavigationConfiguration>().ImplementedBy<NavigationConfiguration>().LifestyleSingleton(),
            //    Component.For<ILocalizationConfiguration, LocalizationConfiguration>().ImplementedBy<LocalizationConfiguration>().LifestyleSingleton(),
            //    Component.For<IAuthorizationConfiguration, AuthorizationConfiguration>().ImplementedBy<AuthorizationConfiguration>().LifestyleSingleton(),
            //    Component.For<IFeatureConfiguration, FeatureConfiguration>().ImplementedBy<FeatureConfiguration>().LifestyleSingleton(),
            //    Component.For<ISettingsConfiguration, SettingsConfiguration>().ImplementedBy<SettingsConfiguration>().LifestyleSingleton(),
            //    Component.For<IModuleConfigurations, ModuleConfigurations>().ImplementedBy<ModuleConfigurations>().LifestyleSingleton(),
            //    Component.For<IEventBusConfiguration, EventBusConfiguration>().ImplementedBy<EventBusConfiguration>().LifestyleSingleton(),
            //    Component.For<IMultiTenancyConfig, MultiTenancyConfig>().ImplementedBy<MultiTenancyConfig>().LifestyleSingleton(),
            //    Component.For<ICachingConfiguration, CachingConfiguration>().ImplementedBy<CachingConfiguration>().LifestyleSingleton(),
            //    Component.For<IAuditingConfiguration, AuditingConfiguration>().ImplementedBy<AuditingConfiguration>().LifestyleSingleton(),
            //    Component.For<IAbpStartupConfiguration, AbpStartupConfiguration>().ImplementedBy<AbpStartupConfiguration>().LifestyleSingleton(),
            //    Component.For<ITypeFinder>().ImplementedBy<TypeFinder>().LifestyleSingleton(),
            //    Component.For<IModuleFinder>().ImplementedBy<DefaultModuleFinder>().LifestyleTransient(),
            //    Component.For<IAbpModuleManager>().ImplementedBy<AbpModuleManager>().LifestyleSingleton(),
            //    Component.For<ILocalizationManager, LocalizationManager>().ImplementedBy<LocalizationManager>().LifestyleSingleton()
        }
    }

    public interface IOdnInstaller
    {
        void Install(IIocContainer container);
    }
}
