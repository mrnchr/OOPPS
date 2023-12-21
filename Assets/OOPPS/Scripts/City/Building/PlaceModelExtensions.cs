using System;

namespace OOPPS.City.Building
{
    public static class PlaceModelExtensions
    {
        public static bool HasMoney(this BuildingModel obj)
        {
            return obj.StartEarnTime + obj.Config.IncomeTime <= DateTime.Now;
        }

        public static void ResetEarnTime(this BuildingModel obj)
        {
            obj.StartEarnTime = DateTime.Now;
        }

        public static void SetBuildTime(this BuildingModel obj)
        {   
            obj.StartBuildTime = DateTime.Now;
            obj.EndBuildTime = obj.StartBuildTime.AddSeconds(obj.Config.BuildTime.Value.TotalSeconds);
        }
    }
}