using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class InputManager : MonoBehaviour
{
    // Script References
    [SerializeField] private PlayerLocomotionHandler playerLocomotionHandler;
    [SerializeField] private CameraManager cameraManager; // Reference to CameraManager


    [Header("Movement Inputs")]
    public float verticalInput;
    public float horizontalInput;
    public bool jumpInput;
    public Vector2 movementInput;
    public Vector3 moveDirection = Vector3.zero;
    public float moveAmount;

    //New Input
    //Refernce to Script created by Unity
    public PlayerInputActions playerMovement;
    //Input Action Component
    private InputAction move;
    private InputAction fire;

    [Header("Camera Inputs")]
    public float scrollInput; // Scroll input for camera zoom
    public Vector2 cameraInput; // Mouse input for the camera

    public bool isPauseKeyPressed = false;

    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        //Enables the new input
        OnEnable();
    }
    public void HandleAllInputs()
    {

        //HandleMovementInput();
        //HandleSprintingInput();
        //HandleJumpInput();
        //HandleCameraInput();
        //HandlePauseKeyInput();
    }

    private void HandleCameraInput()
    {
        // Get mouse input for the camera
        cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Get scroll input for camera zoom
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Send inputs to CameraManager
        cameraManager.zoomInput = scrollInput;
        cameraManager.cameraInput = cameraInput;
    }

    private void HandleMovementInput()
    {
        //moveDirection = playerMovement.ReadValue<Vector3>();

        //movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //horizontalInput = movementInput.x;
        //verticalInput = movementInput.y;
        //moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

    }

    private void HandlePauseKeyInput()
    {
        isPauseKeyPressed = Input.GetKeyDown(KeyCode.Escape); // Detect the escape key press
    }

    private void HandleSprintingInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) && moveAmount > 0.5f)
        {
            playerLocomotionHandler.isSprinting = true;
        }
        else
        {
            playerLocomotionHandler.isSprinting = false;
        }
    }

    private void HandleJumpInput()
    {
        jumpInput = Input.GetKeyDown(KeyCode.Space); // Detect jump input (spacebar)
        if (jumpInput)
        {
            playerLocomotionHandler.HandleJump(); // Trigger jump in locomotion handler
        }
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
    //Enables the new Input
    private void OnEnable()
    {
        move = playerMovement.Player.Move;
        move.Enable();
        fire = playerMovement.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    //Disables the new Input
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }



}

