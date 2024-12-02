using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Used to invoke next action within a queue with looping after one action ends.
/// Looping is done by you. You need to call <b>Dequeue()</b> or <b>InvokeNext()</b> when the method ends.
/// Otherwise it wont loop.
/// </summary>
public sealed partial class ActionQueue
{
    private readonly Queue<UnityAction> actionQueue = new ();

    // Initialize
    /// <summary>
    /// This is main Enqueue method.
    /// <b>You need to call Dequeue at the end of any action manually. InvokeNext won't dequeue actions.</b>
    /// </summary>
    public void Enqueue(UnityAction action)
    {
        actionQueue.Enqueue(action);
    }

    public void EnqueueEnumerator(IEnumerator enumerator)
    {
        Enqueue(() => StaticCoroutineSingleton.Instance.StartCoroutine(enumerator));
    }

    public void EnqueueEvent(UnityEvent eventAction)
    {
        Enqueue(() => eventAction?.Invoke());
    }


    // Update
    public void InvokeNext()
    {
        if(actionQueue.TryDequeue(out UnityAction action))
            action?.Invoke();
        else
			Debug.LogError("Action Queue is empty!");
	}

    /// <summary>
    /// Enqueues the dequeued action again after dequeue
    /// </summary>
    public void InvokeNextLooped()
    {
		if (actionQueue.TryDequeue(out UnityAction action))
        {
            Enqueue(action);
			action?.Invoke();
        }
		else
			Debug.LogError("Action Queue is empty!");
	}


    // Dispose
    /// <summary>
    /// Continue to invoke the Queue by queue if "invokeNextImmediately" is set to true.
    /// </summary>
    public void Dequeue(bool invokeNextImmediately = true)
    {
        actionQueue.Dequeue();
        Debug.Log($"Action Queue count is: {actionQueue.Count}");

        if (actionQueue.Count > 0 && invokeNextImmediately)
            InvokeNext();
        else
            Debug.LogError("Action Queue is empty!");
    }
}


#if UNITY_EDITOR

public sealed partial class ActionQueue { }


#endif