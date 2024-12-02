using System;
using UnityEngine;

public static class BoundsUtils
{
	private static readonly System.Random randomizer = new();


	/// <returns> A random point inside or on the surface of a box with size 1.0 </returns>
	public static Vector3 InsideUnitBox()
	{
		return GetRandomPoint(Vector3.zero, Vector3.one);
	}

	/// <returns> A random point on the surface of a box with size 1.0 </returns>
	public static Vector3 OnUnitBox()
	{
		return GetRandomPointAtSurface(Vector3.zero, Vector3.one);
	}

	public static Vector3 GetRandomPoint(Vector3 center, Vector3 size)
	{
		Vector3 extents = (size * 0.5f);
		Vector3 localPoint = new(
			randomizer.NextFloat(-extents.x, extents.x),
			randomizer.NextFloat(-extents.y, extents.y),
			randomizer.NextFloat(-extents.z, extents.z)
		);

		localPoint += center;
		return localPoint;
	}

	public static Vector3 GetRandomPointInOuter(Vector3 center, Vector3 size, Vector3 dismissBoxSize)
	{
		Vector3 outerBoxSize = (size - dismissBoxSize);

		var onUnitBoxUniformly = OnUnitBox();
		var onDismissedBox = Vector3.Scale(onUnitBoxUniformly, dismissBoxSize);
		var outerBox = new Vector3(
			MathF.Sqrt(randomizer.NextFloat(0f, 1f)) * outerBoxSize.x,
			MathF.Sqrt(randomizer.NextFloat(0f, 1f)) * outerBoxSize.y,
			MathF.Sqrt(randomizer.NextFloat(0f, 1f)) * outerBoxSize.z
		); ;

		Vector3 localPoint = onDismissedBox + Vector3.Scale(onUnitBoxUniformly, outerBox);
		localPoint += center;
		return localPoint;
	}

	public static Vector3 GetRandomPointAtSurface(Vector3 center, Vector3 size)
	{
		Vector3 extents = (size * 0.5f);
		Vector3 localPoint = default;
		var randomFaceDirection = randomizer.NextFloat(1, 7);

		switch (randomFaceDirection)
		{
			// Up
			case 1:
			localPoint = new(
				randomizer.NextFloat(-extents.x, extents.x),
				extents.y,
				randomizer.NextFloat(-extents.z, extents.z)
			);
			break;

			// Down
			case 2:
			localPoint = new(
				randomizer.NextFloat(-extents.x, extents.x),
				-extents.y,
				randomizer.NextFloat(-extents.z, extents.z)
			);
			break;

			// Right
			case 3:
			localPoint = new(
				extents.x,
				randomizer.NextFloat(-extents.y, extents.y),
				randomizer.NextFloat(-extents.z, extents.z)
			);
			break;

			// Left
			case 4:
			localPoint = new(
				-extents.x,
				randomizer.NextFloat(-extents.y, extents.y),
				randomizer.NextFloat(-extents.z, extents.z)
			);
			break;

			// Forward
			case 5:
			localPoint = new(
				randomizer.NextFloat(-extents.x, extents.x),
				randomizer.NextFloat(-extents.y, extents.y),
				extents.z
			);
			break;

			// Backward
			case 6:
			localPoint = new(
				randomizer.NextFloat(-extents.x, extents.x),
				randomizer.NextFloat(-extents.y, extents.y),
				-extents.z
			);
			break;
		}

		localPoint += center;
		return localPoint;
	}
}