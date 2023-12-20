using System;
using OOPPS.City.Building;

namespace OOPPS.City.Services
{
    public interface ICityService
    {
        public event Action OnNotEnoughResources;
        public void Build(BuildingController building);
        public void CollectMoney(BuildingController building);
    }
}