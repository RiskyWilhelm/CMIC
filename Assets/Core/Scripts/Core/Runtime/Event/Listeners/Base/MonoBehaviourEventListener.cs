using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class MonoBehaviourEventListener : MonoBehaviourEventListenerBase
{
	[Header("MonoBehaviourEventListener Event")]
	#region MonoBehaviourEventListener Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<MonoBehaviourEvent> primaryEventsList = new();

	[Space]
	[SerializeField]
	private UnityEvent onResponse = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			RegisterToEvent(iteratedEvent);
	}


	// Update
	public void RegisterToEvent(MonoBehaviourEvent @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(MonoBehaviourEvent @event)
	{
		if (@event)
			@event.UnRegisterListener(this);
	}

	internal void OnEventRaised()
	{
		onResponse?.Invoke();
	}


	// Dispose
	private void OnDisable()
	{
		foreach (var iteratedEvent in primaryEventsList)
			UnRegisterFromEvent(iteratedEvent);
	}
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourEventListener
{ }


#endif