using Odn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Odn.Tests.Infrastructure
{
    [Trait("a", "a")]
    public class SingletonTests
    {
        [Fact]
        public void Singleton_IsNullByDefault()
        {
            var instance = Singleton<SingletonTests>.Instance;
            Assert.Null(instance);
        }

        [Fact]
        public void Singletons_ShareSame_SingletonsDictionary()
        {
            Singleton<int>.Instance = 1;
            Singleton<double>.Instance = 2.0;


            //Assert.That(Singleton<int>.AllSingletons, Is.SameAs(Singleton<double>.AllSingletons));
            //Assert.That(Singleton.AllSingletons[typeof(int)], Is.EqualTo(1));
            //Assert.That(Singleton.AllSingletons[typeof(double)], Is.EqualTo(2.0));

            Assert.Same(Singleton<int>.AllSingletons, Singleton<double>.AllSingletons);
            Assert.Equal(Singleton.AllSingletons[typeof(int)], 1);
            Assert.Equal(Singleton.AllSingletons[typeof(double)], 2.0);
        }

        [Fact]
        public void SingletonDictionary_IsCreatedByDefault()
        {
            var instance = SingletonDictionary<SingletonTests, object>.Instance;
            //Assert.That(instance, Is.Not.Null);
            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonDictionary_CanStoreStuff()
        {
            var instance = SingletonDictionary<Type, SingletonTests>.Instance;
            instance[typeof(SingletonTests)] = this;
            //Assert.That(instance[typeof(SingletonTests)], Is.SameAs(this));
            Assert.Same(instance[typeof(SingletonTests)], this);
        }

        [Fact]
        public void SingletonList_IsCreatedByDefault()
        {
            var instance = SingletonList<SingletonTests>.Instance;
            //Assert.That(instance, Is.Not.Null);
            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonList_CanStoreItems()
        {
            var instance = SingletonList<SingletonTests>.Instance;
            instance.Insert(0, this);
            //Assert.That(instance[0], Is.SameAs(this));
            Assert.Same(instance[0], this);
        }
    }
}
