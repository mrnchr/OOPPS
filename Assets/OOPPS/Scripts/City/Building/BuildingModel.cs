using System;
using OOPPS.City.Fsm;
using OOPPS.Core.Mvc;

namespace OOPPS.City.Building
{
    [Serializable]
    public class BuildingModel : IModel
    {
        public BuildingStage BuildStage;
        public BuildingConfig Config;
        public DateTime StartBuildTime;
        public DateTime EndBuildTime;
        public DateTime StartEarnTime;
    }
}