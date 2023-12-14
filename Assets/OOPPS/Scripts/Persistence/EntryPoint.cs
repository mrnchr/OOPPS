using UnityEngine;
using UnityEngine.SceneManagement;

namespace OOPPS.Persistence
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PersistenceDataConfig _config;
        
        private void Awake()
        {
            new PathHandler(_config).CreatePersistenceDirectory();
            SceneManager.LoadScene(1);
        }
    }
}