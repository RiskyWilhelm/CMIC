using UnityEngine.EventSystems;

public partial class IDropHandlerEvent : MonoBehaviourEvent<PointerEventData>, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IDropHandlerEvent { }


#endif