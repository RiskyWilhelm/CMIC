using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class ComponentExtensions
{
	public static void GetComponents<T>(this Component a, bool includeInactiveComponents, List<T> results)
		=> a.gameObject.GetComponents<T>(includeInactiveComponents, results);

	public static void SendMessageMultiple(this Component a, string methodName, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, includeInactiveComponents);

	public static void SendMessageMultiple<T1>(this Component a, string methodName, T1 t1, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2>(this Component a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, includeInactiveComponents);

	public static void SendMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, includeInactiveComponents);

	public static void SendMessageMultipleUpwards(this Component a, string methodName, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1>(this Component a, string methodName, T1 t1, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2>(this Component a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, includeInactiveComponents);

	public static void SendMessageMultipleUpwards<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
		=> a.gameObject.SendMessageMultipleUpwards(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, includeInactiveComponents);

	public static void BroadcastMessageMultiple(this Component a, string methodName, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1>(this Component a, string methodName, T1 t1, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2>(this Component a, string methodName, T1 t1, T2 t2, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, includeInactiveComponents);

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, includeInactiveComponents);
	

	public static void BroadcastMessageMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Component a, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, bool includeInactiveComponents = false)
		=> a.gameObject.BroadcastMessageMultiple(methodName, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, includeInactiveComponents);

}