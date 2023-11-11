using System;
using System.Collections.Generic;

namespace OOPPS.Core
{
    public interface IDiContainer
    {
        public DiContainer Bind<T>(T obj, params Type[] interfaces);
        public DiContainer Bind(Type type, object obj);
        public DiContainer BindInterfaces<T>(T obj, params Type[] interfaces);
        public DiContainer BindAll<T>(T obj);
        public bool Has<T>();
        public T Resolve<T>();
        public List<T> ResolveAll<T>();
    }
}