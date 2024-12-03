using System;
using UnityEngine;

/// <summary> Used with <see cref="EventReflectorUtils"/> </summary>
public sealed partial class EventReflector : MonoBehaviour
{
	public GameObject reflected;

    /// <returns> If found: reflected GameObject, else: self </returns>
    public static bool TryGetReflectedGameObject(GameObject gameObject, out GameObject reflectedTo)
    {
        if (gameObject.TryGetComponent<EventReflector>(out EventReflector foundEventReflector))
        {
            reflectedTo = foundEventReflector.reflected;
            return true;
        }

        reflectedTo = gameObject;
        return false;
    }

    /// <summary> Same with <see cref="GameObject.TryGetComponent{T}(out T)"/> except it reflects the method to desired <see cref="GameObject"/> via <see cref="EventReflector"/> if there is any </summary>
    public static bool TryGetComponentInReflected<TargetType>(GameObject searchGameObject, out TargetType foundTarget)
    {
        TryGetReflectedGameObject(searchGameObject, out searchGameObject);
        return searchGameObject.TryGetComponent<TargetType>(out foundTarget);
    }

    /// <summary> Same with <see cref="GameObject.TryGetComponent(System.Type, out Component)"/> except it reflects the method to desired <see cref="GameObject"/> via <see cref="EventReflector"/> if there is any </summary>
    public static bool TryGetComponentInReflected(Type targetType, GameObject searchGameObject, out Component foundTarget)
    {
        TryGetReflectedGameObject(searchGameObject, out searchGameObject);
        return searchGameObject.TryGetComponent(targetType, out foundTarget);
    }
}


#if UNITY_EDITOR

public sealed partial class EventReflector
{ }


#endif
