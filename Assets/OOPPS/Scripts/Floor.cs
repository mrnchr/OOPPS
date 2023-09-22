using UnityEngine;

namespace OOPPS
{
    public class Floor : MonoBehaviour
    {
        [SerializeField] private LayerMask GroundLayer;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Hook _hook;

        public void SetVelocity(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == GroundLayer.GetLayerIndex())
                Destroy(gameObject);
        }
    }
}