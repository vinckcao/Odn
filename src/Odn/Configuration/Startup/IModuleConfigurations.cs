using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Configuration.Startup
{
    /// <summary>
    /// Used to provide a way to configure modules.
    /// Create entension methods to this class to be used over <see cref="IAbpStartupConfiguration.Modules"/> object.
    /// </summary>
    public interface IModuleConfigurations
    {
        /// <summary>
        /// Gets the ABP configuration object.
        /// </summary>
        IOdnStartupConfiguration OdnConfiguration { get; }
    }
}
