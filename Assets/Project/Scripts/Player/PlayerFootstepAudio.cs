using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerFootstepAudio : EEBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private AudioSource audioFootsteps;

        private bool isFirstStart = true;
        protected override void EEAwake()
        {
            base.EEAwake();
            playerMovement.MovingNotifier.Event += PlayFootsteps;
            playerMovement.StopMoveNotifier.Event += StopFootsteps;

        }
        protected override void EEDisable()
        {
            base.EEDisable();
            playerMovement.MovingNotifier.Event -= PlayFootsteps;
            playerMovement.StopMoveNotifier.Event -= StopFootsteps;
        }

        private void StopFootsteps()
        {
            audioFootsteps.Stop();
        }



        private void PlayFootsteps()
        {
            if (isFirstStart)
            {
                isFirstStart = false;
                return;
            }
            if (audioFootsteps.isPlaying) return;
            audioFootsteps.Play();
        }
    }
}
