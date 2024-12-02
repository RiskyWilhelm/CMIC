using UnityEngine.EventSystems;

public partial class ISubmitHandlerEvent : MonoBehaviourEvent<BaseEventData>, ISubmitHandler
{
	public void OnSubmit(BaseEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class ISubmitHandlerEvent { }


#endif