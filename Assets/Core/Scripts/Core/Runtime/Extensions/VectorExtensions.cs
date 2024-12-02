using System.Collections.Generic;
using System;
using UnityEngine;

public static class VectorExtensions
{
	public enum Direction
	{
		None,

		// 2D
		Top,
		TopRight,
		Right,
		BottomRight,
		Bottom,
		BottomLeft,
		Left,
		TopLeft,
		Middle,
	}

	public static Vector2 Abs(this Vector2 value)
	{
		value.x = Math.Abs(value.x);
		value.y = Math.Abs(value.y);
		return value;
	}

	public static Vector2Int Abs(this Vector2Int value)
	{
		value.x = Math.Abs(value.x);
		value.y = Math.Abs(value.y);
		return value;
	}

	public static Vector3 Abs(this Vector3 value)
	{
		value.x = Math.Abs(value.x);
		value.y = Math.Abs(value.y);
		value.z = Math.Abs(value.z);
		return value;
	}

	public static Vector3Int Abs(this Vector3Int value)
	{
		value.x = Math.Abs(value.x);
		value.y = Math.Abs(value.y);
		value.z = Math.Abs(value.z);
		return value;
	}

	public static Vector4 Abs(this Vector4 value)
	{
		value.x = Math.Abs(value.x);
		value.y = Math.Abs(value.y);
		value.z = Math.Abs(value.z);
		value.w = Math.Abs(value.w);
		return value;
	}

	public static Vector2 Invert(this Vector2 value)
	{
		return value * -1;
	}

	public static Vector2Int Invert(this Vector2Int value)
	{
		return value * -1;
	}

	public static Vector3 Invert(this Vector3 value)
	{
		return value * -1;
	}

	public static Vector3Int Invert(this Vector3Int value)
	{
		return value * -1;
	}

	public static Vector4 Invert(this Vector4 value)
	{
		return value * -1;
	}

	/// <summary> Checks if A approximately equals with B or A and B distance are within allowed difference - with absolute value </summary>
	/// <param name="allowedDifference"> Default value is <see cref="Vector2.kEpsilon"/> </param>
	public static bool Approximately(this Vector2 a, Vector2 b, float allowedDifference = Vector2.kEpsilon)
	{
		return (a - b).sqrMagnitude <= allowedDifference;
	}

	/// <param name="allowedDifference"> Default value is 1 </param>
	/// <inheritdoc cref="Approximately(Vector2, Vector2, float)"/>
	public static bool Approximately(this Vector2Int a, Vector2Int b, int allowedDifference = 1)
	{
		return (a - b).sqrMagnitude <= allowedDifference;
	}

	/// <param name="allowedDifference"> Default value is <see cref="Vector3.kEpsilon"/> </param>
	/// <inheritdoc cref="Approximately(Vector2, Vector2, float)"/>
	public static bool Approximately(this Vector3 a, Vector3 b, float allowedDifference = Vector3.kEpsilon)
	{
		return (a - b).sqrMagnitude <= allowedDifference;
	}

	/// <param name="allowedDifference"> Default value is 1 </param>
	/// <inheritdoc cref="Approximately(Vector2, Vector2, float)"/>
	public static bool Approximately(this Vector3Int a, Vector3Int b, int allowedDifference = 1)
	{
		return (a - b).sqrMagnitude <= allowedDifference;
	}

	/// <param name="allowedDifference"> Default value is <see cref="Vector4.kEpsilon"/> </param>
	/// <inheritdoc cref="Approximately(Vector2, Vector2, float)"/>
	public static bool Approximately(this Vector4 a, Vector4 b, float allowedDifference = Vector4.kEpsilon)
	{
		return (a - b).sqrMagnitude <= allowedDifference;
	}

	/// <summary> Checks if A and B distance approximately lesser than percentage of A - with percentage i.e. between 0 and 1 </summary>
	/// <returns> true if close eachother within a percentage of first vector </returns>
	public static bool ApproximatelyOfSelf(this Vector2 a, Vector2 b, float percentage)
	{
		return (a - b).sqrMagnitude <= (percentage * a).sqrMagnitude;
	}

	/// <inheritdoc cref="ApproximatelyOfSelf(Vector2, Vector2, float)"/>
	public static bool ApproximatelyOfSelf(this Vector2Int a, Vector2Int b, float percentage)
	{
		return (a - b).sqrMagnitude <= (percentage * (Vector2)a).sqrMagnitude;
	}

	/// <inheritdoc cref="ApproximatelyOfSelf(Vector2, Vector2, float)"/>
	public static bool ApproximatelyOfSelf(this Vector3 a, Vector3 b, float percentage)
	{
		return (a - b).sqrMagnitude <= (percentage * a).sqrMagnitude;
	}

