public sealed partial class OnPreRenderEvent : MonoBehaviourEvent
{
    private void OnPreRender()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnPreRenderEvent { }


#endif