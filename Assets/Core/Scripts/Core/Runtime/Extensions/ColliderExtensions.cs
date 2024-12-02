using UnityEngine;

public static class ColliderExtensions
{
	/// <param name="declineColliderGameObject"> Checks if collider and rigidbody game object's are the same </param>
	public static bool TryGetBodyGameObject(this Collider a, out GameObject result, bool declineColliderGameObject = false)
	{
		result = null;

		var attachedBody = a.GetBody();
		if (!attachedBody)
			return false;

		var otherAttachedBodyGO = attachedBody.gameObject;
		if (declineColliderGameObject && (a.gameObject == otherAttachedBodyGO))
			return false;

		result = otherAttachedBodyGO;
		return true;
	}

	public static Component GetBody(this Collider a)
		=> (a.attachedRigidbody as Component) ?? (a.attachedArticulationBody as Component);

	public static Vector3 GetRandomPoint(this Collider a)
	{
        switch (a)
		{
			case BoxCollider:
			return (a as BoxCollider).GetRandomPoint();

			case SphereCollider:
			return (a as SphereCollider).GetRandomPoint();
		}

		Debug.LogErrorFormat("Type {0} is un-supported. BoxCollider and SphereCollider is supported only", a.GetType());
		return default;
	}

	public static Vector3 GetRandomPointAtSurface(this Collider a)
	{
		switch (a)
		{
			case BoxCollider:
			return (a as BoxCollider).GetRandomPointAtSurface();

			case SphereCollider:
			return (a as SphereCollider).GetRandomPointAtSurface();
		}

		Debug.LogErrorFormat("Type {0} is un-supported. BoxCollider and SphereCollider is supported only", a.GetType());
		return default;
	}
}