using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Advanced.Notifiers;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerMovement : EEBehaviourUpdate
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private float speed = 12f;

        public EENotifier MovingNotifier, StopMoveNotifier;

        private bool canMove = true;
        private Vector3 lastPosition;

        protected override void EEUpdate()
        {
            base.EEUpdate();
            if(!canMove) return;
            Move();
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if(lastPosition != transform.position) MovingNotifier.Notify();
            else StopMoveNotifier.Notify();
            lastPosition = transform.position;
        }

        public void StopMove() => canMove = false;
        public void StartMove() => canMove = true;
    }
}
