public sealed partial class OnMouseDragEvent : MonoBehaviourEvent
{
    private void OnMouseDrag()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnMouseDragEvent { }


#endif