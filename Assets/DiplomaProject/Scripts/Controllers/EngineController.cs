using Dimploma.EngineParts;
using System.Linq;
using UnityEngine;

namespace Dimploma.Controllers
{
    public class EngineController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _engineRoot;

        [HideInInspector] public EnginePartBase[] engineParts;

        public void Initialize()
        {
            InitializeEngineParts();
        }

        private void InitializeEngineParts()
        {
            engineParts = _engineRoot.GetComponentsInChildren<EnginePartBase>(true);

            foreach (var enginePart in engineParts)
            {
                enginePart.Initialize();
            }

            engineParts = engineParts.OrderBy(eP => eP.enginePartData.index).ToArray();
        }
    }
}