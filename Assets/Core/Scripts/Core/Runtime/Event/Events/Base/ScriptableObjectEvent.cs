using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEvent : ScriptableObjectEventBase
{
	[Header("ScriptableObjectEvent Event")]
	#region ScriptableObjectEvent Event

	[Tooltip("Raised before other listener's Response")]
	[SerializeField]
	private UnityEvent onRaised = new();

	[SerializeField]
	private List<ScriptableObjectEventListener> listeners = new();


	#endregion


	// Update
	public virtual bool RegisterListener(ScriptableObjectEventListener listener)
	{
		if (listeners.Contains(listener))
			return false;

		listeners.Add(listener);
		return true;
	}

	public virtual bool UnRegisterListener(ScriptableObjectEventListener listener)
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

public abstract partial class ScriptableObjectEvent
{ }


#endif