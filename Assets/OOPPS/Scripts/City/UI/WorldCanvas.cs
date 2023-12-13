using UnityEngine;

namespace OOPPS.City.UI
{
    [ExecuteAlways]
    public class WorldCanvas : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.forward = _camera.transform.forward;
        }
    }
}