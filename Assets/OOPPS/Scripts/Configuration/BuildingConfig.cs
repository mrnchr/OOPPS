using OOPPS.City.Building;
using OOPPS.Persistence;
using OOPPS.Persistence.Serializables;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Building Config", menuName = "OOPPS/Config/Building")]
    public class BuildingConfig : ScriptableObject
    {
        public BuildingType Type;
        public float BuildPrice;
        public SerializableTimeSpan BuildTime;
        public float Income;
    }
}