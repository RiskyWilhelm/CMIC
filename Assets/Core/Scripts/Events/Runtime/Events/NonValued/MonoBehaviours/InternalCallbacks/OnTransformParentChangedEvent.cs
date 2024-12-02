public sealed partial class OnTransformParentChangedEvent : MonoBehaviourEvent
{
    private void OnTransformParentChanged()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnTransformParentChangedEvent { }


#endif