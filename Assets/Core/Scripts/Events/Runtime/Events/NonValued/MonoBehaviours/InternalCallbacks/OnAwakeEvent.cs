public sealed partial class OnAwakeEvent : MonoBehaviourEvent
{
    private void Awake()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnAwakeEvent { }


#endif