public sealed partial class OnMouseUpEvent : MonoBehaviourEvent
{
    private void OnMouseUp()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnMouseUpEvent { }


#endif