using UnityEngine;

public sealed partial class OnTriggerExit2DEvent : MonoBehaviourEvent<Collider2D>
{
	// Update
	private void OnTriggerExit2D(Collider2D other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnTriggerExit2DEvent { }


#endif