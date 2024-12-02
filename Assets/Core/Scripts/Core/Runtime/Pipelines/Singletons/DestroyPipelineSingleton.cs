using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public sealed partial class DestroyPipelineSingleton : MonoBehaviourSingletonBase<DestroyPipelineSingleton>
{
	private static readonly Dictionary<Object, HashSet<IBeforeDestroyListener>> onBeforeDestroyListenersDict = new();


	// Update
	private void LateUpdate()
	{
		var cachedDict = DictionaryPool<Object, HashSet<IBeforeDestroyListener>>.Get();

        foreach (var iteratedOnBeforeDestroyPair in onBeforeDestroyListenersDict)
			cachedDict[iteratedOnBeforeDestroyPair.Key] = iteratedOnBeforeDestroyPair.Value;

        foreach (var iteratedOnBeforeDestroyPair in cachedDict)
        {
			var iteratedObject = iteratedOnBeforeDestroyPair.Key;
			if (!iteratedObject)
			{
				Debug.LogWarningFormat("A destroyed object is detected. You should use pipeline to destroy objects if you listen {0}. Therefore, using pipeline for destroying always is recommended", nameof(IBeforeDestroyListener.OnBeforeDestroy));
				onBeforeDestroyListenersDict.Remove(iteratedObject);
			}
        }

		DictionaryPool<Object, HashSet<IBeforeDestroyListener>>.Release(cachedDict);
	}

	public void Listen(IBeforeDestroyListener listener, Object other)
	{
		var initializedValue = onBeforeDestroyListenersDict.ContainsKey(other);
		if (!initializedValue)
			onBeforeDestroyListenersDict[other] = new HashSet<IBeforeDestroyListener>();

		onBeforeDestroyListenersDict[other].Add(listener);
	}

	public void StopListening(IBeforeDestroyListener listener, Object other)
	{
		var hasListeners = onBeforeDestroyListenersDict.TryGetValue(other, out HashSet<IBeforeDestroyListener> listenersSet);
		if (hasListeners)
			listenersSet.Remove(listener);
	}

	private void NotifyOnBeforeDestroy(Object willGetDestroyObj)
	{
		var hasListeners = onBeforeDestroyListenersDict.TryGetValue(willGetDestroyObj, out HashSet<IBeforeDestroyListener> listenersSet);
		if (hasListeners)
			foreach (var iteratedListener in listenersSet)
			{
				try
				{
					iteratedListener.OnBeforeDestroy(willGetDestroyObj);
				}
				catch (Exception e)
				{
					Debug.LogException(e);
				}
			}
	}

	/// <summary> Calls <see cref="IBeforeDestroyListener.OnBeforeDestroy(Object)"/> </summary>
	public new void Destroy(Object destroyObj, float t)
	{
		NotifyOnBeforeDestroy(destroyObj);
		onBeforeDestroyListenersDict.Remove(destroyObj);
		Object.Destroy(destroyObj, t);
	}

	/// <inheritdoc cref="Destroy(Object, float)"/>
	public new void Destroy(Object destroyObj)
		=> Destroy(destroyObj, 0f);

	/// <summary> Calls <see cref="IBeforeDestroyListener.OnBeforeDestroy(Object)"/> </summary>
	public new void DestroyImmediate(Object destroyObj, bool allowDestroyingAssets)
	{
		NotifyOnBeforeDestroy(destroyObj);
		onBeforeDestroyListenersDict.Remove(destroyObj);
		Object.DestroyImmediate(destroyObj, allowDestroyingAssets);
	}

	/// <inheritdoc cref="DestroyImmediate(Object, bool)"/>
	public new void DestroyImmediate(Object destroyObj)
		=> DestroyImmediate(destroyObj, false);
}


#if UNITY_EDITOR

public partial class DestroyPipelineSingleton
{ }

#endif