using UnityEngine;

public sealed partial class OnTriggerStayEvent : MonoBehaviourEvent<Collider>
{
	// Update
	private void OnTriggerStay(Collider other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerStayEvent { }


#endif