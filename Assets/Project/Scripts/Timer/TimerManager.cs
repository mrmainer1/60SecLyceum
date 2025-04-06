using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Timers;
using UnityEngine;

namespace Project.Scripts.Timer
{
    public class TimerManager : EEBehaviour
    {
        [SerializeField] private float time;

        public EETime.EETimerData TimerData = new EETime.EETimerData();
        public EENotifier EndTimerNotifier, StartTimerNotifier;
        protected override void EEAwake()
        {
            base.EEAwake();
            StartTimerNotifier.Notify();
            TimerData.FinalTime = time;
            TimerData.Action = EndTimer;

            EETime.StartTimer(TimerData);
        }

        private void EndTimer()
        {
            EndTimerNotifier.Notify();
        }
    }
}
