public sealed partial class OnLateUpdateEvent : MonoBehaviourEvent
{
    private void LateUpdate()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnLateUpdateEvent { }


#endif