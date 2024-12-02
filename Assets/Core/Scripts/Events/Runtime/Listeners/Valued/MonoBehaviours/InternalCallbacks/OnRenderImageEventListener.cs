using UnityEngine;

public sealed partial class OnRenderImageEventListener : MonoBehaviourEventListener<RenderTexture, RenderTexture>
{ }


#if UNITY_EDITOR

public sealed partial class OnRenderImageEventListener { }


#endif