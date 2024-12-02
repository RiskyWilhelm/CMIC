public sealed partial class OnAudioFilterReadEvent : MonoBehaviourEvent<float[], int>
{
	// Update
	private void OnAudioFilterRead(float[] data, int channels)
    {
		Raise(data, channels);
	}
}


#if UNITY_EDITOR

public sealed partial class OnAudioFilterReadEvent { }


#endif