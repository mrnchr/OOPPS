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
            if (data.Buildings.Count <= 0)
                return;

            for (int i = 0; i < data.Buildings.Count; i++)
            {
                BuildingModelData modelData = data.Buildings[i];
                modelData.LoadModel(_controllers[i].Model);

                _controllers[i].OnLoad();
            }
        }

        public void Save(GameData data)
        {
            data.Buildings.Clear();
            foreach (BuildingController ctrl in _controllers)
            {
                var modelData = new BuildingModelData();
                modelData.SaveModel(ctrl.Model);
                data.Buildings.Add(modelData);  
            }
        }
    }
}