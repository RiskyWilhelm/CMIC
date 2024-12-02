#if UNITY_EDITOR

public sealed class E_OnDrawGizmosSelectedEvent : MonoBehaviourEvent
{
    private void OnDrawGizmosSelected()
    {
        Raise();
    }
}

#endif