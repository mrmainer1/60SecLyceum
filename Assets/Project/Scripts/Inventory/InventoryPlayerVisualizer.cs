using System.Collections.Generic;
using System.Linq;
using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.Scripts.Item;
using Sirenix.Utilities;
using UnityEngine;

namespace Project.Scripts.Inventory
{
    public class InventoryPlayerVisualizer : EEBehaviour
    {
        [SerializeField] private List<Cell.CellInventory> cells;

        private Base.Inventory inventory;

        protected override void EEAwake()
        {
            base.EEAwake();
            inventory = EESingleton.Get<InventoryPlayer>().inventory;

            inventory.UpdateAmountItemNotifier.Event += UpdateItemView;
            inventory.AddNewItemNotifier.Event += UpdateItemView;
            inventory.RemoveAllItemNotifier.Event += RemoveAllItemView;
        }

        protected override void EEDestroy()
        {
            base.EEDestroy();
            inventory.AddNewItemNotifier.Event -= UpdateItemView;
            inventory.UpdateAmountItemNotifier.Event -= UpdateItemView;
            inventory.RemoveAllItemNotifier.Event -= RemoveAllItemView;
        }

        private void RemoveAllItemView()
        {
            foreach (var cell in cells)
            {
                cell.Disable();
            }
        }

        private void UpdateItemView()
        {
            var index = 0;
            foreach (var itemStack in inventory.Items)
            {
                var item = itemStack.Item;
                var amount = itemStack.Amount;

                for (var j = 0; j < amount; j++)
                {
                    cells[index].Active(item);
                    index++;
                }
            }
        }
    }
}
