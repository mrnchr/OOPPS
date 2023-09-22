using UnityEngine;
using UnityEngine.SceneManagement;

namespace OOPPS
{
    public class MenuMediator : MonoBehaviour
    {
        public void Play() => SceneManager.LoadScene(1);
    }
}