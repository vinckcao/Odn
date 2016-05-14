using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Collections.Extensions;

namespace Odn.Modules
{
    /// <summary>
    /// Used to store AbpModuleInfo objects as a dictionary.
    /// </summary>
    internal class AbpModuleCollection : List<AbpModuleInfo>
    {
        /// <summary>
        /// Gets a reference to a module instance.
        /// </summary>
        /// <typeparam name="TModule">Module type</typeparam>
        /// <returns>Reference to the module instance</returns>
        public TModule GetModule<TModule>() where TModule : OdnModule
        {
            var module = this.FirstOrDefault(m => m.Type == typeof(TModule));
            if (module == null)
            {
                throw new OdnException("Can not find module for " + typeof(TModule).FullName);
            }

            return (TModule)module.Instance;
        }

        /// <summary>
        /// Sorts modules according to dependencies.
        /// If module A depends on module B, A comes after B in the returned List.
        /// </summary>
        /// <returns>Sorted list</returns>
        public List<AbpModuleInfo> GetSortedModuleListByDependency()
        {
            return this.SortByDependencies(x => x.Dependencies).ToList();
        }
    }
}
