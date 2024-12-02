using System.ComponentModel;
using System.Globalization;
using System;

/// <summary> Dictionary key serialization support </summary>
public sealed class GuidSerializableTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return (sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string guidString)
			return new GuidSerializable(guidString);

		return base.ConvertFrom(context, culture, value);
	}
	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if ((destinationType == typeof(string)) && (value is GuidSerializable guid))
			return guid.ToString();

		return base.ConvertTo(context, culture, value, destinationType);
	}
}