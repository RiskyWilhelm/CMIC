public sealed partial class OnApplicationQuitEvent : MonoBehaviourEvent
{
    private void OnApplicationQuit()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnApplicationQuitEvent { }


#endif