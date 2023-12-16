using System;
using OOPPS.City;
using OOPPS.City.Building;
using OOPPS.Persistence.Serializables;

namespace OOPPS.Persistence
{
    [Serializable]
    public class GameData
    {
        public PlayingResources Resources = new PlayingResources();
        public SerializableDictionary<BuildingType, BuildingModelData> Buildings =
            new SerializableDictionary<BuildingType, BuildingModelData>();
    }
}