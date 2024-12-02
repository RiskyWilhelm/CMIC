public sealed partial class OnAnimatorMoveEvent : MonoBehaviourEvent
{
    private void OnAnimatorMove()
    {
        Raise();
    }
}


#if UNITY_EDITOR

public sealed partial class OnAnimatorMoveEvent { }


#endif