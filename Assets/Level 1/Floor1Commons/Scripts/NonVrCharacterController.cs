using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVrCharacterController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float moveSpeed = 5.0f;
    public Transform playerCamera; // Reference to the camera transform

    private float verticalRotation;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // If the camera reference is not set in the Inspector, try to find it in the children
        if (playerCamera == null)
        {
            playerCamera = transform.Find("Camera");
        }
    }

    void Update()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned. Please assign a camera in the Inspector or make sure there is a child GameObject with 'Camera' in its name.");
            return;
        }

        // Mouse input for camera rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, horizontalRotation, 0);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Character movement
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalMove, 0, verticalMove));
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        characterController.Move(-transform.up * 1f);
    }
}
