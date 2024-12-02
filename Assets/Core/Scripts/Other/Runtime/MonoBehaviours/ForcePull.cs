using System.Collections.Generic;
using UnityEngine;

public sealed partial class ForcePull : MonoBehaviour
{
	[Header("ForcePull Force")]
	#region ForcePull Force

	[Tooltip("Optional. If zero, a direction of registered rigibody to transform position (origin) is used")]
	public Vector3 pullDirection;

	public ForceMode forceMode = ForceMode.Acceleration;

	public float power = 9.81f;

	public bool isPullDirectionWorldAxis;

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
		var calculatedPull = pullDirection;
		var isUsingOriginForPull = (pullDirection == Vector3.zero);
		if (!isUsingOriginForPull && !isPullDirectionWorldAxis)
			calculatedPull = this.transform.rotation * pullDirection;

		foreach (var iteratedRigidbody in registeredRigibodiesSet)
		{
			if (isUsingOriginForPull)
				calculatedPull = iteratedRigidbody.transform.position.GetWorldDirectionTo(this.transform.position);

			iteratedRigidbody.AddForce(calculatedPull * power, forceMode);
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

public sealed partial class ForcePull
{
	[Header("ForcePull Edit")]
	[RenameLabelTo("Interactive Editing")]
	public bool e_IsActivatedInteractiveEditing;
}


#endif
