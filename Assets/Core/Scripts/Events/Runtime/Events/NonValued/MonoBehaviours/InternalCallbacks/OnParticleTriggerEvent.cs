public sealed partial class OnParticleTriggerEvent : MonoBehaviourEvent
{
    private void OnParticleTrigger()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnParticleTriggerEvent { }


#endif