using UnityEngine.EventSystems;

public partial class IDragHandlerEvent : MonoBehaviourEvent<PointerEventData>, IDragHandler
{
	public void OnDrag(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IDragHandlerEvent { }


#endif