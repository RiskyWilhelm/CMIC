using UnityEngine.EventSystems;

public partial class IBeginDragHandlerEvent : MonoBehaviourEvent<PointerEventData>, IBeginDragHandler, IDragHandler
{
	public void OnBeginDrag(PointerEventData eventData)
    {
		Raise(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{ }
}


#if UNITY_EDITOR

public partial class IBeginDragHandlerEvent { }


#endif