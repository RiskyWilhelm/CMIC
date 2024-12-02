public sealed partial class OnApplicationPauseEvent : MonoBehaviourEvent<bool>
{
	// Update
	private void OnApplicationPause(bool isPaused)
    {
		Raise(isPaused);
	}
}


#if UNITY_EDITOR

public sealed partial class OnApplicationPauseEvent { }


#endif