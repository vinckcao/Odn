using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Dependency.Autofac
{
    public static class AutoLifetimeCycleExtension
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ApplyLifetimeCycle<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> obj, DependencyLifeStyle lifeStyle, params object[] lifeTypeScopeTag)
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Singleton:
                    return obj.SingleInstance();
                case DependencyLifeStyle.Transient:
                    return obj.InstancePerDependency();
                case DependencyLifeStyle.PerScope:
                    return obj.InstancePerMatchingLifetimeScope(lifeTypeScopeTag);
                default:
                    return obj.InstancePerDependency();
            }
        }
    }
    public class AutofacContainer : IIocContainer
    {
        #region Fields

        private ContainerManager _containerManager;

        #endregion

        public AutofacContainer()
        {

        }

        /// <summary>
        /// 构造函数以外的初始化
        /// </summary>
        public void Initialize()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            this._containerManager = new ContainerManager(container);
        }

        public void Dispose()
        {
            _containerManager.Dispose();
        }

        public bool IsRegistered(Type type)
        {
            return _containerManager.IsRegistered(type);
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(type).As(type).ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(impl).As(type).ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TType>().ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }

        public void RegisterWithInstance<T>(T instance, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(instance).ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }

        public void Release(object obj)
        {

        }

        public object Resolve(Type type)
        {
            return _containerManager.Resolve(type);
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            throw new NotSupportedException("Autofac 暂不支持按照参数解析对象");
        }

        public T Resolve<T>()
        {
            return _containerManager.Resolve<T>();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            throw new NotSupportedException("Autofac 暂不支持按照参数解析对象");
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle)
             where TType : class
             where TImpl : class, TType
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TImpl>().As<TType>().ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }

        public void Register<TType1, TType2, TImpl>(DependencyLifeStyle lifeStyle)
            where TType1 : class
            where TType2 : class
            where TImpl : class, TType1, TType2
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TImpl>().As<TType1, TType2>().ApplyLifetimeCycle(lifeStyle);
            builder.Update(_containerManager.Container);
        }
    }
}
