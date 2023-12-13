using System;
using OOPPS.City.Fsm;
using OOPPS.City.Services;
using OOPPS.Core;
using OOPPS.Core.Mvc;

namespace OOPPS.City.Building
{
    public class BuildingController : IController, IUpdatable
    {
        private readonly BuildingView _view;
        private readonly BuildingStateMachine _machine;
        private readonly ICityService _cityService;
        private readonly BuildingModel _model;

        public BuildingView View => _view;
        public BuildingModel Model => _model;

        public BuildingController(BuildingView view, BuildingStateMachine machine, ICityService cityService)
        {
            _view = view;
            _machine = machine;
            _cityService = cityService;
            _model = new BuildingModel();

            ConfigureModel();
            _view.SetController(this);

#if UNITY_EDITOR
            _view.SetModel(_model);
#endif
        }

        public void Initialize()
        {
            _view.Hide();
            _machine.ChangeState(BuildingStage.Place);
        }

        public void Update()
        {
            switch (_model.BuildStage)
            {
                case BuildingStage.Place:
                    _view.SetPrice($"{_model.Config.BuildPrice:####}");
                    break;
                case BuildingStage.Build:
                    _view.SetTime((_model.EndBuildTime - DateTime.Now).ToString(@"hh\:mm\:ss"));
                    break;
                case BuildingStage.Earn:
                    _view.SetMoney($"{_model.GetTotalSum():####}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void RequestBuild()
        {
            _cityService.Build(this);
        }

        public void CollectMoney()
        {
            _cityService.CollectMoney(this);
        }

        public void StartBuild()
        {
            _machine.ChangeState(BuildingStage.Build);
        }

        public void StartEarn()
        {
            _machine.ChangeState(BuildingStage.Earn);
        }

        private void ConfigureModel()
        {
            _model.Config = _view.Config;
        }
    }
}