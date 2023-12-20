using UnityEngine;

namespace OOPPS
{
    public interface IConfigurationProvider
    {
        public T Get<T>() where T : ScriptableObject;
    }
}