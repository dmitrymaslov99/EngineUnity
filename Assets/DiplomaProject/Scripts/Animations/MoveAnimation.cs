using DG.Tweening;
using Dimploma.Configs;
using UnityEngine;

namespace Dimploma.Animations
{
    public class MoveAnimation : MonoBehaviour, IAnimation
    {
        public int ID => _id;
        public Transform Target => _target;

        [Header("Settings")]
        [SerializeField] private int _id;

        [Header("Components")]
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _finishPosition;

        [Header("Configs")]
        [SerializeField] private AnimationsConfig _animationsConfig;

        private Vector3 _startPosition;

        public void Initialize()
        {
            _startPosition = _target.position;
        }

        public Tween Animate()
        {
            return _target.DOMove(_finishPosition.position, _animationsConfig.duration);
        }

        public void ToStart()
        {
            _target.transform.position = _startPosition;
        }

        public void ToFinish()
        {
            _target.transform.position = _finishPosition.position;
        }
    }
}