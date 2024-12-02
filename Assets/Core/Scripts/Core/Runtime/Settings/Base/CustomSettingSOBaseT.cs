using UnityEngine;

public abstract partial class CustomSettingSOBaseT<SettingsType> : CustomSettingSOBase
	where SettingsType : CustomSettingSOBaseT<SettingsType>
{
	private static SettingsType _privateInstance;

	protected static SettingsType PrivateInstance
	{
		get => _privateInstance ?? GetOrDefaultSettings();
		private set => _privateInstance = value;
	}


	// Update
	public static SettingsType GetOrDefaultSettings()
	{
		if ((_privateInstance == null) && !TryGetSetting<SettingsType>(out _privateInstance))
		{
			Debug.LogWarning($"{typeof(SettingsType).Name} not found. Continuing with default settings...");
			_privateInstance = ScriptableObject.CreateInstance<SettingsType>();
		}

		return _privateInstance;
	}
}

#if UNITY_EDITOR

public abstract partial class CustomSettingSOBaseT<SettingsType>
{ }


#endif