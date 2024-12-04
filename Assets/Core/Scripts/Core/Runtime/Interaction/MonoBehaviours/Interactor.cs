using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

[DisallowMultipleComponent]
public sealed partial class Interactor : MonoBehaviour
{
	[Header("Interactor Settings")]
	#region Interactor Interaction

	[Tooltip("Used for the root point in calculating the range of interaction")]
	public Transform behaviourPointTransform;

	public InteractionBehaviourType behaviourType;

	public bool isAbleToInteract = true;


	#endregion

	[Header("Interactor Events")]
	#region Interactor Events

	public UnityEvent<Interactable> onInteracted = new();


    #endregion

    #region Interactor Others

	private HashSet<Interactable> detectedInteractablesSet = new();


    #endregion


    // Initialize
    private void OnEnable()
	{
		isAbleToInteract = true;
    }


    // Update
    private void Update()
    {
		DoShowUI();
    }

	private void DoShowUI()
	{
		// TODO: Show UI by behaviour type
    }

	public bool TrySelectNearestInteractable(out Interactable nearestInteractable)
	{
		// Take transforms of only the interactable ones
		var cachedDict = DictionaryPool<Transform, Interactable>.Get();

        foreach (var iteratedInteractable in detectedInteractablesSet)
        {
			if (!this.IsAbleToInteractWith(iteratedInteractable))
				continue;

			cachedDict[iteratedInteractable.transform] = iteratedInteractable;
        }

        // Select nearest and return
        var isFoundNearest = behaviourPointTransform.TryGetNearestTransform(cachedDict.Keys.GetEnumerator(), out Transform nearestTransform);
		nearestInteractable = (isFoundNearest) ? cachedDict[nearestTransform] : null;

        DictionaryPool<Transform, Interactable>.Release(cachedDict);
        return isFoundNearest;
    }

    public bool TryInteractOnceWith(Interactable requester)
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
		return (isAbleToInteract && this.isActiveAndEnabled) && (requester.isAbleToGetInteracted && requester.isActiveAndEnabled);
	}

	public void OnInteractableEnter_Event(Collider collider)
	{
		if (EventReflector.TryGetComponentInReflected<Interactable>(collider.gameObject, out Interactable found))
			detectedInteractablesSet.Add(found);
	}

    public void OnInteractableExit_Event(Collider collider)
    {
        if (EventReflector.TryGetComponentInReflected<Interactable>(collider.gameObject, out Interactable found))
            detectedInteractablesSet.Remove(found);
    }


    // Dispose
    private void OnDisable()
	{
		isAbleToInteract = false;
	}
}


#if UNITY_EDITOR

public sealed partial class Interactor
{ }

#endif