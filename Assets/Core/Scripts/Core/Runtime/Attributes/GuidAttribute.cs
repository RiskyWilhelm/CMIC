using UnityEngine;

/// <summary> Customizes the field shown in the inspector </summary>
public sealed partial class GuidAttribute : PropertyAttribute
{
	public GuidAttribute ()
	{ }
}


#if UNITY_EDITOR

public sealed partial class GuidAttribute
{ }

#endif
