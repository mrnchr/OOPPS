using System.Collections;
using UnityEngine;

namespace OOPPS
{
    public class Turtle : MonoBehaviour
    {
        public float MoveSpeed;
        public float AccelerationTime;

        [SerializeField] private Rigidbody _rb;
        [SerializeField] private InputController _controller;

        private void OnEnable()
        {
        }

        private void Move(int direction)
        {
            Vector3 velocity = Vector3.right * (direction * MoveSpeed);
            if (velocity != _rb.velocity)
            {
                StopAllCoroutines();
                StartCoroutine(Accelerate(velocity));
            }


            //return later, now it interfer in rotation code
        /*    if (direction == 1 && transform.rotation.y == 1)
                transform.rotation = new Quaternion(0, 0, 0, 1);
            else if (direction == -1 && transform.rotation.x == 0)
                transform.rotation = new Quaternion(0, 1, 0, 0);*/
        }

        private IEnumerator Accelerate(Vector3 endVelocity)
        {
            float delta = endVelocity.x - _rb.velocity.x;
            float sign = Mathf.Sign(delta);
            while (Mathf.Abs(_rb.velocity.x) < Mathf.Abs(endVelocity.x))
            {
                _rb.velocity += Vector3.right * delta / AccelerationTime * Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            _rb.velocity = endVelocity;
        }

        [ContextMenu("Debug Quaternion")]
        public void DebugQuaternion()
        {
            Debug.Log(transform.rotation);
        }
    }
}