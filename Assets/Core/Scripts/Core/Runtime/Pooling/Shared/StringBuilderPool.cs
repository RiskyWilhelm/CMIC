using System.Text;
using UnityEngine.Pool;

public static class StringBuilderPool
{
	private static readonly ObjectPool<StringBuilder> pool = new (
	   () => new StringBuilder(),
	   (sb) => sb.Clear());

	public static StringBuilder Get()
		=> pool.Get();

	public static PooledObject<StringBuilder> Get(out StringBuilder v)
		=> pool.Get(out v);

	public static void Release(StringBuilder element)
		=> pool.Release(element);

	public static void Clear()
		=> pool.Clear();
}