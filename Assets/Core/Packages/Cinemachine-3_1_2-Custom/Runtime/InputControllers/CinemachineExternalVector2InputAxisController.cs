using System;
using Unity.Cinemachine;
using UnityEngine;

public sealed partial class CinemachineExternalVector2InputAxisController : InputAxisControllerBase<CinemachineExternalVector2InputAxisController.Reader>
{
	[Serializable]
	public class Reader : IInputAxisReader
	{
		public CinemachineExternalVector2InputAxisController valueController;

		[Tooltip("Enable this if the input value is inherently dependent on frame time. For example, mouse deltas will naturally be bigger for longer frames, "
				+ "so in this case the default deltaTime scaling should be canceled.")]
		public bool cancelDeltaTime = false;

		[Tooltip("The input value is multiplied by this amount prior to processing. "
				+ "Controls the input power. Set it to a negative value to invert the input")]
		public float gain = 1;

		public float GetValue(UnityEngine.Object context, IInputAxisOwner.AxisDescriptor.Hints hint)
		{
			if (!valueController)
				return 0f;

			var value = (hint == IInputAxisOwner.AxisDescriptor.Hints.Y) ? valueController.TemporaryValue.y : valueController.TemporaryValue.x;

			if (cancelDeltaTime && (Time.deltaTime > 0f))
				value /= Time.deltaTime;

			return value * gain;
		}
	}

	private Vector2 _temporaryValue;

	public Vector2 TemporaryValue
	{
		get => _temporaryValue;
		set
		{
			_temporaryValue = value;

			if (isActiveAndEnabled)
				UpdateControllers();
		}
	}


	// Initialize
	protected override void InitializeControllerDefaultsForAxis(
			in IInputAxisOwner.AxisDescriptor axis, Controller controller)
	{
		controller.Driver = DefaultInputAxisDriver.Default;
	}
}


#if UNITY_EDITOR

[ExecuteAlways]
public sealed partial class CinemachineExternalVector2InputAxisController
{ }


#endif
