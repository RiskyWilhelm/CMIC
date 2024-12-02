#if UNITY_EDITOR

public sealed class E_OnDrawGizmosEvent : MonoBehaviourEvent
{
    private void OnDrawGizmos()
    {
        Raise();
    }
}

#endif