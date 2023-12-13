using OOPPS.City.Building;

namespace OOPPS.City.Services
{
    public interface ICityService
    {
        public void Build(BuildingController building);
        public void CollectMoney(BuildingController building);
    }
}