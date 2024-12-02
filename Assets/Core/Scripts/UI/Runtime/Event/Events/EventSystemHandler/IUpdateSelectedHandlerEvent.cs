using UnityEngine.EventSystems;

public partial class IUpdateSelectedHandlerEvent : MonoBehaviourEvent<BaseEventData>, IUpdateSelectedHandler
{
	public void OnUpdateSelected(BaseEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IUpdateSelectedHandlerEvent { }


#endif