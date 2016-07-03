using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;
using Xunit;

namespace Odn.Tests
{
    public class OdnBootStrapperTest
    {
        [Fact]
        public void Test()
        {
            OdnBootstrapper bootstrapper = new OdnBootstrapper();

            Assert.NotNull(IocManager.Instance);
        }
    }

    public class IocManager_Tests : IDisposable
    {
        OdnBootstrapper Bootstrapper = null;
        public IocManager_Tests()
        {
            Bootstrapper = new OdnBootstrapper();
        }

        [Fact]
        public void Should_Get_First_Registered_Class_If_Registered_Multiple_Class_For_Same_Interface()
        {
            //此处为Castle与Autofac的不同, Castle一个对象只允许注册一次, Autofac支持多次注册, 解析是默认返回最后注册的对象
            IocManager.Instance.Register<IEmpty, EmptyImplOne>();
            IocManager.Instance.Register<IEmpty, EmptyImplTwo>(); //Second registered has no effect!
            var obj = IocManager.Instance.Resolve<IEmpty>();
            Assert.True(obj is EmptyImplOne);
        }

        public interface IEmpty
        {

        }

        public class EmptyImplOne : IEmpty
        {

        }

        public class EmptyImplTwo : IEmpty
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Bootstrapper.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~IocManager_Tests() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
