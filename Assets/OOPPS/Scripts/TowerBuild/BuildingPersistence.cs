using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OOPPS.TowerBuild;

namespace OOPPS.Persistence
{

    public class BuildingPersistence : MonoBehaviour, IDataPersistence
    {
        private BuildingResourcesController _resourcesController;

        public void Construct(BuildingResourcesController resourcesController)
        {
            _resourcesController = resourcesController;
        }

        public void Load(GameData data)
        {
            Debug.Log("Load:" + data.Resources.Woods);
            _resourcesController.SetWoods(data.Resources.Woods);
        }

        public void Save(GameData data)
        {
            Debug.Log("Save1:"+data.Resources.Woods);
            data.Resources.Woods = _resourcesController.GetWoods();
            Debug.Log("Save2:" + data.Resources.Woods);
        }
    }
}
