public sealed partial class OnBecameInvisibleEvent : MonoBehaviourEvent
{
    private void OnBecameInvisible()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnBecameInvisibleEvent { }


#endif