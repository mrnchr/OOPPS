using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Building Minigame Config", menuName = "OOPPS/Config/BuildingMinigame")]
    public class BuildingMinigameConfig : ScriptableObject
    {
        //!!������������� � ������������ ������
        public int maxFloorCount;
        public int resMultiplier;
        public int hpCount;
    }
}