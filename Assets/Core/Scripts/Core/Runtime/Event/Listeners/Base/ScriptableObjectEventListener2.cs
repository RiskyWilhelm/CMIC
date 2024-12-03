using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEventListener<T0, T1> : ScriptableObjectEventListenerBase
{
	[Header("ScriptableObjectEventListener<T0, T1> Event")]
	#region ScriptableObjectEventListener<T0, T1> Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<ScriptableObjectEvent<T0, T1>> primaryEventsList = new();

	[Space]
	[SerializeField]
	private UnityEvent<T0, T1> onResponse = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			RegisterToEvent(iteratedEvent);
	}


	// Update
	public void RegisterToEvent(ScriptableObjectEvent<T0, T1> @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(ScriptableObjectEvent<T0, T1> @event)
	{
		if (@event)
			@event.UnRegisterListener(this);
	}

	internal void OnEventRaised(T0 arg0, T1 arg1)
	{
		onResponse?.Invoke(arg0, arg1);
	}


	// Dispose
	private void OnDisable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			UnRegisterFromEvent(iteratedEvent);
	}
}


#if UNITY_EDITOR

public abstract partial class ScriptableObjectEventListener<T0, T1>
{ }


#endif