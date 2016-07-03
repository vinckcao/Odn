using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Dependency.Autofac
{
    public class AutofacContainer : IIocContainer
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            throw new NotImplementedException();
        }

        public void RegisterWithInstance<T>(T instance, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public void Release(object obj)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        void IIocContainer.Register<TType, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        void IIocContainer.Register<TType1, TType2, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        void IIocContainer.Register<TType1, TType2, TType3, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        void IIocContainer.Register<TType1, TType2, TType3, TType4, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        void IIocContainer.Register<TType1, TType2, TType3, TType4, TType5, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }
    }
}
