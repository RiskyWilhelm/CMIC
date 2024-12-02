using UnityEngine;

public sealed partial class FloatingOriginTransform : MonoBehaviour
{
	[Header("FloatingOriginTransform Floating Origin")]
	#region FloatingOriginTransform Floating Origin

	[SerializeField]
	private Transform selfTransform;


	#endregion


	// Initialize
	private void OnEnable()
	{
		FloatingOriginSingleton.Instance.RegisterTransform(selfTransform);
	}


	// Dispose
	private void OnDisable()
	{
		FloatingOriginSingleton.Instance.UnRegisterTransform(selfTransform);
	}
}


#if UNITY_EDITOR

public sealed partial class FloatingOriginTransform
{ }


#endif
