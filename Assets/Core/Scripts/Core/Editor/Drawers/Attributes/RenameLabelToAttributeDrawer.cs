using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(RenameLabelToAttribute), true)]
public sealed class RenameLabelToAttributeDrawer : PropertyDrawer
{
	private RenameLabelToAttribute Attribute => (RenameLabelToAttribute)attribute;


	// Initialize
	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		return new PropertyField(property, Attribute.NewName);
	}
}