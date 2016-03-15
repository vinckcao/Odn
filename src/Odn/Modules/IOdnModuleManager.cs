using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Modules
{
    internal interface IOdnModuleManager
    {
        void InitializeModules();

        void ShutdownModules();
    }
}
