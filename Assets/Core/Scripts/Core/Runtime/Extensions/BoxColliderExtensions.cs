using UnityEngine;

public static class BoxColliderExtensions
{
	public static Vector3 GetRandomPoint(this BoxCollider a)
	{
		return a.transform.TransformPoint(BoundsUtils.GetRandomPoint(a.center, a.size));
	}

	public static Vector3 GetRandomPointInOuter(this BoxCollider a, Vector3 dismissBoxSize)
	{
		return a.transform.TransformPoint(BoundsUtils.GetRandomPointInOuter(a.center, a.size, dismissBoxSize));
	}

	public static Vector3 GetRandomPointAtSurface(this BoxCollider a)
	{
		return a.transform.TransformPoint(BoundsUtils.GetRandomPointAtSurface(a.center, a.size));
	}
}