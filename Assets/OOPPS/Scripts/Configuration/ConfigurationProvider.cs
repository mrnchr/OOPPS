using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Configuration Provider", menuName = "OOPPS/Config Provider")]
    public class ConfigurationProvider : ScriptableObject, IConfigurationProvider
    {
        [SerializeField] private List<ScriptableObject> _configs;
        
        public T Get<T>() where T : ScriptableObject
        {
            return _configs.Where(x => x is T).Cast<T>().First();
        }
    }
}