using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.Scripts.Player;

namespace Project.Scripts
{
    public class GlobalSettings : EEBehaviour
    {
        private PlayerJumper playerJumper;
        private PlayerMovement playerMovement;
        private PlayerLooker playerLooker;
        protected override void EEAwake()
        {
            base.EEAwake();
            playerMovement = EESingleton.Get<PlayerMovement>();
            playerLooker = EESingleton.Get<PlayerLooker>();
            playerJumper = EESingleton.Get<PlayerJumper>();

        }

        public void StopAnyMovePlayer()
        {
            playerMovement.StopMove();
            playerLooker.StopLook();
            playerJumper.StopJump();
        }

        public void StartAnyMovePlayer()
        {
            playerMovement.StartMove();
            playerLooker.StartLook();
            playerJumper.StartJump();
        }
    }
}
