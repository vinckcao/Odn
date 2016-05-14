using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency;
using Xunit;

namespace Odn.Tests
{
    public abstract class TestBaseWithLocalIocManager : IDisposable
    {
        protected IIocManager LocalIocManager;

        protected TestBaseWithLocalIocManager()
        {
            LocalIocManager = new IocManager();
        }

        public virtual void Dispose()
        {
            LocalIocManager.Dispose();
        }
    }

    public class OdnBootStrapperTest
    {
        [Fact]
        public void Test()
        {
            OdnBootstrapper bootstrapper = new OdnBootstrapper();
            Assert.True(true);
        }
    }

    public class IocManager_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void Should_Get_First_Registered_Class_If_Registered_Multiple_Class_For_Same_Interface()
        {
            LocalIocManager.Register<IEmpty, EmptyImplOne>();
            LocalIocManager.Register<IEmpty, EmptyImplTwo>(); //Second registered has no effect!
            var obj = LocalIocManager.Resolve<IEmpty>();
            Assert.True(obj is EmptyImplOne);

            //obj.GetType().ShouldBe(typeof(EmptyImplOne));

            //LocalIocManager.Resolve<IEmpty>().GetType().ShouldBe(typeof(EmptyImplOne));
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
    }
}
