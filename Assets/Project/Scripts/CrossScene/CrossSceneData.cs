using System.Collections.Generic;
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
            itemStacks.Add(itemStack);
        }

        [Button]
        public void ClearListItemStack()
        {
            itemStacks.Clear();
        }
    }
}
