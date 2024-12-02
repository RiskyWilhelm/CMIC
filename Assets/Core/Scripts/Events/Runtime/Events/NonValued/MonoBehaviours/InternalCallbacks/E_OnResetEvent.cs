#if UNITY_EDITOR

public sealed class E_OnResetEvent : MonoBehaviourEvent
{
    private void Reset()
    {
        Raise();
    }
}

#endif