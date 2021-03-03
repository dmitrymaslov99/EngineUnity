using UnityEngine;

namespace Dimploma.Datasets
{
    [CreateAssetMenu(fileName = "DescriptionPanelData", menuName = "Datasets/Description Panel Data")]
    public class DescriptionPanelData : ScriptableObject
    {
        [TextArea] public string description;
    }
}