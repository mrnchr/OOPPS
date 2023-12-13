using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OOPPS.Persistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [SerializeField] private GameDataConfig _config;
        private List<IDataPersistence> _dataPersistenceObjects = new List<IDataPersistence>();
        private GameData _gameData;
        
        private void Awake()
        {
            _dataPersistenceObjects = FindDataPersistenceObjects().ToList();
        }

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            // TODO: Write load
            _gameData = _config.ManualGameData;
            _dataPersistenceObjects.ForEach(x => x.Load(_gameData));
        }

        public void Save()
        {
            _dataPersistenceObjects.ForEach(x => x.Save(_gameData));
            // TODO: Write save
        }

        private IEnumerable<IDataPersistence> FindDataPersistenceObjects()
        {
            return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .OfType<IDataPersistence>();
        }
    }
}