using UnityEngine;

public sealed partial class OnCollisionExit2DEvent : MonoBehaviourEvent<Collision2D>
{
	// Update
	private void OnCollisionExit2D(Collision2D collision)
    {
		Raise(collision);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionExit2DEvent { }


#endif