using UnityEngine;

public sealed partial class OnTriggerExitDisabledEvent : MonoBehaviourEvent<Collider>, ITriggerExitDisabledListener
{
	// Update
	public void OnTriggerExitDisabled(Collider other)
	{
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerExitEvent { }


#endif