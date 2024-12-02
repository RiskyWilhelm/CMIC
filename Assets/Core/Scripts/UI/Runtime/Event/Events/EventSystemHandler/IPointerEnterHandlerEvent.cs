using UnityEngine.EventSystems;

public partial class IPointerEnterHandlerEvent : MonoBehaviourEvent<PointerEventData>, IPointerEnterHandler
{
	public void OnPointerEnter(PointerEventData eventData)
    {
        Raise(eventData);
    }
}


#if UNITY_EDITOR

public partial class IPointerEnterHandlerEvent { }


#endif