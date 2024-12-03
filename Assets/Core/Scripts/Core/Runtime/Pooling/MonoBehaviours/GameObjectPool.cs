using System;
using UnityEngine;

public sealed partial class GameObjectPool : MonoBehaviourPoolBase<GameObject>
{
    // Start
    protected override GameObject OnCreatePooledObject()
    {
        throw new Exception($"This pool does not supports creation due to instantiation parameters. You must instantiate manually and use {nameof(MainPool.Release)}");
    }

    protected override void OnGetPooledObject(GameObject pooledObject)
    { }


    // Update


    // Dispose
    protected override void OnReleasePooledObject(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
    }

    protected override void OnDestroyPooledObject(GameObject pooledObject)
    {
        GameObject.Destroy(pooledObject);
    }
}

#if UNITY_EDITOR

public sealed partial class GameObjectPool
{}

#endif
