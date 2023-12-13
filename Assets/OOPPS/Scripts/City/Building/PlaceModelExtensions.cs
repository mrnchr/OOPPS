using System;
using OOPPS.City.Fsm;

namespace OOPPS.City.Building
{
    public static class PlaceModelExtensions
    {
        public static float GetTotalSum(this BuildingModel obj)
        {   
            return obj.BuildStage == BuildingStage.Earn 
                ? (float)(DateTime.Now - obj.StartEarnTime).TotalSeconds * obj.Config.Income
                : -1;
        }

        public static float GetLastBuildTime(this BuildingModel obj)
        {
            return obj.BuildStage == BuildingStage.Build
                ? (float)(DateTime.Now - obj.StartBuildTime).TotalSeconds
                : -1;
        }   

        public static void SetBuildTime(this BuildingModel obj)
        {   
            obj.StartBuildTime = DateTime.Now;
            obj.EndBuildTime = obj.StartBuildTime.AddSeconds(obj.Config.BuildTime);
        }

        public static void ResetEarnTime(this BuildingModel obj)
        {
            obj.StartEarnTime = DateTime.Now;
        }
    }
}