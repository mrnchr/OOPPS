using OOPPS.City.Building;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Building Config", menuName = "OOPPS/Config/Building")]
    public class BuildingConfig : ScriptableObject
    {
        public BuildingType Type;
        public float BuildPrice;
        public float Hours;
        public float Minutes;
        public float Seconds;
        public float Income;
        
        [Header("ReadOnly")]
        public float BuildTime;

        private void OnValidate()
        {
            BuildTime = Hours * 3600 + Minutes * 60 + Seconds;
        }
    }
}