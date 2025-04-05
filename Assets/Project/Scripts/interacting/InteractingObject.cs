using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.Scripts.Interface;
using Project.Scripts.Inventory;
using Project.Scripts.Item;
using UnityEngine;

namespace Project.Scripts.interacting
{
    public class InteractingObject : EEBehaviourUpdate, IInteracting
    {
        [SerializeField] private ItemData itemData;
        [SerializeField] private int amount = 1;

        private InteractingHolderVisualizer interacteingHolderVisualizer;
        private InventoryPlayer inventoryPlayer;

        private EEGameObject eeGameObject;

        protected override void EEAwake()
        {
            base.EEAwake();
            interacteingHolderVisualizer = EESingleton.Get<InteractingHolderVisualizer>();
            inventoryPlayer = EESingleton.Get<InventoryPlayer>();
        }

        public void Interacte()
        {
            if (inventoryPlayer.inventory.Adder.TryAddItem(itemData, amount))
            {
                transform.parent.gameObject.SetActive(false);
                interacteingHolderVisualizer.SetStateButtonInteracteView(false);
            }

        }

        public void Hover()
        {
            interacteingHolderVisualizer.SetStateButtonInteracteView(true);
        }

        public void EndHover()
        {
            interacteingHolderVisualizer.SetStateButtonInteracteView(false);
        }
    }
}
