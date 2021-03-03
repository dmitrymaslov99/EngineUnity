using TMPro;
using UnityEngine;

namespace Dimploma.UI
{
    public class PartInfoPanel : PanelBase
    {
        [Header("UI")]
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;

        public override void UpdateView(PanelContent panelContent)
        {
            titleText.text = panelContent.title;
            descriptionText.text = panelContent.description;
        }
    }
}