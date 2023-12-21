using System;
using OOPPS.Persistence;

namespace OOPPS.TowerBuild
{
    public class GameEndObserver : IListener
    {
        public event Action<int> OnSaveData;
        public event Action OnGoToNextScene;

        private GameLoopController _gameLoopController;
        private ResultView _resultView;
        private TurtleMovementController _turtleMovement;
        private BuildingResourcesController _resourcesController;
        private DataPersistenceManager _dataPersistenceManage;
        private SceneLoader _sceneLoader;
        private CloudTransitionsController _cloudAnimator;

        public GameEndObserver(GameLoopController gameLoopController, ResultView resultView, TurtleMovementController turtleMovement, BuildingResourcesController resourcesController, Persistence.DataPersistenceManager dataPersistenceManager, SceneLoader sceneLoader, CloudTransitionsController cloudAnimator)
        {
            _gameLoopController = gameLoopController;
            _resultView = resultView;
            _turtleMovement = turtleMovement;
            _resourcesController = resourcesController;
            _dataPersistenceManage = dataPersistenceManager;
            _sceneLoader = sceneLoader;
            _cloudAnimator = cloudAnimator;
        }


        public void OnEnable()
        {
            _gameLoopController.OnGameEnd += _resultView.SetUpResultView;
            _gameLoopController.OnGameEnd += OnGameEndActions;

            OnGoToNextScene += GoToCityScene;
            _resultView.AddButtonListener(OnGoToNextScene);
            _cloudAnimator.OnCloudShowEnded += GoToTheCityScene;
        }

        public void OnDisable()
        {
            _gameLoopController.OnGameEnd -= _resultView.SetUpResultView;
            _gameLoopController.OnGameEnd -= OnGameEndActions;

            _resultView.RemoveButtonListener(OnGoToNextScene);
            OnGoToNextScene -= GoToCityScene;
            _cloudAnimator.OnCloudShowEnded -= GoToTheCityScene;
        }

        private void OnGameEndActions(int floors, int maxFloors, int res)
        {
            _turtleMovement.DisableMovement();
            _resourcesController.AddWoods(res);
            _dataPersistenceManage.Save();
        }

        private void GoToCityScene()
        {
            _cloudAnimator.ShowClouds();
        }

        private void GoToTheCityScene()
        {
             _sceneLoader.LoadScene("City");
        }
    }
}
