using UnityEngine.EventSystems;

public partial class BaseEventListener : MonoBehaviourEventListener<BaseEventData>
{ }


#if UNITY_EDITOR

public partial class BaseEventListener { }


#endif