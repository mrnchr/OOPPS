using UnityEngine;

namespace OOPPS.City.Raycasting
{
    public class CityRaycaster : IRaycaster
    {
        private readonly Camera _camera;

        public CityRaycaster(Camera camera)
        {
            _camera = camera;
        }
        
        public bool Raycast(Vector2 position, out RaycastHit hitInfo)
        {
            Ray ray = _camera.ScreenPointToRay(position);
            return Physics.Raycast(ray, out hitInfo);
        }
    }
}