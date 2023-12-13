using System;
using System.Collections;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class FloorSpawn : MonoBehaviour
    {
        public event Action<FloorStates> IsNewFloorSpawned;

        public FloorStates Floor;
        public float MinSpeed;
        public float MaxSpeed;
        public float MinSpawnTime;
        public float MaxSpawnTime;


        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                FloorStates floor = Instantiate(Floor, GetPosition(), Quaternion.identity);
                floor.SetVelocity(Vector3.down * UnityEngine.Random.Range(MinSpeed, MaxSpeed));
                IsNewFloorSpawned?.Invoke(floor);
                yield return new WaitForSeconds(UnityEngine.Random.Range(MinSpawnTime, MaxSpawnTime));
            }
        }

        private Vector3 GetPosition()
        {
            Vector3 pos = transform.position;
            Vector3 scale = transform.localScale;
            return new Vector3(UnityEngine.Random.Range(pos.x - scale.x / 2, pos.x + scale.x / 2), pos.y, pos.z);
        }
    }
}