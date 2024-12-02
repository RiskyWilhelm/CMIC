using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class GameObjectExtensions
{
	public static void GetComponents<T>(this GameObject a, bool includeInactiveComponents, List<T> results)
	{
		a.GetComponents<T>(results);

		if (!includeInactiveComponents)
			results.RemoveAll((c) => (c is Behaviour b) && !b.enabled);
	}

	public static void SendMessageMultiple(this GameObject a, string methodName, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1>(this GameObject a, string methodName, T1 t1, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2>(this GameObject a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponents(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void SendMessageMultipleUpwards(this GameObject a, string methodName, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1>(this GameObject a, string methodName, T1 t1, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2>(this GameObject a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
	{
		Transform tranform = a.transform;
		while (tranform != null)
		{
			tranform.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, includeInactiveComponents);
			tranform = tranform.parent;
		}
	}

	public static void BroadcastMessageMultiple(this GameObject a, string methodName, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1>(this GameObject a, string methodName, T1 t1, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2>(this GameObject a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this GameObject a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
	{
		var cachedList = ListPool<Component>.Get();

		try
		{
			a.GetComponentsInChildren<Component>(includeInactiveComponents, cachedList);

			foreach (var iteratedComponent in cachedList)
				iteratedComponent.InvokeIfExists(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}
		finally
		{
			ListPool<Component>.Release(cachedList);
		}
	}
}