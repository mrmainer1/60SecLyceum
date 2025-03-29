using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerLooker : EEBehaviourUpdate
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float mouseSensitivity = 1f;

        private float xRotation;
        private bool unlockPressed, lockPressed;

        protected override void EEAwake()
        {
            base.EEAwake();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void EEUpdate()
        {
            base.EEUpdate();

            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            unlockPressed = Input.GetKeyDown(KeyCode.Escape);
            lockPressed = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);

            if (unlockPressed)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (lockPressed)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (Cursor.lockState != CursorLockMode.Locked) return;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerTransform.Rotate(Vector3.up * mouseX);
        }

    }
}
