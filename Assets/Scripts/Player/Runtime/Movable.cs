using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public sealed class Movable : MonoBehaviour
{
    #region Movable Settings

    [Header("Movable Settings")]
    [SerializeField]
    private Rigidbody selfRigidbody;

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private float forceScale;

    #endregion

    #region Movable Other

    private Vector2 moveAmount;

    #endregion


    // Start
    private void OnEnable()
    {
        InputUser.PerformPairingWithDevice(Keyboard.current, playerInput.user);
        playerInput.ActivateInput();
    }


    // Update
    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        DoMove_Fixed();
    }

    private void DoMove_Fixed()
    {
        var movementForce = new Vector3(moveAmount.x, 0f, moveAmount.y);
        selfRigidbody.AddForce(movementForce * forceScale);
    }


    // Dispose
    private void OnDisable()
    {
        playerInput.DeactivateInput();
    }
}
