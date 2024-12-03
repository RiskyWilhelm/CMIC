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
            rigidbodySpawner.transform.position = randomnessCollider.GetRandomPoint();
            rigidbodySpawner.Spawn();
            timer.Randomize();
        }
        else
            timer.Tick();
    }


    // Dispose
}

#if UNITY_EDITOR

public sealed partial class FragmentSpawner
{}

#endif
