using UnityEngine.EventSystems;

public partial class ICancelHandlerEvent : MonoBehaviourEvent<BaseEventData>, ICancelHandler
{
	public void OnCancel(BaseEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class ICancelHandlerEvent { }


#endif