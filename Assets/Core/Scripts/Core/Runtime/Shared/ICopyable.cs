public interface ICopyable
{
	public void Copy(in object other);
}

public interface ICopyable<T> : ICopyable
{
	public void Copy(in T other);
}