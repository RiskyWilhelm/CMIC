using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed partial class FragmentSpawner : MonoBehaviour
{
    #region FragmentSpawner Settings

    [SerializeField]
    private AssetReference fragmentReference;

    [SerializeField]
    private Collider randomnessCollider;

    [SerializeField]
    private Timer timer;


    #endregion


    // Start


    // Update
    private void Update()
    {
        if (timer.HasEnded)
        {
            GetOrSpawn();
            timer.Randomize();
        }
        else
            timer.Tick();
    }

    private void GetOrSpawn()
    {
        try
        {
            var fragment = FragmentPoolSingleton.Instance.Get();
            fragment.transform.position = randomnessCollider.GetRandomPoint();
            fragment.gameObject.SetActive(true);
        }
        catch
        {
            Addressables.InstantiateAsync(fragmentReference, randomnessCollider.GetRandomPoint(), Quaternion.identity).Completed += OnSpawnCompleted;
        }
    }

    private void OnSpawnCompleted(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status is not AsyncOperationStatus.Succeeded)
            handle.Release();
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class FragmentSpawner
{}

#endif
