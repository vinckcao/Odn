using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Reflection
{
    public interface ITypeFinder
    {

        #region 返回值Abp喜欢用数组
        IEnumerable<Type> Find(Func<Type, bool> predicate);

        IEnumerable<Type> FindAll(); 
        #endregion


        #region Nop提供的方法, 返回值Nop设计偏向于用List泛型
        IList<Assembly> GetAssemblies();

        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true); 
        #endregion
    }
}
