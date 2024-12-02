public sealed partial class OnPostRenderEvent : MonoBehaviourEvent
{
    private void OnPostRender()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnPostRenderEvent { }


#endif