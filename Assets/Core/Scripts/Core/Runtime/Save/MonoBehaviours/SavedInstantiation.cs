using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[DisallowMultipleComponent]
public sealed partial class SavedInstantiation : MonoBehaviourSaveDataControllerBase<InstantiationData>
{
	[Header("SavedInstantiation Data")]
	#region SavedInstantiation Data

	[Tooltip("Set to true if you want only initialization.\n" +
		"true: Prevents itself from getting attached to others and loads last instances via Awake() method.\n" +
		"false: An instance that would be lost if it had no handler")]
	public bool isRootData;

	private SavedInstantiation _parentHandler;

	private AsyncOperationHandle<GameObject> _addressableHandle;

	public SavedInstantiation ParentHandler
		=> _parentHandler;

	public AsyncOperationHandle<GameObject> AddressableHandle
		=> _addressableHandle;


	#endregion


	// Initialize
	protected override void Awake()
	{
		if (isRootData)
			LoadFromGameData();
	}

	protected override void LoadFromGameData()
	{
		if (_isLoadedData)
			return;

		base.LoadFromGameData();
		InstantiateLastChildren();
	}

	private void InstantiateLastChildren()
	{
		foreach (var iteratedChildGuid in _data.childInstantiationDataRefsSet)
		{
			var childData = SaveDataFileControllerSingleton.JData[iteratedChildGuid].ToObject<InstantiationData>();
			var handle = Addressables.InstantiateAsync(childData.instantiationAssetReference, childData.instantiationParams.worldPosition, childData.instantiationParams.worldRotation, trackHandle: true);

			handle.Completed +=
				(handle) => InitializeInstantiated(handle, childData, iteratedChildGuid);
		}
	}

	private void InitializeInstantiated(AsyncOperationHandle<GameObject> handle, InstantiationData data, string gameDataGuid)
	{
		var isSucceeded = (handle.Status == AsyncOperationStatus.Succeeded);
		if (!isSucceeded)
		{
			handle.Release();
			return;
		}

		var isInstantiatedCorrectType = handle.Result.TryGetComponent<SavedInstantiation>(out SavedInstantiation instantiated);
		if (!isInstantiatedCorrectType)
		{
			Debug.LogErrorFormat("AssetReference root does not contains {0}. Releasing the handle", nameof(SavedInstantiation));
			handle.Release();
			return;
		}

		instantiated.gameDataGuid = gameDataGuid;
		instantiated._data = data;
		instantiated._addressableHandle = handle;
		instantiated.AttachToHandler(this);
		instantiated.LoadFromGameData();
	}


	// Update
	public void AttachToHandler(SavedInstantiation newParentHandler)
	{
		if (isRootData)
			throw new ($"You cannot attach root data '{this.gameDataGuid}' to any handler");

		if (_parentHandler)
			_parentHandler.Data.childInstantiationDataRefsSet.Remove(gameDataGuid);

		if (newParentHandler)
		{
			newParentHandler.Data.childInstantiationDataRefsSet.Add(gameDataGuid);
			this.transform.SetParent(newParentHandler.transform, true);
		}
		else
			this.transform.SetParent(null);

		_parentHandler = newParentHandler;
	}
}


#if UNITY_EDITOR

public sealed partial class SavedInstantiation
{ }


#endif
