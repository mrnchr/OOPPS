using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OOPPS.Persistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        public SaveState State; 
        [SerializeField] private PersistenceDataConfig _config;
        private List<IDataPersistence> _dataPersistenceObjects = new List<IDataPersistence>();
        private GameData _gameData;
        private IFileDataHandler _fileHandler;
        private IPathHandler _pathHandler;
        private INewGameCreator _creator;
        private bool _isDirty;

        private void Awake()
        {
            _config = Instantiate(_config);
            _dataPersistenceObjects = FindDataPersistenceObjects().ToList();
            _pathHandler = new PathHandler(_config);
            _fileHandler = new FileDataHandler(_pathHandler.GetFileName());
            _creator = new NewGameCreator();
        }

        private void Start()
        {
#if UNITY_EDITOR
            _pathHandler.CreatePersistenceDirectory();
#endif
            Load();
            StartCoroutine(PermanentlySave());
        }

        public bool IsPlanSaving() => _isDirty || State == SaveState.Save;

        public void Load()
        {
            State = SaveState.Load;
            Debug.Log("SAVE: Data loading");
            _gameData = _config.DefaultGameData;
            if (!_fileHandler.Load(ref _gameData))
            {
                Debug.Log("SAVE: New Game");
                _creator.Create(_gameData);
                Save();
            }
            
            _dataPersistenceObjects.ForEach(x => x.Load(_gameData));
            State = SaveState.None;
        }

        public void Save()
        {
            _isDirty = true;
        }

        public async void SaveImmediatelyAsync()
        {
            State = SaveState.Save;
            Debug.Log("SAVE: Start saving");
            _dataPersistenceObjects.ForEach(x => x.Save(_gameData));
            await _fileHandler.SaveAsync(_gameData);
            Debug.Log("SAVE: Finish saving");
            State = SaveState.None;
        }

        private IEnumerator PermanentlySave()
        {
            while (true)
            {
                if (_isDirty && State == SaveState.None)
                {
                    SaveImmediatelyAsync();
                    _isDirty = false;
                }

                yield return null;
            }
        }

        private IEnumerable<IDataPersistence> FindDataPersistenceObjects()
        {
            return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .OfType<IDataPersistence>();
        }
    }
}