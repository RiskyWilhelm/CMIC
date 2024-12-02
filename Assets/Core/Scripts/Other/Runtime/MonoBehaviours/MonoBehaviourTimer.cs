using UnityEngine;
using UnityEngine.Events;

public sealed partial class MonoBehaviourTimer : MonoBehaviour
{
	[Header("MonoBehaviourTimer Timer")]
	#region MonoBehaviourTimer Timer

	[SerializeField]
	private Timer timer;


	#endregion

	[Header("MonoBehaviourTimer Events")]
	#region MonoBehaviourTimer Events

	public UnityEvent onTimerFinished;


	#endregion


	// Update
	private void Update()
	{
		if (timer.Tick())
		{
			onTimerFinished?.Invoke();
			timer.Reset();
		}
	}
}


#if UNITY_EDITOR

public sealed partial class MonoBehaviourTimer
{ }


#endif
