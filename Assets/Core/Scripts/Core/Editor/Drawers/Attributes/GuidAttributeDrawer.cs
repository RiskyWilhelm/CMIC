using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(GuidAttribute), true)]
public sealed class GuidAttributeDrawer : PropertyDrawer
{
	// Initialize
	private static readonly List<string> guidActionList = new()
	{
		"Generate new guid",
		"Empty the guid"
	};

	[SerializeField]
	private VisualTreeAsset guidAttributeDrawerUXML;

	private SerializedProperty mainProperty;

	private object mainPropertyPreviousValue;

	private PropertyField trackingPropertyField;


	// Initialize
	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		var visualTree = guidAttributeDrawerUXML.CloneTree();
		mainProperty = property;
		mainPropertyPreviousValue = property.boxedValue;

		// Find fields
		var dropdownInputElement = visualTree.Q<DropdownInputElement>("property-container");
		trackingPropertyField = dropdownInputElement.Q<PropertyField>("property-field");

		// Stylize fields
		dropdownInputElement.DropdownElement.choices = guidActionList;
		OnMainPropertyChanged(mainProperty);

		// Register callbacks
		dropdownInputElement.DropdownElement.RegisterValueChangedCallback(OnDropdownFieldValueChanged);
		dropdownInputElement.TrackPropertyValue(mainProperty, OnMainPropertyChanged);

		// Bind fields
		trackingPropertyField.BindProperty(mainProperty);

		return visualTree;
	}


	// Update
	private void UpdateMainPropertyWithGuid(Guid newGuid)
	{
		switch (mainProperty.propertyType)
		{
			case SerializedPropertyType.String:
				mainProperty.stringValue = newGuid.ToString();
			break;

			default:
				throw new ArgumentException($"{mainProperty.propertyType} is not supported. Only {SerializedPropertyType.String} supported for {nameof(GuidAttribute)}");
		}
		
		mainProperty.serializedObject.ApplyModifiedProperties();
	}

	private void OnDropdownFieldValueChanged(ChangeEvent<string> evt)
	{
		switch (guidActionList.IndexOf(evt.newValue))
		{
			case 0:
			UpdateMainPropertyWithGuid(Guid.NewGuid());
			break;

			case 1:
			UpdateMainPropertyWithGuid(Guid.Empty);
			break;
		}

		// Let the dropdownfield.value stay as "Null" for next actions
		(evt.currentTarget as DropdownField).SetValueWithoutNotify(null);
	}

	private void OnMainPropertyChanged(SerializedProperty property)
	{
		// Validate new value
		var isValidGuid = true;
		var previousGuid = Guid.Empty;

		// previous value may be invalid
		try
		{
			switch (mainProperty.propertyType)
			{
				case SerializedPropertyType.String:
				{
					if (!Guid.TryParse(mainProperty.stringValue, out _))
					{
						isValidGuid = false;
						previousGuid = new Guid((string)mainPropertyPreviousValue);
					}
				}
				break;

				default:
					throw new ArgumentException($"{mainProperty.propertyType} is not supported. Only {SerializedPropertyType.String} supported for {nameof(GuidAttribute)}");
			}
		}
		finally
		{
			if (isValidGuid)
				mainPropertyPreviousValue = mainProperty.boxedValue;
			else
			{
				UpdateMainPropertyWithGuid(previousGuid);
				Debug.LogError("Guid is not valid. Keeping the old value");
			}
		}
	}
}