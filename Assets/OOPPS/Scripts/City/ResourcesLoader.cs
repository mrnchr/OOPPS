using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City
{
    public class ResourcesLoader : MonoBehaviour, IDataPersistence
    {
        private PlayingResources _resources;

        public void Construct(PlayingResources resources)
        {
            _resources = resources;
        }
        
        public void Load(GameData data)
        {
            _resources.Copy(data.Resources);
        }

        public void Save(GameData data)
        {
            data.Resources.Copy(_resources);
        }
    }
}