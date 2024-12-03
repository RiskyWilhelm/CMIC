using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEvent<T0, T1> : ScriptableObjectEventBase
{
	[Header("ScriptableObjectEvent<T0, T1> Event")]
	#region ScriptableObjectEvent<T0, T1> Event

	[Tooltip("Raised before other listener's Response")]
	[SerializeField]
	private UnityEvent<T0, T1> onRaised = new();

	[SerializeField]
	private List<ScriptableObjectEventListener<T0, T1>> listeners = new();


	#endregion


	// Update
	public virtual bool RegisterListener(ScriptableObjectEventListener<T0, T1> listener)
	{
		if (listeners.Contains(listener))
			return false;

		listeners.Add(listener);
		return true;
	}

	public virtual bool UnRegisterListener(ScriptableObjectEventListener<T0, T1> listener)
	{
		if (!listeners.Contains(listener))
			return false;

		listeners.Remove(listener);
		return true;
	}

	public void Raise(T0 arg0, T1 arg1)
	{
		try
		{
			onRaised?.Invoke(arg0, arg1);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}

		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			try
			{
				listeners[i].OnEventRaised(arg0, arg1);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}
}


#if UNITY_EDITOR

public abstract partial class ScriptableObjectEvent<T0, T1>
{ }


#endif