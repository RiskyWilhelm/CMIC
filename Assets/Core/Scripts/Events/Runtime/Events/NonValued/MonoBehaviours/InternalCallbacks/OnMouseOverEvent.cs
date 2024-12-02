public sealed partial class OnMouseOverEvent : MonoBehaviourEvent
{
    private void OnMouseOver()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnMouseOverEvent { }


#endif