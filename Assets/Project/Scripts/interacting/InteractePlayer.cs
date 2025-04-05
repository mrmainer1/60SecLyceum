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
        private IInteracting lastInteracting;

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
            var hasHit = Physics.Raycast(ray, out hit, raycastDistance);

            if (!hasHit)
            {
                ClearLastInteraction();
                return;
            }

            if (!hit.collider.TryGetComponent(out IInteracting interacting))
            {
                ClearLastInteraction();
                return;
            }

            HandleNewHover(interacting);

            if (!Input.GetKeyDown(KeyCode.E)) return;
            interacting.Interacte();
            lastInteracting = null;

        }

        private void ClearLastInteraction()
        {
            if (lastInteracting == null) return;
            lastInteracting.EndHover();
            lastInteracting = null;
        }

        private void HandleNewHover(IInteracting newInteracting)
        {
            if (lastInteracting == newInteracting) return;

            ClearLastInteraction();
            newInteracting.Hover();
            lastInteracting = newInteracting;
        }

        private void DebugVisual() =>  Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }
}
