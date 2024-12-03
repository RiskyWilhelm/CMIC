using UnityEngine;

public sealed partial class Fragment : MonoBehaviour
{
    // Start


    // Update
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
