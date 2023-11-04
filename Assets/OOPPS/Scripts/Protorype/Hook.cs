using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace OOPPS
{
    public class Hook : MonoBehaviour
    {
        public BaseFloor Floor => _floor;
        public Hook NextHook => _nextHook;
        public Hook PreviousHook => _previousHook;
        public LayerMask FloorLayer;

        [SerializeField] private BaseFloor _floor;
        private Hook _nextHook;
        private Hook _previousHook;
        private LevelMover _level;

        public Hook GetPrevious() => PreviousHook ? PreviousHook : null;
        public Hook GetNext() => NextHook ? NextHook : null;

        public void UnhookForcefully()
        {
            if (!_nextHook) return;
            _nextHook.Unhook();
            _nextHook = null;
        }

        private void MakeHook(Hook previous)
        {
            _previousHook = previous;
            Floor.MakeHook(previous);
        }

        private void Unhook()
        {
            _previousHook = null;
            Floor.Unhook();
            UnhookForcefully();
        }

        private void Awake()
        {
            _level = FindObjectOfType<LevelMover>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_nextHook && IsHookedFloor() && IsFloor(other.gameObject))
            {
                _nextHook = other.GetComponent<BaseFloor>().Hook;
                _nextHook.MakeHook(this);
                _level.Move(Floor.transform.position.y);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_nextHook && IsHookedFloor() && IsFloor(other.gameObject))
            {
                UnhookForcefully();
                _level.Move(GetPrevious()?.Floor.transform.position.y ?? 0);
            }
        }


        private bool IsHookedFloor() => _floor.IsHooked;
        private bool IsFloor(GameObject obj) => obj.layer == FloorLayer.GetLayerIndex();
    }
}