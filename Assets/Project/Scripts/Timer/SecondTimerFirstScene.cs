using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.EntenEller.Base.Scripts.UI.Menu;
using Project.Scripts.CCLib.Animation;
using Project.Scripts.FirstScene;
using UnityEngine;

namespace Project.Scripts.Timer
{
    public class SecondTimerFirstScene : EEBehaviour
    {
        [SerializeField] private int time;
        [SerializeField] private EEMenu menuSecondTimer;

        [SerializeField]private CCAnimatedSecondTimer animatedSecondTimer;

        protected override void EEAwake()
        {
            base.EEAwake();
            animatedSecondTimer.EndSecondTimerTimerNotifier.Event += OnTimerTimerEnd;

            EESingleton.Get<FirstSceneInitilization>().InitPlayer();
            animatedSecondTimer.StartTimer(time);
        }

        protected override void EEDestroy()
        {
            base.EEDestroy();
            animatedSecondTimer.EndSecondTimerTimerNotifier.Event -= OnTimerTimerEnd;
        }

        private void OnTimerTimerEnd()
        {
            menuSecondTimer.SetState(false);
            EESingleton.Get<GlobalSettings>().StartAnyMovePlayer();
        }
    }
}
