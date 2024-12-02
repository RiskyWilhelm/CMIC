public sealed partial class OnJointBreakEvent : MonoBehaviourEvent<float>
{
	// Update
	private void OnJointBreak(float breakForce)
    {
		Raise(breakForce);
	}
}


#if UNITY_EDITOR

public sealed partial class OnJointBreakEvent { }


#endif