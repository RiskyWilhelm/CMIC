using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public sealed partial class ScreenControllerSingleton : MonoBehaviourSingletonBase<ScreenControllerSingleton>
{
	#region ScreenControllerSingleton Volume

	private readonly Dictionary<Volume, Coroutine> activeControlledVolumeWeightDict = new();


	#endregion


	// Update
	public Coroutine ChangeVolumeWeight(Volume volume, float startWeight, float targetWeight, float endTimeInSeconds = 1f, Action onEnded = null)
	{
		// Stop and remove old volume coroutine
		if (activeControlledVolumeWeightDict.ContainsKey(volume))
		{
			var lastVolumeCoroutine = activeControlledVolumeWeightDict[volume];

			if (lastVolumeCoroutine != null)
				StopCoroutine(lastVolumeCoroutine);

			activeControlledVolumeWeightDict.Remove(volume);
		}

		var volumeWeightCoroutine = StartCoroutine(ChangeVolumeweight_Internal(volume, startWeight, targetWeight, endTimeInSeconds, onEnded));
		activeControlledVolumeWeightDict.Add(volume, volumeWeightCoroutine);
		return volumeWeightCoroutine;
	}

	private IEnumerator ChangeVolumeweight_Internal(Volume volume, float startWeight, float targetWeight, float endTimeInSeconds, Action onEnded)
	{
		startWeight = Mathf.Clamp01(startWeight);
		targetWeight = Mathf.Clamp01(targetWeight);
		var fadeOutTimer = new Timer(endTimeInSeconds);

		// TODO: Timer progress used here
		while (!fadeOutTimer.HasEnded)
		{
			fadeOutTimer.Tick();
			var timerProgress = (fadeOutTimer.TickSecond - fadeOutTimer.CurrentSecond) / fadeOutTimer.TickSecond;

			volume.weight = Mathf.Lerp(startWeight, targetWeight, timerProgress);
			yield return null;
		}

		activeControlledVolumeWeightDict.Remove(volume);
		onEnded?.Invoke();
	}
}


#if UNITY_EDITOR

public sealed partial class ScreenControllerSingleton
{ }

#endif