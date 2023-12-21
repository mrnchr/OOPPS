using System;
using OOPPS.Persistence;


namespace OOPPS.TowerBuild
{
    public class GameLoopController : IListener
    {
        public event Action<int, int, int> OnGameEnd;


        private FloorManager _floorManager;
        private GameLoopView _gameLoopView;
        private BuildingMinigameConfig _minigameConfig;
        private CloudTransitionsController _cloudAnimator;

        public GameLoopController(FloorManager floorManager, GameLoopView gameLoopView, BuildingMinigameConfig minigameConfig, CloudTransitionsController cloudAnimator)
        {
            _floorManager = floorManager;
            _gameLoopView = gameLoopView;
            _minigameConfig = minigameConfig;

            _crntHp = _minigameConfig.hpCount;
            _cloudAnimator = cloudAnimator;
        }


        private int _crntHp;

        public void OnEnable()
        {
            _floorManager.OnFloorAdded += AddFloor;
            _floorManager.OnFloorRemoved += RemoveFloor;
            _floorManager.OnFloorMissed += MissFloor;
            OnGameEnd += _gameLoopView.HideGameScreen;
        }
        public void OnDisable()
        {
            _floorManager.OnFloorAdded -= AddFloor;
            _floorManager.OnFloorRemoved -= RemoveFloor;
            _floorManager.OnFloorMissed -= MissFloor;
            OnGameEnd -= _gameLoopView.HideGameScreen;
        }

        public void InitGameScreen()
        {
            _crntHp = _minigameConfig.hpCount;

            _gameLoopView.InitGameScreen(_minigameConfig.hpCount, _minigameConfig.maxFloorCount);
            _floorManager.InitFloorManager(_minigameConfig.maxFloorCount);

            _cloudAnimator.HideClouds();
        }

        public void StartGame()
        {
            _gameLoopView.HideBuffsPanel();
            _gameLoopView.ShowGameScreen();
            _floorManager.StartBuilding();
        }

        private void AddFloor(int crntFloorCount)
        {
            _gameLoopView.SetFloorCounter(crntFloorCount, _minigameConfig.maxFloorCount);

            if (crntFloorCount == _minigameConfig.maxFloorCount)
            {
                _floorManager.StopBuilding();
                OnGameEnd?.Invoke(crntFloorCount, _minigameConfig.maxFloorCount, GetResorcesValue(crntFloorCount));
            }


        }
        private void MissFloor(int crntFloorCount)
        {
            _crntHp--;
            _gameLoopView.SetHp(_crntHp);

            if (_crntHp == 0)
            {
                _floorManager.StopBuilding();
                OnGameEnd?.Invoke(crntFloorCount, _minigameConfig.maxFloorCount, GetResorcesValue(crntFloorCount));
            }
        }
        private void RemoveFloor(int crntFloorCount)
        {
            _gameLoopView.SetFloorCounter(crntFloorCount, _minigameConfig.maxFloorCount);
        }

        private int GetResorcesValue(int catchedCount)
        {
            return catchedCount * _minigameConfig.resMultiplier;
        }
    }
}