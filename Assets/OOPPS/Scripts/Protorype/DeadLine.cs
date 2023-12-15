using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class DeadLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<FloorStates>())
            {
                other.gameObject.GetComponent<FloorStates>().GroundCheck();
            }
        }
    }
}
