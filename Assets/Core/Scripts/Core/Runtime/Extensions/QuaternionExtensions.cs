using System;
using UnityEngine;

[Flags]
public enum AcceptedRotationDirectionAxisType
{
	None = 0,

	X = 1 << 0,

	Y = 1 << 1,

	Z = 1 << 2,

	All = ~(-1 << 3),
}

public static class QuaternionExtensions
{
	/// <returns> Non-normalized local direction </returns>
	public static Vector3 Forward(this Quaternion a)
	{
		return a * Vector3.forward;
	}

	/// <inheritdoc cref="Forward(Quaternion)"/>
	public static Vector3 Back(this Quaternion a)
	{
		return a * Vector3.back;
	}

	/// <inheritdoc cref="Forward(Quaternion)"/>
	public static Vector3 Up(this Quaternion a)
	{
		return a * Vector3.up;
	}

	/// <inheritdoc cref="Forward(Quaternion)"/>
	public static Vector3 Down(this Quaternion a)
	{
		return a * Vector3.down;
	}

	/// <inheritdoc cref="Forward(Quaternion)"/>
	public static Vector3 Right(this Quaternion a)
	{
		return a * Vector3.right;
	}

	/// <inheritdoc cref="Forward(Quaternion)"/>
	public static Vector3 Left(this Quaternion a)
	{
		return a * Vector3.left;
	}

	/// <summary> Subtracts A using B’s local coords (a - b) </summary>
	public static Quaternion Subtract(this Quaternion a, Quaternion b)
	{
		return a * Quaternion.Inverse(b);
	}

	/// <param name="preventForwardInvert"> Sometimes the forward is inverted due to quaternions slerping to nearest behaviour. Prevents that and keeps the forward exactly as before </param>
	public static Quaternion EqualizeUpRotationWithDirection(this Quaternion a, Vector3 direction, bool preventForwardInvert = true, float powerDelta = 360f)
	{
		if (powerDelta == 0f)
			return a;

		var newForward = a.Forward();

		if (preventForwardInvert)
			newForward = Vector3.ProjectOnPlane(newForward, direction).normalized;

		var finalRotation = Quaternion.LookRotation(newForward, direction);
		return Quaternion.RotateTowards(a, finalRotation, powerDelta);
	}

	public static Quaternion RotateTowardsDirection(this Quaternion current, Vector3 direction, Vector3 upwards, AcceptedRotationDirectionAxisType acceptedRotationDirectionAxisType = AcceptedRotationDirectionAxisType.All, float powerDelta = 360f)
	{
		var newRotation = Quaternion.LookRotation(direction, upwards);

		// Allow only specific axis
		if (!acceptedRotationDirectionAxisType.HasFlag(AcceptedRotationDirectionAxisType.X))
			newRotation = Quaternion.FromToRotation(newRotation.Right(), current.Right()) * newRotation;

		if (!acceptedRotationDirectionAxisType.HasFlag(AcceptedRotationDirectionAxisType.Y))
			newRotation = Quaternion.FromToRotation(newRotation.Up(), current.Up()) * newRotation;

		if (!acceptedRotationDirectionAxisType.HasFlag(AcceptedRotationDirectionAxisType.Z))
			newRotation = Quaternion.FromToRotation(newRotation.Forward(), current.Forward()) * newRotation;

		return Quaternion.RotateTowards(current, newRotation, powerDelta);
	}

	public static Quaternion RotateTowardsDirection(this Quaternion current, Vector3 normalizedDirection, AcceptedRotationDirectionAxisType acceptedRotationDirectionAxisType = AcceptedRotationDirectionAxisType.All, float powerDelta = 360f)
		=> current.RotateTowardsDirection(normalizedDirection, Vector3.up, acceptedRotationDirectionAxisType, powerDelta);
}