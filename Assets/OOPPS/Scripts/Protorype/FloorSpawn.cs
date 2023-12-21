using System;
using System.Collections;
using UnityEngine;

namespace OOPPS.TowerBuild
{
    public class FloorSpawn : MonoBehaviour
    {
        public event Action<FloorStates> IsNewFloorSpawned;


        [SerializeField] private FloorStates[] _floorPref;
        [SerializeField] private float MinSpeed;
        [SerializeField] private float MaxSpeed;
        [SerializeField] private float MinSpawnTime;
        [SerializeField] private float MaxSpawnTime;


        /*      public int _initCount;
              private List<FloorStates> _floorPool = new();*/
        [SerializeField] private Transform _floorsContainer;
        [SerializeField] private ColorManager _colorManager;

        /*      public void InitPool(int count)
              {
                  // _initCount = count;

                  _initCount = 3;

                  for (int i = 0; i < _initCount; i++)
                  {
                      var newFloor = Instantiate(_floorPref, _floorsContainer);

                      newFloor.gameObject.SetActive(false);
                      _floorPool.Add(newFloor);
                  }
              }

              private FloorStates GetFloor()
              {
                  var crntCount = _floorPool.Count;
                  for (int i = 0; i < crntCount; i++)
                  {
                      if (!_floorPool[i].gameObject.activeInHierarchy)
                      {
                          return _floorPool[i];
                      }
                  }

                  var newFloor = Instantiate(_floorPref, _floorsContainer);
                  _floorPool.Add(newFloor);

                  return newFloor;
              }
      */


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
                var floor = Instantiate(_floorPref[UnityEngine.Random.Range(0, _floorPref.Length)], GetPosition(), Quaternion.identity, _floorsContainer);

                floor.SetVelocity(Vector3.down * UnityEngine.Random.Range(MinSpeed, MaxSpeed));
                floor.SetMaterials(_colorManager.GetRandomMaterials());

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