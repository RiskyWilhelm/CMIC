public sealed partial class OnMouseEnterEvent : MonoBehaviourEvent
{
    private void OnMouseEnter()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnMouseEnterEvent { }


#endif