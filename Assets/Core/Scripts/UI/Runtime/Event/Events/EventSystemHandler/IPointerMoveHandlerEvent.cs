using UnityEngine.EventSystems;

public partial class IPointerMoveHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerMoveHandler
{
	public void OnPointerMove(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IPointerMoveHandlerEvent { }


#endif