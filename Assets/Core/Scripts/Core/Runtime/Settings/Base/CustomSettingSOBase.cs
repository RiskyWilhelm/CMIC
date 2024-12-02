using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

/// <summary> Base class for every custom setting </summary>
public abstract partial class CustomSettingSOBase : ScriptableObject
{
	private static readonly Dictionary<Type, CustomSettingSOBase> loadedSettingsDict = new();


	// Initialize
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnBeforeSceneLoad()
	{
		Resources.LoadAll<CustomSettingSOBase>("");
	}

	protected virtual void OnEnable()
	{
		RegisterOrDestroySetting();
	}


	// Update
	private void RegisterOrDestroySetting()
	{
		if (loadedSettingsDict.ContainsValue(this))
			return;

		var isSingleInstanced = loadedSettingsDict.TryAdd(this.GetType(), this);
		if (!isSingleInstanced)
		{
			Debug.LogErrorFormat("Only single {0} can live", this.GetType().Name);
			DeleteAssetOrDestroy();
		}
	}

	private void UnRegisterSetting()
	{
		if (loadedSettingsDict.ContainsValue(this))
			loadedSettingsDict.Remove(this.GetType());
	}

	public static bool TryGetSetting<SettingsType>(out SettingsType found)
		where SettingsType : CustomSettingSOBase
	{
		found = (loadedSettingsDict[typeof(SettingsType)] as SettingsType);
		return (found != null);
	}

	private void DeleteAssetOrDestroy()
	{
#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			DeleteSelfAsset();
			return;
		}
#endif

		UnRegisterSetting();
		Destroy(this);
	}


	// Dispose
	private void OnDisable()
	{
		UnRegisterSetting();
	}
}


#if UNITY_EDITOR

public abstract partial class CustomSettingSOBase
{
	public void OnCreatedAsset()
	{
		RegisterOrDestroySetting();
	}

	public void OnWillDeletedAsset()
	{
		UnRegisterSetting();
	}

	public void OnWillMoveAsset()
	{ }

	private void DeleteSelfAsset()
	{
		var assetPath = AssetDatabase.GetAssetPath(this);

		if (!string.IsNullOrEmpty(assetPath))
			AssetDatabase.DeleteAsset(assetPath);
	}
}


#endif