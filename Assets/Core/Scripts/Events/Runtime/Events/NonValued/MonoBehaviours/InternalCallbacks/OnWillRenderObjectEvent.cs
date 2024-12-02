public sealed partial class OnWillRenderObjectEvent : MonoBehaviourEvent
{
    private void OnWillRenderObject()
    {
		Raise();
	}
}


#if UNITY_EDITOR

#pragma warning disable 0414

public sealed partial class OnWillRenderObjectEvent { }

#pragma warning restore 0414

#endif