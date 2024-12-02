using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public sealed class UseSameInputDevice : MonoBehaviour
{
    #region UseSameInputDevice Settings

    [Header("UseSameInputDevice Settings")]
    [SerializeField]
    private PlayerInput playerInput;


    #endregion


    // Start
    private void OnEnable()
    {
        playerInput.ActivateInput();
        InputUser.PerformPairingWithDevice(Keyboard.current, playerInput.user);
    }


    // Update


    // Dispose
    private void OnDisable()
    {
        playerInput.DeactivateInput();
    }
}
