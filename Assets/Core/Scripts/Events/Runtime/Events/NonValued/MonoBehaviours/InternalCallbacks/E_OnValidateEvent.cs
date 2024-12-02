#if UNITY_EDITOR

public sealed class E_OnValidateEvent : MonoBehaviourEvent
{
    private void OnValidate()
    {
		Raise();
    }
}

#endif