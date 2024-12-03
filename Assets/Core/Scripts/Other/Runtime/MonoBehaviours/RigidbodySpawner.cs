using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed partial class RigidbodySpawner : MonoBehaviour
{
	[Header("RigidbodySpawner Spawn")]
	#region RigidbodySpawner Spawn

	[SerializeField]
	private AssetReference assetRef;

	public bool isPushWorldAxis;

	public Vector3 pushForce;


	#endregion


	// Update
	[ContextMenu(nameof(Spawn))]
	public void Spawn()
	{
		Addressables.InstantiateAsync(assetRef, this.transform.position, this.transform.rotation).Completed += OnSpawnCompleted;
	}

	private void OnSpawnCompleted(AsyncOperationHandle<GameObject> handle)
	{
		if (handle.Status is not AsyncOperationStatus.Succeeded)
		{
			handle.Release();
			return;
		}

		var isInstantiatedCorrectType = handle.Result.TryGetComponent<Rigidbody>(out Rigidbody instantiated);
		if (!isInstantiatedCorrectType)
		{
			Debug.LogErrorFormat("AssetReference root does not contains {0}. Releasing the handle", nameof(Rigidbody));
			handle.Release();
			return;
		}

		PushInstantiated(instantiated);
	}

	private void PushInstantiated(Rigidbody instantiated)
	{
		if (isPushWorldAxis)
			instantiated.AddForce(pushForce, ForceMode.VelocityChange);
		else
			instantiated.AddForce(this.transform.rotation * pushForce, ForceMode.VelocityChange);
	}
}


#if UNITY_EDITOR

public sealed partial class RigidbodySpawner
{
	[Header("RigidbodySpawner Edit")]
	[RenameLabelTo("Interactive Editing")]
	public bool e_IsActivatedInteractiveEditing;
}


#endif
