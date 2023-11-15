using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS
{
    public class FloorsRotationController : MonoBehaviour
    {
        private float _sumSideOffset { get; set; }

        [Header("Dependencies")]
        [SerializeField]
        private GameObject _rotObject;

        [SerializeField]
        private float _criticalOffset;

        [SerializeField]
        private LevelMover _levelMover;


        [Header("Values")]
        [SerializeField]
        private float _amplitudeTime;
        // Кол-во этажей, через которое начнётся смещатся центр поворота
        [SerializeField] 
        private int _upShiftToRot;
        // Кол-во этажей, через которое начнётся смещатся камера
        [SerializeField]
        private int _upShiftToCamMove;


        private void Start()
        {
            //need to refactor, move to another game controller
            StartRotate();
        }


        public void AddNewFloorOffset(List<FloorStates> floorsList)
        {
            AddOffset(floorsList[floorsList.Count - 2]._offsetByNextFloor);

            if (MathF.Abs(_sumSideOffset) > _criticalOffset)
            {
                FloorContainer.OnOwerwaite?.Invoke();

                return;
            }

            if (floorsList.Count > _upShiftToCamMove)
            {
                _levelMover.Move(floorsList[floorsList.Count - 2].transform.position.y);
            }

            if (floorsList.Count > _upShiftToRot)
            {
                ShiftBaseFloor(floorsList);
            }
        }
        public void RemoveLastFloorOffset(List<FloorStates> floorsList)
        {
            AddOffset(-floorsList[floorsList.Count - 2]._offsetByNextFloor);


            if (floorsList.Count > _upShiftToCamMove)
            {
                _levelMover.Move(floorsList[floorsList.Count - 3].transform.position.y);
            }

            if (floorsList.Count > _upShiftToRot)
            {
                ShiftBaseFloor(floorsList);
            }
        }
        public void AddOffset(float newOffset)
        {
            _sumSideOffset += newOffset;
        }


        public void ShiftBaseFloor(List<FloorStates> floorsList)
        {

            //от количества этажей определить новую основу для поворота
            Vector3 newFloorPos = floorsList[floorsList.Count - _upShiftToRot].transform.position;

            //переназначить прицепку начального джоинта к новому
            floorsList[0].ShiftJointAnchor(floorsList[floorsList.Count - _upShiftToRot]._rb);

            _rotObject.transform.position = new Vector3(_rotObject.transform.position.x, newFloorPos.y, _rotObject.transform.position.z);
        }



        public void StartRotate()
        {
            StartCoroutine(RotateBaseFloor());
        }
        public void StopRotate()
        {
            StopAllCoroutines();
        }
        IEnumerator RotateBaseFloor()
        {
            float tmpDeg = 0f;

            while (tmpDeg < 90f)
            {
                tmpDeg += RotateBySide(true);
                yield return null;
            }

            tmpDeg = 0f;
            while (tmpDeg < 180f)
            {
                tmpDeg += RotateBySide(false);
                yield return null;
            }
            tmpDeg = 0f;
            while (tmpDeg < 90f)
            {
                tmpDeg += RotateBySide(true);
                yield return null;
            }



            yield return null;

            StartCoroutine(RotateBaseFloor());

        }
        private float RotateBySide(bool isPositivRot)
        {
            float crntSummOffset = isPositivRot ? Mathf.Abs(_sumSideOffset) : Mathf.Abs(_sumSideOffset) * (-1);

            _rotObject.transform.Rotate(_rotObject.transform.forward, crntSummOffset / _amplitudeTime * 50f * Time.deltaTime);

            return crntSummOffset / _amplitudeTime * 50 * Time.deltaTime;
        }


    }
}