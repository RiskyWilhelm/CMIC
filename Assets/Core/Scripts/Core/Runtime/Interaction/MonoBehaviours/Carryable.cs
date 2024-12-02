using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed partial class Carryable : MonoBehaviour
{
	[Header("Carryable Carry")]
	#region Carryable Carry

	public List<CarryierType> acceptedCarryiersList = new();

	[SerializeField]
	private CarryableType _type;

	[SerializeField]
	private bool _isAbleToGetCarried;

	public CarryableType Type
		=> _type;

	public bool IsAbleToGetCarried
		=> _isAbleToGetCarried;


	#endregion

	[Header("Carryable Events")]
	#region Carryable Events

	public UnityEvent<Carryier> onGotCarried = new();

	public UnityEvent<Carryier> onGotUnCarried = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		Unlock();
	}


	// Update
	public bool TryGetCarriedBy(Carryier requester)
		=> requester.TryCarry(this);

	public void GetUnCarriedBy(Carryier requester)
		=> requester.UnCarry(this);

	public bool IsAbleToGetCarriedBy(Carryier requester)
		=> requester.IsAbleToCarryCarryable(this);

	public void Lock()
	{
		_isAbleToGetCarried = false;
	}

	public void Unlock()
	{
		_isAbleToGetCarried = true;
	}


	// Dispose
	private void OnDisable()
	{
		Lock();
	}
}


#if UNITY_EDITOR

public sealed partial class Carryable
{ }

#endif