using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public class BuildBuildingState : BuildingState
    {

        public BuildBuildingState(BuildingStage id, BuildingController controller) : base(id, controller)
        {
        }

        public override void Enter()
        {
            _model.BuildStage = BuildingStage.Build;
            _view.SetActiveStage(BuildingStage.Build, true);
        }

        public override void Exit()
        {
            _view.SetActiveStage(BuildingStage.Build, false);
        }
    }
}