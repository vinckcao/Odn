using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Castle.MicroKernel.Lifestyle.Scoped;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Odn.Dependency
{
    /// <summary>
    /// IocManager负责对象的注册,释放
    /// </summary>
    public class IocManager : IIocManager, IIocRegistrar, IIocResolver, IDisposable
    {
        private readonly IWindsorContainer _iocContainer;

        public virtual IWindsorContainer IocContainer => _iocContainer;

        public IocManager(IWindsorContainer iocContainer = null)
        {
            if (iocContainer == null)
                iocContainer = new WindsorContainer();
            this._iocContainer = iocContainer;

            //_container.ComponentRegistry.Register();
            //IocContainer = new WindsorContainer();
            //_conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //Register self!
            IocContainer.Register(Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this));
        }

        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type), lifeStyle));
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class where TImpl : class, TType
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type, impl).ImplementedBy(impl), lifeStyle));
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.Kernel.HasComponent(typeof(TType));
        }

        public T Resolve<T>()
        {
            return _iocContainer.Resolve<T>();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        public object Resolve(Type type)
        {
            return _iocContainer.Resolve(type);
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve(type, argumentsAsAnonymousType);
        }

        public void Release(object obj)
        {
            IocContainer.Release(obj);
        }

        public void Dispose()
        {
            IocContainer.Dispose();
        }

        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle) 
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }
    }
}
