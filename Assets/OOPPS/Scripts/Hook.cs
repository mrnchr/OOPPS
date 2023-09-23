using System;
using UnityEngine;

namespace OOPPS
{
    public class Hook : MonoBehaviour
    {
        public BaseFloor Floor => _floor;
        public BaseFloor NextFloor => _nextFloor;
        public LayerMask FloorLayer;

        [SerializeField] private BaseFloor _floor;
        private BaseFloor _nextFloor;
        private LevelMover _level;

        public void UnhookForcefully()
        {
            if (!_nextFloor) return;
            _nextFloor.Unhook();
            _nextFloor = null;
        }

        private void Awake()
        {
            _level = FindObjectOfType<LevelMover>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_nextFloor && IsHookedFloor() && IsFloor(other.gameObject))
            {
                _nextFloor = other.GetComponent<BaseFloor>();
                _nextFloor.Hook();
                _level.Move(_nextFloor.transform.position.y);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_nextFloor && IsHookedFloor() && IsFloor(other.gameObject))
            {
                UnhookForcefully();
                _level.Move(Floor.transform.position.y);
            }
        }

        private bool IsHookedFloor() => _floor.IsHooked;
        private bool IsFloor(GameObject obj) => obj.layer == FloorLayer.GetLayerIndex();
    }
}