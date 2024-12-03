using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public sealed partial class GameControllerPersistentSingleton : MonoBehaviourSingletonBase<GameControllerPersistentSingleton>
{
	[Header("GameControllerPersistentSingleton Events")]
	#region GameControllerPersistentSingleton Events

	[SerializeField]
	private UnityEvent onRestartGame = new();


	#endregion

	#region GameControllerPersistentSingleton States

	private static float lastTimeScaleBeforePause = 1f;

	private static Version _appVersion;

	public static Version AppVersion
		=> _appVersion ??= new (Application.version);

	public static AppVisibilityStateType VisibilityState
	{ get; private set; }

	public static bool IsQuitting
	{ get; private set; }

	public static bool IsPaused
		=> (Time.timeScale == 0);


	#endregion


	// Initialize
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
	private static void OnBeforeSplashScreen()
	{
		SceneManager.activeSceneChanged += OnActiveSceneChanged;
	}


	// Update
	public void PauseGame()
	{
		lastTimeScaleBeforePause = Time.timeScale;
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		if (IsPaused)
			Time.timeScale = lastTimeScaleBeforePause;
	}

	public void RestartGame()
	{
		onRestartGame?.Invoke();
		SceneControllerPersistentSingleton.Instance.RestartScene();
	}

	private static void OnActiveSceneChanged(Scene lastScene, Scene loadedScene)
	{
		if (!IsAnyInstanceLiving)
			CreateSingleton();
	}

#if UNITY_WEBGL && !UNITY_EDITOR

	private void OnVisibilityChange(string value) => VisibilityState = Enum.Parse<JSVisibilityStateType>(value, true);

	private void OnBeforeUnload() => IsQuitting = true;

	// TODO: In mobile, this should act like OnBeforeUnload. See: https://www.igvita.com/2015/11/20/dont-lose-user-and-app-state-use-page-visibility/
	private void OnPageHide(int isPersisted) => IsQuitting = true;

#else

	private void OnApplicationPause(bool pause)
	{
		if (pause)
			VisibilityState = AppVisibilityStateType.Hidden;
		else
			VisibilityState = AppVisibilityStateType.Visible;
	}

	private void OnApplicationQuit()
	{
		IsQuitting = true;
	}

#endif
}


#if UNITY_EDITOR

public sealed partial class GameControllerPersistentSingleton
{ }

#endif