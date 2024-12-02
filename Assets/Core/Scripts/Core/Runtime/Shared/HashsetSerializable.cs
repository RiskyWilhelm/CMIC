using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class HashsetSerializable<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ISet<T>, IDeserializationCallback, ISerializable, ISerializationCallbackReceiver, IEquatable<HashsetSerializable<T>>, IEquatable<HashSet<T>>
{
	// Provides a public method for serialization
	private class CustomHashSet<TValue> : HashSet<TValue>
	{
		public CustomHashSet() : base() { }
		public CustomHashSet(IEnumerable<TValue> collection) : base(collection) { }
		public CustomHashSet(IEqualityComparer<TValue> comparer) : base(comparer) { }
		public CustomHashSet(int capacity) : base(capacity) { }
		public CustomHashSet(IEnumerable<TValue> collection, IEqualityComparer<TValue> comparer) : base(collection, comparer) { }
		public CustomHashSet(int capacity, IEqualityComparer<TValue> comparer) : base(capacity, comparer) { }
		public CustomHashSet(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}

	private readonly CustomHashSet<T> m_customHashSet;

	[SerializeField]
	private T[] m_keys;

	public int Count => m_customHashSet.Count;

	public bool IsReadOnly => ((ISet<T>)m_customHashSet).IsReadOnly;

	public IEqualityComparer<T> Comparer => m_customHashSet.Comparer;


	// Initialize
	public HashsetSerializable() => m_customHashSet = new CustomHashSet<T>();
	public HashsetSerializable(IEnumerable<T> collection) => m_customHashSet = new CustomHashSet<T>(collection);
	public HashsetSerializable(IEqualityComparer<T> comparer) => m_customHashSet = new CustomHashSet<T>(comparer);
	public HashsetSerializable(int capacity) => m_customHashSet = new CustomHashSet<T>(capacity);
	public HashsetSerializable(IEnumerable<T> collection, IEqualityComparer<T> comparer) => m_customHashSet = new CustomHashSet<T>(collection, comparer);
	public HashsetSerializable(int capacity, IEqualityComparer<T> comparer) => m_customHashSet = new CustomHashSet<T>(capacity, comparer);
	public HashsetSerializable(SerializationInfo info, StreamingContext context) => m_customHashSet = new CustomHashSet<T>(info, context);


	// Update
	public bool Add(T item) => m_customHashSet.Add(item);
	void ICollection<T>.Add(T item) => m_customHashSet.Add(item);
	public void Clear() => m_customHashSet.Clear();
	public bool Contains(T item) => m_customHashSet.Contains(item);
	public void CopyTo(T[] array) => m_customHashSet.CopyTo(array);
	public void CopyTo(T[] array, int arrayIndex) => m_customHashSet.CopyTo(array, arrayIndex);
	public void CopyTo(T[] array, int arrayIndex, int count) => m_customHashSet.CopyTo(array, arrayIndex, count);
	public int EnsureCapacity(int capacity) => m_customHashSet.EnsureCapacity(capacity);
	public void ExceptWith(IEnumerable<T> other) => m_customHashSet.ExceptWith(other);
	public HashSet<T>.Enumerator GetEnumerator() => m_customHashSet.GetEnumerator(); // Necessary implementation to prevent garbage allocation
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context) => m_customHashSet.GetObjectData(info, context);
	public void IntersectWith(IEnumerable<T> other) => m_customHashSet.IntersectWith(other);
	public bool IsProperSubsetOf(IEnumerable<T> other) => m_customHashSet.IsProperSubsetOf(other);
	public bool IsProperSupersetOf(IEnumerable<T> other) => m_customHashSet.IsProperSupersetOf(other);
	public bool IsSubsetOf(IEnumerable<T> other) => m_customHashSet.IsSubsetOf(other);
	public bool IsSupersetOf(IEnumerable<T> other) => m_customHashSet.IsSupersetOf(other);
	public virtual void OnDeserialization(object sender) => m_customHashSet.OnDeserialization(sender);
	public bool Overlaps(IEnumerable<T> other) => m_customHashSet.Overlaps(other);
	public bool Remove(T item) => m_customHashSet.Remove(item);
	public int RemoveWhere(Predicate<T> match) => m_customHashSet.RemoveWhere(match);
	public bool SetEquals(IEnumerable<T> other) => m_customHashSet.SetEquals(other);
	public void SymmetricExceptWith(IEnumerable<T> other) => m_customHashSet.SymmetricExceptWith(other);
	public void TrimExcess() => m_customHashSet.TrimExcess();
	public bool TryGetValue(T equalValue, out T actualValue) => m_customHashSet.TryGetValue(equalValue, out actualValue);
	public void UnionWith(IEnumerable<T> other) => m_customHashSet.UnionWith(other);

	public void CopyFrom(ISet<T> set)
	{
		m_customHashSet.Clear();

		// Ensure clearing all the memory including buckets
		m_customHashSet.TrimExcess();

		foreach (var value in set)
			m_customHashSet.Add(value);
	}

	public void OnBeforeSerialize()
	{
		// Adding one to let user add single non-null reference
		m_keys = new T[m_customHashSet.Count + 1];

		int i = 0;
		foreach (var value in m_customHashSet)
		{
			m_keys[i] = value;
			++i;
		}
	}

	public void OnAfterDeserialize()
	{
		if (m_keys != null)
		{
			m_customHashSet.Clear();

			// Ensure clearing all the memory including buckets
			m_customHashSet.TrimExcess();

			foreach (var key in m_keys)
			{
				if (key != null)
					m_customHashSet.Add(key);
			}

			m_keys = null;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is HashsetSerializable<T> or HashSet<T>))
			return false;

		if (obj is HashSet<T>)
			return Equals(obj as HashSet<T>);

		return Equals(obj as HashsetSerializable<T>);
	}

	public bool Equals(HashSet<T> other)
	{
		return other is not null &&
			   m_customHashSet.Equals(other);
	}

	public bool Equals(HashsetSerializable<T> other)
	{
		return other is not null &&
			   Equals(other.m_customHashSet);
	}

	public override int GetHashCode()
	{
		return m_customHashSet.GetHashCode();
	}

	public static bool operator ==(HashsetSerializable<T> left, HashsetSerializable<T> right)
	{
		return left.Equals(right);
	}

	public static bool operator ==(HashsetSerializable<T> left, HashSet<T> right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HashsetSerializable<T> left, HashsetSerializable<T> right)
	{
		return !(left == right);
	}

	public static bool operator !=(HashsetSerializable<T> left, HashSet<T> right)
	{
		return !(left == right);
	}
}