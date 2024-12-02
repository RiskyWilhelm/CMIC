using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(RotationalPull))]
public class RotationalPullEditor : Editor
{
	private RotationalPull Target
		=> (target as RotationalPull);


	// Initialize
	// WARNING: Custom properties wont get drawn due to Unity. They are using IMGUI for DrawDefaultInspector() internally
	public override VisualElement CreateInspectorGUI()
	{
		var rootElement = new VisualElement();
		InspectorElement.FillDefaultInspector(rootElement, serializedObject, this);
		return rootElement;
	}


	// Update
	private void OnSceneGUI()
	{
		if (Target.e_IsActivatedInteractiveEditing)
			DrawInteractiveUpDirection();
	}

	private void DrawInteractiveUpDirection()
	{
		Handles.color = Color.magenta;

		// Draw interactable
		EditorGUI.BeginChangeCheck();

		var currentRotation = Quaternion.identity;
		var isUsingOriginForUp = (Target.upDirection == Vector3.zero);
		if (!isUsingOriginForUp)
			currentRotation = Quaternion.LookRotation(Target.upDirection);

		Quaternion newRotation = Handles.FreeRotateHandle(currentRotation, Target.transform.position, HandleUtility.GetHandleSize(Target.transform.position) * 0.25f);
		
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(Target, "Changed Up Direction");
			Target.upDirection = newRotation.Forward();
		}

		// Draw the direction
		if (isUsingOriginForUp)
			return;

		Handles.ArrowHandleCap(
			0,
			Target.transform.position,
			!Target.isUpDirectionWorldAxis ? (Target.transform.rotation * newRotation) : newRotation,
			HandleUtility.GetHandleSize(Target.transform.position) * 1.25f,
			EventType.Repaint
		);
	}
}
