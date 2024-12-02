public sealed partial class OnMouseUpAsButtonOnAwakeEvent : MonoBehaviourEvent
{
    private void OnMouseUpAsButton()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnMouseUpAsButtonOnAwakeEvent { }


#endif