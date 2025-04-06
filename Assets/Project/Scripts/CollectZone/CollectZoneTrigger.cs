using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using Project.EntenEller.Base.Scripts.Advanced.Tags;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.Scripts.Inventory;
using UnityEngine;

namespace Project.Scripts.CollectZone
{
    public class CollectZoneTrigger : EEBehaviour
    {
        [SerializeField] private CollectZone collectZone;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<EETagHolder>().FirstTag != "player-body") return;
            var inventory = EETagUtils.FindEETagInChildren(other.GetEEGameObject(), "inventory-player").GetSelf<InventoryPlayer>();

            collectZone.OnPlayerEnter(inventory.inventory);
        }
    }
}
