using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class FloorManager : IListener
    {
        public event Action<int> OnFloorAdded;
        public event Action<int> OnFloorRemoved;
        public event Action<int> OnFloorMissed;

        private FloorSpawn _spawnController;
        private FloorContainer _floorContainer;

        private int _crntFloorCount;
        private int _maxFloorCount;

        public FloorManager(FloorSpawn spawnController, FloorContainer floorContainer)
        {
            _spawnController = spawnController;
            _floorContainer = floorContainer;
        }


        public void OnEnable()
        {
            _spawnController.IsNewFloorSpawned += _floorContainer.SetFloorListeners;

            _floorContainer.OnFloorMissed += MissFloor;
            _floorContainer.OnFloorAdded += AddFloor;
            _floorContainer.OnFloorRemoved += RemoveFloor;
        }
        public void OnDisable()
        {
            _spawnController.IsNewFloorSpawned -= _floorContainer.SetFloorListeners;

            _floorContainer.OnFloorMissed -= MissFloor;
            _floorContainer.OnFloorAdded -= AddFloor;
            _floorContainer.OnFloorRemoved -= RemoveFloor;
        }

        public void InitFloorManager(int maxFlCnt)
        {
            _crntFloorCount = 0;
            _maxFloorCount = maxFlCnt;
            _floorContainer.InitBuilding();

        }


        private void AddFloor()
        {
            _crntFloorCount++;
            _crntFloorCount = Mathf.Clamp(_crntFloorCount, 0, _maxFloorCount);
            OnFloorAdded?.Invoke(_crntFloorCount);
        }
        private void RemoveFloor()
        {
            _crntFloorCount--;
            _crntFloorCount = Mathf.Clamp(_crntFloorCount, 0, _maxFloorCount);
            OnFloorRemoved?.Invoke(_crntFloorCount);
        }
        private void MissFloor()
        {
            OnFloorMissed?.Invoke(_crntFloorCount);
        }

        internal void StartBuilding()
        {
            EnableFloorSpawn();
            _floorContainer.EnableHookOnLastFloor();
        }

        internal void StopBuilding()
        {
            DisableFloorSpawn();
            _floorContainer.DisableHookOnLastFloor();
        }

        private void EnableFloorSpawn()
        {
            _spawnController.StartSpawn();
        }

        private void DisableFloorSpawn()
        {
            _spawnController.StopSpawn();
        }
    }
}
