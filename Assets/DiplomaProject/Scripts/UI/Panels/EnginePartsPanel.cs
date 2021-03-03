using Dimploma.Controllers;
using UnityEngine;

namespace Dimploma.UI
{
    public class EnginePartsPanel : PanelBase
    {
        [Header("Components")]
        [SerializeField] private Transform _enginePartElementsRoot;

        [Header("Prefabs")]
        [SerializeField] private EnginePartListElement _enginePartElementPrefab;

        private EngineController EngineController => SceneController.EngineController;

        public override void Initialize()
        {
            base.Initialize();
            InitializeEnginePartElements();
        }

        private void InitializeEnginePartElements()
        {
            foreach (var enginePart in EngineController.engineParts)
            {
                EnginePartListElement partListElement = Instantiate(_enginePartElementPrefab, _enginePartElementsRoot);
                partListElement.Initialize(enginePart);
            }
        }
    }
}