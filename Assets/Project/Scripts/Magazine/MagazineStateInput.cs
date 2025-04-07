using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using UnityEngine;

namespace Project.Scripts.Magazine
{
    public class MagazineStateInput : EEBehaviourUpdate
    {
        [SerializeField] private MagazineStateContoller magazineStateContoller;

        protected override void EEUpdate()
        {
            base.EEUpdate();
            if(!Input.GetKeyDown(KeyCode.J)) return;
            magazineStateContoller.SwitchState();
        }
    }
}
