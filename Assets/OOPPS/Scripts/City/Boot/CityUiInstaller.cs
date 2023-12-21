using System.Collections.Generic;
using OOPPS.City.Building;
using OOPPS.City.Services;
using OOPPS.City.UI.BuildButton;
using OOPPS.City.UI.InfoField;
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
        [SerializeField] private StartButtonView _startButton;
        [SerializeField] private InfoView _infoView;
        [SerializeField] private BuildButtonView _buildButton;
        
        public override void InstallBindings()
        {
            var city = _container.Resolve<ICityService>();
            var runner = _container.Resolve<ICoroutineRunner>();
            var resources = _container.Resolve<PlayingResources>();
            var gameStarter = _container.Resolve<IGameStarter>();
            var provider = _container.Resolve<IConfigurationProvider>();
            var buildings = _container.Resolve<List<BuildingController>>();
            
            var barCtrl = new ResourceBarController(_woodView, _moneyView, _diamondView, resources);
            var energyCtrl = new EnergyBarController(_energyView, resources, provider.Get<ResourcesConfig>());
            var startButtonCtrl = new StartButtonController(_startButton, gameStarter, resources, provider.Get<CityConfig>());

            var infoCtrl = new InfoController(_infoView, city, runner, provider.Get<InfoFieldConfig>());

            var buildModeCtrl = new BuildButtonController(_buildButton, buildings);

            _container
                .BindAll(barCtrl)
                .BindAll(energyCtrl)
                .BindAll(startButtonCtrl)
                .BindAll(infoCtrl)
                .BindAll(buildModeCtrl);
        }
    }
}