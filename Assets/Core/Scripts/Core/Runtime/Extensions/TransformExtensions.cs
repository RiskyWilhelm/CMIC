using System;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
	/// <summary> Transforms position from local space to world space. Takes position and rotation into account only </summary>
	public static Vector3 TransformPointUnscaled(this Transform a, Vector3 targetPos)
	{
		return VectorUtils.VectorPoint(a.position, a.rotation, Vector3.one, targetPos);
	}

	/// <summary> Transforms position from world space to local space. Takes position and rotation into account only </summary>
	public static Vector3 InverseTransformPointUnscaled(this Transform a, Vector3 targetPos)
	{
		return VectorUtils.InverseVectorPoint(a.position, a.rotation, Vector3.one, targetPos);
	}
	
	public static bool TryGetNearestTransform<TransformEnumeratorType>(this Transform relativeTo, TransformEnumeratorType transformEnumerator, out Transform nearestTransform, Predicate<Transform> predicateNearest = null)
		where TransformEnumeratorType : IEnumerator<Transform>
	{
		nearestTransform = default;

		var isFoundNearest = false;
		float nearestHorizontalDistance = float.MaxValue;
		float iteratedDistance;

		// Check sqr distances and select nearest
		foreach (var iteratedTransform in transformEnumerator)
		{
			iteratedDistance = (iteratedTransform.position - relativeTo.position).sqrMagnitude;

			if ((iteratedDistance < nearestHorizontalDistance) && (predicateNearest == null || predicateNearest.Invoke(iteratedTransform)))
			{
				nearestTransform = iteratedTransform;
				nearestHorizontalDistance = iteratedDistance;
				isFoundNearest = true;
			}
		}

		return isFoundNearest;
	}
}
