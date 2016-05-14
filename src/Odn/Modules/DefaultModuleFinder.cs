using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Reflection;

namespace Odn.Modules
{
    internal class DefaultModuleFinder : IModuleFinder
    {
        private readonly ITypeFinder _typeFinder;

        public DefaultModuleFinder(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public ICollection<Type> FindAll()
        {
            return _typeFinder.Find(OdnModule.IsOdnModule).ToList();
        }
    }
}
