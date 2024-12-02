using UnityEngine;

public sealed partial class OnParticleCollisionEvent : MonoBehaviourEvent<GameObject>
{
	// Update
	private void OnParticleCollision(GameObject other)
    {
		Raise(other);
	}
}


#if UNITY_EDITOR

public sealed partial class OnParticleCollisionEvent { }


#endif