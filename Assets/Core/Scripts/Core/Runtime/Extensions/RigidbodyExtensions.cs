using UnityEngine;

public static class RigidbodyExtensions
{
	/// <summary> Transforms position from local space to world space. Takes position, rotation and scale into account </summary>
	public static Vector3 RigidbodyPoint(this Rigidbody a, Vector3 targetPos)
	{
		return VectorUtils.VectorPoint(a.position, a.rotation, a.transform.lossyScale, targetPos);
	}

	/// <summary> Transforms position from local space to world space. Takes position and rotation into account only </summary>
	public static Vector3 RigidbodyPointUnscaled(this Rigidbody a, Vector3 targetPos)
	{
		return VectorUtils.VectorPoint(a.position, a.rotation, Vector3.one, targetPos);
	}

	/// <summary> Transforms position from world space to local space. Takes position, rotation and scale into account </summary>
	public static Vector3 InverseRigidbodyPoint(this Rigidbody a, Vector3 targetPos)
	{
		return VectorUtils.InverseVectorPoint(a.position, a.rotation, a.transform.lossyScale, targetPos);
	}

	/// <summary> Transforms position from world space to local space. Takes position and rotation into account only </summary>
	public static Vector3 InverseRigidbodyPointUnscaled(this Rigidbody a, Vector3 targetPos)
	{
		return VectorUtils.InverseVectorPoint(a.position, a.rotation, Vector3.one, targetPos);
	}

	public static Vector3 LocalLinearVelocity(this Rigidbody a)
	{
		return a.transform.InverseTransformDirection(a.linearVelocity);
	}

	/// <summary> Checks if <b>exactly</b> moving </summary>
	public static bool IsMoving(this Rigidbody a)
	{
		return a.linearVelocity.sqrMagnitude != 0f;
	}

	/// <summary> Checks if <b>exactly</b> rotating </summary>
	public static bool IsRotating(this Rigidbody a)
	{
		return a.angularVelocity.sqrMagnitude != 0f;
	}

	/// <summary> Checks if moving more than a <b>threshold</b> </summary>
	/// <param name="allowedDifference"> Default value is <see cref="Vector3.kEpsilon"/> </param>
	public static bool IsMovingApproximately(this Rigidbody a, float allowedDifference = Vector3.kEpsilon)
	{
		return !VectorExtensions.Approximately(a.linearVelocity, Vector3.zero, allowedDifference);
	}

	/// <summary> Checks if rotating more than a <b>threshold</b> </summary>
	/// <param name="allowedDifference"> Default value is <see cref="Vector3.kEpsilon"/> </param>
	public static bool IsRotatingApproximately(this Rigidbody a, float allowedDifference = Vector3.kEpsilon)
	{
		return !VectorExtensions.Approximately(a.angularVelocity, Vector3.zero, allowedDifference);
	}

	/// <summary> Use when temporary limitation wanted </summary>
	/// <remarks> If you dont want velocity limit on specific axises, set them to zero </remarks>
	public static void LimitLinearVelocity(this Rigidbody a, Vector3 maxVelocity)
	{
		var updatedLinearVelocity = a.linearVelocity;

		if (maxVelocity.x > 0f)
			updatedLinearVelocity.x = Mathf.Clamp(updatedLinearVelocity.x, -maxVelocity.x, maxVelocity.x);

		if (maxVelocity.y > 0f)
			updatedLinearVelocity.y = Mathf.Clamp(updatedLinearVelocity.y, -maxVelocity.y, maxVelocity.y);

		if (maxVelocity.z > 0f)
			updatedLinearVelocity.z = Mathf.Clamp(updatedLinearVelocity.z, -maxVelocity.z, maxVelocity.z);

		a.linearVelocity = updatedLinearVelocity;
	}
}