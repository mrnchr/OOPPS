using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class GameEndObserver: IListener
    {
        private GameLoopController _gameLoopController;
        private ResultView _resultView;
        private TurtleMovementController _turtleMovement;


        public GameEndObserver(GameLoopController gameLoopController, ResultView resultView, TurtleMovementController turtleMovement)
        {
            _gameLoopController = gameLoopController;
            _resultView = resultView;
            _turtleMovement = turtleMovement;
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

        private void OnGameEndActions(int _1, int _2, int _3)
        {
            _turtleMovement.DisableMovement();
        }

    }
}
