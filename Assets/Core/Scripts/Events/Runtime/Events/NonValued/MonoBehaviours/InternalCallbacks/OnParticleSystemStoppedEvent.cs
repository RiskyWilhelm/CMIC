public sealed partial class OnParticleSystemStoppedEvent : MonoBehaviourEvent
{
    private void OnParticleSystemStopped()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnParticleSystemStoppedEvent { }


#endif