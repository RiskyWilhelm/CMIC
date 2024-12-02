using UnityEngine;

public sealed partial class OnRenderImageEvent : MonoBehaviourEvent<RenderTexture, RenderTexture>
{
	// Update
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
		Raise(source, destination);
	}
}


#if UNITY_EDITOR

public sealed partial class OnRenderImageEvent { }


#endif