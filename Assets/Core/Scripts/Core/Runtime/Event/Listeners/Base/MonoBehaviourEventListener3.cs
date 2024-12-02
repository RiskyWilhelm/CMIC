using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class MonoBehaviourEventListener<T0, T1, T2> : MonoBehaviourEventListenerBase
{
	[Header("MonoBehaviourEventListener<T0, T1, T2> Event")]
	#region MonoBehaviourEventListener<T0, T1, T2> Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<MonoBehaviourEvent<T0, T1, T2>> primaryEventsList = new();

	[Space]
	[SerializeField]
	private UnityEvent<T0, T1, T2> onResponse = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			RegisterToEvent(iteratedEvent);
	}


	// Update
	public void RegisterToEvent(MonoBehaviourEvent<T0, T1, T2> @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(MonoBehaviourEvent<T0, T1, T2> @event)
	{
		if (@event)
			@event.UnRegisterListener(this);
	}

	internal void OnEventRaised(T0 arg0, T1 arg1, T2 arg2)
	{
		onResponse?.Invoke(arg0, arg1, arg2);
	}


	// Dispose
	private void OnDisable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			UnRegisterFromEvent(iteratedEvent);
	}
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourEventListener<T0, T1, T2>
{ }


#endif