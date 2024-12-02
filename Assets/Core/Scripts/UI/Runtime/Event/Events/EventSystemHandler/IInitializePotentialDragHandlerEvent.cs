using UnityEngine.EventSystems;

public partial class IInitializePotentialDragHandlerEvent : MonoBehaviourEvent<PointerEventData>, IInitializePotentialDragHandler
{
	public void OnInitializePotentialDrag(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IInitializePotentialDragHandlerEvent { }


#endif