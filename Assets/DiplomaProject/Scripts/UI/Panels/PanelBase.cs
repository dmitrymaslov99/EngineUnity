using UnityEngine;

namespace Dimploma.UI
{
    public class PanelBase : MonoBehaviour
    {
        public virtual void Initialize() { }

        public virtual void UpdateView(PanelContent panelContent) { }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}