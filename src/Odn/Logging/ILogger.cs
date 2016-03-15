using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Logging
{
    public interface ILogger
    {
        void Warn(string message, Exception ex);
    }
}
