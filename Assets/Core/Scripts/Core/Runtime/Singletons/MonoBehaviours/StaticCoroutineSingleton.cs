// Copyright belongs to: https://forum.unity.com/members/cykesdev.1703063/
// WARNING: I didnt implemented the way he did because the coroutine methods are already public
using UnityEngine;
 
public sealed partial class StaticCoroutineSingleton : MonoBehaviourSingletonBase<StaticCoroutineSingleton>
{ }


#if UNITY_EDITOR

[ExecuteAlways]
public partial class StaticCoroutineSingleton { }

#endif