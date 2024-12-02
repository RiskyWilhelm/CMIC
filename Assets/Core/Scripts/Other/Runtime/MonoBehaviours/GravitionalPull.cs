using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed partial class GravitionalPull : MonoBehaviour
{
	[Header("GravitionalPull Gravity")]
	#region GravitionalPull Gravity

	public const float GRAVITY_CONSTANT = 16_870.75f;

	[SerializeField]
	private Rigidbody _selfRigidbody;

	[SerializeField]
	private ForceMode forceMode = ForceMode.Acceleration;

	private readonly HashSet<Rigidbody> registeredRigibodiesSet = new();


	#endregion


	// Update
	private void FixedUpdate()
	{
		PullToOriginFixed();
	}

	private void PullToOriginFixed()
	{
		var isNullDetected = false;
		var selfPosition = _selfRigidbody.position;
		var m1 = _selfRigidbody.mass;

		foreach (var iteratedRigidbody in registeredRigibodiesSet)
		{
			if (!iteratedRigidbody)
			{
				isNullDetected = true;
				continue;
			}

			var m2 = iteratedRigidbody.mass;
			var direction = (selfPosition - iteratedRigidbody.position);
			var directionLength = direction.magnitude; // Also distance

			// The case where direction is zero and potentially retun NaN due to normalization
			if (directionLength < Vector3.kEpsilon)
				return;

			var forceMagnitude = GRAVITY_CONSTANT * (m1 * m2) / MathF.Pow(directionLength, 2f); // https://en.wikipedia.org/wiki/Newton%27s_law_of_universal_gravitation 2
			var force = (direction / directionLength) * forceMagnitude;

			iteratedRigidbody.AddForce(force, forceMode);
		}

		if (isNullDetected)
			registeredRigibodiesSet.RemoveWhere(x => !x);
	}

	public void RegisterChildRigidbody(Rigidbody childRigidbody)
		=> registeredRigibodiesSet.Add(childRigidbody);

	public void UnRegisterChildRigidbody(Rigidbody childRigidbody)
		=> registeredRigibodiesSet.Remove(childRigidbody);

	// WARNING: Support implementation for custom Events
	public void OnRigidbodyTriggerEnter(Collider other)
	{
		//Debug.LogWarning($"Enter {other.name}");
		if (other.attachedRigidbody)
			RegisterChildRigidbody(other.attachedRigidbody);
	}

	public void OnRigidbodyTriggerExit(Collider other)
	{
		//Debug.LogWarning($"Exit {other.name}");
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

public sealed partial class GravitionalPull
{
	// Update
	private void OnDrawGizmosSelected()
	{
		DrawMass();
	}

	private void DrawMass()
	{
		Gizmos.color = new Color(1f, 0f, 0f, 0.25f);

		Gizmos.DrawWireSphere(this.transform.position, _selfRigidbody.mass);
		Handles.Label(this.transform.position + (Vector3.one * (_selfRigidbody.mass * 0.5f)), "Mass");
	}
}


#endif
