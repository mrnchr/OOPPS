using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS
{
    public class RotatingFloor : Floor2
    {
        public bool canRotate;

        [SerializeField]
        private float rotationRatio = 2f;
        [SerializeField]
        private float amplitudeTime;

        [SerializeField]
        private GameObject objToRotate;

        private void Start()
        {
            isHooked = true;//delete later
            InitSpringJoint();
           // StartRotate();
        }

      /*  public void StartRotate()
        {
            StartCoroutine(RotateBaseFloor());
        }
        public void StopRotate()
        {
            StopAllCoroutines();
        }


        IEnumerator RotateBaseFloor()
        {
            while (!canRotate)
            { yield return null; }

            float tmpTime = 0f;
            float crntSummOffset = Mathf.Abs(floorOffsetManager.summOffset);

            while (tmpTime < amplitudeTime)
            {
                objToRotate.transform.Rotate(objToRotate.transform.forward, crntSummOffset / amplitudeTime * 45f * Time.deltaTime);

                if (Mathf.Abs(objToRotate.transform.rotation.eulerAngles.z)>=90f)
                { break; }

                tmpTime += Time.deltaTime;
                yield return null;
            }

            tmpTime = 0f;
            while (tmpTime < amplitudeTime)
            {
                objToRotate.transform.Rotate(-objToRotate.transform.forward, crntSummOffset / amplitudeTime * 45f * Time.deltaTime);

                if (Mathf.Abs(objToRotate.transform.rotation.eulerAngles.z) >= 90f)
                { break; }


                tmpTime += Time.deltaTime;
                yield return null;
            }

            crntSummOffset = Mathf.Abs(floorOffsetManager.summOffset);

            tmpTime = 0f;
            while (tmpTime < amplitudeTime)
            {
                objToRotate.transform.Rotate(-objToRotate.transform.forward, crntSummOffset / amplitudeTime * 45f * Time.deltaTime);

                if (Mathf.Abs(objToRotate.transform.rotation.eulerAngles.z) >= 90f)
                { break; }


                tmpTime += Time.deltaTime;
                yield return null;
            }


            tmpTime = 0f;
            while (tmpTime < amplitudeTime)
            {
                objToRotate.transform.Rotate(objToRotate.transform.forward, crntSummOffset / amplitudeTime * 45f * Time.deltaTime);

                if (Mathf.Abs(objToRotate.transform.rotation.eulerAngles.z) >= 90f)
                { break; }


                tmpTime += Time.deltaTime;
                yield return null;
            }

            yield return null;

            StartCoroutine(RotateBaseFloor());

        }
*/
        private void Update()
        {
            // Debug.Log(summOffset);
        }

    }
}

