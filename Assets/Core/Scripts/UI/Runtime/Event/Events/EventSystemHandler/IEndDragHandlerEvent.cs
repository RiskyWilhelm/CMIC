using UnityEngine.EventSystems;

public partial class IEndDragHandlerEvent : MonoBehaviourEvent<PointerEventData>, IEndDragHandler, IDragHandler
{
	public void OnDrag(PointerEventData eventData)
	{ }

	public void OnEndDrag(PointerEventData eventData)
    {
		Raise(eventData);
	}
}

#if UNITY_EDITOR

public partial class IEndDragHandlerEvent { }


#endif