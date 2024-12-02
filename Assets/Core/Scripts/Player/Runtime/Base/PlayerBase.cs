using UnityEditor;
using UnityEngine;

public abstract partial class PlayerBase : MonoBehaviour
{
	[Header("PlayerBase Movement")]
	#region PlayerBase Movement

	[SerializeField]
	private Rigidbody _selfRigidbody;

	

	private RaycastHit _currentGroundedHit;

	public Rigidbody SelfRigidbody
		=> _selfRigidbody;

	

	public RaycastHit CurrentIsGroundedHit
		=> _currentGroundedHit;


	#endregion

	[Header("PlayerBase Grounded/UnGrounded")]
	#region PlayerBase Grounded/UnGrounded

	public LayerMask isGroundedLayerMask = Layers.Mask.Ground;

	public float isGroundedCheckRadius = 1f;

	public float isGroundedCheckDistance = 1f;

	private bool _isGrounded;

	public bool IsGrounded
		=> _isGrounded;


	#endregion


	// Initialize
	protected virtual void Awake()
	{
		OnUnGrounded();
	}


	// Update
	protected virtual void Update()
	{
		UpdateGroundedState();
	}

	// TODO: Replace with collision stay angle check: https://discussions.unity.com/t/oncollisionstay-exit-problem-solved/625321/2
	public void UpdateGroundedState()
	{
		var currentGroundedState = IsGroundedAtVector(_selfRigidbody.position, out _currentGroundedHit, isGroundedLayerMask);

		if (_isGrounded != currentGroundedState)
		{
			_isGrounded = currentGroundedState;
			if (_isGrounded)
				OnGrounded();
			else
				OnUnGrounded();
		}
	}

	public bool IsGroundedAtVector(Vector3 worldPosition, out RaycastHit hit, int layerMask = Layers.Mask.Ground)
	{
		return Physics.SphereCast(worldPosition, isGroundedCheckRadius, _selfRigidbody.rotation.Down(), out hit, isGroundedCheckDistance, layerMask);
	}

	protected virtual void OnGrounded()
	{ }

	protected virtual void OnUnGrounded()
	{ }
}


#if UNITY_EDITOR

public abstract partial class PlayerBase
{
	// Update
	protected virtual void OnDrawGizmosSelected()
	{
		DrawAcceptedDistanceForGroundedCheck();
	}

	private void DrawAcceptedDistanceForGroundedCheck()
	{
		var currentRotation = _selfRigidbody.rotation;
		Gizmos.color = new Color(1f, 0f, 0f, 0.25f);

		Gizmos.DrawSphere(this.transform.position, isGroundedCheckRadius);
		Gizmos.DrawSphere(this.transform.position + (currentRotation.Down() * isGroundedCheckDistance), isGroundedCheckRadius);
		Handles.Label(this.transform.position + (currentRotation.Down() * isGroundedCheckDistance), "Grounded Check");
	}
}

#endif