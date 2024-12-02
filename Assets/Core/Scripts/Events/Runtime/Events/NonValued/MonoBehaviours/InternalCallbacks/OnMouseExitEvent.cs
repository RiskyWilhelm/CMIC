public sealed partial class OnMouseExitEvent : MonoBehaviourEvent
{
    private void OnMouseExit()
    {
		Raise();
	}
}


#if UNITY_EDITOR

public sealed partial class OnMouseExitEvent { }


#endif