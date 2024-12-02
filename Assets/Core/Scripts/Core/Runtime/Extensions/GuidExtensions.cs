using System;

public static class GuidExtensions
{
	private static readonly byte[] byteBuffer = new byte[16];


	/// <summary> Decomposes a 16-byte <see cref="Guid"/> into two 8-byte <see cref="ulong"/>s. Recompose with <see cref="GuidUtils.Compose(ulong, ulong)"/> </summary>
	/// <param name="low"> The lower 8 bytes of the guid </param>
	/// <param name="high"> The upper 8 bytes of the guid </param>
	public static void Decompose(this Guid guid, out ulong low, out ulong high)
	{
		guid.TryWriteBytes(byteBuffer.AsSpan());

		low = BitConverter.ToUInt64(byteBuffer, 0);
		high = BitConverter.ToUInt64(byteBuffer, 8);
	}

	/*public static void Decompose(this Guid guid, out ulong low, out ulong high) // Old Version of Decompose
	{
		var bytes = guid.ToByteArray();
		low = BitConverter.ToUInt64(bytes, 0);
		high = BitConverter.ToUInt64(bytes, 8);
	}*/
}