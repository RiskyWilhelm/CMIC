using System.Collections.Generic;
using UnityEngine;

public sealed partial class OnCollisionExitEvent : MonoBehaviourEvent<Collision>, ICollisionExitListener
{
	// Update
	public void OnCollisionExit(Collision collision)
    {
        Raise(collision);
    }

	public void OnCollisionExitDisabled(Collider thisCollider, Collider otherCollider)
	{ }
}


#if UNITY_EDITOR

public sealed partial class OnCollisionExitEvent { }


#endif