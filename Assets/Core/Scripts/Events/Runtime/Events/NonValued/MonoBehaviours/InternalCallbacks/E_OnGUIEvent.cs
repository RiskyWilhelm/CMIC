#if UNITY_EDITOR

public sealed class E_OnGUIEvent : MonoBehaviourEvent
{
    private void OnGUI()
    {
        Raise();
    }
}

#endif