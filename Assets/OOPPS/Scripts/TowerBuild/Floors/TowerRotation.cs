using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS.TowerBuild
{
    public class TowerRotation : MonoBehaviour
    {
        private float _amplitudeTime = 5f;
        [SerializeField] private GameObject _rotObject;

        private float _offset;

        public void StartRotate()
        {
            StartCoroutine(RotateBaseFloor());
        }
        public void StopRotate()
        {
            StopAllCoroutines();
        }

        public void SetOffset(float offset)
        {
            _offset = offset;
        }

        internal float GetRotObjYPos()
        {
            return _rotObject.transform.position.y;
        }

        internal void SetRotObjYPos(float y)
        {
            _rotObject.transform.position = new Vector3(_rotObject.transform.position.x, y, _rotObject.transform.position.z);
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
            float crntSummOffset = isPositivRot ? Mathf.Abs(_offset) : Mathf.Abs(_offset) * (-1);

            _rotObject.transform.Rotate(_rotObject.transform.forward, crntSummOffset / _amplitudeTime * 1000f * Time.deltaTime);

            return crntSummOffset / _amplitudeTime * 50 * Time.deltaTime;
        }
    }
}