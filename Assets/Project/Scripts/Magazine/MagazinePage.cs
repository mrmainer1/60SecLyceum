using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;

namespace Project.Scripts.Magazine
{
    public class MagazinePage : EEBehaviour
    {
        private MagazineAllPageStateContoller magazineAllPageStateContoller;

        protected override void EEAwake()
        {
            base.EEAwake();
            magazineAllPageStateContoller = EESingleton.Get<MagazineAllPageStateContoller>();
        }

        public void Active()
        {
            gameObject.SetActive(true);
            magazineAllPageStateContoller.DisableOtherMenu(this);
        }

        public void Desable()
        {
            gameObject.SetActive(false);
        }
    }
}
