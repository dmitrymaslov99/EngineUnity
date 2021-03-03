using UnityEngine;

namespace Dimploma.Input
{
    public class CameraController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _rotateSpeed = 3f;
        [SerializeField] private Vector2Int _rotationBounds = new Vector2Int(-70, 70);
        [SerializeField] private Vector2 _scaleBounds = new Vector2(2f, 7f);

        [Header("Components")]
        [SerializeField] private InteractiveUIElement _interactiveElement;

        private Quaternion _cameraRotation;
        private bool _isDrag;

        private void Start()
        {
            _cameraRotation = transform.localRotation;

            _interactiveElement.onMouseDown += e => _isDrag = true;
            _interactiveElement.onMouseUp += e => _isDrag = false;
        }

        private void Update()
        {
            if (_isDrag)
            {
                _cameraRotation.y += _rotateSpeed * UnityEngine.Input.GetAxis("Mouse X");
                _cameraRotation.x -= _rotateSpeed * UnityEngine.Input.GetAxis("Mouse Y");

                _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, _rotationBounds.x, _rotationBounds.y);

                transform.localRotation = Quaternion.Euler(_cameraRotation.x, _cameraRotation.y, _cameraRotation.z);
            }

            float scrollFactor = UnityEngine.Input.GetAxis("Mouse ScrollWheel");

            if (scrollFactor != 0)
            {
                float scale = Mathf.Clamp(transform.localScale.x * (1f - scrollFactor), _scaleBounds.x, _scaleBounds.y);
                transform.localScale = Vector3.one * scale;
            }
        }
    }
}