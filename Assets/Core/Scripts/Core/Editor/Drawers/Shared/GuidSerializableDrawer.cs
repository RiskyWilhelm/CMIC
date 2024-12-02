using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(GuidSerializable))]
public sealed class GuidSerializableDrawer : PropertyDrawer
{
	private static readonly List<string> guidActionList = new()
	{
		"Generate new guid",
		"Empty the guid"
	};

	[SerializeField]
	private VisualTreeAsset guidSerializableDrawerUXML;

	private SerializedProperty mainProperty;

	private TextField guidTextField;


	// Initialize
	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		var visualTree = guidSerializableDrawerUXML.CloneTree();
		mainProperty = property;

		// Find fields
		var dropdownInputElement = visualTree.Q<DropdownInputElement>("property-container");
		guidTextField = dropdownInputElement.Q<TextField>("property-guid_text");

		// Stylize fields
		dropdownInputElement.DropdownElement.choices = guidActionList;
		guidTextField.label = mainProperty.displayName;
		guidTextField.SetValueWithoutNotify(mainProperty.boxedValue.ToString());

		// Register callbacks
		guidTextField.RegisterValueChangedCallback(OnTextFieldValueChanged);
		dropdownInputElement.DropdownElement.RegisterValueChangedCallback(OnDropdownFieldValueChanged);
		dropdownInputElement.TrackPropertyValue(mainProperty, OnMainPropertyChanged);

		return visualTree;
	}


	// Update
	private void UpdateMainPropertyWithGuid(GuidSerializable newGuid)
	{
		mainProperty.boxedValue = newGuid;
		mainProperty.serializedObject.ApplyModifiedProperties();
	}

	private void OnDropdownFieldValueChanged(ChangeEvent<string> evt)
	{
		switch (guidActionList.IndexOf(evt.newValue))
		{
			case 0:
			UpdateMainPropertyWithGuid(GuidSerializable.NewGuid());
			break;

			case 1:
			UpdateMainPropertyWithGuid(GuidSerializable.Empty);
			break;
		}

		// Let the dropdownfield.value stay as "Null" for next actions
		(evt.currentTarget as DropdownField).SetValueWithoutNotify(null);
	}

	private void OnTextFieldValueChanged(ChangeEvent<string> evt)
	{
		// If the new value is not a valid guid, keep old value and throw exception
		if (!Guid.TryParse(guidTextField.value, out _))
		{
			guidTextField.SetValueWithoutNotify(evt.previousValue);
			throw new ArgumentException("Guid is not valid. Keeping the old value");
		}

		UpdateMainPropertyWithGuid(new GuidSerializable(guidTextField.value));
	}

	private void OnMainPropertyChanged(SerializedProperty property)
	{
		guidTextField.SetValueWithoutNotify(property.boxedValue.ToString());
	}
}