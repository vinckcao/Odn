using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Authorizations
{
    public interface IAuthorizeAttributeHelper
    {
        Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(IAbpAuthorizeAttribute authorizeAttribute);

        void Authorize(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes);

        void Authorize(IAbpAuthorizeAttribute authorizeAttribute);
    }
}
