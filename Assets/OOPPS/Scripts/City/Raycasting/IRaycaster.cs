using UnityEngine;

namespace OOPPS.City.Raycasting
{
    public interface IRaycaster
    {
        public bool Raycast(Vector2 position, out RaycastHit hitInfo);
    }
}