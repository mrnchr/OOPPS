using System.Collections;
using UnityEngine;

namespace OOPPS
{
    public class LevelMover : MonoBehaviour
    {
        public float MoveTime;

        public void Move(float yPos)
        {
            StopAllCoroutines();
            StartCoroutine(MoveLinear(yPos));
        }

        private IEnumerator MoveLinear(float yPos)
        {
            float delta = yPos - transform.position.y;
            while (Mathf.Sign(delta) * (yPos - transform.position.y) > 0)
            {
                transform.position += Vector3.up * delta / MoveTime * Time.deltaTime;
                yield return null;
            }

            Vector3 pos = transform.position;
            pos.y = yPos;
            transform.position = pos;
        }
    }
}