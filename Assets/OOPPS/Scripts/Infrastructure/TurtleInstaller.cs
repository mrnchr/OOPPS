using OOPPS.Core;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class TurtleInstaller : MonoInstaller
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private TurtleView _turtle;
        [SerializeField] private MoveButton _back;
        [SerializeField] private MoveButton _forward;
        [SerializeField] private TurtleConfig _config;

        [SerializeField] private Boarders _boarders;

        [Header("Game Loop Dependencies")]
        [SerializeField] private GameLoopView _gameLoopView;
        [SerializeField] private BuildingMinigameConfig _minigameConfig;

        [SerializeField] private ResultView _resultView;

        [Header("Floor Manager Dependencies")]
        [SerializeField] private FloorSpawn _spawnController;
        [SerializeField] private FloorContainer _floorContainer;

        public override void InstallBindings()
        {
            var moveCtrl = new TurtleMovementController(_turtle, _back, _forward, _config, _boarders);
            var animCtrl = new TurtleAnimationController(_turtle);

            var floorManager = new FloorManager(_spawnController, _floorContainer);
            var loopController = new GameLoopController(floorManager, _gameLoopView, _minigameConfig);
            var gameEndObserver = new GameEndObserver(loopController, _resultView, moveCtrl);

            _container
                .BindAll(moveCtrl)
                .BindAll(animCtrl)
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