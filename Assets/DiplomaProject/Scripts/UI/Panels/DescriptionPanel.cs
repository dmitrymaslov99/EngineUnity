using Dimploma.Datasets;
using TMPro;
using UnityEngine;

namespace Dimploma.UI
{
    public class DescriptionPanel : PanelBase
    {
        [Header("UI")]
        [SerializeField] private TMP_Text _descriptionText;

        [Header("Data")]
        [SerializeField] private DescriptionPanelData _data;

        public override void Initialize()
        {
            base.Initialize();
            InitializeUI();
        }

        private void InitializeUI()
        {
            _descriptionText.text = _data.description;
        }
    }
}