using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;
using Odn.Modules;

namespace Odn.Web.Mvc
{
    /// <summary>
    /// This module is used to build ASP.NET MVC web sites using Abp.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class AbpWebMvcModule : OdnModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            //IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocManager.IocContainer.Kernel));
            //GlobalFilters.Filters.Add(IocManager.Resolve<AbpHandleErrorAttribute>());
        }
    }
}
