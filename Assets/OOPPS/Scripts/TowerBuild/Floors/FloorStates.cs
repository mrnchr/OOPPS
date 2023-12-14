using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OOPPS.TowerBuild
{

    public class FloorStates : MonoBehaviour
    {
        public event Action<FloorStates> OnGroundCollide;

        public Rigidbody _rb { get; private set; }
        private float _initMas;
        public float _offsetByNextFloor { get; set; }


        [SerializeField] private GameObject _hook;
        public FloorHook _hookComponent;
        private bool _isHooked;
        public bool IsHooked { get => _isHooked; set => _isHooked = value; }

        [SerializeField] private GameObject _boarders;
        [SerializeField] private float _roofSize;


        private SpringJoint _joint;

        private void Awake()
        {
            _isHooked = false;
            _offsetByNextFloor = 0f;
            _joint = GetComponent<SpringJoint>();
            _rb = GetComponent<Rigidbody>();
            _initMas = _rb.mass;
            ResetJoint();
        }

        public void GroundCheck()
        {
            if (!_isHooked)
            {
                OnGroundCollide?.Invoke(this);
                //!!! заменить на выход из пула
                Invoke("DestroyObj", 2f);
            }
        }
        private void DestroyObj()
        {
            Destroy(this.gameObject);
           // this.gameObject.SetActive(false);
        }

        public void SetHookListener(Action<FloorStates> TryAddFloorEvent)
        {
            _hookComponent.OnHookNewFloor += TryAddFloorEvent;
        }

        public void RemoveHookListener(Action<FloorStates> TryAddFloorEvent)
        {
            _hookComponent.OnHookNewFloor -= TryAddFloorEvent;
        }


        public void EnableHook()
        {
            _hook.SetActive(true);
        }
        public void DisableHook()
        {
            _hook.SetActive(false);
        }
        private void DisableBoarders()
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

        internal void NullMass()
        {
            _rb.mass = 0;
        }
        internal void ReturnMass()
        {
            _rb.mass = _initMas;
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


        private void FreezeRotation()
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


        public void SetAddedFloorProperty()
        {
            DisableBoarders();
            FreezeRotation();
        }
        public void DestroyFloorProperty()
        {
            DisableHook();
            EnablePhys();
            DestroyJoint();
            DisableBoarders();

            Invoke("DestroyObj", 2f);
            Destroy(this);

        }

    }
}
