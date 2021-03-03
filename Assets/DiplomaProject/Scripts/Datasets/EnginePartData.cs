using UnityEngine;

namespace Dimploma.Datasets
{
    [CreateAssetMenu(fileName = "EnginePartData", menuName = "Datasets/Engine Part Data")]
    public class EnginePartData : ScriptableObject
    {
        public int index;
        [TextArea(1, 2)] public string partName;
        [TextArea(3, 5)] public string partDescription;
    }
}