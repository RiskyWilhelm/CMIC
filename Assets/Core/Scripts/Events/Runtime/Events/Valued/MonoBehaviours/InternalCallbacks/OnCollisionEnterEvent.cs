using UnityEngine;

public sealed partial class OnCollisionEnterEvent : MonoBehaviourEvent<Collision>, ICollisionEnterListener
{
	// Update
	public void OnCollisionEnter(Collision collision)
	{
		Raise(collision);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionEnterEvent { }


#endif