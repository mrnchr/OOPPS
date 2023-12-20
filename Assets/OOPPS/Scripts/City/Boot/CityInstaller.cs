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
        [SerializeField] private ConfigurationProvider _provider;
        
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
            var resourcesCtrl = new ResourcesController(resources, _provider.Get<ResourcesConfig>(), persistence);
            var city = new CityService(resources);
            var buildUpdater = new BuildUpdater(list);

            var sceneLoader = new SceneLoader(persistence, runner);
            var gameStarter = new GameStarter(_provider.Get<CityConfig>(), resourcesCtrl, sceneLoader);

            loader.Construct(resources, resourcesCtrl);
            _cityPersistence.Construct(list);

            _container
                .BindAll(_provider)
                .BindAll(list)
                .BindAll(persistence)
                .BindAll(input)
                .BindAll(raycaster)
                .BindAll(interactor)
                .BindAll(resources)
                .BindAll(resourcesCtrl)
                .BindAll(city)
                .BindAll(buildUpdater)
                .BindAll(sceneLoader)
                .BindAll(gameStarter)
                .BindAll(loader)
                .BindAll(updater)
                .BindAll(runner);
        }
    }
}