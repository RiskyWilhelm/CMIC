using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed partial class Player : StateMachineDrivenPlayerBase
{
    [Header("Player Settings")]
    #region Player Settings

    [SerializeField]
    private Movable selfController;

    [SerializeField]
    private Interactor selfInteractor;

    [SerializeField]
    private PlayerType _selfType;

    public PlayerType PlayerType
        => _selfType;


    #endregion


    // Start


    // Update
    protected override void DoIdle()
    {
        if (selfController.SelfRigidbody.IsMovingApproximately())
            State = PlayerStateType.Walking;
    }

    protected override void DoWalking()
    {
        if (!selfController.SelfRigidbody.IsMovingApproximately())
            State = PlayerStateType.Idle;
    }

    public void OnInputMove_Event(InputAction.CallbackContext context)
    {
        var currentInput = context.ReadValue<Vector2>();
        selfController.NormalizedMovingDirection = new Vector3(currentInput.x, 0f, currentInput.y);
    }

    public void OnInputInteract_Event(InputAction.CallbackContext context)
    {
        if (context.phase is InputActionPhase.Performed)
        {
            var isFoundNearestInteractable = selfInteractor.TrySelectNearestInteractable(out Interactable nearestInteractable);
            if (isFoundNearestInteractable)
                selfInteractor.TryInteractOnceWith(nearestInteractable);
        }
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class Player
{}

#endif
