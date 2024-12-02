using UnityEngine;

public sealed partial class OnTriggerStay2DEvent : MonoBehaviourEvent<Collider2D>
{
	// Update
	private void OnTriggerStay2D(Collider2D other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerStay2DEvent { }


#endif