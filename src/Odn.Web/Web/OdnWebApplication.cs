using Odn.Dependency.Extensions;
using Odn.Reflection;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using Odn.Dependency;
using Odn.Localization;

namespace Odn.Web
{
    public class OdnWebApplication : HttpApplication
    {
        private const string LocalizationCultureName = "Odn.Localization.CultureName";

        /// <summary>
        /// Gets a reference to the <see cref="AbpBootstrapper"/> instance.
        /// </summary>
        private OdnBootstrapper OdnBootstrapper { get; set; }

        protected OdnWebApplication()
        {
            OdnBootstrapper = new OdnBootstrapper();
        }

        /// <summary>
        /// This method is called by ASP.NET system on web application's startup.
        /// </summary>
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            OdnBootstrapper.IocManager.RegisterIfNot<IAssemblyFinder, WebAssemblyFinder>();
            OdnBootstrapper.Initialize();
        }

        protected virtual void Application_End(object sender, EventArgs e)
        {
            OdnBootstrapper.Dispose();
        }

        protected virtual void Session_Start(object sender, EventArgs e)
        {

        }

        protected virtual void Session_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method is called by ASP.NET system when a request starts.
        /// </summary>
        protected virtual void Application_BeginRequest(object sender, EventArgs e)
        {
            var langCookie = Request.Cookies[LocalizationCultureName];
            if (langCookie != null && GlobalizationHelper.IsValidCultureCode(langCookie.Value))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(langCookie.Value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCookie.Value);
            }
        }

        /// <summary>
        /// This method is called by ASP.NET system when a request ends.
        /// </summary>
        protected virtual void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected virtual void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected virtual void Application_Error(object sender, EventArgs e)
        {

        }
    }
}
