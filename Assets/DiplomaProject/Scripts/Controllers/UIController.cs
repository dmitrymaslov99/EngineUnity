using Dimploma.EngineParts;
using Dimploma.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dimploma.Controllers
{
    public class UIController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private PartInfoPanel _partInfoPanel;
        [SerializeField] private Transform _panelsRoot;
        [Space]
        [SerializeField] private Button _exitButton;


        private EngineController EngineController => SceneController.EngineController;
        private List<PanelBase> _panelsList;

        private PanelBase _currentPanel;
        private EnginePartBase _currentEnginePart;

        public void Intialize()
        {
            InitializePanels();
            InitializeEngineParts();
            InitializeButtons();
        }

        private void InitializePanels()
        {
            _panelsList = _panelsRoot.GetComponentsInChildren<PanelBase>(true).ToList();

            foreach (var panel in _panelsList)
            {
                panel.Initialize();
                panel.gameObject.SetActive(false);
            }
        }

        private void InitializeEngineParts()
        {
            foreach (var enginePart in EngineController.engineParts)
            {
                enginePart.onMouseEnter += OnEnginePartMouseEnterHandler;
                enginePart.onMouseExit += OnEnginePartMouseExitHandler;
            }
        }

        private void InitializeButtons()
        {
            _exitButton.onClick.AddListener(Application.Quit);
        }

        private void OnEnginePartMouseEnterHandler(EnginePartBase enginePart)
        {
            _currentEnginePart = enginePart;

            _partInfoPanel.Open();

            var panelContent = new PanelContent
            {
                title = enginePart.enginePartData.partName,
                description = enginePart.enginePartData.partDescription
            };
            _partInfoPanel.UpdateView(panelContent);
        }

        private void OnEnginePartMouseExitHandler(EnginePartBase enginePart)
        {
            _currentEnginePart = null;
            _partInfoPanel.Close();
        }

        public void OpenPanel(PanelBase panel)
        {
            if (_currentPanel != null)
                _currentPanel.Close();

            if (panel == _currentPanel)
            {
                _currentPanel = null;
                return;
            }

            _currentPanel = panel;
            _currentPanel.Open();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.H))
            {
                if (_currentEnginePart == null)
                    return;

                _currentEnginePart.gameObject.SetActive(false);
            }
        }
    }
}