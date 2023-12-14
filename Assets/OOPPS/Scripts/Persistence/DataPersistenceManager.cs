using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OOPPS.Persistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [SerializeField] private PersistenceDataConfig _config;
        private List<IDataPersistence> _dataPersistenceObjects = new List<IDataPersistence>();
        private GameData _gameData;
        private IFileDataHandler _fileHandler;
        private IPathHandler _pathHandler;

        private void Awake()
        {
            _config = Instantiate(_config);
            _dataPersistenceObjects = FindDataPersistenceObjects().ToList();
            _pathHandler = new PathHandler(_config);
            _fileHandler = new FileDataHandler(_pathHandler.GetFileName());
        }

        private void Start()
        {
#if UNITY_EDITOR
            _pathHandler.CreatePersistenceDirectory();
#endif
            StartCoroutine(DelayLoad());
        }

        private IEnumerator DelayLoad()
        {
            yield return null;
            Load();
        }

        public void Load()
        {
            Debug.Log("SAVE: Data loading");
            _gameData = _config.DefaultGameData;
            if (!_fileHandler.Load(ref _gameData))
            {
                Debug.Log("SAVE: New Game");
                _fileHandler.Save(_gameData);
            }
            
            
            _dataPersistenceObjects.ForEach(x => x.Load(_gameData));
        }

        public void Save()
        {
            Debug.Log("SAVE: Start saving");
            _dataPersistenceObjects.ForEach(x => x.Save(_gameData));
            _fileHandler.Save(_gameData);
        }

        private IEnumerable<IDataPersistence> FindDataPersistenceObjects()
        {
            return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .OfType<IDataPersistence>();
        }
    }
}