using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS
{
    public class FloorOffsetManager : MonoBehaviour
    {

        public float summOffset;

        private List<Floor2> floorsList = new List<Floor2>();

        public int countOfFloors;

        private int baseFloorInd;

        [SerializeField]
        private float rotationRatio;
        [SerializeField]
        private float amplitudeTime;

        [SerializeField]
        private Floor2 turtleBack;
        private GameObject rotatingObj;
        [SerializeField]
        private Transform movingObj;

        [SerializeField]
        private int offsetFloors;


        private void Awake()
        {
            rotatingObj = movingObj.gameObject;

        }
        private void Start()
        {
            AddFloor(turtleBack, 0f);
            countOfFloors = 0;
            baseFloorInd = 0;
            StartRotate();
        }

        public void AddFloor(Floor2 newFloor, float offset)
        {
            floorsList.Add(newFloor);
            newFloor.isHooked = true;
            if (floorsList.Count > offsetFloors)
            {
                baseFloorInd++;
                ShiftBaseFloor();
            }
            countOfFloors++;

            summOffset += offset + (newFloor.gameObject.transform.position.x - floorsList[0].transform.position.x);


        }

        private void ShiftBaseFloor()
        {
            rotatingObj = floorsList[baseFloorInd].gameObject;

            turtleBack.spJoint.autoConfigureConnectedAnchor = false;

            turtleBack.spJoint.connectedBody = rotatingObj.GetComponent<Rigidbody>();

            Vector3 newAnchor = new Vector3(0, turtleBack.spJoint.anchor.y, 0);
            //  turtleBack.spJoint.connectedAnchor = Vector3.zero;
            turtleBack.spJoint.connectedAnchor = newAnchor;
            //turtleBack.spJoint.connectedAnchor = new Vector3(turtleBack.spJoint.connectedAnchor.x, turtleBack.spJoint.connectedAnchor.y+rotatingObj.position.y, turtleBack.spJoint.connectedAnchor.z);

            movingObj.position = new Vector3(movingObj.position.x, rotatingObj.transform.position.y, movingObj.position.z);
            //StartCoroutine(MoveLinear(rotatingObj.position.y));
            //  StopRotate();
            //  StartRotate();
            rotatingObj = movingObj.gameObject;
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
            float crntSummOffset;

            while (tmpDeg<90f)
            {
                crntSummOffset = Mathf.Abs(summOffset);
        
                rotatingObj.transform.Rotate(rotatingObj.transform.forward, crntSummOffset / amplitudeTime * 50f * Time.deltaTime);

          
                tmpDeg += crntSummOffset / amplitudeTime * 50 * Time.deltaTime; 
                yield return null;
            }

            tmpDeg = 0f;
            while (tmpDeg <180f)
            {
                crntSummOffset = Mathf.Abs(summOffset);
                rotatingObj.transform.Rotate(rotatingObj.transform.forward, -crntSummOffset / amplitudeTime * 50f * Time.deltaTime);

                tmpDeg += crntSummOffset / amplitudeTime * 50 * Time.deltaTime;
                yield return null;
            }
            tmpDeg = 0f;
            while (tmpDeg < 90f)
            {
                crntSummOffset = Mathf.Abs(summOffset);
               
                rotatingObj.transform.Rotate(rotatingObj.transform.forward, crntSummOffset / amplitudeTime * 50f * Time.deltaTime);


                tmpDeg += crntSummOffset / amplitudeTime * 50 * Time.deltaTime; 
                yield return null;
            }

           

            yield return null;

            StartCoroutine(RotateBaseFloor());

        }

        private void Update()
        {
            //   Debug.Log(summOffset);
        }

    }
}

