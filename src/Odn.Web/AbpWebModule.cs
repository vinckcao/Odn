using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Odn.Dependency;
using Odn.Modules;

namespace Odn
{
    /// <summary>
    /// This module is used to use ABP in ASP.NET web applications.
    /// </summary>
    public class AbpWebModule : OdnModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            //if (HttpContext.Current != null)
            //{
            //    XmlLocalizationSource.RootDirectoryOfApplication = HttpContext.Current.Server.MapPath("~");
            //}

            //IocManager.Register<IAbpWebModuleConfiguration, AbpWebModuleConfiguration>();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        AbpWebLocalizedMessages.SourceName,
            //        new XmlEmbeddedFileLocalizationDictionaryProvider(
            //            Assembly.GetExecutingAssembly(), "Abp.Web.Localization.AbpWebXmlSource"
            //            )));
        }
    }
}
