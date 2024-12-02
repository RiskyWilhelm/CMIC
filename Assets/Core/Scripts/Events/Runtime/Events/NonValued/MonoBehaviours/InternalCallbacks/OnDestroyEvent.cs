public sealed partial class OnDestroyEvent : MonoBehaviourEvent
{
    private void OnDestroy()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnDestroyEvent { }


#endif