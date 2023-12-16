using OOPPS.City.UI.ResourceBar;
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
        
        public override void InstallBindings()
        {
            var resources = _container.Resolve<PlayingResources>();
            
            var barCtrl = new ResourceBarController(_woodView, _moneyView, _diamondView, resources);
            var energyCtrl = new EnergyBarController(_energyView, resources, _resourcesConfig);

            _container
                .BindAll(barCtrl)
                .BindAll(energyCtrl);
        }
    }
}