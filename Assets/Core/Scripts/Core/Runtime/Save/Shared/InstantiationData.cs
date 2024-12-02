using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
[JsonObject(MemberSerialization.OptIn)]
public sealed class InstantiationData : SaveDataBase, ICopyable<InstantiationData>
{
	[JsonProperty]
	[SerializeField]
	public AssetReference instantiationAssetReference;

	[JsonProperty]
	public (Vector3 worldPosition, Quaternion worldRotation) instantiationParams;

	[JsonProperty]
	public HashSet<string> childInstantiationDataRefsSet = new();


	// Initialize
	public InstantiationData()
	{ }


	// Update
	public override void Copy(in object other)
	{
		if (other is InstantiationData same)
			Copy(same);
	}

	public void Copy(in InstantiationData other)
	{
		this.instantiationAssetReference = (other.instantiationAssetReference != null) ? new (other.instantiationAssetReference.AssetGUID) : null;
		this.instantiationParams = other.instantiationParams;
		this.childInstantiationDataRefsSet = new(other.childInstantiationDataRefsSet);
	}
}