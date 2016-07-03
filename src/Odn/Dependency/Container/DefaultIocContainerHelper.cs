using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Dependency.Container
{
    public class DefaultIocContainerHelper
    {
        public static IIocContainer CreateDefaultContainer()
        {
            return NullIocContainer.Instance;
        }
    }
}
