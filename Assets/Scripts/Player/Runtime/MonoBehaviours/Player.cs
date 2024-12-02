using UnityEngine;
using UnityEngine.InputSystem;

public sealed partial class Player : MonoBehaviour
{
    #region Player Settings

    [SerializeField]
    private Movable movementController;


    #endregion


    // Start


    // Update
    public void OnInputMove(InputAction.CallbackContext context)
    {
        var currentInput = context.ReadValue<Vector2>();
        movementController.NormalizedMovingDirection = new Vector3(currentInput.x, 0f, currentInput.y);
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class Player : MonoBehaviour
{}

#endif
