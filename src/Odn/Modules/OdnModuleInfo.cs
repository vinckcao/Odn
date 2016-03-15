using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Modules
{
    /// <summary>
    /// Used to store all needed information for a module.
    /// </summary>
    internal class OdnModuleInfo
    {
        /// <summary>
        /// The assembly which contains the module definition.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// Type of the module.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Instance of the module.
        /// </summary>
        public OdnModule Instance { get; private set; }

        /// <summary>
        /// All dependent modules of this module.
        /// </summary>
        public List<OdnModuleInfo> Dependencies { get; private set; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        /// <param name="instance"></param>
        public OdnModuleInfo(OdnModule instance)
        {
            Dependencies = new List<OdnModuleInfo>();
            Type = instance.GetType();
            Instance = instance;
            Assembly = Type.Assembly;
        }

        public override string ToString()
        {
            return string.Format("{0}", Type.AssemblyQualifiedName);
        }
    }
}
