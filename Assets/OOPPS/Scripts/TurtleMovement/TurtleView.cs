using System;
using UnityEngine;

namespace OOPPS
{
    public class TurtleView : MonoBehaviour
    {
        public Rigidbody Rb;
        public Animator Animator;
        public Transform model;



        internal void DisableModel()
        {
            model.gameObject.SetActive(false);
        }
        internal void DisableModelCollider()
        {
            model.gameObject.GetComponent<Collider>().enabled = false;
        }

        internal void RotateModel(float direction)
        {
            if (direction != 0)
            {
                model.rotation = Quaternion.Euler(-90, direction * 90, 0);
            }
        }
    }
}