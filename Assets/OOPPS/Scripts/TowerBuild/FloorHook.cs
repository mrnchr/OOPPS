using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOPPS
{
    public class FloorHook : MonoBehaviour
    {
        private void OnTriggerEnter(Collider newFloor)
        {
            if (newFloor.GetComponent<FloorStates>())
            {
                FloorContainer.OnFloorCollide?.Invoke(newFloor.GetComponent<FloorStates>());
            }
        }
    }
}