using System.Collections;
using UnityEngine;

namespace OOPPS
{
    public class FloorSpawn : MonoBehaviour
    {
        public Floor2 Floor2;
        public float MinSpeed;
        public float MaxSpeed;
        public float MinSpawnTime;
        public float MaxSpawnTime;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Floor2 floor = Instantiate(Floor2, GetPosition(), Quaternion.identity);
                floor.SetVelocity(Vector3.down * Random.Range(MinSpeed, MaxSpeed));
                yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            }
        }

        private Vector3 GetPosition()
        {
            Vector3 pos = transform.position;
            Vector3 scale = transform.localScale;
            return new Vector3(Random.Range(pos.x - scale.x / 2, pos.x + scale.x / 2), pos.y, pos.z);
        }
    }
}