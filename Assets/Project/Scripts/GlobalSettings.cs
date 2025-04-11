using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.Scripts.Magazine;
using Project.Scripts.Player;

namespace Project.Scripts
{
    [ExecutionOrder(-9999)]
    public class GlobalSettings : EEBehaviour
    {
        private PlayerJumper playerJumper;
        private PlayerMovement playerMovement;
        private PlayerLooker playerLooker;
        private MagazineStateContoller magazineStateContoller;
        protected override void EEAwake()
        {
            base.EEAwake();
            playerMovement = EESingleton.Get<PlayerMovement>();
            playerLooker = EESingleton.Get<PlayerLooker>();
            playerJumper = EESingleton.Get<PlayerJumper>();
            magazineStateContoller = EESingleton.Get<MagazineStateContoller>();
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

        public void CanActiveMagazineMenu() => magazineStateContoller.CanActive();
        public void NotCanActiveMagazineMenu() => magazineStateContoller.NotCanActive();
    }
}
