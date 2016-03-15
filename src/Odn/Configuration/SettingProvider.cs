using Odn.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Configuration
{
    /// <summary>
    /// Inherit this class to define settings for a module/application.
    /// </summary>
    public abstract class SettingProvider : ITransientDependency
    {
        /// <summary>
        /// Gets all setting definitions provided by this provider.
        /// </summary>
        /// <returns>List of settings</returns>
        //public abstract IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context);
    }
}
