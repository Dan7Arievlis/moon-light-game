using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake() 
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();

        playerInputActions.Player.Jump.performed += DoJump;
        playerInputActions.Player.Jump.canceled += CutJump;
        playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!");
    }

    private void FixedUpdate()
    {
        Debug.Log("Movement values: " + movement.ReadValue<Vector2>());
    }

    private void CutJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Cut Jump!");
    }
}
