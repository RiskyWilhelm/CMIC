/// <summary> Does nothing in special. Just a contract for the methods </summary>
public interface ISaveDataRequester
{
	public void OverrideCurrentData();
}

/// <inheritdoc cref="ISaveDataRequester"/>
public interface ISaveDataRequester<DataType> : ISaveDataRequester
	where DataType : SaveDataBase
{
	// WARNING: Support implementation for custom events
	public void OnLastDataLoaded(DataType loadedData);
}