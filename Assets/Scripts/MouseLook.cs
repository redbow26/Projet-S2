using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Mouse sensitivity (base 100f)
    public float mouseSensitivity = 100f;
    // Player object
    public Transform playerBody;
    // Base y rotation (base 0f)
    float yRotation = 0f;

    void Start()
    {
        // Lock the cursor on the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the input for the mouse X rotation multiply by the sensitivity and the time since the last update
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // Get the input for the mouse y rotation multiply by the sensitivity and the time since the last update
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        // Block the Y rotation to 90° up and down
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        // Apply the X rotation to the cameras
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        // Rotate the player on the X axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
