using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public class EmptyBuildingState : BuildingState
    {
        public EmptyBuildingState(BuildingStage id, BuildingController controller) : base(id, controller)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}