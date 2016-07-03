using Odn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Odn.Dependency
{
    /// <summary>
    /// IocManager负责对象的注册,释放
    /// </summary>
    public class IocManager : IIocManager, IIocRegistrar, IIocResolver, IDisposable
    {
        private readonly IIocContainer _iocContainer;

        public virtual IIocContainer IocContainer => _iocContainer;

        public IocManager(IIocContainer iocContainer)
        {
            this._iocContainer = iocContainer;

            //Register self!
            //this._iocContainer.Register(Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this));
            this._iocContainer.RegisterWithInstance<IIocManager>(this);
        }

        private IIocContainer CreateDefaultIocContainer()
        {
            throw new NotImplementedException();
        }

        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register<TType>(lifeStyle);
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(type, lifeStyle);
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class where TImpl : class, TType
        {
            IocContainer.Register<TType, TImpl>(lifeStyle);
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(type, impl, lifeStyle);
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.IsRegistered(type);
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.IsRegistered(typeof(TType));
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

        public static IIocManager Instance
        {
            get
            {
                if (Singleton<IIocManager>.Instance == null)
                {
                    throw new OdnFrameworkException("IocManager对象未注册, 无法解析, 请检查OdnBootstraper中的InitializeIocManager方法");
                }
                return Singleton<IIocManager>.Instance;
            }
        }
    }
}
