using System;
using OOPPS.City.Building;

namespace OOPPS.City.Services
{
    public class CityService : ICityService
    {
        private readonly PlayingResources _resources;

        public CityService(PlayingResources resources)
        {
            _resources = resources;
        }

        public event Action OnNotEnoughResources;

        public void Build(BuildingController building)
        {   
            if (_resources.Woods >= building.Model.Config.BuildPrice)
            {
                _resources.Woods -= building.Model.Config.BuildPrice;
                building.StartBuild();
            }
            else
            {
                OnNotEnoughResources?.Invoke();
            }
        }

        public void CollectMoney(BuildingController building)
        {
            _resources.Coins += building.Model.Config.Income;
            building.Model.ResetEarnTime();
        }
    }
}