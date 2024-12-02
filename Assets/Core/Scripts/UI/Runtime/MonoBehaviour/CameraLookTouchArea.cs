using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public sealed partial class CameraLookTouchArea : MonoBehaviour, IDragHandler, IEndDragHandler
{
	#region CameraLookTouchArea Events

	[SerializeField]
	private UnityEvent<Vector2> onPointerMovedWithDelta;


	#endregion


	// Update
	/// <summary> Acts like a normalizer for delta movement vector </summary>
	private Vector2 GetScaledDelta(Vector2 value)
	{
		// Scale with delta time
		value /= Time.unscaledDeltaTime;

		// Scale vector2
		value *= 0.1f;

		return value;
	}

	public void OnDrag(PointerEventData eventData)
	{
		onPointerMovedWithDelta?.Invoke(GetScaledDelta(eventData.delta));
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		onPointerMovedWithDelta?.Invoke(Vector2.zero);
	}
}


#if UNITY_EDITOR

public sealed partial class CameraLookTouchArea
{ }


#endif
