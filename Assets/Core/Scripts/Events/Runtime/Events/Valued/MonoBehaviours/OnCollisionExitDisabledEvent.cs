using UnityEngine;

public sealed partial class OnCollisionExitDisabledEvent : MonoBehaviourEvent<Collider, Collider>, ICollisionExitDisabledListener
{
	// Update
	public void OnCollisionExitDisabled(Collider thisCollider, Collider otherCollider)
	{
		Raise(thisCollider, otherCollider);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionExitEvent { }


#endif