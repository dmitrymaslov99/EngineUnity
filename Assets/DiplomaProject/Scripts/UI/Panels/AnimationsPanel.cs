using UnityEngine;
using UnityEngine.UI;

namespace Dimploma.UI
{
    public class AnimationsPanel : PanelBase
    {
        [Header("Components")]
        [SerializeField] private Button _assemblyButton;
        [SerializeField] private Button _disassemblyButton;
        [Space]
        [SerializeField] private Animation _animation;

        [Header("Animations")]
        [SerializeField] private AnimationClip _assemblyClip;
        [SerializeField] private AnimationClip _disassemblyClip;

        public override void Initialize()
        {
            base.Initialize();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            _assemblyButton.onClick.AddListener(OnAssemblyButtonClickHandler);
            _disassemblyButton.onClick.AddListener(OnDisssemblyButtonClickHandler);
        }

        private void OnAssemblyButtonClickHandler()
        {
            PlayAnimation(_assemblyClip);
        }

        private void OnDisssemblyButtonClickHandler()
        {
            PlayAnimation(_disassemblyClip);
        }

        private void PlayAnimation(AnimationClip clip)
        {
            _animation.clip = clip;
            _animation.Play();
        }
    }
}