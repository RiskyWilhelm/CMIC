public sealed partial class OnEnableEvent : MonoBehaviourEvent
{
    private void OnEnable()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnEnableEvent { }


#endif