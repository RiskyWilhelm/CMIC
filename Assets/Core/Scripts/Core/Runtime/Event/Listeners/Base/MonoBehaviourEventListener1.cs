using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class MonoBehaviourEventListener<T0> : MonoBehaviourEventListenerBase
{
	[Header("MonoBehaviourEventListener<T0> Event")]
	#region MonoBehaviourEventListener<T0> Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<MonoBehaviourEvent<T0>> primaryEventsList = new();

	[Space]
	[SerializeField]
	private UnityEvent<T0> onResponse = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			RegisterToEvent(iteratedEvent);
	}


	// Update
	public void RegisterToEvent(MonoBehaviourEvent<T0> @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(MonoBehaviourEvent<T0> @event)
	{
		if (@event)
			@event.UnRegisterListener(this);
	}

	internal void OnEventRaised(T0 t0)
	{
		onResponse?.Invoke(t0);
	}


	// Dispose
	private void OnDisable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			UnRegisterFromEvent(iteratedEvent);
	}
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourEventListener<T0>
{ }


#endif