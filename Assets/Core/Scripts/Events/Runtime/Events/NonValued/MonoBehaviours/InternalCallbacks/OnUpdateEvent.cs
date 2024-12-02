public sealed partial class OnUpdateEvent : MonoBehaviourEvent
{
	private void Update()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnUpdateEvent { }


#endif