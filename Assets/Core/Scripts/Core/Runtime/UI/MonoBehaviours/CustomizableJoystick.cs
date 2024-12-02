using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public sealed partial class CustomizableJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[Header("CustomizableJoystick Movement")]
	#region CustomizableJoystick Movement

	public JoystickBehaviourType joystickBehaviourType;

	public JoystickAxisType joystickAxisType = JoystickAxisType.All;

	[SerializeField]
	private RectTransform knobRTransform;

	[Min(1f)]
	public float knobMovementRange = 50f;

	private Vector2 _input;

	public Vector2 Input
	{
		get => _input;
		set
		{
			LastInput = _input;
			_input = value;
			onInputChanged?.Invoke(_input);
		}
	}

	public Vector2 LastInput
	{ get; private set; }

	public bool IsGettingInteracted
	{ get; private set; }


	#endregion

	[Header("CustomizableJoystick Events")]
	#region CustomizableJoystick Events

	[SerializeField]
	private UnityEvent<Vector2> onInputChanged = new();


	#endregion

	#region CustomizableJoystick Other

	private Vector3 initialKnobOriginPosition;

	private Vector2 cachedPointerDownPosition;


	#endregion


	// Initialize
	private void Start()
	{
		// TODO: You may need to change transform's to knobRTransform
		// Unable to setup elements according to settings if a RectTransform is not available (ISXB-915, ISXB-916).
		if (transform is not RectTransform)
			return;

		initialKnobOriginPosition = knobRTransform.anchoredPosition;

		if (joystickBehaviourType != JoystickBehaviourType.ExactPositionWithDynamicOrigin)
			return;

		cachedPointerDownPosition = initialKnobOriginPosition;
	}


	// Update
	public void OnPointerDown(PointerEventData eventData)
		=> BeginInteraction(eventData.position, eventData.pressEventCamera);

	public void OnDrag(PointerEventData eventData)
		=> MoveKnob(eventData.position, eventData.pressEventCamera);

	public void OnPointerUp(PointerEventData eventData)
		=> EndInteraction();
	
	private void BeginInteraction(Vector2 pointerPosition, Camera uiCamera)
	{
		var canvasRectTransform = (knobRTransform.parent != null) ? knobRTransform.parent.GetComponentInParent<RectTransform>() : null;
		if (canvasRectTransform == null)
		{
			Debug.LogError($"{GetType()} needs to be attached as a child to a UI Canvas and have a RectTransform component to function properly.");
			return;
		}

		switch (joystickBehaviourType)
		{
			case JoystickBehaviourType.RelativePositionWithStaticOrigin:
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPosition, uiCamera, out cachedPointerDownPosition);
			break;
			case JoystickBehaviourType.ExactPositionWithStaticOrigin:
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPosition, uiCamera, out cachedPointerDownPosition);
			MoveKnob(pointerPosition, uiCamera);
			break;
			case JoystickBehaviourType.ExactPositionWithDynamicOrigin:
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPosition, uiCamera, out var pointerDownPosition);
			cachedPointerDownPosition = knobRTransform.anchoredPosition = pointerDownPosition;
			break;
		}

		IsGettingInteracted = true;
		Input = Vector2.zero;
	}

	private void MoveKnob(Vector2 pointerPosition, Camera uiCamera)
	{
		// TODO: You may need to change transform's to knobRTransform
		var canvasRectTransform = (knobRTransform.parent != null) ? knobRTransform.parent.GetComponentInParent<RectTransform>() : null;
		if (canvasRectTransform == null)
		{
			Debug.LogError($"{GetType()} needs to be attached as a child to a UI Canvas and have a RectTransform component to function properly.");
			return;
		}

		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPosition, uiCamera, out var position);
		var delta = position - cachedPointerDownPosition;

		switch (joystickAxisType)
		{
			case JoystickAxisType.None:
			delta = Vector2.zero;
			break;

			case JoystickAxisType.X:
			delta.y = 0f;
			break;

			case JoystickAxisType.Y:
			delta.x = 0f;
			break;
		}

		switch (joystickBehaviourType)
		{
			case JoystickBehaviourType.RelativePositionWithStaticOrigin:
			delta = Vector2.ClampMagnitude(delta, knobMovementRange);
			knobRTransform.anchoredPosition = (Vector2)initialKnobOriginPosition + delta;
			break;

			case JoystickBehaviourType.ExactPositionWithStaticOrigin:
			delta = position - (Vector2)initialKnobOriginPosition;
			delta = Vector2.ClampMagnitude(delta, knobMovementRange);
			knobRTransform.anchoredPosition = (Vector2)initialKnobOriginPosition + delta;
			break;

			case JoystickBehaviourType.ExactPositionWithDynamicOrigin:
			delta = Vector2.ClampMagnitude(delta, knobMovementRange);
			knobRTransform.anchoredPosition = cachedPointerDownPosition + delta;
			break;
		}

		Input = new Vector2(delta.x / knobMovementRange, delta.y / knobMovementRange);
	}

	private void EndInteraction()
	{
		knobRTransform.anchoredPosition = cachedPointerDownPosition = initialKnobOriginPosition;
		IsGettingInteracted = false;
		Input = Vector2.zero;
	}
}


#if UNITY_EDITOR

public sealed partial class CustomizableJoystick
{
	private void OnDrawGizmosSelected()
	{
		// This will not produce meaningful results unless we have a rect transform (ISXB-915, ISXB-916).
		var parentRectTransform = knobRTransform.parent as RectTransform;
		if (parentRectTransform == null)
			return;

		Gizmos.matrix = parentRectTransform.localToWorldMatrix;

		var startPos = parentRectTransform.anchoredPosition;
		if (Application.isPlaying)
			startPos = this.initialKnobOriginPosition;

		Gizmos.color = new Color32(84, 173, 219, 255);

		var center = startPos;
		if (Application.isPlaying && joystickBehaviourType == JoystickBehaviourType.ExactPositionWithDynamicOrigin)
			center = cachedPointerDownPosition;

		DrawGizmoCircle(center, knobMovementRange);
	}

	private void DrawGizmoCircle(Vector2 center, float radius)
	{
		for (var i = 0; i < 32; i++)
		{
			var radians = i / 32f * Mathf.PI * 2;
			var nextRadian = (i + 1) / 32f * Mathf.PI * 2;
			Gizmos.DrawLine(
				new Vector3(center.x + Mathf.Cos(radians) * radius, center.y + Mathf.Sin(radians) * radius, 0),
				new Vector3(center.x + Mathf.Cos(nextRadian) * radius, center.y + Mathf.Sin(nextRadian) * radius, 0));
		}
	}
}


#endif
