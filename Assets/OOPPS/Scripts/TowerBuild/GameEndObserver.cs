using System;


namespace OOPPS.TowerBuild
{
    public class GameEndObserver: IListener
    {
        public event Action<int> OnSaveData; 

        private GameLoopController _gameLoopController;
        private ResultView _resultView;
        private TurtleMovementController _turtleMovement;
        private BuildingResourcesController _resourcesController;
        private Persistence.DataPersistenceManager _dataPersistenceManage;

        public GameEndObserver(GameLoopController gameLoopController, ResultView resultView, TurtleMovementController turtleMovement, BuildingResourcesController resourcesController, Persistence.DataPersistenceManager dataPersistenceManager)
        {
            _gameLoopController = gameLoopController;
            _resultView = resultView;
            _turtleMovement = turtleMovement;
            _resourcesController = resourcesController;
            _dataPersistenceManage = dataPersistenceManager;
        }


        public void OnEnable()
        {
            _gameLoopController.OnGameEnd += _resultView.SetUpResultView;
            _gameLoopController.OnGameEnd += OnGameEndActions;
        }

        public void OnDisable()
        {
            _gameLoopController.OnGameEnd -= _resultView.SetUpResultView;
            _gameLoopController.OnGameEnd -= OnGameEndActions;
        }

        private void OnGameEndActions(int floors, int maxFloors, int res)
        {
            _turtleMovement.DisableMovement();
            _resourcesController.AddWoods(res);
            _dataPersistenceManage.Save();
        }

    }
}
