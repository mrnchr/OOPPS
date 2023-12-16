using System;
using OOPPS.Persistence;
using OOPPS.Persistence.Serializables;

namespace OOPPS.City.Building
{
    [Serializable]
    public class BuildingModelData
    {
        public BuildingStage BuildStage;
        public SerializableDateTime StartBuildTime = new SerializableDateTime();
        public SerializableDateTime EndBuildTime = new SerializableDateTime();
        public SerializableDateTime StartEarnTime = new SerializableDateTime();

        public void LoadModel(BuildingModel model)
        {
            model.BuildStage = BuildStage;
            model.StartBuildTime = StartBuildTime.Value;
            model.EndBuildTime = EndBuildTime.Value;
            model.StartEarnTime = StartEarnTime.Value;
        }

        public void SaveModel(BuildingModel model)
        {
            BuildStage = model.BuildStage;
            StartBuildTime.Value = model.StartBuildTime;
            EndBuildTime.Value = model.EndBuildTime;
            StartEarnTime.Value = model.StartEarnTime;
        }
    }
}