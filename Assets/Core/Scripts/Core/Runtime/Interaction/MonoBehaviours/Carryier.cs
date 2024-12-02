using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public sealed partial class Carryier : MonoBehaviour
{
	[Header("Carryier Carry")]
	#region Carryier Carry

	[SerializeField]
	private CarryierType _type;

	[SerializeField]
	private bool _isAbleToCarry;

	public CarryierType Type
		=> _type;

	public bool IsAbleToCarry
		=> _isAbleToCarry;


	#endregion

	[Header("Carryier Events")]
	#region Carryier Events

	public UnityEvent<Carryable> onCarried = new();

	public UnityEvent<Carryable> onUnCarried = new();


	#endregion


	// Initialize
	private void OnEnable()
	{
		Unlock();
	}


	// Update
	public bool TryCarry(Carryable requester)
	{
		if (IsAbleToCarryCarryable(requester))
		{
			requester.onGotCarried?.Invoke(this);
			onCarried?.Invoke(requester);
			return true;
		}

		return false;
	}

	public void UnCarry(Carryable requester)
	{
		onUnCarried?.Invoke(requester);
		requester.onGotUnCarried?.Invoke(this);
	}

	public bool IsAbleToCarryCarryable(Carryable requester)
	{
		return _isAbleToCarry && requester.IsAbleToGetCarried && requester.acceptedCarryiersList.Contains(Type);
	}

	public void Lock()
	{
		_isAbleToCarry = false;
	}

	public void Unlock()
	{
		_isAbleToCarry = true;
	}


	// Dispose
	private void OnDisable()
	{
		Lock();
	}
}


#if UNITY_EDITOR

public sealed partial class Carryier
{ }

#endif