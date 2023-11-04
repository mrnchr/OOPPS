using UnityEngine;

namespace OOPPS
{
    public class ControlButton : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect;
        public int InputValue;

        public bool IsInBox(Vector2 coordinate)
        {
            var corners = new Vector3[4];
            _rect.GetWorldCorners(corners);
            Vector2 minPos = corners[0];
            Vector2 maxPos = corners[2];
            return minPos.x < coordinate.x && minPos.y < coordinate.y
                && maxPos.x > coordinate.x && maxPos.y > coordinate.y;
        }
    }
}