	/// <inheritdoc cref="ApproximatelyOfSelf(Vector2, Vector2, float)"/>
	public static bool ApproximatelyOfSelf(this Vector3Int a, Vector3Int b, float percentage)
	{
		return (a - b).sqrMagnitude <= (percentage * (Vector3)a).sqrMagnitude;
	}

	/// <inheritdoc cref="ApproximatelyOfSelf(Vector2, Vector2, float)"/>
	public static bool ApproximatelyOfSelf(this Vector4 a, Vector4 b, float percentage)
	{
		return (a - b).sqrMagnitude <= (percentage * a).sqrMagnitude;
	}

	/// <returns> Angle in radians in PI (-180~180 Degrees) </returns>
	public static float ToRadianAngle(this Vector2 a)
		=> MathF.Atan2(a.y, a.x);

	/// <returns> Angle in degrees in PI (-180~180) </returns>
	public static float ToDegreeAngle(this Vector2 a)
		=> MathF.Atan2(a.y, a.x) * Mathf.Rad2Deg;

	/// <returns> Angle in radians in 2PI (0~360 Degrees) </returns>
	public static float ToRadianAngle_360(this Vector2 a)
	{
		var radian = MathF.Atan2(a.y, a.x);

		// Same as adding 360 degree to a angle in degrees
		if (radian < 0f)
			radian += (Mathf.PI * 2);

		return radian;
	}

	/// <returns> Angle in degrees in 2PI (0~360) </returns>
	public static float ToDegreeAngle_360(this Vector2 a)
		=> ToRadianAngle_360(a) * Mathf.Rad2Deg;

	/// <returns> Non-normalized rotated original vector </returns>
	public static Vector2 RotateByRadianAngle(this Vector2 a, float rotateAngleInRadians)
	{
		return new Vector2(
			a.x * MathF.Cos(rotateAngleInRadians) - a.y * MathF.Sin(rotateAngleInRadians),
			a.x * MathF.Sin(rotateAngleInRadians) + a.y * MathF.Cos(rotateAngleInRadians)
		);
	}

	/// <inheritdoc cref="RotateByRadianAngle(Vector2, float)"/>
	public static Vector2 RotateByDegreeAngle(this Vector2 a, float rotateAngleInDegrees)
		=> RotateByRadianAngle(a, rotateAngleInDegrees * Mathf.Deg2Rad);

	/// <inheritdoc cref="RotateByRadianAngle(Vector2, float)"/>
	public static Vector3 RotateByDegreeAngle(this Vector3 a, float rotateAngleInDegrees, Vector3 axisToRotateAround)
		=> Quaternion.AngleAxis(rotateAngleInDegrees, axisToRotateAround) * a;

	/// <inheritdoc cref="RotateByRadianAngle(Vector2, float)"/>
	public static Vector3 RotateByRadianAngle(this Vector3 a, float rotateAngleInRadians, Vector3 axisToRotateAround)
		=> RotateByDegreeAngle(a, rotateAngleInRadians * Mathf.Rad2Deg, axisToRotateAround);

	public static bool TryGetNearestVector<VectorEnumeratorType>(this Vector4 relativeTo, VectorEnumeratorType vectorCollection, out Vector4 nearestVector, Predicate<Vector4> predicateNearest = null)
		where VectorEnumeratorType : IEnumerator<Vector4>
	{
		nearestVector = default;

		var isFoundNearest = false;
		float nearestHorizontalDistance = float.MaxValue;
		float iteratedDistance;

		// Check sqr distances and select nearest
		foreach (var iteratedVector in vectorCollection)
		{
			iteratedDistance = (iteratedVector - relativeTo).sqrMagnitude;

			if ((iteratedDistance < nearestHorizontalDistance) && (predicateNearest == null || predicateNearest.Invoke(iteratedVector)))
			{
				nearestVector = iteratedVector;
				nearestHorizontalDistance = iteratedDistance;
				isFoundNearest = true;
			}
		}

		return isFoundNearest;
	}

	public static bool TryGetNearestVector<VectorEnumeratorType>(this Vector2 relativeTo, VectorEnumeratorType vectorCollection, out Vector2 nearestVector, Predicate<Vector2> predicateNearest = null)
		where VectorEnumeratorType : IEnumerator<Vector2>
	{
		nearestVector = default;

		var isFoundNearest = false;
		float nearestHorizontalDistance = float.MaxValue;
		float iteratedDistance;

		// Check sqr distances and select nearest
		foreach (var iteratedVector in vectorCollection)
		{
			iteratedDistance = (iteratedVector - relativeTo).sqrMagnitude;

			if ((iteratedDistance < nearestHorizontalDistance) && (predicateNearest == null || predicateNearest.Invoke(iteratedVector)))
			{
				nearestVector = iteratedVector;
				nearestHorizontalDistance = iteratedDistance;
				isFoundNearest = true;
			}
		}

		return isFoundNearest;
	}

