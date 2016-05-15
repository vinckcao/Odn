using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Odn.Authorizations;
using Odn.Dependency;
using Odn.Dependency.Extensions;
using Odn.Logging;

namespace Odn.WebApi.Authorization
{
    /// <summary>
    /// This attribute is used on a method of an <see cref="ApiController"/>
    /// to make that method usable only by authorized users.
    /// </summary>
    public class AbpApiAuthorizeAttribute : AuthorizeAttribute, IAbpAuthorizeAttribute
    {
        /// <inheritdoc/>
        public string[] Permissions { get; set; }

        /// <inheritdoc/>
        public bool RequireAllPermissions { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="AbpApiAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="permissions">A list of permissions to authorize</param>
        public AbpApiAuthorizeAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }

        /// <inheritdoc/>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!base.IsAuthorized(actionContext))
            {
                return false;
            }

            try
            {
                using (var authorizationAttributeHelper = IocManager.Instance.ResolveAsDisposable<IAuthorizeAttributeHelper>())
                {
                    authorizationAttributeHelper.Object.Authorize(this);
                }

                return true;
            }
            catch (AbpAuthorizationException ex)
            {
                LogHelper.Logger.Warn(ex.ToString(), ex);
                return false;
            }
        }
    }
}
