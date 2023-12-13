using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Floor Config", menuName = "OOPPS/Config/Floor")]
    public class FloorConfig : ScriptableObject
    {
        public float MinSpeed;
        public float MaxSpeed;
    }
}