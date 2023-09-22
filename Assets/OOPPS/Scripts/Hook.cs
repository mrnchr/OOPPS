using UnityEngine;

namespace OOPPS
{
    public class Hook : MonoBehaviour
    {
        public Floor Floor => _floor;
        public Floor NextFloor => _nextFloor;
        public LayerMask FloorLayer;
        
        [SerializeField] private Floor _floor;
        private Floor _nextFloor;
        private LevelMover _level;

        private void Awake()
        {
            _level = FindObjectOfType<LevelMover>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == FloorLayer.GetLayerIndex())
            {
                _nextFloor = other.GetComponent<Floor>();
                _level.Move(_nextFloor.transform.position.y);
            }
        }
    }
}