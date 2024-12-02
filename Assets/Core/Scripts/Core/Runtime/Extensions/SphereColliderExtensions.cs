using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class SphereColliderExtensions
{
	public static Vector3 GetRandomPoint(this SphereCollider a)
	{
		Vector3 localPoint = Random.insideUnitSphere * a.radius;
		localPoint += a.center;
		return a.transform.TransformPoint(localPoint);
	}

	public static Vector3 GetRandomPointInOuter(this SphereCollider a, float dismissRadius)
	{
		var onUnitSphereUniformly = Random.onUnitSphere;
		var onDismissedSphere = (onUnitSphereUniformly * dismissRadius);
		var outerRadius = MathF.Sqrt(Random.Range(0, 1f)) * (a.radius - dismissRadius);

		Vector3 localPoint = onDismissedSphere + (onUnitSphereUniformly * outerRadius);
		localPoint += a.center;
		return a.transform.TransformPoint(localPoint);
	}

	public static Vector3 GetRandomPointAtSurface(this SphereCollider a)
	{
		Vector3 localPoint = Random.onUnitSphere * a.radius;
		localPoint += a.center;
		return a.transform.TransformPoint(localPoint);
	}
}