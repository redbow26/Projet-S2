using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Camera")]
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header("Teleportation")]
    public float xOffset;
    public float yOffset;
    public float zOffset;
    private Grab grab;

    [Header("Interact")]
    [SerializeField]
    private List<GameObject> interactables;
    [SerializeField]
    private float threshold = 0.98f;
    public float useDistance = 2f;

    [Header("Input")]
    private InputManager inputActions;
    private Vector2 movementInput;
    private Vector2 lookInput;
    private Vector3 mousePosition;

    [Header("Data")]
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    Boolean Jump;
    Boolean Run;
    private int chamber = 1;

    [HideInInspector]
    public bool canMove = true;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        grab = GetComponent<Grab>();

        inputActions = new InputManager();
        inputActions.GamePlay.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.GamePlay.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.GamePlay.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        inputActions.GamePlay.Jump.performed += ctx => Jump = true;
        inputActions.GamePlay.Jump.canceled += ctx => Jump = false;
        inputActions.GamePlay.Run.performed += ctx => Run = true;
        inputActions.GamePlay.Run.canceled += ctx => Run = false;
        inputActions.GamePlay.Teleport.performed += _ => Teleportation();
        inputActions.GamePlay.Use.performed += _ => Use();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        lookSpeed /= 10;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Run;
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * movementInput.y : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * movementInput.x : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Jump && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -lookInput.y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, lookInput.x * lookSpeed, 0);
        }
    }

    private void Teleportation()
    {
        if (canMove)
        {
            if (chamber == 1)
            {
                characterController.enabled = false;
                characterController.transform.position += new Vector3(xOffset, yOffset, zOffset);
                characterController.enabled = true;
                chamber = 2;
            }
            else if (chamber == 2)
            {
                characterController.enabled = false;
                characterController.transform.position -= new Vector3(xOffset, yOffset, zOffset);
                characterController.enabled = true;
                chamber = 1;
            }

            grab.teleport();
        }
        
    }

    private void Use()
    {
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);

        var closest = 0f;
        GameObject _selection = null;

        for (int i = 0; i < interactables.Count; i++)
        {
            if (useDistance >= Vector3.Distance(this.transform.position, interactables[i].transform.position)) {
                var vector1 = ray.direction;
                var vector2 = interactables[i].transform.position - ray.origin;

                var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

                if (lookPercentage > threshold && lookPercentage > closest)
                {
                    closest = lookPercentage;
                    _selection = interactables[i];
                }
            }
        }

        if (_selection != null && _selection.GetComponent<Interactable>() != null)
        {
            _selection.GetComponent<Interactable>().Active();
        }
    }

}
