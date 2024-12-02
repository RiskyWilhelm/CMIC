public sealed partial class OnPreCullEvent : MonoBehaviourEvent
{
    private void OnPreCull()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnPreCullEvent { }


#endif