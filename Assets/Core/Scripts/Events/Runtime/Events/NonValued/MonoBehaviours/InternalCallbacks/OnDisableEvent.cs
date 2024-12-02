public sealed partial class OnDisableEvent : MonoBehaviourEvent
{
    private void OnDisable()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnDisableEvent { }


#endif