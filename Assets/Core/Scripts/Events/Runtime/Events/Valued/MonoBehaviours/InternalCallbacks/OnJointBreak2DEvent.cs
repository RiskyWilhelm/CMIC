using UnityEngine;

public sealed partial class OnJointBreak2DEvent : MonoBehaviourEvent<Joint2D>
{
	// Update
	private void OnJointBreak2D(Joint2D joint)
    {
		Raise(joint);
	}
}


#if UNITY_EDITOR

public sealed partial class OnJointBreak2DEvent { }


#endif