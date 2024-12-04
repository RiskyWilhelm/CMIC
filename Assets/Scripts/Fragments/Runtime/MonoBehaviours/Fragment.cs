using UnityEngine;

public sealed partial class Fragment : MonoBehaviour
{
    #region Fragment Settings

    [SerializeField]
    private Rigidbody selfRigidbody;

    [Min(0)]
    [Tooltip("Optional. Set to zero if no velocity limitation wanted")]
    public Vector3 maxMovementVelocity;


    #endregion


    // Start
    private void FixedUpdate()
    {
        selfRigidbody.LimitLinearVelocity(maxMovementVelocity);
    }


    // Update
    public void OnGotInteracted_Event(Interactor interactor)
    {
        Debug.Log("Got Interacted");
        // TODO: Play Particle
        FragmentPoolSingleton.Instance.Release(this);
    }

    public void OnDisappearEnter_Event(Collision collision)
    {
        if (EventReflector.TryGetComponentInReflected<FloorTile>(collision.collider.gameObject, out _))
        {
            // TODO: Play Particle
            FragmentPoolSingleton.Instance.Release(this);
        }
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class Fragment
{}

#endif
