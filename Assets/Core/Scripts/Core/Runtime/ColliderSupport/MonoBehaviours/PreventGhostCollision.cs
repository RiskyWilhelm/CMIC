using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Pool;

/// <remarks> Colliders must provice contact and have configurable contacts </remarks>
public sealed partial class PreventGhostCollision : MonoBehaviour
{
    #region PreventGhostCollision Settings

    [SerializeField]
    private Rigidbody selfRigidbody;

    [SerializeField]
    private PreventGhostCollisionType preventGhostCollisionType = PreventGhostCollisionType.Simple;


    #endregion


    // Start
    private void OnEnable()
    {
        var cachedList = ListPool<Collider>.Get();
        GetComponentsInChildren<Collider>(cachedList);

        foreach (var iteratedCollider in cachedList)
        {
            iteratedCollider.providesContacts = true;
            iteratedCollider.hasModifiableContacts = true;
        }

        Physics.ContactModifyEvent += PreventGhostBumpsCCD;
        ListPool<Collider>.Release(cachedList);
    }

    private void PreventGhostBumpsCCD(PhysicsScene scene, NativeArray<ModifiableContactPair> contactPairs)
    {
        switch (preventGhostCollisionType)
        {
            case PreventGhostCollisionType.Simple:
                SimplePrevention(contactPairs);
            return;
        }
    }

    private void SimplePrevention(NativeArray<ModifiableContactPair> ballContactPairs)
    {
        foreach (ModifiableContactPair pair in ballContactPairs)
        {
            if (pair.bodyInstanceID != selfRigidbody.GetInstanceID())
                continue;

            for (int i = 0; i < pair.contactCount; i++)
            {
                if (pair.GetSeparation(i) > 0)
                    pair.SetNormal(i, Vector3.up);
            }
        }
    }


    // Update


    // Dispose
    private void OnDisable()
    {
        Physics.ContactModifyEvent -= PreventGhostBumpsCCD;
    }
}

#if UNITY_EDITOR

public sealed partial class PreventGhostCollision
{}

#endif
