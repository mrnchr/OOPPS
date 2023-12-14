using System.Collections.Generic;
using OOPPS.City.Building;
using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City.Services
{
    public class CityPersistence : MonoBehaviour, IDataPersistence
    {
        private List<BuildingController> _controllers;

        public void Construct(List<BuildingController> controllers)
        {
            _controllers = controllers;
        }

        public void Load(GameData data)
        {
            foreach (BuildingController ctrl in _controllers)
            {
                if (data.Buildings.TryGetValue(ctrl.Model.Config.Type, out BuildingModelData modelData))
                    modelData.LoadModel(ctrl.Model);

                ctrl.OnLoad();
            }
        }

        public void Save(GameData data)
        {
            foreach (BuildingController ctrl in _controllers)
            {
                var modelData = new BuildingModelData();
                modelData.SaveModel(ctrl.Model);
                data.Buildings[ctrl.Model.Config.Type] = modelData;
            }
        }
    }
}