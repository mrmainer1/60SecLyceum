using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.EntenEller.Base.Scripts.Timers;
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

        [Space]
        [SerializeField] private GameObject visual;
        [SerializeField] private new GameObject collider;
        [SerializeField] private AudioSource audioSource;


        public EENotifier SelectedItemNotifier;
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
                collider.SetActive(false);
                visual.SetActive(false);
                interacteingHolderVisualizer.SetStateButtonInteracteView(false);
                SelectedItemNotifier.Notify();

                EETime.StartTimer(new EETime.EETimerData()
                {
                    FinalTime = audioSource.clip.length,
                    Action = () => transform.parent.gameObject.SetActive(false)
                });



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
