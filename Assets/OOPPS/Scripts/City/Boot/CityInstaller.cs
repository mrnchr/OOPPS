using System.Collections.Generic;
using OOPPS.City.Building;
using OOPPS.City.InputSystem;
using OOPPS.City.Interacting;
using OOPPS.City.Raycasting;
using OOPPS.City.Services;
using OOPPS.City.UI.ResourceBar;
using OOPPS.Core;
using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City.Boot
{
    public class CityInstaller : MonoInstaller
    {
        [SerializeField] private CityPersistence _cityPersistence;
        [SerializeField] private ResourceView _woodView;
        [SerializeField] private ResourceView _moneyView;
        [SerializeField] private ResourceView _diamondView;
        [SerializeField] private ResourceView _energyView;
        
        public override void InstallBindings()
        {
            var persistence = FindAnyObjectByType<DataPersistenceManager>();
            var updater = FindAnyObjectByType<Updater>();
            var runner = FindAnyObjectByType<CoroutineRunner>();
            var loader = FindAnyObjectByType<ResourcesLoader>();
            Camera mainCamera = Camera.main;

            var list = new List<BuildingController>();
            var input = new CityInputController(runner);
            var raycaster = new CityRaycaster(mainCamera);

            var interactor = new Interactor(input, raycaster);
            
            var resources = new PlayingResources();
            var city = new CityService(resources);
            var buildUpdater = new BuildUpdater(list);

            var barCtrl = new ResourceBarController(_woodView, _moneyView, _diamondView, _energyView, resources);

            loader.Construct(resources);
            _cityPersistence.Construct(list);

            _container
                .BindAll(list)
                .BindAll(persistence)
                .BindAll(input)
                .BindAll(raycaster)
                .BindAll(interactor)
                .BindAll(resources)
                .BindAll(city)
                .BindAll(buildUpdater)
                .BindAll(loader)
                .BindAll(barCtrl)
                .BindAll(updater)
                .BindAll(runner);
        }
    }
}