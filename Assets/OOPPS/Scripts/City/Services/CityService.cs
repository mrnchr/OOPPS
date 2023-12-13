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

        public void Build(BuildingController building)
        {   
            if (_resources.Woods >= building.Model.Config.BuildPrice)
            {
                _resources.Woods -= building.Model.Config.BuildPrice;
                building.StartBuild();
            }
        }

        public void CollectMoney(BuildingController building)
        {
            float money = building.Model.GetTotalSum();
            if (money > 0)
            {
                _resources.Coins += money;
                building.Model.ResetEarnTime();
            }
        }
    }
}