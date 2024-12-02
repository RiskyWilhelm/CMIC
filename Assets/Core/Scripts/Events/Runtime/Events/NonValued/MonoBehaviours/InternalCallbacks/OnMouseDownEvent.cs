public sealed partial class OnMouseDownEvent : MonoBehaviourEvent
{
    private void OnMouseDown()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnMouseDownEvent { }


#endif