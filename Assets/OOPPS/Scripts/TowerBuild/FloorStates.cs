using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OOPPS
{

    public class FloorStates : MonoBehaviour
    {
        public Rigidbody _rb { get; private set; }
        public float _offsetByNextFloor { get; set; }


        [SerializeField]
        private GameObject _hook;
        [SerializeField]
        private GameObject _boarders;
        [SerializeField]
        private float _roofSize;


        private SpringJoint _joint;

        private void Awake()
        {
            _offsetByNextFloor = 0f;
            _joint = GetComponent<SpringJoint>();
            _rb = GetComponent<Rigidbody>();
            ResetJoint();
        }

        public void EnableHook()
        {
            _hook.SetActive(true);
        }
        public void DisableHook()
        {
            _hook.SetActive(false);
        }
        public void DisableBoarders()
        {
            _boarders.SetActive(false);
        }


        public void ResetJoint()
        {
            _joint.connectedBody = null;
            _joint.spring = 0f;
            _joint.damper = 0f;
            _joint.autoConfigureConnectedAnchor = true;
        }
        public void ConnectNewJoint(Rigidbody newFloorRb)
        {
            _joint.connectedBody = newFloorRb;
            _joint.spring = 4000f;
            _joint.damper = 5f;
        }
        public void ShiftJointAnchor(Rigidbody newFloorRb)
        {
            _joint.autoConfigureConnectedAnchor = false;
            _joint.connectedBody = newFloorRb;
            Vector3 newAnchor = new Vector3(0, _joint.anchor.y, 0);
            _joint.connectedAnchor = newAnchor;
        }
        private void DestroyJoint()
        {
            Destroy(_joint);
        }

        public bool IsNextFellStraight(Rigidbody newFloorRb, Vector3 firstFloorPos)
        {
            ConnectNewJoint(newFloorRb);

            _offsetByNextFloor = _joint.connectedAnchor.x;

            if (Mathf.Abs(_offsetByNextFloor) < _roofSize * 0.75f)
            {
                // Need refactor, logic not match the method name
                _offsetByNextFloor += (newFloorRb.gameObject.transform.position.x - firstFloorPos.x);
                return true;
            }
            else
            {
                _offsetByNextFloor = 0f;
                ResetJoint();
                return false;
            }

        }


        public void FreezeRotation()
        {

            _rb.freezeRotation = true;
        }
        public void EnablePhys()
        {
            _rb.isKinematic = false;
            _rb.freezeRotation = false;
        }
        public void SetVelocity(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        public void DestroyFloorProperty()
        {
            DisableHook();
            EnablePhys();
            DestroyJoint();
            DisableBoarders();
            Destroy(this);
        }

    }
}
