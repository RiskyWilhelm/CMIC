using UnityEngine;

public sealed partial class FragmentSpawner : MonoBehaviour
{
    #region FragmentSpawner Settings

    [SerializeField]
    private RigidbodySpawner rigidbodySpawner;

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
            rigidbodySpawner.transform.position = randomnessCollider.GetRandomPoint();
            rigidbodySpawner.Spawn();
        }
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class FragmentSpawner
{}

#endif
