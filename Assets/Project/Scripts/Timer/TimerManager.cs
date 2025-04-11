using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Timers;
using Project.Scripts.CCLib.Animation;
using UnityEngine;

namespace Project.Scripts.Timer
{
    public class TimerManager : EEBehaviour
    {
        [SerializeField] private float timeOnCollect;

        [SerializeField] private CCAnimatedSecondTimer animatedSecondTimer;

        public EETime.EETimerData TimerData = new EETime.EETimerData();
        public EENotifier EndTimerNotifier, StartTimerNotifier;

        protected override void EEAwake()
        {
            base.EEAwake();
            animatedSecondTimer.EndSecondTimerTimerNotifier.Event += StartTimer;
        }

        protected override void EEDestroy()
        {
            base.EEDestroy();
            animatedSecondTimer.EndSecondTimerTimerNotifier.Event -= StartTimer;
        }

        public void StartTimer()
        {
            StartTimerNotifier.Notify();
            TimerData.FinalTime = timeOnCollect;
            TimerData.Action = EndTimer;

            EETime.StartTimer(TimerData);
        }

        private void EndTimer()
        {
            EndTimerNotifier.Notify();
        }
    }
}
