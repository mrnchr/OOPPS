using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public abstract class BuildingState : IBuildingState
    {
        protected readonly BuildingController _controller;
        protected readonly BuildingModel _model;
        protected readonly BuildingView _view;
        public BuildingStage Id { get; }

        protected BuildingState(BuildingStage id, BuildingController controller)
        {
            Id = id;
            _controller = controller;
            _view = controller.View;
            _model = controller.Model;
        }

        public abstract void Enter();

        public abstract void Exit();
    }
}