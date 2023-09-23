using System.Collections;
using UnityEngine;

namespace OOPPS
{
    public class FloorSpawn : MonoBehaviour
    {
        public Floor Floor;
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
                Floor floor = Instantiate(Floor, GetPosition(), Quaternion.identity);
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