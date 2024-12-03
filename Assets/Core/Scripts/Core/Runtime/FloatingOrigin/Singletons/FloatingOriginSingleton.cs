using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public sealed partial class FloatingOriginSingleton : MonoBehaviourSingletonBase<FloatingOriginSingleton>
{
	[Header("FloatingOriginSingleton Floating Origin")]
	#region FloatingOriginSingleton Floating Origin

	[SerializeField]
	private Rigidbody worldOriginRigidbody;

	[SerializeField]
	private Rigidbody alignRigidbody;

	public bool doShiftingEveryAllowedDistance = true;

	public uint allowedDistance = 3000;

	private Vector3 syncedShiftPosition;

	private readonly HashSet<Rigidbody> registeredRigidbodiesSet = new();

	private readonly HashSet<Transform> registeredTransformsSet = new();


	#endregion

	[Header("FloatingOriginSingleton Events")]
	#region FloatingOriginSingleton Events

	[SerializeField]
	private OnBeforeOriginShiftEventSO onBeforeOriginShifted;

	[SerializeField]
	private OnAfterOriginShiftedFixedEventSO onAfterOriginShiftedFixed;


	#endregion


	// Update
	private void LateUpdate()
	{
		TryAutoShift();
	}

	private void FixedUpdate()
	{
		if (syncedShiftPosition != Vector3.zero)
		{
			ShiftTransforms(syncedShiftPosition);
			ShiftCineCameras(syncedShiftPosition);

			onAfterOriginShiftedFixed.Raise(syncedShiftPosition);
			syncedShiftPosition = Vector3.zero;
		}
	}

	public void Shift(Vector3 shiftPosition)
	{
		syncedShiftPosition += shiftPosition;
		onBeforeOriginShifted.Raise(syncedShiftPosition);

		// This change will be there in the next FixedUpdate
		ShiftRigidbodies(shiftPosition);
	}

	public void Shift()
		=> Shift(alignRigidbody.position);

	private void TryAutoShift()
	{
		if (doShiftingEveryAllowedDistance)
		{
			var currentVelocity = alignRigidbody.linearVelocity;
			if ((currentVelocity.x >= allowedDistance) || (currentVelocity.y >= allowedDistance) || (currentVelocity.z >= allowedDistance))
			{
				Debug.LogWarningFormat("{0}'s speed more than floating origin's allowed distance! Limiting its speed to allowed distance", alignRigidbody.gameObject.name);
				alignRigidbody.LimitLinearVelocity(new Vector3(allowedDistance, allowedDistance, allowedDistance));
			}

			var currentPosition = alignRigidbody.position.Abs();
			if ((currentPosition.x >= allowedDistance) || (currentPosition.y >= allowedDistance) || (currentPosition.z >= allowedDistance))
				Shift();
		}
	}

	private void ShiftRigidbodies(Vector3 shiftPosition)
	{
		worldOriginRigidbody.position -= shiftPosition;

		registeredRigidbodiesSet.RemoveWhere((x) => !x);
		foreach (var iteratedRigidbody in registeredRigidbodiesSet)
			iteratedRigidbody.position -= shiftPosition;

		alignRigidbody.position = Vector3.zero;
	}

	private void ShiftTransforms(Vector3 shiftPosition)
	{
		registeredTransformsSet.RemoveWhere((x) => !x);
		foreach (var iteratedTransform in registeredTransformsSet)
			iteratedTransform.position -= shiftPosition;
	}

	private void ShiftCineCameras(Vector3 shiftPosition)
	{
		for (int i = 0; i < CinemachineBrain.ActiveBrainCount; i++)
		{
			var iteratedVCamera = (CinemachineVirtualCameraBase)CinemachineBrain.GetActiveBrain(i).ActiveVirtualCamera;
			iteratedVCamera.OnTargetObjectWarped(iteratedVCamera.LookAt ?? iteratedVCamera.transform, -shiftPosition);
		}
	}

	public void RegisterChildRigidbody(Rigidbody requester)
		=> registeredRigidbodiesSet.Add(requester);

	public void UnRegisterChildRigidbody(Rigidbody requester)
		=> registeredRigidbodiesSet.Remove(requester);

	/// <remarks> Not recommended to use </remarks>
	public void RegisterTransform(Transform requester)
		=> registeredTransformsSet.Add(requester);

	public void UnRegisterTransform(Transform requester)
		=> registeredTransformsSet.Remove(requester);
}


#if UNITY_EDITOR

public partial class FloatingOriginSingleton
{ }

#endif