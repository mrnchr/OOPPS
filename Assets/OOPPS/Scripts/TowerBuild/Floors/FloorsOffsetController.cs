using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS.TowerBuild
{
    public class FloorsOffsetController 
    {
        public Action<bool> OnOwerwaite;

        private LevelMover _levelMover;
        private TowerRotation _rotationController;

        private float _sumSideOffset;

        private float _criticalOffset;
        private int _upShiftToRot;
        private int _upShiftToCamMove;

        public FloorsOffsetController(TowerRotation towerRotation, BuildingMinigameConfig minigameConfig, LevelMover levelMover)
        {
            _rotationController = towerRotation;
            _levelMover = levelMover;

            _criticalOffset = minigameConfig.criticalOffset;
            _upShiftToRot = minigameConfig.upShiftToRot;
            _upShiftToCamMove = minigameConfig.upShiftToCamMove;
        }

        public bool TryAddNewFloorOffset(List<FloorStates> floorsList)
        {
            AddOffset(floorsList[floorsList.Count - 2]._offsetByNextFloor, floorsList.Count);

            if (MathF.Abs(_sumSideOffset) > _criticalOffset)
            {
                OnOwerwaite?.Invoke(true);

                return false;
            }



            if (floorsList.Count == _upShiftToRot)
            { _rotationController.StartRotate(); }

            if (floorsList.Count > _upShiftToRot)
            {
                ShiftBaseFloor(floorsList);
            }
            else if (floorsList.Count > _upShiftToCamMove)
            {
                _levelMover.Move(floorsList[floorsList.Count - 2].transform.position.y);
            }

            return true;
        }

        public void RemoveLastFloorOffset(List<FloorStates> floorsList)
        {
            AddOffset(-floorsList[floorsList.Count - 2]._offsetByNextFloor, floorsList.Count);


            if (floorsList.Count > _upShiftToRot)
            {
                ShiftBaseFloor(floorsList);
            }
            else if (floorsList.Count > _upShiftToCamMove)
            {
                _levelMover.Move(floorsList[floorsList.Count - 3].transform.position.y);
            }

        }
        public void AddOffset(float newOffset, int allFloorsCnt)
        {
            //   x = (x1m1 + x2m2 + ... + xnmn)/ (m1 + m2 + ...mn)

            //возможно неверно работает при ремуве
            _sumSideOffset = (_sumSideOffset * (allFloorsCnt - 1) + newOffset) / (allFloorsCnt);
            _rotationController.SetOffset(_sumSideOffset);
            //_sumSideOffset += newOffset;
        }


        public void ShiftBaseFloor(List<FloorStates> floorsList)
        {

            //от количества этажей определить новую основу для поворота
            Vector3 newFloorPos = floorsList[floorsList.Count - _upShiftToRot].transform.position;

            //переназначить прицепку начального джоинта к новому
            floorsList[0].ShiftJointAnchor(floorsList[floorsList.Count - _upShiftToRot]._rb);

            _rotationController.SetRotObjYPos(newFloorPos.y);

            if (floorsList.Count > _upShiftToCamMove)
            {
                _levelMover.Move(_rotationController.GetRotObjYPos() + 3);
            }

        }

    }
}