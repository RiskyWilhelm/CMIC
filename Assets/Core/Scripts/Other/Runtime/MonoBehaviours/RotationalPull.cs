using System.Collections.Generic;
using UnityEngine;

public sealed partial class RotationalPull : MonoBehaviour
{
	[Header("RotationalPull Rotation")]
	#region RotationalPull Rotation

	[SerializeField]
	[Tooltip("Optional. If zero, a direction of transform position (origin) to registered rigibody is used")]
	internal Vector3 upDirection;

	[SerializeField]
	internal bool isUpDirectionWorldAxis;

	[SerializeField]
	private float equalizeUpPower = 90f;

	private readonly HashSet<Rigidbody> registeredRigibodiesSet = new();


	#endregion


	// Update
	private void Update()
	{
		registeredRigibodiesSet.RemoveWhere(x => !x);
	}

	private void FixedUpdate()
	{
		PullControlledRigidbodiesFixed();
	}

	private void PullControlledRigidbodiesFixed()
	{
		var calculatedUp = upDirection;
		var isUsingOriginForUp = (upDirection == Vector3.zero);
		if (!isUsingOriginForUp && !isUpDirectionWorldAxis)
			calculatedUp = this.transform.rotation * upDirection;

		foreach (var iteratedRigidbody in registeredRigibodiesSet)
        {
			if (iteratedRigidbody.isKinematic)
				return;

			if (isUsingOriginForUp)
				calculatedUp = this.transform.position.GetWorldDirectionTo(iteratedRigidbody.transform.position);

			iteratedRigidbody.rotation = iteratedRigidbody.rotation.EqualizeUpRotationWithDirection(calculatedUp, powerDelta: equalizeUpPower * Time.deltaTime);
        }
    }

	public void RegisterChildRigidbody(Rigidbody childRigidbody)
		=> registeredRigibodiesSet.Add(childRigidbody);

	public void UnRegisterChildRigidbody(Rigidbody childRigidbody)
		=> registeredRigibodiesSet.Remove(childRigidbody);

	// WARNING: Support implementation for custom Events
	public void OnRigidbodyTriggerEnter(Collider other)
	{
		if (other.attachedRigidbody)
			RegisterChildRigidbody(other.attachedRigidbody);
	}

	public void OnRigidbodyTriggerExit(Collider other)
	{
		if (other.attachedRigidbody)
			UnRegisterChildRigidbody(other.attachedRigidbody);
	}


	// Dispose
	private void OnDisable()
	{
		registeredRigibodiesSet.Clear();
	}
}


#if UNITY_EDITOR

public sealed partial class RotationalPull
{
	[Header("RotationalPull Edit")]
	[RenameLabelTo("Interactive Editing")]
	public bool e_IsActivatedInteractiveEditing;
}


#endif