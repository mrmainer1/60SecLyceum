using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using Project.EntenEller.Base.Scripts.UI.Menu;
using UnityEngine;

namespace Project.Scripts.Magazine
{
    public class MagazineStateContoller : EEBehaviour
    {
        [SerializeField] private EEMenu menu;
        [SerializeField] private MagazineAllPageStateContoller magazineAllPageStateContoller;

        private GlobalSettings globalSettings;

        protected override void EEAwake()
        {
            base.EEAwake();
            globalSettings = EESingleton.Get<GlobalSettings>();
        }

        public void SwitchState()
        {
            if (menu.IsActive) Disable();
            else Active();
        }

        public void Active()
        {
            menu.SetState(true);
            globalSettings.StopAnyMovePlayer();
            magazineAllPageStateContoller.ActiveLastPage();

        }

        public void Disable()
        {
            menu.SetState(false);
            globalSettings.StartAnyMovePlayer();
        }
    }
}
