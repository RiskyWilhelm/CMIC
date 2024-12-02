using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute), true)]
public sealed class ReadOnlyAttributeDrawer : PropertyDrawer
{
	// Initialize
	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		var readonlyElement = new PropertyField(property);
		readonlyElement.SetEnabled(false);
		return readonlyElement;
	}
}