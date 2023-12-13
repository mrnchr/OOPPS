using System;
using System.Collections.Generic;
using System.Linq;
using OOPPS.City.Building;
using OOPPS.Core;

namespace OOPPS.City.Services
{
    public class BuildUpdater : IBuildUpdater, IUpdatable
    {
        private readonly List<BuildingController> _list;

        public BuildUpdater(List<BuildingController> list)
        {
            _list = list;
        }
        
        public void Update()
        {
            foreach (BuildingController controller in _list.Where(controller => controller.Model.BuildStage == BuildingStage.Build))
            {
                if (controller.Model.EndBuildTime <= DateTime.Now)
                    controller.StartEarn();
            }
        }
    }
}

namespace OOPPS.City
{
    public interface IBuildUpdater
    {
    }
}