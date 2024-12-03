using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEvent<T0, T1, T2, T3> : ScriptableObjectEventBase
{
	[Header("ScriptableObjectEvent<T0, T1, T2, T3> Event")]
	#region ScriptableObjectEvent<T0, T1, T2, T3> Event

	[Tooltip("Raised before other listener's Response")]
	[SerializeField]
	private UnityEvent<T0, T1, T2, T3> onRaised = new();

	[SerializeField]
	private List<ScriptableObjectEventListener<T0, T1, T2, T3>> listeners = new();


	#endregion


	// Update
	public virtual bool RegisterListener(ScriptableObjectEventListener<T0, T1, T2, T3> listener)
	{
		if (listeners.Contains(listener))
			return false;

		listeners.Add(listener);
		return true;
	}

	public virtual bool UnRegisterListener(ScriptableObjectEventListener<T0, T1, T2, T3> listener)
	{
		if (!listeners.Contains(listener))
			return false;

		listeners.Remove(listener);
		return true;
	}

	public void Raise(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		try
		{
			onRaised?.Invoke(arg0, arg1, arg2, arg3);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}

		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			try
			{
				listeners[i].OnEventRaised(arg0, arg1, arg2, arg3);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}
}


#if UNITY_EDITOR

public abstract partial class ScriptableObjectEventBase
{ }


#endif