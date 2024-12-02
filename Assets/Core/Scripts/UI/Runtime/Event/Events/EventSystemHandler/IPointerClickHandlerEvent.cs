using UnityEngine.EventSystems;

public partial class IPointerClickHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IPointerClickHandlerEvent { }


#endif