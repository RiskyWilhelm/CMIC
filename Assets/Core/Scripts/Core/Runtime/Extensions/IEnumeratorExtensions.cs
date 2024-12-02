using System.Collections;

public static class IEnumeratorExtensions
{
	/// <summary> Allows you to iterate through an IEnumerator. This is useful for where you dont want garbage for IEnumerable when passing them to somewhere </summary>
	public static T GetEnumerator<T>(this T enumerator)
		where T : IEnumerator
	{
		return enumerator;
	}
}