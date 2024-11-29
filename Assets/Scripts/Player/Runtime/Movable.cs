using System;
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

    [SerializeField]
    private Vector3 maxVelocity;

    #endregion

    #region Movable Other

    private Vector2 moveAmount;

    #endregion


    // Start
    private void OnEnable()
    {
        playerInput.ActivateInput();
        InputUser.PerformPairingWithDevice(Keyboard.current, playerInput.user);
    }


    // Update
    private void FixedUpdate()
    {
        DoMove_Fixed();
        LimitVelocity();
    }

    public void OnInputMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    private void DoMove_Fixed()
    {
        var movementForce = new Vector3(moveAmount.x, 0f, moveAmount.y);
        selfRigidbody.AddForce(movementForce * forceScale);
    }

    private void LimitVelocity()
    {
        var newVelocity = selfRigidbody.linearVelocity;

        if ((maxVelocity.x > 0f) && (Math.Abs(newVelocity.x) > maxVelocity.x))
            newVelocity.x = maxVelocity.x * Math.Sign(newVelocity.x);

        if ((maxVelocity.y > 0f) && (Math.Abs(newVelocity.y) > maxVelocity.y))
            newVelocity.y = maxVelocity.y * Math.Sign(newVelocity.y);

        if ((maxVelocity.z > 0f) && (Math.Abs(newVelocity.z) > maxVelocity.z))
            newVelocity.z = maxVelocity.z * Math.Sign(newVelocity.z);

        selfRigidbody.linearVelocity = newVelocity;
    }


    // Dispose
    private void OnDisable()
    {
        playerInput.DeactivateInput();
    }
}
