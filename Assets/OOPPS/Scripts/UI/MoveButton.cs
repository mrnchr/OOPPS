using UnityEngine;
using UnityEngine.EventSystems;

namespace OOPPS
{
    public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [HideInInspector] public bool IsClickHold;

        public void OnPointerDown(PointerEventData eventData)
        {
            IsClickHold = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsClickHold = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsClickHold = false;
        }
    }
}