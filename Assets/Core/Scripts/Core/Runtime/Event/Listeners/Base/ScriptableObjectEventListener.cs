using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class ScriptableObjectEventListener : ScriptableObjectEventListenerBase
{
	[Header("ScriptableObjectEventListener Event")]
	#region ScriptableObjectEventListener Event

	[Tooltip("Registers and unregisters at OnEnable() and OnDisable()")]
	[SerializeField]
	private List<ScriptableObjectEvent> primaryEventsList = new();

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
	public void RegisterToEvent(ScriptableObjectEvent @event)
	{
		if (@event)
			@event.RegisterListener(this);
	}

	public void UnRegisterFromEvent(ScriptableObjectEvent @event)
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

public abstract partial class ScriptableObjectEventListener
{ }


#endif