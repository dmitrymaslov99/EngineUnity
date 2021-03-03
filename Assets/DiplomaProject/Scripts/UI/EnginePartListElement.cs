using Dimploma.EngineParts;
using Dimploma.Input;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dimploma.UI
{
    public class EnginePartListElement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Toggle _visibilityToggle;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private InteractiveUIElement _interactiveElement;

        private EnginePartBase _enginePart;

        public void Initialize(EnginePartBase enginePart)
        {
            _enginePart = enginePart;
            _nameText.text = _enginePart.enginePartData.partName;

            _interactiveElement.onMouseEnter += OnMouseEnterHandler;
            _interactiveElement.onMouseExit += OnMouseExitHandler;

            _enginePart.onHide += OnHideHandler;

            _visibilityToggle.onValueChanged.AddListener(OnVisibilityToggleValueChangedHandler);
        }

        private void OnMouseEnterHandler(PointerEventData eventData)
        {
            _enginePart.OnMouseEnterHandler();
        }

        private void OnMouseExitHandler(PointerEventData eventData)
        {
            _enginePart.OnMouseExitHandler();
        }

        private void OnHideHandler()
        {
            _visibilityToggle.isOn = false;
        }

        private void OnVisibilityToggleValueChangedHandler(bool value)
        {
            _enginePart.gameObject.SetActive(value);
        }
    }
}