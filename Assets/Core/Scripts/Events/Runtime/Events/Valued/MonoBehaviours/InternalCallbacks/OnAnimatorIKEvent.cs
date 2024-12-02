public sealed partial class OnAnimatorIKEvent : MonoBehaviourEvent<int>
{
	// Update
	private void OnAnimatorIK(int layerIndex)
    {
		Raise(layerIndex);
	}
}


#if UNITY_EDITOR

public sealed partial class OnAnimatorIKEvent { }


#endif