using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Persistence Data", menuName = "OOPPS/Config/Persistence Data")]
    public class PersistenceDataConfig : ScriptableObject
    {
        public string FileName;
        public string DirectoryName;
        public float PersistenceInterval;
        public GameData DefaultGameData;
    }
}