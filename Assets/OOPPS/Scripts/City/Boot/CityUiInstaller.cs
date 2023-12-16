using OOPPS.City.Services;
using OOPPS.City.UI.ResourceBar;
using OOPPS.City.UI.StartButton;
using OOPPS.Core;
using UnityEngine;

namespace OOPPS.City.Boot
{
    public class CityUiInstaller : MonoInstaller
    {
        [SerializeField] private ResourceView _woodView;
        [SerializeField] private ResourceView _moneyView;
        [SerializeField] private ResourceView _diamondView;
        [SerializeField] private ResourceView _energyView;
        [SerializeField] private ResourcesConfig _resourcesConfig;
        [SerializeField] private StartButtonView _startButton;
        [SerializeField] private CityConfig _cityConfig;
        
        public override void InstallBindings()
        {
            var resources = _container.Resolve<PlayingResources>();
            var gameStarter = _container.Resolve<IGameStarter>();
            
            var barCtrl = new ResourceBarController(_woodView, _moneyView, _diamondView, resources);
            var energyCtrl = new EnergyBarController(_energyView, resources, _resourcesConfig);
            var startButtonCtrl = new StartButtonController(_startButton, gameStarter, resources, _cityConfig);

            _container
                .BindAll(barCtrl)
                .BindAll(energyCtrl)
                .BindAll(startButtonCtrl);
        }
    }
}