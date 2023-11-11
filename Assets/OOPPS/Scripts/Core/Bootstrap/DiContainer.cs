using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPPS.Core
{
    public class DiContainer : IDiContainer
    {
        private readonly Dictionary<Type, List<object>> _container = new Dictionary<Type, List<object>>();

        public DiContainer Bind<T>(T obj, params Type[] interfaces)
        {
            foreach (Type type in interfaces.Append(typeof(T)))
                Bind(type, obj);

            return this;
        }

        public DiContainer Bind(Type type, object obj)
        {
            if (_container.TryGetValue(type, out var value))
            {
                value.Add(obj);
            }
            else
            {
                _container.Add(type, new List<object> { obj });
            }

            return this;
        }

        public DiContainer BindInterfaces<T>(T obj, params Type[] interfaces)
        {
            var types = interfaces?.Length > 0 ? interfaces : typeof(T).GetInterfaces();
            foreach (Type type in types)
                Bind(type, obj);
            return this;
        }

        public DiContainer BindAll<T>(T obj)
        {
            return Bind(obj, typeof(T).GetInterfaces());
        }

        public bool Has<T>() => _container.ContainsKey(typeof(T));

        public T Resolve<T>() => (T)_container[typeof(T)][0];

        public List<T> ResolveAll<T>() =>
            _container.TryGetValue(typeof(T), out var resolves) ? resolves.OfType<T>().ToList() : null;
    }
}