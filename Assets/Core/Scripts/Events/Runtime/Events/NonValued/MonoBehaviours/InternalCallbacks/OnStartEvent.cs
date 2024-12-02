public sealed partial class OnStartEvent : MonoBehaviourEvent
{
    private void Start()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnStartEvent { }


#endif