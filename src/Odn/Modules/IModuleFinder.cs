using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Modules
{
    /// <summary>
    /// This interface is responsible to find all modules (derived from <see cref="OdnModule"/>)
    /// in the application.
    /// </summary>
    public interface IModuleFinder
    {
        /// <summary>
        /// Finds all modules.
        /// </summary>
        /// <returns>List of modules</returns>
        ICollection<Type> FindAll();
    }
}
