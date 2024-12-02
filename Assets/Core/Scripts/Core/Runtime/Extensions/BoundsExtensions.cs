using UnityEngine;

public static class BoundsExtensions
{
	public static Vector3 GetRandomPoint(this Bounds a)
	{
		return BoundsUtils.GetRandomPoint(a.center, a.size);
	}

	public static Vector3 GetRandomPointInOuter(this Bounds a, Vector3 dismissBoxSize)
	{
		return BoundsUtils.GetRandomPointInOuter(a.center, a.size, dismissBoxSize);
	}

	public static Vector3 GetRandomPointAtSurface(this Bounds a)
	{
		return BoundsUtils.GetRandomPointAtSurface(a.center, a.size);
	}
}