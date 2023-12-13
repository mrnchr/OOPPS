using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS.TowerBuild
{
    public class FloorContainer : MonoBehaviour
    {
        public event Action<FloorStates> OnFloorCollide;

        public event Action OnFloorAdded;
        public event Action OnFloorRemoved;
        public event Action OnFloorMissed;
        public event Action<FloorStates> OnFloorGotGround;


        [SerializeField] private FloorsOffsetController _rotController;
        [SerializeField] private FloorStates _firstFloor;

        private List<FloorStates> _floorsList = new List<FloorStates>();


        private void OnEnable()
        {
            OnFloorCollide += TryToAddFloor;
            _rotController.OnOwerwaite += RemoveLastFloor;
            OnFloorGotGround += FloorGotGroundActions;
        }
        private void OnDisable()
        {
            OnFloorCollide -= TryToAddFloor;
            _rotController.OnOwerwaite -= RemoveLastFloor;
            OnFloorGotGround -= FloorGotGroundActions;
        }


        public void InitBuilding()
        {
            SetFloorListeners(_firstFloor);
            AddFloor(_firstFloor);
        }



        private void FloorGotGroundActions(FloorStates floor)
        {
            OnFloorMissed?.Invoke();
        }


        internal void SetFloorListeners(FloorStates floor)
        {
            floor._hookComponent.OnHookNewFloor += OnFloorCollide;
            floor.OnGroundCollide += OnFloorGotGround;
            floor.OnGroundCollide += RemoveFloorListeners;
        }
        internal void RemoveFloorListeners(FloorStates floor)
        {
            floor._hookComponent.OnHookNewFloor -= OnFloorCollide;
            floor.OnGroundCollide -= OnFloorGotGround;
            floor.OnGroundCollide -= RemoveFloorListeners;
        }


        public void TryToAddFloor(FloorStates newFloor)
        {
            if (!_floorsList.Contains(newFloor))
            {
                if (_floorsList[_floorsList.Count - 1].IsNextFellStraight(newFloor._rb, _floorsList[0].transform.position))
                {
                    AddFloor(newFloor);        
                }
                else
                {
                    OnFloorMissed?.Invoke();
                    newFloor.DestroyFloorProperty();
                }
            }


        }
        public void AddFloor(FloorStates newFloor)
        {
            newFloor.IsHooked = true;
            _floorsList.Add(newFloor);
            _floorsList[_floorsList.Count - 1].EnableHook();

            //checkout for init turtle back floor
            if (_floorsList.Count > 1)
            {
                _floorsList[_floorsList.Count - 1].SetAddedFloorProperty();

                _floorsList[_floorsList.Count - 2].DisableHook();

                if (_rotController.TryAddNewFloorOffset(_floorsList))
                {
                    if (_floorsList.Count > 6)
                    {
                        _floorsList[_floorsList.Count - 6].NullMass();
                    }
                    OnFloorAdded?.Invoke();
                }
            }


        }
        private void RemoveLastFloor(bool isNewFloor)
        {

            if (_floorsList.Count > 2)
            {
                _rotController.RemoveLastFloorOffset(_floorsList);

                FloorStates removedFloor = _floorsList[_floorsList.Count - 1];
                _floorsList.Remove(removedFloor);
                removedFloor.IsHooked = false;

                removedFloor.DestroyFloorProperty();
            }

            _floorsList[_floorsList.Count - 1].ResetJoint();
            _floorsList[_floorsList.Count - 1].EnableHook();

            if (isNewFloor)
            {
                OnFloorMissed?.Invoke();
            }
            else
            {
                if (_floorsList.Count > 6)
                {
                    _floorsList[_floorsList.Count - 6].ReturnMass();
                }

                OnFloorRemoved?.Invoke();
            }

        }

        public void EnableHookOnLastFloor()
        {
            _floorsList[_floorsList.Count - 1].EnableHook();
        }

        public void DisableHookOnLastFloor()
        {
            _floorsList[_floorsList.Count - 1].DisableHook();
        }



    }


}
