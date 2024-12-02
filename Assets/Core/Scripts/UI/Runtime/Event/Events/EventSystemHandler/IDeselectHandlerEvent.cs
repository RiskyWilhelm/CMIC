using UnityEngine.EventSystems;

public partial class IDeselectHandlerEvent : MonoBehaviourEvent<BaseEventData>, IDeselectHandler
{
	public void OnDeselect(BaseEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IDeselectHandlerEvent { }


#endif