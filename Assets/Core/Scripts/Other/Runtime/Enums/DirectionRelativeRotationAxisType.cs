using System;

[Flags]
public enum DirectionRelativeRotationAxisType
{
	None = 0,

	X = 1 << 0,

	Y = 1 << 1,

	Z = 1 << 2,

	All = ~(-1 << 3),
}
