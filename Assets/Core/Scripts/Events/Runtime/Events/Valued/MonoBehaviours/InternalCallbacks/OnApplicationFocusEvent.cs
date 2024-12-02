public sealed partial class OnApplicationFocusEvent : MonoBehaviourEvent<bool>
{
	// Update
	private void OnApplicationFocus(bool isFocused)
    {
		Raise(isFocused);
	}
}


#if UNITY_EDITOR

public sealed partial class OnApplicationFocusEvent { }


#endif