using OOPPS.Persistence;
using OOPPS.Persistence.Serializables;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Resources Config", menuName = "OOPPS/Config/Resources")]
    public class ResourcesConfig : ScriptableObject
    {
        public float MaxEnergy;
        public SerializableTimeSpan ResetEnergyTime;
        public float ResetEnergyUnit;
    }
}