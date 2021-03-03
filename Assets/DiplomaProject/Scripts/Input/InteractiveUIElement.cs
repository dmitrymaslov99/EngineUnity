using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dimploma.Input
{
    public class InteractiveUIElement : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        // Events
        public Action<PointerEventData> onMouseClick;

        public Action<PointerEventData> onMouseDown;
        public Action<PointerEventData> onMouseUp;

        public Action<PointerEventData> onMouseEnter;
        public Action<PointerEventData> onMouseExit;

        public void OnPointerClick(PointerEventData eventData)
        {
            onMouseClick?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onMouseDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onMouseUp?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onMouseEnter?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onMouseExit?.Invoke(eventData);
        }
    }
}