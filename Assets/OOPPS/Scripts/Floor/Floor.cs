using UnityEngine;

namespace OOPPS
{
    public class Floor : BaseFloor
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Rigidbody _rb;
        
        public void SetVelocity(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        public override void MakeHook(Hook hook)
        {
            IsHooked = true;
            PreviousHook = hook;
            TurnOnGravity();
        }

        public void TurnOnGravity()
        {
            _rb.useGravity = true;
            _rb.drag = 2;
            _rb.velocity = Vector3.zero;
        }

        public override void Unhook()
        {
            IsHooked = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            TurnOnGravity();
            if (other.gameObject.layer == _groundLayer.GetLayerIndex())
                Destroy(gameObject);
        }
    }
}