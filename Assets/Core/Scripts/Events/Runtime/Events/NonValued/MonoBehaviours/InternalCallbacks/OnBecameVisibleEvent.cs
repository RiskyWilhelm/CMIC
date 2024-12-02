public sealed partial class OnBecameVisibleEvent : MonoBehaviourEvent
{
    private void OnBecameVisible()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnBecameVisibleEvent { }


#endif