using System;
using OOPPS.City.Fsm;
using OOPPS.City.Services;
using OOPPS.Core;
using OOPPS.Core.Mvc;
using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City.Building
{
    public class BuildingController : IController, IUpdatable
    {
        private readonly BuildingView _view;
        private readonly IBuildingStateMachine _machine;
        private readonly ICityService _cityService;
        private readonly DataPersistenceManager _persistence;
        private readonly BuildingModel _model;

        public BuildingView View => _view;
        public BuildingModel Model => _model;

        public BuildingController(BuildingView view, 
            IBuildingStateMachine machine, 
            ICityService cityService,
            DataPersistenceManager persistence)
        {
            _view = view;
            _machine = machine;
            _cityService = cityService;
            _persistence = persistence;
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
        }

        public void OnLoad()
        {
            _machine.ChangeState(_model.BuildStage);
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
            _persistence.Save();
        }

        public void StartBuild()
        {
            _machine.ChangeState(BuildingStage.Build);
            _model.SetBuildTime();
            _persistence.Save();
        }

        public void StartEarn()
        {
            _machine.ChangeState(BuildingStage.Earn);
            _model.StartEarnTime = _model.EndBuildTime;
            _persistence.Save();
        }

        private void ConfigureModel()
        {
            _model.Config = _view.Config;
        }
    }
}