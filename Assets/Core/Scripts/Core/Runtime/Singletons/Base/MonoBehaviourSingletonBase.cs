using System;
using UnityEngine;

[DisallowMultipleComponent]
public abstract partial class MonoBehaviourSingletonBase<SingletonType> : MonoBehaviour
    where SingletonType : MonoBehaviourSingletonBase<SingletonType>
{
    private static SingletonType _instance;

    public static SingletonType Instance
    {
        get
        {
			if (GameControllerPersistentSingleton.IsQuitting)
				throw new Exception(string.Format("Cannot access {0} when quitting the game." +
					" You are probably trying to instantiate or access in OnDestroy() or OnDisable(). You should fix your script.", typeof(SingletonType).Name));

			if (_instance == null)
                FindOrTryCreateSingleton();

            return _instance;
        }
    }

    public static bool IsAnyInstanceLiving
        => IsCurrentInstanceLiving || FindFirstObjectByType<SingletonType>(findObjectsInactive: FindObjectsInactive.Include);

    public static bool IsCurrentInstanceLiving
        => (_instance != null);

	public virtual string SingletonGOName
        => typeof(SingletonType).Name;


	// Initialize
	protected virtual void Awake()
    {
        if ((_instance != null) && (_instance != this))
        {
            Debug.LogErrorFormat("An instance of {0} is already living. Destroying duplicate...", typeof(SingletonType).Name);
            DestroyImmediate(this.gameObject);
            return;
        }

		_instance = (this as SingletonType);
    }


	// Update
	/// <summary> Creates by checking the state of game </summary>
	public static void TryCreateSingleton()
    {
        if (IsAnyInstanceLiving || GameControllerPersistentSingleton.IsQuitting || SceneControllerPersistentSingleton.IsActiveSceneChanging)
        {
            throw new Exception(string.Format("Cant create Singleton {0}." +
                " You are probably trying to instantiate or access in OnDestroy() or OnDisable()." +
				" This occurs when changing scenes nor quitting the game or when there is a living instance exists. You should fix your script.", typeof(SingletonType).Name));
        }

        CreateSingleton();
	}

	/// <summary> Creates without checking the state of game </summary>
    public static void CreateSingleton()
    {
        _instance = new GameObject(typeof(SingletonType).Name, typeof(SingletonType)).GetComponent<SingletonType>();
		_instance.name = _instance.SingletonGOName;

#if UNITY_EDITOR
		if (!Application.isPlaying)
			_instance.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
#endif
    }

    public static void FindOrTryCreateSingleton()
    {
		// Try to find
		if (_instance == null)
            _instance = FindFirstObjectByType<SingletonType>(findObjectsInactive: FindObjectsInactive.Include);

        // If still cant find, try to create
        if (_instance == null)
            TryCreateSingleton();
    }


	// Dispose
	protected static void DestroyAllInstances()
    {
        foreach (var iteratedInstance in FindObjectsByType<SingletonType>(FindObjectsInactive.Include, sortMode: FindObjectsSortMode.None))
            DestroyImmediate(iteratedInstance.gameObject);
    }
}


#if UNITY_EDITOR

public abstract partial class MonoBehaviourSingletonBase<SingletonType>
{ }

#endif