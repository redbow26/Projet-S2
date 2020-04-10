using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    // Ajust the speed of the character (base 12f)
    public float speed = 12f;
    // Ajust the gravity (base -9.81f)
    public float gravity = -19.62f;
    // Ajust jump heigth
    public float jumpHeigth = 3f;

    public Transform groundCheck;
    // Radius of the ground Check
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Free fall Velocity vector
    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If we are grounded reset the free fall velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get unity horizontal input (1: right or -1: left)
        float x = Input.GetAxis("Horizontal");
        // Get unity vertical input (1: forward  or -1: back)
        float z = Input.GetAxis("Vertical");

        // Create new verctor 3D with the actual position and rotation of the object
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply move vector multiply by the speed to the character controller and the time since the last update
        controller.Move(move * speed * Time.deltaTime);
        
        // Jump check and apply to the velocity vector
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Jump = (jump heigth * -2 * g)**0.5
            velocity.y = Mathf.Sqrt(jumpHeigth * -2f * gravity);
        }

        // Delta y = (1/2)g * t^2
        velocity.y += gravity * Time.deltaTime;
        
        // Aplly the velocity to the character controller
        controller.Move(velocity * Time.deltaTime);
    }
}
