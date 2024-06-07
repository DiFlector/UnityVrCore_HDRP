using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
        public float mouseSensitivity = 2.0f;
        public Transform cameraTransform;
    
        private CharacterController characterController;
        private float pitch = 0.0f;
    
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            // Mouse look
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

            // Movement
            float moveDirectionY = Input.GetAxis("Vertical");
            float moveDirectionX = Input.GetAxis("Horizontal");

            Vector3 moveDirection = new Vector3(moveDirectionX, 0, moveDirectionY);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            characterController.Move(moveDirection * Time.deltaTime);
        }
}
