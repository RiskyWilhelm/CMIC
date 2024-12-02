using UnityEngine.EventSystems;

public partial class IMoveHandlerEvent : MonoBehaviourEvent<AxisEventData>, IMoveHandler
{
	public void OnMove(AxisEventData eventData)
    {
		Raise(eventData);
	}
}


#if UNITY_EDITOR

public partial class IMoveHandlerEvent { }


#endif