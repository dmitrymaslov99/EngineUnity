using DG.Tweening;
using EasyButtons;
using System.Linq;
using UnityEngine;

namespace Dimploma.Animations
{
    public class AnimationsController : MonoBehaviour
    {
        //[Header("Components")]

        private IAnimation[] _animations;
        private Sequence _animationsSequence;

        private void Start()
        {
            InitializeAnimations();
        }

        [Button]
        public void InitializeAnimations()
        {
            _animations = GetComponentsInChildren<IAnimation>();
            _animations = _animations.OrderBy(a => a.ID).ToArray();

            foreach (var animation in _animations)
            {
                animation.Initialize();
            }
        }

        [Button]
        public void Animate()
        {
            ToStart();

            _animationsSequence = DOTween.Sequence();

            foreach (var animation in _animations)
            {
                _animationsSequence.Append(animation.Animate());
            }
        }

        [Button]
        public void ToStart()
        {
            foreach (var animation in _animations)
                animation.ToStart();
        }

        [Button]
        public void ToFinish()
        {
            foreach (var animation in _animations)
                animation.ToFinish();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                Animate();
            }
        }
    }
}