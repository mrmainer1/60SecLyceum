using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;

namespace Project.Scripts.CollectZone
{
    public class CollectZone : EEBehaviour
    {
        public EENotifier DropItemNotifier;
        public void OnPlayerEnter(Inventory.Base.Inventory inventory)
        {
            DropItemNotifier.Notify();
            inventory.AdderToCrossScene.AddAllItemToCrossScene(true);
        }
    }
}
