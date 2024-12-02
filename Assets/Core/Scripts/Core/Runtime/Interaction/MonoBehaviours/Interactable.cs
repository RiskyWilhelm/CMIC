using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed partial class Interactable : MonoBehaviour
{
	[Header("Interactable Interaction")]
	#region Interactable Interaction

	[SerializeField]
	private InteractableType _type;

	[SerializeField]
	private bool _isAbleToGetInteracted;

	public InteractableType Type
		=> _type;

	public bool IsAbleToGetInteracted
		=> _isAbleToGetInteracted;


	#endregion

	[Header("Interactable Events")]
	#region Interactable Events

	public UnityEvent<Interactor> onGotInteracted = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		Unlock();
	}


	// Update
	public bool TryGetInteractedBy(Interactor requester)
		=> requester.TryInteractWith(this);

	public bool IsAbleToGetInteractedBy(Interactor requester)
		=> requester.IsAbleToInteractWith(this);

	public void Lock()
	{
		_isAbleToGetInteracted = false;
	}

	public void Unlock()
	{
		_isAbleToGetInteracted = true;
	}


	// Dispose
	private void OnDisable()
	{
		Lock();
	}
}


#if UNITY_EDITOR

public sealed partial class Carryable
{ }

#endif