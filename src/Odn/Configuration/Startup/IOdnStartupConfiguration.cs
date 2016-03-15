
using Odn.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Configuration.Startup
{
    public interface IOdnStartupConfiguration : IDictionaryBasedConfig
    {        /// <summary>
        /// Gets the IOC manager associated with this configuration.
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// Used to configure settings.
        /// </summary>
        ISettingsConfiguration Settings { get; }

        /// <summary>
        /// Used to configure modules.
        /// Modules can write extension methods to <see cref="IModuleConfigurations"/> to add module specific configurations.
        /// </summary>
        IModuleConfigurations Modules { get; }
    }
}
