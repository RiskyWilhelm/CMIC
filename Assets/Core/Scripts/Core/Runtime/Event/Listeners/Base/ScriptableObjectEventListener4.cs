using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEventListener<T0, T1, T2, T3> : ScriptableObjectEventListenerBase
{
	[Header("ScriptableObjectEventListener<T0, T1, T2, T3> Event")]
	#region ScriptableObjectEventListener<T0, T1, T2, T3> Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<ScriptableObjectEvent<T0, T1, T2, T3>> primaryEventsList = new();

	[Space]
	[SerializeField]
	private UnityEvent<T0, T1, T2, T3> onResponse = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			RegisterToEvent(iteratedEvent);
	}


	// Update
	public void RegisterToEvent(ScriptableObjectEvent<T0, T1, T2, T3> @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(ScriptableObjectEvent<T0, T1, T2, T3> @event)
	{
		if (@event)
			@event.UnRegisterListener(this);
	}

	internal void OnEventRaised(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		onResponse?.Invoke(arg0, arg1, arg2, arg3);
	}


	// Dispose
	private void OnDisable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			UnRegisterFromEvent(iteratedEvent);
	}
}


#if UNITY_EDITOR

public abstract partial class ScriptableObjectEventListener<T0, T1, T2, T3>
{ }


#endif