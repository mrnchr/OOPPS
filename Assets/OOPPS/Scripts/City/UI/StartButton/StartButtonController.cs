using OOPPS.City.Services;
using OOPPS.Core;
using OOPPS.Core.Mvc;

namespace OOPPS.City.UI.StartButton
{
    public class StartButtonController : IController, IUpdatable
    {
        private readonly StartButtonView _view;
        private readonly IGameStarter _starter;
        private readonly PlayingResources _resources;
        private readonly CityConfig _config;
        private readonly StartButtonModel _model;

        public StartButtonController(StartButtonView view, IGameStarter starter, PlayingResources resources, CityConfig config)
        {
            _view = view;
            _starter = starter;
            _resources = resources;
            _config = config;
            _model = new StartButtonModel();
            
            _view.SetController(this);
        }

        public void Update()
        {
            if (_resources.Energy.Value >= _config.EnergyToStart)
            {
                _model.Type = StartButtonType.Allow;
                _view.SetAllowSprite();
            }
            else
            {
                _model.Type = StartButtonType.Disallow;
                _view.SetDisallowSprite();
            }
        }

        public void RequestStart()
        {
            if (_model.Type == StartButtonType.Allow)
                _starter.StartGame();    
        }
    }
}