using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Advanced.Cameras;
using Project.Scripts.Interface;
using UnityEngine;

namespace Project.Scripts.interacting
{
    public class InteractePlayer : EEBehaviourUpdate
    {
        [SerializeField] private float raycastDistance = 100f;

        private Camera mainCamera;
        private Ray ray;
        private RaycastHit hit;

        protected override void EEAwake()
        {
            base.EEAwake();
            mainCamera = EECameraUtils.MainCamera;
        }

        protected override void EEUpdate()
        {
            base.EEUpdate();
            CastRayFromCenter();
            DebugVisual();
        }

        private void CastRayFromCenter()
        {
            ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (!Physics.Raycast(ray, out hit, raycastDistance)) return;
            if(!hit.collider.TryGetComponent(out IInteracting interacting)) return;
            interacting.Hover();
        }

        private void DebugVisual() =>  Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }
}
