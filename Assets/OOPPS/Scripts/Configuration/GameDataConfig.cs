using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "OOPPS/Config/Game Data")]
    public class GameDataConfig : ScriptableObject
    {
        public GameData ManualGameData;
    }
}