using System.Collections.Generic;
using UnityEngine;

public sealed partial class OnCollisionStayEvent : MonoBehaviourEvent<Collision>, ICollisionStayListener
{
	// Update
	public void OnCollisionStay(Collision collision)
    {
		Raise(collision);
	}
}


#if UNITY_EDITOR

public sealed partial class OnCollisionStayEvent { }


#endif