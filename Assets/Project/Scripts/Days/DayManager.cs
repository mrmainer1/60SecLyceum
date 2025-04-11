using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Days
{
    public class DayManager : EEBehaviour
    {
        [SerializeField] private DayData dayData;

        private DayTextWriter dayTextWriter;
        private DayData nextDay;

        protected override void EEAwake()
        {
            base.EEAwake();
            dayTextWriter = EESingleton.Get<DayTextWriter>();
        }


        [Button]
        public void StartDay()
        {
            dayTextWriter.SetDayTextInMagazine(dayData);
            nextDay = dayData;
            EESingleton.Get<GlobalSettings>().CanActiveMagazineMenu();
        }

        public void FinishDay()
        {

        }

    }
}
