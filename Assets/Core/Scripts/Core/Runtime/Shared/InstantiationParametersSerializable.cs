using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

[Serializable]
[JsonObject(MemberSerialization.OptIn)]
public struct InstantiationParametersSerializable
{
    [SerializeField]
    [JsonProperty]
    private Vector3 _position;

    [SerializeField]
    [JsonProperty]
    private Vector3 _rotation;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    [JsonProperty]
    private bool _instantiateInWorldPosition;

    [SerializeField]
    [JsonProperty]
    private bool _setPositionRotation;

	/// <summary> Position in world space to instantiate object. </summary>
	public Vector3 Position
    {
        get => _position;
    }
  
    /// <summary> Rotation in world space to instantiate object. </summary>
    public Quaternion Rotation
    {
		get => Quaternion.Euler(_rotation);
    }
  
    /// <summary> Transform to set as the parent of the instantiated object. </summary>
    public Transform Parent
    {
		get => parent;
    }

    /// <summary> When setting the parent Transform, this sets whether to preserve instance transform relative to world space or relative to the parent. </summary>
    public bool InstantiateInWorldPosition
    {
		get => _instantiateInWorldPosition;
    }
  
    /// <summary> Flag to tell the IInstanceProvider whether to set the position and rotation on new instances. </summary>
    public bool SetPositionRotation
    {
		get => _setPositionRotation;
    }

  
    /// <summary> Create a new InstantationParameters class that will set the parent transform and use the prefab transform. </summary>
    /// <param name="parent">Transform to set as the parent of the instantiated object.</param>
    /// <param name="instantiateInWorldPosition">Flag to tell the IInstanceProvider whether to set the position and rotation on new instances.</param>
    public InstantiationParametersSerializable(Transform parent, bool instantiateInWorldPosition)
    {
        _position = Vector3.zero;
        _rotation = Vector3.zero;
        this.parent = parent;
        _instantiateInWorldPosition = instantiateInWorldPosition;
        _setPositionRotation = false;
    }

  
    /// <summary> Create a new InstantationParameters class that will set the position, rotation, and Transform parent of the instance. </summary>
    /// <param name="position">Position relative to the parent to set on the instance.</param>
    /// <param name="rotation">Rotation relative to the parent to set on the instance.</param>
    /// <param name="parent">Transform to set as the parent of the instantiated object.</param>
    public InstantiationParametersSerializable(Vector3 position, Quaternion rotation, Transform parent)
    {
        _position = position;
        _rotation = rotation.eulerAngles;
        this.parent = parent;
        _instantiateInWorldPosition = false;
        _setPositionRotation = true;
    }

	public readonly T Instantiate<T>(T source)
        where T : UnityEngine.Object
	{
		T result;
		if (parent == null)
		{
			if (_setPositionRotation)
				result = UnityEngine.Object.Instantiate(source, _position, Quaternion.Euler(_rotation));
			else
				result = UnityEngine.Object.Instantiate(source);
		}
		else
		{
			if (_setPositionRotation)
				result = UnityEngine.Object.Instantiate(source, _position, Quaternion.Euler(_rotation), parent);
			else
				result = UnityEngine.Object.Instantiate(source, parent, _instantiateInWorldPosition);
		}

		return result;
	}

	public static implicit operator InstantiationParameters(InstantiationParametersSerializable instantiationParametersSerializable)
    {
        InstantiationParameters instantiationParameters;

		// Almost same as UnityEngine.ResourceManagement.ResourceProviders.InstantiationParameters.Instantiate() Method
		if (instantiationParametersSerializable.Parent == null)
        {
            if (instantiationParametersSerializable.SetPositionRotation)
                instantiationParameters = new InstantiationParameters(instantiationParametersSerializable.Position, instantiationParametersSerializable.Rotation, instantiationParametersSerializable.Parent);
            else
                instantiationParameters = new InstantiationParameters();
        }
        else
        {
            if (instantiationParametersSerializable.SetPositionRotation)
                instantiationParameters = new InstantiationParameters(instantiationParametersSerializable.Position, instantiationParametersSerializable.Rotation, instantiationParametersSerializable.Parent);
            else
                instantiationParameters = new InstantiationParameters(instantiationParametersSerializable.Parent, instantiationParametersSerializable.InstantiateInWorldPosition);
        }

        return instantiationParameters;
    }
}
