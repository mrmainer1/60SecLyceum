using UnityEngine;

namespace Project.Scripts.Item
{
    [CreateAssetMenu(menuName = "ItemData", fileName = "Item")]
    public class ItemData : ScriptableObject
    {
        public string ID;
        public string Name;
        public Sprite Icon;
        public int SizeY = 1;
    }
}
