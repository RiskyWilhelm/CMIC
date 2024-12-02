using UnityEngine;

public sealed partial class DirectionRelativeRotation : MonoBehaviour
{
	[Header("DirectionRelativeRotation Movement")]
	#region DirectionRelativeRotation Movement

	[SerializeField]
	private Transform relativeTo;

	[SerializeField]
	private Rigidbody selfRigidbody;

	[SerializeField]
	private UpdateType updateType = UpdateType.FixedUpdate;

	[SerializeField]
	private AcceptedRotationDirectionAxisType controlledAxisTypes = AcceptedRotationDirectionAxisType.All;

    private Vector3 lastPosition;


	#endregion


	// Initialize
	private void Start()
	{
		lastPosition = selfRigidbody.position;
	}


	// Update
	private void Update()
	{
		if (updateType is UpdateType.Update)
			UpdateRotationByCurrentDirection();
	}

	private void FixedUpdate()
	{
		if (updateType is UpdateType.FixedUpdate)
			UpdateRotationByCurrentDirection();
	}

	private void LateUpdate()
	{
		if (updateType is UpdateType.LateUpdate)
			UpdateRotationByCurrentDirection();
	}

	private void UpdateRotationByCurrentDirection()
	{
		var currentDirection = relativeTo.position.GetWorldDirectionWithMagnitudeTo(lastPosition);
		if (currentDirection == Vector3.zero)
			return;

		selfRigidbody.rotation = selfRigidbody.rotation.RotateTowardsDirection(currentDirection, controlledAxisTypes);
		lastPosition = relativeTo.position;
	}
}


#if UNITY_EDITOR

public sealed partial class DirectionRelativeRotation
{ }

#endif