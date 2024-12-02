using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public sealed partial class TouchControllerPersistentSingleton : MonoBehaviourSingletonBase<TouchControllerPersistentSingleton>
{
	[Header("TouchControllerPersistentSingleton Events")]
	#region TouchControllerPersistentSingleton Events

	public UnityEvent<ETouch> onPressed = new();

	public UnityEvent<ETouch> onMove = new();

	public UnityEvent<ETouch> onReleased = new();


	#endregion


	// Initialize
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
	private static void OnBeforeSplashScreen()
	{
		SceneManager.activeSceneChanged += OnActiveSceneChanged;
	}

	private void OnEnable()
	{
		EnhancedTouchSupport.Enable();

		ETouch.onFingerDown += OnFingerDown;
		ETouch.onFingerMove += OnFingerMove;
		ETouch.onFingerUp += OnFingerUp;
	}

	private static void OnActiveSceneChanged(Scene lastScene, Scene loadedScene)
	{
		if (!IsAnyInstanceLiving)
			CreateSingleton();
	}


	// Update
	private void OnFingerDown(Finger finger)
	{
		onPressed?.Invoke(finger.currentTouch);
	}

	private void OnFingerMove(Finger finger)
	{
		onMove?.Invoke(finger.currentTouch);
	}

	private void OnFingerUp(Finger finger)
	{
		onReleased?.Invoke(finger.currentTouch);
	}


	// Dispose
	private void OnDisable()
	{
		ETouch.onFingerDown -= OnFingerDown;
		ETouch.onFingerMove -= OnFingerMove;
		ETouch.onFingerUp -= OnFingerUp;

		EnhancedTouchSupport.Disable();
	}

	// TODO: Move to an extension
	public bool IsCurrentTouchOverUI()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	public bool IsTouchOverUI(ETouch eTouch)
	{
		return EventSystem.current.IsPointerOverGameObject(eTouch.touchId);
	}

	public bool IsPositionInsideScreen(ETouch eTouch)
	{
		return Screen.safeArea.Contains(eTouch.screenPosition);
	}
}


#if UNITY_EDITOR

#pragma warning disable 0414

public sealed partial class TouchControllerPersistentSingleton
{ }

#pragma warning restore 0414

#endif
