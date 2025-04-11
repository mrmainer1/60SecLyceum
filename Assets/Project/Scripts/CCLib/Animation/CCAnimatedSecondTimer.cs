using System.Collections;
using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using TMPro;
using UnityEngine;

namespace Project.Scripts.CCLib.Animation
{
    public class CCAnimatedSecondTimer : EEBehaviourUpdate
    {
        [SerializeField] private TMP_Text timerText;

        public EENotifier EndSecondTimerTimerNotifier;

        private Coroutine timerCoroutine;

        public void StartTimer(float time)
        {
            if (timerCoroutine != null)
                StopCoroutine(timerCoroutine);

            timerCoroutine = StartCoroutine(TimerRoutine(time));
        }

        private IEnumerator TimerRoutine(float time)
        {
            var remainingTime = time;

            while (remainingTime > 0)
            {
                timerText.text = Mathf.CeilToInt(remainingTime).ToString();

                if (remainingTime != 0) yield return null;
                remainingTime -= Time.deltaTime;
            }

            EndSecondTimerTimerNotifier.Notify();
            timerText.text = "0";
        }
    }
}
