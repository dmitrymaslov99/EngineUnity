using Dimploma.Datasets;
using Dimploma.Input;
using EasyButtons;
using System;
using UnityEngine;

//using UnityEditor.Presets;

namespace Dimploma.EngineParts
{
    public abstract class EnginePartBase : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject[] _targets;

        //[Header("Presets")]
        //[SerializeField] private Preset _outlinePreset;

        [Header("Data")]
        public EnginePartData enginePartData;

        protected InteractiveElement[] interactiveElements;
        protected Outline[] outlines;

        // Events
        public Action<EnginePartBase> onMouseEnter;
        public Action<EnginePartBase> onMouseExit;
        public Action onHide;

        /*[Button]
        public void Generate()
        {
            if (_targets == null || _targets.Length == 0)
                _targets = new GameObject[] { gameObject };

            foreach (var target in _targets)
            {
                var meshCollider = target.AddComponent<MeshCollider>();
                meshCollider.convex = true;
                meshCollider.isTrigger = true;

                var outline = target.AddComponent<Outline>();
                _outlinePreset.ApplyTo(outline);

                target.AddComponent<InteractiveElement>();
            }
        }*/

        public virtual void Initialize()
        {
            if (_targets == null || _targets.Length == 0)
                _targets = new GameObject[] { gameObject };

            InitializeInteractiveElements();
            InitializeOutlines();
        }

        private void InitializeInteractiveElements()
        {
            interactiveElements = new InteractiveElement[_targets.Length];

            for (int i = 0; i < _targets.Length; i++)
                interactiveElements[i] = _targets[i].GetComponent<InteractiveElement>();

            foreach (var interactiveElement in interactiveElements)
            {
                interactiveElement.onMouseEnter += OnMouseEnterHandler;
                interactiveElement.onMouseExit += OnMouseExitHandler;
            }
        }

        private void InitializeOutlines()
        {
            outlines = new Outline[_targets.Length];

            for (int i = 0; i < _targets.Length; i++)
                outlines[i] = _targets[i].GetComponent<Outline>();

            foreach (var outline in outlines)
            {
                outline.enabled = false;
            }
        }

        public void OnMouseEnterHandler()
        {
            onMouseEnter?.Invoke(this);
            SetActiveOutline(true);
        }

        public void OnMouseExitHandler()
        {
            onMouseExit?.Invoke(this);
            SetActiveOutline(false);
        }

        private void SetActiveOutline(bool value)
        {
            foreach (var outline in outlines)
            {
                outline.enabled = value;
            }
        }

        private void OnDisable()
        {
            SetActiveOutline(false);
            onHide?.Invoke();
        }
    }
}