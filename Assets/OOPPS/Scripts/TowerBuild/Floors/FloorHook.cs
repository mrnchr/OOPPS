using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS.TowerBuild
{
    public class FloorHook : MonoBehaviour
    {
        public event Action<FloorStates> OnHookNewFloor;

        private void OnTriggerEnter(Collider newFloor)
        {
            if (newFloor.GetComponent<FloorStates>())
            {
                OnHookNewFloor?.Invoke(newFloor.GetComponent<FloorStates>());
            }
        }
    }
}