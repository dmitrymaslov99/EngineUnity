using UnityEngine;

namespace Dimploma.Controllers
{
    public class SceneController : MonoBehaviour
    {
        public static EngineController EngineController { get; private set; }
        public static UIController UIController { get; private set; }

        private void Start()
        {
            EngineController = FindObjectOfType<EngineController>();
            EngineController.Initialize();

            UIController = FindObjectOfType<UIController>();
            UIController.Intialize();
        }
    }
}