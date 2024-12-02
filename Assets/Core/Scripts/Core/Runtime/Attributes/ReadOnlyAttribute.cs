using UnityEngine;

/// <summary> Customizes the field shown in the inspector </summary>
public sealed partial class ReadOnlyAttribute : PropertyAttribute
{
	public ReadOnlyAttribute ()
	{ }
}


#if UNITY_EDITOR

public sealed partial class ReadOnlyAttribute
{ }

#endif
