using Newtonsoft.Json.Linq;
using System;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class MonoBehaviourSaveDataControllerBase : MonoBehaviour
{
	[Header("MonoBehaviourSaveDataControllerBase Data")]
	#region MonoBehaviourSaveDataControllerBase Data

	[SerializeField]
	[Guid]
	protected string gameDataGuid = Guid.NewGuid().ToString();

	protected bool _isLoadedData;

	public abstract SaveDataBase RawData
	{ get; protected set; }

	public bool IsLoadedData
		=> _isLoadedData;


	#endregion

	[Header("MonoBehaviourSaveDataControllerBase Events")]
	#region MonoBehaviourSaveDataControllerBase Events

	public UnityEvent<SaveDataBase> onLoadedData = new();


	#endregion


	// Initialize
	protected virtual void Awake()
	{
		LoadFromGameData();
	}

	protected virtual void LoadFromGameData()
	{
		if (_isLoadedData)
			return;

		var isFoundLastSave = SaveDataFileControllerSingleton.JData.TryGetValue(gameDataGuid, out JToken found);
		if (isFoundLastSave)
		{
			CheckJsonDataVersion();
			RawData = found.ToObject<SaveDataBase>();
		}
		else
			SaveDataFileControllerSingleton.RegisterDataUpdate(gameDataGuid, RawData);

		_isLoadedData = true;
		onLoadedData?.Invoke(RawData);
	}


	// Update
	protected void CheckJsonDataVersion()
	{
		var isFoundLastSave = SaveDataFileControllerSingleton.JData.TryGetValue(gameDataGuid, out JToken found);
		if (!isFoundLastSave)
			return;

		var gameVersion = GameControllerPersistentSingleton.AppVersion;
		var dataVersion = found["@version"].ToObject<Version>();

        if (dataVersion == VersionUtils.empty)
			found["@version"] = Application.version;
        else if (gameVersion > dataVersion)
			OnOldJsonDataVersionDetected(dataVersion);
		else if (gameVersion < dataVersion)
			OnNewJsonDataVersionDetected(dataVersion);
	}

	protected virtual void OnOldJsonDataVersionDetected(Version dataVersion)
	{
		Debug.LogWarning("A data that belongs to old version detected. Please consider overriding the OnOldJsonDataVersionDetected() and OnNewJsonDataVersionDetected() methods");
	}

	protected virtual void OnNewJsonDataVersionDetected(Version dataVersion)
	{
		Debug.LogWarning("A data that belongs to old version detected. Please consider overriding the OnOldJsonDataVersionDetected() and OnNewJsonDataVersionDetected() methods");
	}

	public void RemoveFromGameData()
	{
		SaveDataFileControllerSingleton.JData.Remove(gameDataGuid);
		SaveDataFileControllerSingleton.UnRegisterDataUpdate(gameDataGuid);
	}
}

public abstract partial class MonoBehaviourSaveDataControllerBase<ControlledDataType> : MonoBehaviourSaveDataControllerBase
	where ControlledDataType : SaveDataBase, new()
{
	[Header("MonoBehaviourSaveDataControllerBase<ControlledDataType> Data")]
	#region MonoBehaviourSaveDataControllerBase<ControlledDataType> Data

	[SerializeField]
	[Tooltip("You can set initial data here. These will be discarded after first save.\n" +
		"REMINDER: If you change these, you should consider game updates by overriding OnOldJsonDataVersionDetected() && OnNewJsonDataVersionDetected")]
	protected ControlledDataType _data = new();

	public override SaveDataBase RawData
	{
		get => _data;
		protected set
		{
			if (!value.GetType().IsAssignableFrom(typeof(ControlledDataType)))
				throw new ArgumentException($"New value should be same as type {typeof(ControlledDataType).Name}, or derive from type {typeof(ControlledDataType).Name}");
			
			_data = (value as ControlledDataType);
		}
	}

	/// <summary> Whenever gets accessed, assumes its inner data are got overridden </summary>
	public ControlledDataType Data
	{
		get
		{
			SaveDataFileControllerSingleton.RegisterDataUpdate(gameDataGuid, _data);
			return _data;
		}
	}


	#endregion
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourSaveDataControllerBase
{ }


#endif
