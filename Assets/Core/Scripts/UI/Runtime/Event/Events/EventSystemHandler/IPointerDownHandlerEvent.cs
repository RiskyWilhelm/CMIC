using UnityEngine.EventSystems;

public partial class IPointerDownHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerDownHandler
{
	public void OnPointerDown(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IPointerDownHandlerEvent { }


#endif