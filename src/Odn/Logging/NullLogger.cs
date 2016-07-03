using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Logging
{
    public class NullLogger : ILogger
    {
        public static NullLogger Instance { get; private set; }
        static NullLogger()
        {
            Instance = new NullLogger();
        }

        NullLogger()
        { 
        
        }

        public void Warn(string message, Exception ex)
        {
            //throw new NotImplementedException();
        }
    }
}
