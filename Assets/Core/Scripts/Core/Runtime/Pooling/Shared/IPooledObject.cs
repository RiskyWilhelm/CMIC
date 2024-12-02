public interface IPooledObject<PooledObjectType>
	where PooledObjectType : class
{
	public IPool<PooledObjectType> ParentPool { get; set; }


	public void OnTakenFromPool(IPool<PooledObjectType> pool);

	public void OnReleasedToPool(IPool<PooledObjectType> pool);
}

public interface IMonoBehaviourPooledObject<PooledObjectType> : IPooledObject<PooledObjectType>
	where PooledObjectType : class
{
	public void ReleaseOrDestroySelf();
}