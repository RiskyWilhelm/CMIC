using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class MonoBehaviourEvent : MonoBehaviourEventBase
{
	[Header("MonoBehaviourEvent Event")]
	#region MonoBehaviourEvent Event

	[Tooltip("Raised before other listener's Response")]
	[SerializeField]
	private UnityEvent onRaised = new();

	[SerializeField]
	private List<MonoBehaviourEventListener> listeners = new();


	#endregion


	// Update
	public virtual bool RegisterListener(MonoBehaviourEventListener listener)
	{
		if (listeners.Contains(listener))
			return false;

		listeners.Add(listener);
		return true;
	}

	public virtual bool UnRegisterListener(MonoBehaviourEventListener listener)
	{
		if (!listeners.Contains(listener))
			return false;

		listeners.Remove(listener);
		return true;
	}

	public void Raise()
	{
		try
		{
			onRaised?.Invoke();
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}

		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			try
			{
				listeners[i].OnEventRaised();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourEvent
{ }


#endif