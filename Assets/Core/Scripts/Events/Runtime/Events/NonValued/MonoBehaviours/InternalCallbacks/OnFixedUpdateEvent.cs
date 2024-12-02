public sealed partial class OnFixedUpdateEvent : MonoBehaviourEvent
{
    private void FixedUpdate()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnFixedUpdateEvent { }


#endif