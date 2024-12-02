using Newtonsoft.Json;
using System;

public abstract class SaveDataBase : ICopyable
{
	[JsonProperty("@version", Required = Required.Always)]
	private readonly Version version = new ();


	// Initialize
	public SaveDataBase()
	{}


	// Update
	public virtual void Copy(in object other)
	{ }
}