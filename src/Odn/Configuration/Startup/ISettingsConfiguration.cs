using Odn.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Configuration.Startup
{
    public interface ISettingsConfiguration
    {
        /// <summary>
        /// List of settings providers.
        /// </summary>
        ITypeList<SettingProvider> Providers { get; }
    }
}
