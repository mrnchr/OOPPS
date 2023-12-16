using OOPPS.Persistence;
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