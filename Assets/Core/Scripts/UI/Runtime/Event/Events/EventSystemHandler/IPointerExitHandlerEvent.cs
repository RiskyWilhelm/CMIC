using UnityEngine.EventSystems;

public partial class IPointerExitHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerExitHandler
{
	public void OnPointerExit(PointerEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IPointerExitHandlerEvent { }


#endif