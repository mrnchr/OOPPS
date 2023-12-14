using System;
using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public class EarnBuildingState : BuildingState
    {
        public EarnBuildingState(BuildingStage id, BuildingController controller) : base(id, controller)
        {
        }

        public override void Enter()
        {
            _model.BuildStage = BuildingStage.Earn;
            _view.SetActiveStage(BuildingStage.Earn, true);
        }

        public override void Exit()
        {
        }
    }
}