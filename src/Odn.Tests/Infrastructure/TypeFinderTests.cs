using Odn.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Odn.Tests.Infrastructure
{
    public class TypeFinderTests
    {
        [Fact]
        public void TypeFinder_Benchmark_Findings()
        {
            var finder = new TypeFinder();

            var type = finder.FindClassesOfType<ISomeInterface>();
            Assert.Equal(type.Count(), 1);
            Assert.True(typeof(ISomeInterface).IsAssignableFrom(type.FirstOrDefault()));
        }

        public interface ISomeInterface
        {
        }

        public class SomeClass : ISomeInterface
        {
        }
    }
}
