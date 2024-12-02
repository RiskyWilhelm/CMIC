using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Same as <see cref="MonoBehaviour"/> but able to sync fixed update with update by customization </summary>
public abstract partial class MonoBehaviourFrameDependentPhysics<InteractionEnumType> : MonoBehaviour
	where InteractionEnumType : Enum
{
	#region MonoBehaviourFrameDependentPhysics Other

	private Queue<FrameDependentPhysicsInteraction<InteractionEnumType>> FrameDependentInteractionQueue
	{ get; } = new();


	#endregion


	// Update
	protected virtual void Update()
	{
		DoFrameDependentPhysics();
	}

	protected void DoFrameDependentPhysics()
	{
		for (int i = FrameDependentInteractionQueue.Count; i > 0; i--)
		{
			var iteratedPhysicsInteraction = FrameDependentInteractionQueue.Dequeue();

			if (iteratedPhysicsInteraction.collider || (iteratedPhysicsInteraction.collision != null))
				OnFrameDependentFixedUpdateInteraction(iteratedPhysicsInteraction);
			else
				Debug.LogWarningFormat("Corrupted PhysicsInteraction catched for interaction type {0}", iteratedPhysicsInteraction.interactionType);
		}
	}

	public void RegisterFrameDependentPhysicsInteraction(FrameDependentPhysicsInteraction<InteractionEnumType> interaction)
	{
		if (!FrameDependentInteractionQueue.Contains(interaction))
			FrameDependentInteractionQueue.Enqueue(interaction);
	}

	protected abstract void OnFrameDependentFixedUpdateInteraction(FrameDependentPhysicsInteraction<InteractionEnumType> iteratedPhysicsInteraction);


	// Dispose
	protected virtual void OnDisable()
	{
		CallExitInteractions();
		FrameDependentInteractionQueue.Clear();
	}

	/// <summary> In 3D, OnXXXExit() wont get called when other or self collider is destroyed or disabled. Use this method to call all custom OnXXXExit()'s </summary>
	/// <remarks> In 2D, you dont need to implement this </remarks>
	protected abstract void CallExitInteractions();
}


#if UNITY_EDITOR

#pragma warning disable 0414

public abstract partial class MonoBehaviourFrameDependentPhysics<InteractionEnumType>
{ }

#pragma warning restore 0414

#endif
