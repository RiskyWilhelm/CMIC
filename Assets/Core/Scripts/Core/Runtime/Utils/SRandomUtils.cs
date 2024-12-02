using UnityEngine;

public static class SRandomUtils
{
	private static readonly System.Random randomizer = new();

	public static Vector3 NextVector3()
	{
		var x = randomizer.NextFloat(0f, 1f);
		var y = randomizer.NextFloat(0f, 1f);
		var z = randomizer.NextFloat(0f, 1f);
		return new Vector3(x, y, z);
	}

	public static Vector3 NextVector3(Vector3 minInclusive, Vector3 maxExclusive)
		=> randomizer.NextVector3(minInclusive, maxExclusive);
}