	public static bool TryGetNearestVector<VectorEnumeratorType>(this Vector3 relativeTo, VectorEnumeratorType vectorCollection, out Vector3 nearestVector, Predicate<Vector3> predicateNearest = null)
		where VectorEnumeratorType : IEnumerator<Vector3>
	{
		nearestVector = default;

		var isFoundNearest = false;
		float nearestHorizontalDistance = float.MaxValue;
		float iteratedDistance;

		// Check sqr distances and select nearest
		foreach (var iteratedVector in vectorCollection)
		{
			iteratedDistance = (iteratedVector - relativeTo).sqrMagnitude;

			if ((iteratedDistance < nearestHorizontalDistance) && (predicateNearest == null || predicateNearest.Invoke(iteratedVector)))
			{
				nearestVector = iteratedVector;
				nearestHorizontalDistance = iteratedDistance;
				isFoundNearest = true;
			}
		}

		return isFoundNearest;
	}

	public static Vector2 GetWorldDirectionTo(this Vector2 a, Vector2 b)
	{
		return (b - a).normalized;
	}

	public static Vector3 GetWorldDirectionTo(this Vector3 a, Vector3 b)
	{
		return (b - a).normalized;
	}

	public static Vector4 GetWorldDirectionTo(this Vector4 a, Vector4 b)
	{
		return (b - a).normalized;
	}

	public static Vector2 GetWorldDirectionWithMagnitudeTo(this Vector2 a, Vector2 b)
	{
		return (b - a);
	}

	public static Vector3 GetWorldDirectionWithMagnitudeTo(this Vector3 a, Vector3 b)
	{
		return (b - a);
	}

	public static Vector4 GetWorldDirectionWithMagnitudeTo(this Vector4 a, Vector4 b)
	{
		return (b - a);
	}

	public static Vector2 GetDifferenceTo(this Vector2 a, Vector2 b)
	{
		return (b - a);
	}

	public static Vector3 GetDifferenceTo(this Vector3 a, Vector3 b)
	{
		return (b - a);
	}

	public static Vector4 GetDifferenceTo(this Vector4 a, Vector4 b)
	{
		return (b - a);
	}

	public static bool IsNearToApproximately(this Vector3 a, Vector3 b, float exceedDistance)
	{
		return (b - a).sqrMagnitude <= (exceedDistance * exceedDistance);
	}

	public static bool IsNormalized(this Vector2 a)
	{
		return Mathf.Approximately(a.sqrMagnitude, 1.0f);
	}

	public static bool IsNormalized(this Vector3 a)
	{
		return Mathf.Approximately(a.sqrMagnitude, 1.0f);
	}

	public static bool IsNormalized(this Vector4 a)
	{
		return Mathf.Approximately(a.sqrMagnitude, 1.0f);
	}

	public static bool IsNormalizedOrZero(this Vector2 a)
	{
		return (a == Vector2.zero) || IsNormalized(a);
	}

	public static bool IsNormalizedOrZero(this Vector3 a)
	{
		return (a == Vector3.zero) || IsNormalized(a);
	}

	public static bool IsNormalizedOrZero(this Vector4 a)
	{
		return (a == Vector4.zero) || IsNormalized(a);
	}

	public static Direction GetDirection2D(Vector2 checkDir, Vector2 upwards, bool flipRightwards = false)
	{
		checkDir.Normalize();
		upwards.Normalize();
		var rightwards = upwards.RotateByDegreeAngle(-90f * Math.Sign(flipRightwards ? -1 : 1));

		float angle = MathF.Acos(Vector2.Dot(rightwards, checkDir)) * Mathf.Rad2Deg;

		// Keep rightwards by flipping it
		if (Vector2.Dot(upwards, checkDir) < 0)
			angle = -angle;

		// Keep angle between 0 and 360 (2PI)
		angle = (angle + 360) % 360;

		if (angle <= 22.5f || angle > 337.5f)
		{
			return Direction.Right;
		}
		else if (angle > 22.5f && angle <= 67.5f)
		{
			return Direction.TopRight;
		}
		else if (angle > 67.5f && angle <= 112.5f)
		{
			return Direction.Top;
		}
		else if (angle > 112.5f && angle <= 157.5f)
		{
			return Direction.TopLeft;
		}
		else if (angle > 157.5f && angle <= 202.5f)
		{
			return Direction.Left;
		}
		else if (angle > 202.5f && angle <= 247.5f)
		{
			return Direction.BottomLeft;
		}
		else if (angle > 247.5f && angle <= 292.5f)
		{
			return Direction.Bottom;
		}
		else if (angle > 292.5f && angle <= 337.5f)
		{
			return Direction.BottomRight;
		}

		return Direction.None;
	}
}