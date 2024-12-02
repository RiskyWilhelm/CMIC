public sealed partial class OnParticleUpdateJobScheduledEvent : MonoBehaviourEvent
{
    private void OnParticleUpdateJobScheduled()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnParticleUpdateJobScheduledEvent { }


#endif