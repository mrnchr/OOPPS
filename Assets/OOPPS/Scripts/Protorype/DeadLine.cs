using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS
{


    public class DeadLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<Floor2>())
            {
                if (!other.gameObject.GetComponent<Floor2>().isHooked)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
