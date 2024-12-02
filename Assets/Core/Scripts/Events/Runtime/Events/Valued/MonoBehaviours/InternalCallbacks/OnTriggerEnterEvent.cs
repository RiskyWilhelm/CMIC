using UnityEngine;

public sealed partial class OnTriggerEnterEvent : MonoBehaviourEvent<Collider>
{
	// Update
	private void OnTriggerEnter(Collider other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerEnterEvent { }


#endif