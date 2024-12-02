using System;

[Flags]
public enum JoystickAxisType
{
	None = 0,

	X = 1 << 0,

	Y = 1 << 1,

	All = ~(-1 << 2),
}