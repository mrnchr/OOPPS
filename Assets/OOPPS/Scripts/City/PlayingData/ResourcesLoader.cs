using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City
{
    public class ResourcesLoader : MonoBehaviour, IDataPersistence
    {
        private PlayingResources _resources;
        private IResourcesController _resourcesCtrl;

        public void Construct(PlayingResources resources, IResourcesController resourcesCtrl)
        {
            _resources = resources;
            _resourcesCtrl = resourcesCtrl;
        }
        
        public void Load(GameData data)
        {
            _resources.Copy(data.Resources);
            _resourcesCtrl.OnLoad();
        }

        public void Save(GameData data)
        {
            data.Resources.Copy(_resources);
        }
    }
}