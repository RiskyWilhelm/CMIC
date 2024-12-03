using UnityEngine;
using UnityEngine.InputSystem;

public sealed partial class Player : StateMachineDrivenPlayerBase
{
    #region Player Settings

    [SerializeField]
    private Movable movementController;


    #endregion


    // Start


    // Update
    protected override void DoIdle()
    {
        if (movementController.SelfRigidbody.IsMovingApproximately())
            State = PlayerStateType.Walking;
    }

    protected override void DoWalking()
    {
        if (!movementController.SelfRigidbody.IsMovingApproximately())
            State = PlayerStateType.Idle;
    }

    public void OnInputMove_Event(InputAction.CallbackContext context)
    {
        var currentInput = context.ReadValue<Vector2>();
        movementController.NormalizedMovingDirection = new Vector3(currentInput.x, 0f, currentInput.y);
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class Player
{}

#endif
