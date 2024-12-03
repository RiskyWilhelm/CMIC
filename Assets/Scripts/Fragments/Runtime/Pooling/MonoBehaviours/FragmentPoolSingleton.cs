using System;
using UnityEngine;

public sealed partial class FragmentPoolSingleton : MonoBehaviourPoolSingletonBase<FragmentPoolSingleton, Fragment>
{
    // Start
    protected override Fragment OnCreatePooledObject()
    {
        throw new Exception("You need to create manually");
    }

    protected override void OnGetPooledObject(Fragment pooledObject)
    { }


    // Update


    // Dispose
    protected override void OnReleasePooledObject(Fragment pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    protected override void OnDestroyPooledObject(Fragment pooledObject)
    {
        GameObject.Destroy(pooledObject.gameObject);
    }
}

#if UNITY_EDITOR

public sealed partial class FragmentPoolSingleton
{}

#endif
