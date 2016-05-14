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
    internal class AbpModuleInfo
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
        public List<AbpModuleInfo> Dependencies { get; private set; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        /// <param name="instance"></param>
        public AbpModuleInfo(OdnModule instance)
        {
            Dependencies = new List<AbpModuleInfo>();
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
