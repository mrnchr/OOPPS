using System;
using System.Collections.Generic;
using OOPPS.City;
using OOPPS.City.Building;
using OOPPS.Persistence.Serializables;

namespace OOPPS.Persistence
{
    [Serializable]
    public class GameData
    {
        public PlayingResources Resources = new PlayingResources();
        public List<BuildingModelData> Buildings =
            new List<BuildingModelData>();
    }
}