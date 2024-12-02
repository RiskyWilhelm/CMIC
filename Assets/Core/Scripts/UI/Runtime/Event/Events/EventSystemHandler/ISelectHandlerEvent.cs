using UnityEngine.EventSystems;

public partial class ISelectHandlerEvent : MonoBehaviourEvent<BaseEventData>, ISelectHandler
{
	public void OnSelect(BaseEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class ISelectHandlerEvent { }


#endif