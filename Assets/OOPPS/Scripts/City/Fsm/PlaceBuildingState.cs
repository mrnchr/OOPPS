using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public class PlaceBuildingState : BuildingState
    {
        public PlaceBuildingState(BuildingStage id, BuildingController controller) : base(id, controller)
        {
        }

        public override void Enter()
        {
            _view.SetActiveStage(BuildingStage.Place, true);
        }

        public override void Exit()
        {
            _view.SetActiveStage(BuildingStage.Place, false);
        }
    }
}