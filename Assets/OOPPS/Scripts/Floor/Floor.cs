using UnityEngine;

namespace OOPPS
{
    public class Floor : BaseFloor
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Hook _hook;
        
        public void SetVelocity(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        public override void Hook()
        {
            IsHooked = true;
            TurnOnGravity();
        }

        public void TurnOnGravity()
        {
            _rb.useGravity = true;
        }

        public override void Unhook()
        {
            IsHooked = false;
            _hook.UnhookForcefully();
        }

        private void OnCollisionEnter(Collision other)
        {
            TurnOnGravity();
            if (other.gameObject.layer == _groundLayer.GetLayerIndex())
                Destroy(gameObject);
        }
    }
}