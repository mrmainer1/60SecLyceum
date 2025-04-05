using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.UI.Menu;
using UnityEngine;

namespace Project.Scripts.interacting
{
    public class InteractingHolderVisualizer : EEBehaviour
    {
        [SerializeField] private EEMenu hoverMenu;

        public void SetStateButtonInteracteView(bool isOn) => hoverMenu.SetState(isOn);
    }
}
