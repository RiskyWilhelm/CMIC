using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed partial class Interactable : MonoBehaviour
{
	[Header("Interactable Interaction")]
	#region Interactable Interaction

	public bool isAbleToGetInteracted = true;


	#endregion

	[Header("Interactable Events")]
	#region Interactable Events

	public UnityEvent<Interactor> onGotInteracted = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		isAbleToGetInteracted = true;
	}


	// Update
	public bool TryGetInteractedBy(Interactor requester)
		=> requester.TryInteractOnceWith(this);

	public bool IsAbleToGetInteractedBy(Interactor requester)
		=> requester.IsAbleToInteractWith(this);


	// Dispose
	private void OnDisable()
	{
		isAbleToGetInteracted = false;
	}
}


#if UNITY_EDITOR

public sealed partial class Carryable
{ }

#endif