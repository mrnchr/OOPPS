using UnityEngine;

namespace OOPPS
{
    [CreateAssetMenu(fileName = "Building Minigame Config", menuName = "OOPPS/Config/BuildingMinigame")]
    public class BuildingMinigameConfig : ScriptableObject
    {
        //!!преобразовать в передаваемый объект
        public float criticalOffset;
        public int upShiftToRot;
        public int upShiftToCamMove;

        public int maxFloorCount;
        public int resMultiplier;
        public int hpCount;
    }
}