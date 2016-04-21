using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;

namespace Odn.Tests.Bootstrapper
{
    public abstract class Bootstrap_Test : IDisposable
    {
        private OdnBootstrapper bootstrapper;

        protected Bootstrap_Test()
        {
            this.bootstrapper = new OdnBootstrapper(new IocManager());
            bootstrapper.Initialize();
        }



        public virtual void Dispose()
        {
            bootstrapper.Dispose();
        }
    }
}
