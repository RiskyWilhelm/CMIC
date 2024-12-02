using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

// TODO: Make events global with custom event system
public sealed partial class SaveDataFileControllerSingleton : MonoBehaviourSingletonBase<SaveDataFileControllerSingleton>
{
	[Header("SaveDataFileControllerSingleton Events")]
	#region SaveDataFileControllerSingleton Events

	public UnityEvent onLoaded = new();

	public UnityEvent onSaving = new();

	public UnityEvent onSaved = new();

	public UnityEvent onCorruptedExceptionThrown = new();


	#endregion

	#region SaveDataFileControllerSingleton Data

	private static JObject _jData;

	private static readonly Dictionary<string, SaveDataBase> updatedDatasDict = new();

	public static JObject JData
	{
		get
		{
			if (_jData == null)
				Instance.LoadFromFile();

			return _jData;
		}
	}

	public static string FullSavePath
		=> Path.Combine(Application.persistentDataPath, "MainSave.json");


	#endregion


	// Update
	public void LoadFromFile()
    {
		try
		{
			IOUtils.Load(FullSavePath, out var found);
			_jData = JObject.Parse(found);
			onLoaded?.Invoke();
		}
		catch
		{
			UseFreshSave();
			throw;
		}
    }

    public void SaveToFile()
    {
		onSaving?.Invoke();

		// Apply changes
		foreach (var iteratedData in updatedDatasDict)
		{
			var gameDataGuid = iteratedData.Key;
			var updatedData = iteratedData.Value;
			JData[gameDataGuid] = JValue.FromObject(updatedData);
		}
		updatedDatasDict.Clear();

		IOUtils.Save(_jData.ToString(Newtonsoft.Json.Formatting.Indented), FullSavePath);
		onSaved?.Invoke();
    }

	public void DeleteFile()
	{
		IOUtils.Delete(FullSavePath);
	}

	public void UseFreshSave()
	{
		_jData = JObject.Parse(@"{ }");
		onLoaded?.Invoke();
	}

	public static void RegisterDataUpdate(string guid, SaveDataBase data)
	{
		updatedDatasDict[guid] = data;
	}

	public static void UnRegisterDataUpdate(string guid)
	{
		updatedDatasDict.Remove(guid);
	}
}


#if UNITY_EDITOR

public sealed partial class SaveDataFileControllerSingleton
{ }

#endif