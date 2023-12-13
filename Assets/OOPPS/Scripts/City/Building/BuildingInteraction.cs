using System;
using OOPPS.City.Interacting;
using UnityEngine;

namespace OOPPS.City.Building
{
    public class BuildingInteraction : MonoBehaviour, IInteractable
    {
        public event Action OnInteracted;
            
        public void Interact()
        {
            OnInteracted?.Invoke();
        }
    }
}