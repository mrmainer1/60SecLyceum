using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Item;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.CrossScene
{
    [CreateAssetMenu(menuName = "60Sec/CrossSceneData", fileName = "CrossSceneData")]
    public class CrossSceneData : ScriptableObject
    {
        [SerializeField] private List<ItemStack> itemStacks;

        public List<ItemStack> GetItemStack()
        {
            return itemStacks;
        }

        public void AddItemStack(ItemStack itemStack)
        {
            foreach (var item in itemStacks.Where(item => item.Item.ID == itemStack.Item.ID))
            {
                item.Amount += itemStack.Amount;
                return;
            }

            itemStacks.Add(itemStack);
        }

        [Button]
        public void ClearListItemStack()
        {
            itemStacks.Clear();
        }
    }
}
