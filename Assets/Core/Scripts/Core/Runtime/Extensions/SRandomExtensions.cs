using UnityEngine;

public static class SRandomExtensions
{
	public static Vector3 NextVector3(this System.Random a, Vector3 minInclusive, Vector3 maxExclusive)
	{
		var x = a.NextFloat(minInclusive.x, maxExclusive.x);
		var y = a.NextFloat(minInclusive.y, maxExclusive.y);
		var z = a.NextFloat(minInclusive.z, maxExclusive.z);
		return new Vector3(x, y, z);
	}

	public static float NextFloat(this System.Random a, float minInclusiveValue, float maxExclusiveValue)
		=> (float)a.NextDouble(minInclusiveValue, maxExclusiveValue);

	public static double NextDouble(this System.Random a, double minInclusiveValue, double maxExclusiveValue)
	{
		return a.NextDouble() * (maxExclusiveValue - minInclusiveValue) + minInclusiveValue;
	}
}