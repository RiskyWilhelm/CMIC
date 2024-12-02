using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed partial class Movable : MonoBehaviour
{
	[Header("Movable Movement")]
	#region Movable Movement

	[SerializeField]
	private Rigidbody _selfRigidbody;

	public ForceMode movementForceMode = ForceMode.Acceleration;

    public Vector3 movementForce;

	[Min(0)]
	[Tooltip("Optional. Set to zero if no velocity limitation wanted")]
	public Vector3 maxMovementVelocity;

	public Rigidbody SelfRigidbody
		=> _selfRigidbody;

	public bool IsTryingToMove
		=> (_movingDirection != Vector3.zero);


	#endregion

	#region Movable Other

	private Vector3 _movingDirection;

	public Vector3 NormalizedMovingDirection
	{
		get => _movingDirection;
		set => _movingDirection = value.normalized;
	}


	#endregion


	// Initialize
	private void OnEnable()
	{
		_movingDirection = default;
		SelfRigidbody.linearVelocity = Vector3.zero;
	}


	// Update
	private void FixedUpdate()
	{
		ApplyForceToDirection_Fixed();
		SelfRigidbody.LimitLinearVelocity(maxMovementVelocity);
	}

	private void ApplyForceToDirection_Fixed()
	{
		SelfRigidbody.AddForce(Vector3.Scale(movementForce, NormalizedMovingDirection), movementForceMode);
	}

	/// <summary> 
	/// Manipulates the <paramref name="normalizedDirection"/> based on <paramref name="relativeTo"/> direction.
	/// For example, <see cref="Vector3.forward"/> can be equal to <paramref name="relativeTo"/>'s forward </summary>
	public void SetMovingDirectionRelativeToTransform(Transform relativeTo, Vector3 normalizedDirection)
		=> NormalizedMovingDirection = (relativeTo.rotation * normalizedDirection);
}


#if UNITY_EDITOR

public sealed partial class Movable
{ }

#endif