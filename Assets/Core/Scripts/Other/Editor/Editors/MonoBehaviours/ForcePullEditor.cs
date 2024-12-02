using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ForcePull))]
public class ForcePullEditor : Editor
{
	private ForcePull Target
		=> (target as ForcePull);


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
			DrawInteractivePullDirection();
	}

	private void DrawInteractivePullDirection()
	{
		Handles.color = Color.magenta;

		// Draw interactable
		EditorGUI.BeginChangeCheck();

		var currentRotation = Quaternion.identity;
		var isUsingOriginForPull = (Target.pullDirection == Vector3.zero);
		if (!isUsingOriginForPull)
			currentRotation = Quaternion.LookRotation(Target.pullDirection);

		Quaternion newRotation = Handles.FreeRotateHandle(currentRotation, Target.transform.position, HandleUtility.GetHandleSize(Target.transform.position) * 0.25f);
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(Target, "Changed Pull Direction");
			Target.pullDirection = newRotation.Forward();
		}

		// Draw the direction
		if (isUsingOriginForPull)
			return;

		Handles.ArrowHandleCap(
			0,
			Target.transform.position,
			!Target.isPullDirectionWorldAxis ? (Target.transform.rotation * newRotation) : newRotation,
			HandleUtility.GetHandleSize(Target.transform.position) * 1.25f,
			EventType.Repaint
		);
	}
}
