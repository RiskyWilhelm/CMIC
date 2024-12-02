using UnityEngine;

/// <summary> Customizes the field label shown in the inspector </summary>
public sealed partial class RenameLabelToAttribute : PropertyAttribute
{
	public string NewName
	{ get; init; }


	public RenameLabelToAttribute (string newName)
	{
		this.NewName = newName;
	}
}


#if UNITY_EDITOR

public sealed partial class RenameLabelToAttribute
{ }

#endif
