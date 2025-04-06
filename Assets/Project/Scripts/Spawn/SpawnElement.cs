using Project.EntenEller.Base.Scripts.Cache.Components.Master;

namespace Project.Scripts.Spawn
{
    public class SpawnElement : EEBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Active()
        {
            gameObject.SetActive(true);
        }
    }
}
