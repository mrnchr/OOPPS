using System;
using OOPPS.Core.Mvc;

namespace OOPPS.City.Building
{
    [Serializable]
    public class BuildingModel : IModel
    {
        public BuildingConfig Config;
        public BuildingStage BuildStage;
        public DateTime StartBuildTime;
        public DateTime EndBuildTime;
        public DateTime StartEarnTime;
    }
}