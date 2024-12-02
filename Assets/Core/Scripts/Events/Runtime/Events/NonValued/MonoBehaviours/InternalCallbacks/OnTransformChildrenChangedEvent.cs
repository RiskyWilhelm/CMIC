public sealed partial class OnTransformChildrenChangedEvent : MonoBehaviourEvent
{
    private void OnTransformChildrenChanged()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnTransformChildrenChangedEvent { }


#endif