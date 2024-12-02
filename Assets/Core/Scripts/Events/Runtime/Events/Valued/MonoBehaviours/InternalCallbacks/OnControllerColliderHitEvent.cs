using UnityEngine;

public sealed partial class OnControllerColliderHitEvent : MonoBehaviourEvent<ControllerColliderHit>
{
	// Update
	private void OnControllerColliderHit(ControllerColliderHit hit)
    {
		Raise(hit);
	}
}


#if UNITY_EDITOR

public sealed partial class OnControllerColliderHitEvent { }


#endif