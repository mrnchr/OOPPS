using OOPPS.Core;
using System.Collections.Generic;
using UnityEngine;
using OOPPS.Persistence;

namespace OOPPS.TowerBuild
{
    public class TurtleInstaller : MonoInstaller
    {
        [Header("Movement")]
        [SerializeField] private Updater _updater;
        [SerializeField] private TurtleView _turtle;
        [SerializeField] private MoveButton _back;
        [SerializeField] private MoveButton _forward;
        [SerializeField] private Boarders _boarders;


        [Header("Config")]
        [SerializeField] private BuildingMinigameConfig _minigameConfig;
        [SerializeField] private TurtleConfig _config;

        [Header("Controllers")]

        [SerializeField] private FloorSpawn _spawnController;
        [SerializeField] private FloorsOffsetController _floorContainer;

        [SerializeField] private LevelMover _levelMover;
        [SerializeField] private TowerRotation _towerRotation;

        [Header("View")]
        [SerializeField] private GameLoopView _gameLoopView;
        [SerializeField] private ResultView _resultView;

        [Header("Other")]
        [SerializeField] private FloorStates _firstFloor;
        [SerializeField] private BuildingPersistence _buildingPersistence;
        [SerializeField] private DataPersistenceManager _dataPersistenceManager;


        public override void InstallBindings()
        {
            var _resourcesController = new BuildingResourcesController();

            var moveCtrl = new TurtleMovementController(_turtle, _back, _forward, _config, _boarders);
            var animCtrl = new TurtleAnimationController(_turtle);


            var floorOffset = new FloorsOffsetController(_towerRotation, _minigameConfig, _levelMover);
            var floorContainer = new FloorContainer(floorOffset, _firstFloor);

            var floorManager = new FloorManager(_spawnController, floorContainer);
            var loopController = new GameLoopController(floorManager, _gameLoopView, _minigameConfig);
            var gameEndObserver = new GameEndObserver(loopController, _resultView, moveCtrl, _resourcesController, _dataPersistenceManager);

            _buildingPersistence.Construct(_resourcesController);

            _container
                .BindAll(moveCtrl)
                .BindAll(animCtrl)
                .BindAll(floorOffset)
                .BindAll(floorContainer)
                .BindAll(floorManager)
                .BindAll(loopController)
                .BindAll(gameEndObserver)
                .BindAll(_updater);
        }

        public GameLoopController GetObjectLoopControler()
        {
            return _container.Resolve<GameLoopController>();
        }

        public List<IListener> GetAllIListeners()
        {
            return _container.ResolveAll<IListener>();
        }


    }
}