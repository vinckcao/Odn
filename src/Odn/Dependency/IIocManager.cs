using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odn.Dependency.Installers;

namespace Odn.Dependency
{
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// Reference to the Castle Windsor Container.
        /// </summary>
        IIocContainer IocContainer { get; }

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        new bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        new bool IsRegistered<T>();
    }

    public interface IIocContainer
    {
        /// <summary>
        /// 构造函数以外的初始化
        /// </summary>
        void Initialize();

        void RegisterWithInstance<T>(T instance, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where T : class;

        void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class;

        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
             where TType : class
             where TImpl : class, TType;

        void Register<TType1, TType2, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType1 : class
            where TType2 : class
            where TImpl : class, TType1, TType2;

        //void Register<TType1, TType2, TType3, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        //    where TType1 : class
        //    where TType2 : class
        //    where TType3 : class
        //    where TImpl : class, TType1, TType2, TType3;

        //void Register<TType1, TType2, TType3, TType4, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        //    where TType1 : class
        //    where TType2 : class
        //    where TType3 : class where TType4 : class
        //    where TImpl : class, TType1, TType2, TType3, TType4;

        //void Register<TType1, TType2, TType3, TType4, TType5, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        //    where TType1 : class
        //    where TType2 : class
        //    where TType3 : class
        //    where TType4 : class
        //    where TType5 : class
        //    where TImpl : class, TType1, TType2, TType3, TType4, TType5;

        bool IsRegistered(Type type);

        T Resolve<T>();

        object Resolve(Type type);

        T Resolve<T>(object argumentsAsAnonymousType);

        object Resolve(Type type, object argumentsAsAnonymousType);

        void Release(object obj);

        void Dispose();
    }

    public static class IocContainerExtensions
    {
        public static void Install(this IIocContainer container, IOdnInstaller installer)
        {
            installer.Install(container);
        }
    }
}
