using Newtonsoft.Json;
using System;
using System.ComponentModel;
using UnityEngine;

/// <summary> A Guid that can be serialized by Unity </summary>
/// <remarks> 128-bit Guid is stored as two 64-bit(8 byte) ulongs which named low and high </remarks>
[Serializable]
[TypeConverter(typeof(GuidSerializableTypeConverter))]
[JsonObject(MemberSerialization.OptIn)]
public struct GuidSerializable : IEquatable<GuidSerializable>
{
	[SerializeField]
	[HideInInspector]
	[JsonProperty]
	private ulong guidLow;

	[SerializeField]
	[HideInInspector]
	[JsonProperty]
	private ulong guidHigh;

	/// <summary> Represents <see cref="Guid.Empty"/>, a GUID where the value is all zero </summary>
	public static GuidSerializable Empty
		=> Guid.Empty;

	/// <summary> Reconstructs a <see cref="System.Guid"/> from two <see cref="ulong"/> values representing the low and high bytes </summary>
	public Guid Guid
		=> GuidUtils.Compose(guidLow, guidHigh);


	/// <summary> Constructs a <see cref="GuidSerializable"/> from two 64-bit(8 byte) <see cref="ulong"/> values </summary>
	/// <param name="guidLow"> The low 8 bytes of the <see cref="System.Guid"/> </param>
	/// <param name="guidHigh"> The high 8 bytes of the <see cref="System.Guid"/> </param>
	[JsonConstructor]
	public GuidSerializable(ulong guidLow, ulong guidHigh)
	{
		this.guidLow = guidLow;
		this.guidHigh = guidHigh;
	}

	/// <summary> Decomposes two values from <see cref="System.Guid"/> representing the low and high 64-bit(8 byte) <see cref="ulong"/> values and constructs a <see cref="GuidSerializable"/> </summary>
	public GuidSerializable(Guid guid)
	{
		guid.Decompose(out guidLow, out guidHigh);
	}

	public GuidSerializable(byte[] b) : this(new Guid(b))
	{ }

	public GuidSerializable(ReadOnlySpan<byte> b) : this(new Guid(b))
	{ }

	public GuidSerializable(string g) : this(new Guid(g))
	{ }

	public GuidSerializable(int a, short b, short c, byte[] d) : this(new Guid(a, b, c, d))
	{ }

	public GuidSerializable(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k) : this(new Guid(a, b, c, d, e, f, g, h, i, j, k))
	{ }

	public GuidSerializable(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k) : this(new Guid(a, b, c, d, e, f, g, h, i, j, k))
	{ }

	/// <summary> Uses <see cref="Guid.NewGuid"/> </summary>
	public static GuidSerializable NewGuid()
		=> new GuidSerializable(Guid.NewGuid());

	public override int GetHashCode()
		=> HashCode.Combine(guidLow, guidHigh);

	public override bool Equals(object obj)
	{
		if (obj is GuidSerializable serializableGuid)
			Equals(serializableGuid);

		return false;
	}

	/// <summary> Generates a string representation of the <see cref="System.Guid"/>. Same as <see cref="Guid.ToString()"/> </summary>
	public override string ToString()
		=> Guid.ToString();

	/// <summary> Generates a string representation of the <see cref="System.Guid"/>. Same as <see cref="Guid.ToString(string)"/> </summary>
	/// <param name="format"> A single format specifier that indicates how to format the value of the <see cref="Guid"/> </param>
	public string ToString(string format)
		=> Guid.ToString(format);

	/// /// <summary> Generates a string representation of the <see cref="System.Guid"/>. Same as <see cref="Guid.ToString(string, IFormatProvider)"/> </summary>
	/// <param name="format"> A single format specifier that indicates how to format the value of the <see cref="System.Guid"/> </param>
	/// <param name="provider"> An object that supplies culture-specific formatting information </param>
	public string ToString(string format, IFormatProvider provider)
		=> Guid.ToString(format, provider);

	public bool Equals(GuidSerializable other)
	{
		return guidLow == other.guidLow &&
			guidHigh == other.guidHigh;
	}

	public static bool operator ==(GuidSerializable lhs, GuidSerializable rhs)
		=> lhs.Equals(rhs);

	public static bool operator !=(GuidSerializable lhs, GuidSerializable rhs)
		=> !(lhs == rhs);

	public static implicit operator GuidSerializable(Guid guid)
		=> new GuidSerializable(guid);
}
