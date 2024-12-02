using UnityEngine;

public sealed partial class OnTriggerExitEvent : MonoBehaviourEvent<Collider>
{
	// Update
	private void OnTriggerExit(Collider other)
	{
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerExitEvent { }


#endif