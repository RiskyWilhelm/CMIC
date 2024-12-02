using UnityEngine.EventSystems;

public partial class IScrollHandlerEvent : MonoBehaviourEvent<PointerEventData>, IScrollHandler
{
	public void OnScroll(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IScrollHandlerEvent { }


#endif