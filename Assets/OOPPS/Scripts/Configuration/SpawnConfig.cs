using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Spawn Config", menuName = "OOPPS/Config/Spawn")]
    public class SpawnConfig : ScriptableObject
    {
        public float MinSpawnDelay;
        public float MaxSpawnDelay;
    }
}