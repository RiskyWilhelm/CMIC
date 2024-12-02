using UnityEngine;

public sealed partial class OnCollisionStay2DEvent : MonoBehaviourEvent<Collision2D>
{
	// Update
	private void OnCollisionStay2D(Collision2D collision)
    {
		Raise(collision);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionStay2DEvent { }


#endif