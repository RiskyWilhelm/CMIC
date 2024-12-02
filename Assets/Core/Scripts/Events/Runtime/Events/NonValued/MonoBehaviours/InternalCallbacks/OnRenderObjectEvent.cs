public sealed partial class OnRenderObjectEvent : MonoBehaviourEvent
{
    private void OnRenderObject()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnRenderObjectEvent { }


#endif