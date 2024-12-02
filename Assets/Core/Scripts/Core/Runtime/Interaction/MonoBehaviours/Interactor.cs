using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed partial class Interactor : MonoBehaviour
{
	[Header("Interactor Interaction")]
	#region Interactor Interaction

	[SerializeField]
	private InteractorType _type;

	[SerializeField]
	private bool _isAbleToInteract;

	public InteractorType Type
		=> _type;

	public bool IsAbleToInteract
		=> _isAbleToInteract;


	#endregion

	[Header("Interactor Events")]
	#region Interactor Events

	public UnityEvent<Interactable> onInteracted = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		Unlock();
	}


	// Update
	public bool TryInteractWith(Interactable requester)
	{
		if (IsAbleToInteractWith(requester))
		{
			requester.onGotInteracted?.Invoke(this);
			onInteracted?.Invoke(requester);
			return true;
		}

		return false;
	}

	public bool IsAbleToInteractWith(Interactable requester)
	{
		return _isAbleToInteract && requester.IsAbleToGetInteracted;
	}

	public void Lock()
	{
		_isAbleToInteract = false;
	}

	public void Unlock()
	{
		_isAbleToInteract = true;
	}


	// Dispose
	private void OnDisable()
	{
		Lock();
	}
}


#if UNITY_EDITOR

public sealed partial class Interactor
{ }

#endif