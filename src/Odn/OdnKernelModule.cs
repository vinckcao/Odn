using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;
using Odn.Dependency.Extensions;
using Odn.Modules;

namespace Odn
{
    /// <summary>
    /// Kernel (core) module of the ABP system.
    /// No need to depend on this, it's automatically the first module always.
    /// </summary>
    public sealed class AbpKernelModule : OdnModule
    {
        public override void PreInitialize()
        {
            //IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            //ValidationInterceptorRegistrar.Initialize(IocManager);

            //FeatureInterceptorRegistrar.Initialize(IocManager);
            //AuditingInterceptorRegistrar.Initialize(IocManager);

            //UnitOfWorkRegistrar.Initialize(IocManager);

            //AuthorizationInterceptorRegistrar.Initialize(IocManager);

            //Configuration.Auditing.Selectors.Add(
            //    new NamedTypeSelector(
            //        "Abp.ApplicationServices",
            //        type => typeof(IApplicationService).IsAssignableFrom(type)
            //        )
            //    );

            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        AbpConsts.LocalizationSourceName,
            //        new XmlEmbeddedFileLocalizationDictionaryProvider(
            //            Assembly.GetExecutingAssembly(), "Abp.Localization.Sources.AbpXmlSource"
            //            )));

            //Configuration.Settings.Providers.Add<EmailSettingProvider>();

            //Configuration.UnitOfWork.RegisterFilter(AbpDataFilters.SoftDelete, true);
            //Configuration.UnitOfWork.RegisterFilter(AbpDataFilters.MustHaveTenant, true);
            //Configuration.UnitOfWork.RegisterFilter(AbpDataFilters.MayHaveTenant, true);

            ConfigureCaches();
        }

        public override void Initialize()
        {
            base.Initialize();

            //IocManager.IocContainer.Install(new EventBusInstaller(IocManager));

            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(),
            //    new ConventionalRegistrationConfig
            //    {
            //        InstallInstallers = false
            //    });
        }

        public override void PostInitialize()
        {
            RegisterMissingComponents();

            //IocManager.Resolve<LocalizationManager>().Initialize();
            //IocManager.Resolve<FeatureManager>().Initialize();
            //IocManager.Resolve<NavigationManager>().Initialize();
            //IocManager.Resolve<PermissionManager>().Initialize();
            //IocManager.Resolve<SettingDefinitionManager>().Initialize();
        }

        private void ConfigureCaches()
        {
            //Configuration.Caching.Configure(SettingManager.ApplicationSettingsCacheName, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            //});

            //Configuration.Caching.Configure(SettingManager.TenantSettingsCacheName, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(60);
            //});

            //Configuration.Caching.Configure(SettingManager.ApplicationSettingsCacheName, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(20);
            //});
        }

        private void RegisterMissingComponents()
        {
            //IocManager.RegisterIfNot<IUnitOfWork, NullUnitOfWork>(DependencyLifeStyle.Transient);
            //IocManager.RegisterIfNot<IAuditInfoProvider, NullAuditInfoProvider>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IAuditingStore, SimpleLogAuditingStore>(DependencyLifeStyle.Transient);
        }
    }
}
