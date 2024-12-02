using UnityEngine;

public sealed partial class OnCollisionEnter2DEvent : MonoBehaviourEvent<Collision2D>
{
	// Update
	private void OnCollisionEnter2D(Collision2D collision)
    {
		Raise(collision);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionEnter2DEvent { }


#endif