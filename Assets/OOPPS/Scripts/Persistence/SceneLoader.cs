using System.Collections;
using OOPPS.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OOPPS.Persistence
{
    public class SceneLoader : ISceneLoader
    {
        private readonly DataPersistenceManager _persistence;
        private readonly ICoroutineRunner _runner;
        private AsyncOperation _operation;

        public SceneLoader(DataPersistenceManager persistence, ICoroutineRunner runner)
        {
            _persistence = persistence;
            _runner = runner;
        }


        public void LoadScene(string sceneName)
        {
            _operation = SceneManager.LoadSceneAsync(sceneName);
            StartWaiting();
        }

        public void LoadScene(int sceneBuildIndex)
        {
            _operation = SceneManager.LoadSceneAsync(sceneBuildIndex);
            StartWaiting();
        }

        private void StartWaiting()
        {
            _operation.allowSceneActivation = false;
            _runner.RunCoroutine(WaitForSave());
        }

        private IEnumerator WaitForSave()
        {
            while (_persistence.IsPlanSaving())
                yield return null;

            _operation.allowSceneActivation = true;
        }
    }

    public interface ISceneLoader
    {
        public void LoadScene(string sceneName);
        public void LoadScene(int sceneBuildIndex);
    }
}