using UnityEngine.EventSystems;

public partial class IPointerUpHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerUpHandler, IPointerDownHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{ }

	public void OnPointerUp(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IPointerUpHandlerEvent { }


#endif