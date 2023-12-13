using OOPPS.City.InputSystem;
using OOPPS.City.Raycasting;
using OOPPS.Core;
using UnityEngine;

namespace OOPPS.City.Interacting
{
    public class Interactor : IInteractor, IUpdatable
    {
        private readonly ICityInputController _input;
        private readonly IRaycaster _raycaster;

        public Interactor(ICityInputController input, IRaycaster raycaster)
        {
            _input = input;
            _raycaster = raycaster;
        }
        
        public void Update()
        {
            Process();
        }

        public void Process()
        {
            if(_input.Data.Tap && _raycaster.Raycast(_input.Data.TapData, out RaycastHit hit)
                && hit.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}