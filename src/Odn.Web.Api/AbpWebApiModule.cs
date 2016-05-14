using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;
using Odn.Modules;

namespace Odn.Web.Api
{
    /// <summary>
    /// This module provides Abp features for ASP.NET Web API.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class AbpWebApiModule : OdnModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            //IocManager.AddConventionalRegistrar(new ApiControllerConventionalRegistrar());
            //IocManager.Register<IAbpWebApiModuleConfiguration, AbpWebApiModuleConfiguration>();

            //Configuration.Settings.Providers.Add<ClearCacheSettingProvider>();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //var httpConfiguration = IocManager.Resolve<IAbpWebApiModuleConfiguration>().HttpConfiguration;

            //InitializeAspNetServices(httpConfiguration);
            //InitializeFilters(httpConfiguration);
            //InitializeFormatters(httpConfiguration);
            //InitializeRoutes(httpConfiguration);
        }

        public override void PostInitialize()
        {
            //foreach (var controllerInfo in DynamicApiControllerManager.GetAll())
            //{
            //    IocManager.IocContainer.Register(
            //        Component.For(controllerInfo.InterceptorType).LifestyleTransient(),
            //        Component.For(controllerInfo.ApiControllerType)
            //            .Proxy.AdditionalInterfaces(controllerInfo.ServiceInterfaceType)
            //            .Interceptors(controllerInfo.InterceptorType)
            //            .LifestyleTransient()
            //        );

            //    LogHelper.Logger.DebugFormat("Dynamic web api controller is created for type '{0}' with service name '{1}'.", controllerInfo.ServiceInterfaceType.FullName, controllerInfo.ServiceName);
            //}
        }

        //private void InitializeAspNetServices(HttpConfiguration httpConfiguration)
        //{
        //    httpConfiguration.Services.Replace(typeof(IHttpControllerSelector), new AbpHttpControllerSelector(httpConfiguration));
        //    httpConfiguration.Services.Replace(typeof(IHttpActionSelector), new AbpApiControllerActionSelector());
        //    httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), new AbpApiControllerActivator(IocManager));
        //}

        //private void InitializeFilters(HttpConfiguration httpConfiguration)
        //{
        //    httpConfiguration.Filters.Add(IocManager.Resolve<AbpExceptionFilterAttribute>());
        //}

        //private static void InitializeFormatters(HttpConfiguration httpConfiguration)
        //{
        //    httpConfiguration.Formatters.Clear();
        //    var formatter = new JsonMediaTypeFormatter();
        //    formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //    httpConfiguration.Formatters.Add(formatter);
        //    httpConfiguration.Formatters.Add(new PlainTextFormatter());
        //}

        //private static void InitializeRoutes(HttpConfiguration httpConfiguration)
        //{
        //    //Dynamic Web APIs (with area name)
        //    httpConfiguration.Routes.MapHttpRoute(
        //        name: "AbpDynamicWebApi",
        //        routeTemplate: "api/services/{*serviceNameWithAction}"
        //        );
        //}
    }
}
