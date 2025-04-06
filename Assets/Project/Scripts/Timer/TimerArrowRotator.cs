using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using UnityEngine;

namespace Project.Scripts.Timer
{
    public class TimerArrowRotator : EEBehaviourUpdate
    {
        [SerializeField] private RectTransform nodeArrow;
        [SerializeField] private bool clockwise = true;

        private TimerManager timerManager;
        private float currentRotation;
        private float rotationStep;
        private bool isStart;

        protected override void EEAwake()
        {
            base.EEAwake();
            timerManager = EESingleton.Get<TimerManager>();
            timerManager.StartTimerNotifier.Event += StartTimer;
            timerManager.EndTimerNotifier.Event += EndTimer;
        }

        protected override void EEDestroy()
        {
            base.EEDestroy();
            timerManager.StartTimerNotifier.Event -= StartTimer;
            timerManager.EndTimerNotifier.Event -= EndTimer;
        }

        private void EndTimer()
        {
            isStart = false;
        }

        private void StartTimer()
        {
            isStart = true;
        }

        protected override void EEUpdate()
        {
            base.EEUpdate();

            if (!isStart) return;
            rotationStep = 360f / timerManager.TimerData.FinalTime * Time.deltaTime;
            rotationStep = clockwise ? -rotationStep : rotationStep;

            currentRotation += rotationStep;

            if (currentRotation >= 360f) currentRotation -= 360f;
            if (currentRotation < 0f) currentRotation += 360f;

            nodeArrow.localRotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }
}
