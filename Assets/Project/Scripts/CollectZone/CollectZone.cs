using Project.EntenEller.Base.Scripts.Cache.Components.Master;

namespace Project.Scripts.CollectZone
{
    public class CollectZone : EEBehaviour
    {
        public void OnPlayerEnter(Inventory.Base.Inventory inventory)
        {
            inventory.AdderToCrossScene.AddAllItemToCrossScene(true);
        }
    }
}
