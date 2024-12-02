using System.Reflection;
using System;
using System.Buffers;
using UnityEngine;
using System.Collections.Generic;

public static class ReflectionExtensions
{
	private static readonly Dictionary<int, Type[]> parameterTypeArrayDict = new();


	static ReflectionExtensions()
	{
        for (int i = 1; i <= 16; i++)
			parameterTypeArrayDict[i] = new Type[i];
    }

	public static bool TryGetMethod(this object objToCheck, string methodName, out MethodInfo methodInfo, Type[] parameterTypes = null)
	{
		methodInfo = objToCheck.GetType().GetMethod(
			methodName,
			(BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public),
			null,
			parameterTypes,
			null
		);

		return methodInfo != null;
	}

	public static void InvokeIfExists(this object objectToCheck, string methodName)
	{
		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo))
		{
			var method = (Action)methodInfo.CreateDelegate(typeof(Action), objectToCheck);
			method.Invoke();
		}
	}

	public static void InvokeIfExists<T1>(this object objectToCheck, string methodName, T1 t1)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1>)methodInfo.CreateDelegate(typeof(Action<T1>), objectToCheck);
			method.Invoke(t1);
		}
	}

	public static void InvokeIfExists<T1, T2>(this object objectToCheck, string methodName, T1 t1, T2 t2)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2>)methodInfo.CreateDelegate(typeof(Action<T1, T2>), objectToCheck);
			method.Invoke(t1, t2);
		}
	}

	public static void InvokeIfExists<T1, T2, T3>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3>), objectToCheck);
			method.Invoke(t1, t2, t3);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4>), objectToCheck);
			method.Invoke(t1, t2, t3, t4);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);
		cachedParameterTypeArray[11] = typeof(T12);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);
		cachedParameterTypeArray[11] = typeof(T12);
		cachedParameterTypeArray[12] = typeof(T13);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);
		cachedParameterTypeArray[11] = typeof(T12);
		cachedParameterTypeArray[12] = typeof(T13);
		cachedParameterTypeArray[13] = typeof(T14);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);
		cachedParameterTypeArray[11] = typeof(T12);
		cachedParameterTypeArray[12] = typeof(T13);
		cachedParameterTypeArray[13] = typeof(T14);
		cachedParameterTypeArray[14] = typeof(T15);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}
	}

	public static void InvokeIfExists<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object objectToCheck, string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
	{
		var cachedParameterTypeArray = parameterTypeArrayDict[1];
		cachedParameterTypeArray[0] = typeof(T1);
		cachedParameterTypeArray[1] = typeof(T2);
		cachedParameterTypeArray[2] = typeof(T3);
		cachedParameterTypeArray[3] = typeof(T4);
		cachedParameterTypeArray[4] = typeof(T5);
		cachedParameterTypeArray[5] = typeof(T6);
		cachedParameterTypeArray[6] = typeof(T7);
		cachedParameterTypeArray[7] = typeof(T8);
		cachedParameterTypeArray[8] = typeof(T9);
		cachedParameterTypeArray[9] = typeof(T10);
		cachedParameterTypeArray[10] = typeof(T11);
		cachedParameterTypeArray[11] = typeof(T12);
		cachedParameterTypeArray[12] = typeof(T13);
		cachedParameterTypeArray[13] = typeof(T14);
		cachedParameterTypeArray[14] = typeof(T15);
		cachedParameterTypeArray[15] = typeof(T16);

		if (TryGetMethod(objectToCheck, methodName, out MethodInfo methodInfo, cachedParameterTypeArray))
		{
			var method = (Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>)methodInfo.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>), objectToCheck);
			method.Invoke(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}
	}
}