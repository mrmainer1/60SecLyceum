using UnityEngine;

namespace Project.Scripts.Days
{
    [CreateAssetMenu(menuName = "60Sec/EventData", fileName = "Event")]
    public class DayData : ScriptableObject
    {
        public int NumberDay;
        [TextArea] public string DescriptionOldDay;
        [TextArea] public string DescriptionEventDay;
    }
}
