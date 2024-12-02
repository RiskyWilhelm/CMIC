using UnityEngine;

public sealed partial class OnTriggerEnter2DEvent : MonoBehaviourEvent<Collider2D>
{
	// Update
	private void OnTriggerEnter2D(Collider2D other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerEnter2DEvent { }


#endif