using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS
{
    public class FloorContainer : MonoBehaviour
    {
        public static Action<FloorStates> OnFloorCollide;
        public static Action OnOwerwaite;

        [SerializeField]
        private FloorsRotationController _rotController;

        [SerializeField]
        private FloorStates _firstFloor;

        private List<FloorStates> _floorsList = new List<FloorStates>();


        private void OnEnable()
        {
            OnFloorCollide += TryToAddFloor;
            OnOwerwaite += RemoveFloor;
        }
        private void OnDisable()
        {
            OnFloorCollide -= TryToAddFloor;
            OnOwerwaite -= RemoveFloor;
        }

        private void Start()
        {
            AddFloor(_firstFloor);
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
                    newFloor.DestroyFloorProperty();
                }
            }


        }


        public void AddFloor(FloorStates newFloor)
        {

            _floorsList.Add(newFloor);
            _floorsList[_floorsList.Count - 1].EnableHook();


            if (_floorsList.Count > 1)
            {
                _floorsList[_floorsList.Count - 1].DisableBoarders();
                _floorsList[_floorsList.Count - 1].FreezeRotation();

                _floorsList[_floorsList.Count - 2].DisableHook();

                _rotController.AddNewFloorOffset(_floorsList);
            }


        }

        private void RemoveFloor()
        {

            if (_floorsList.Count > 2)
            {
                _rotController.RemoveLastFloorOffset(_floorsList);

                FloorStates removedFloor = _floorsList[_floorsList.Count - 1];
                _floorsList.Remove(removedFloor);

                removedFloor.DestroyFloorProperty();
            }

            _floorsList[_floorsList.Count - 1].ResetJoint();
            _floorsList[_floorsList.Count - 1].EnableHook();


        }

    }


}
