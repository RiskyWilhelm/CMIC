using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <remarks> Uses <see cref="System.Linq"/> </remarks>
public static class SceneUtils
{
	/// <summary> The difference from <see cref="UnityEngine.Object.FindObjectsByType{T}(FindObjectsInactive, FindObjectsSortMode)"/> is, this one accepts any type rather than <see cref="UnityEngine.Object"/> </summary>
	public static IEnumerable<T> FindObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode)
	{
		return UnityEngine.Object.FindObjectsByType<MonoBehaviour>(findObjectsInactive, sortMode).OfType<T>();
	}

	public static IEnumerable<T> FindObjectsOfTypeInSpecificScene<T>(Scene loadedScene, bool includeInactive = false)
	{
		return loadedScene.GetRootGameObjects().SelectMany(iteratedGameObject => iteratedGameObject.GetComponentsInChildren<T>(includeInactive));
	}

	public static IEnumerable<T> FindObjectsOfTypeInSpecificScene<T>(string loadedSceneName, bool includeInactive = false)
	{
		return FindObjectsOfTypeInSpecificScene<T>(SceneManager.GetSceneByName(loadedSceneName), includeInactive);
	}

	public static IEnumerable<T> FindObjectsOfTypeInSpecificScenes<T>(IEnumerable<Scene> loadedScenes, bool includeInactive = false)
	{
		return Enumerable.SelectMany(loadedScenes, iteratedLoadedScene => FindObjectsOfTypeInSpecificScene<T>(iteratedLoadedScene, includeInactive));
	}

	public static IEnumerable<T> FindObjectsOfTypeInSpecificScenes<T>(IEnumerable<string> loadedSceneIndexes, bool includeInactive = false)
	{
		return Enumerable.SelectMany(loadedSceneIndexes, iteratedLoadedSceneIndex => FindObjectsOfTypeInSpecificScene<T>(iteratedLoadedSceneIndex, includeInactive));
	}
}