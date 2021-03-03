using System;
using UnityEngine;

namespace Dimploma.Input
{
    public class InteractiveElement : MonoBehaviour
    {
        // Events
        public Action onMouseEnter;
        public Action onMouseExit;

        private void OnMouseEnter()
        {
            onMouseEnter?.Invoke();
        }

        private void OnMouseExit()
        {
            onMouseExit?.Invoke();
        }
    }
}