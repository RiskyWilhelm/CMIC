// Helpers: Discord(mechwarrior99)
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor;

public class FoldableField : Foldout
{
    public new class UxmlFactory : UxmlFactory<FoldableField, UxmlTraits> { }
    public new class UxmlTraits : Foldout.UxmlTraits
    {
        private readonly UxmlStringAttributeDescription m_InputBindingPath;
        private readonly UxmlStringAttributeDescription m_InputLabel;
        private readonly UxmlBoolAttributeDescription m_ShowLabel;
        private readonly UxmlBoolAttributeDescription m_ShowToggle;
        private readonly UxmlBoolAttributeDescription m_ShowToggleBasedOnValue;
        private readonly UxmlBoolAttributeDescription m_BindFoldoutBasedOnValue;

        public UxmlTraits()
        {
            m_InputBindingPath = new UxmlStringAttributeDescription
            {
                name = "input-binding-path"
            };

            m_InputLabel = new UxmlStringAttributeDescription
            {
                name = "input-label"
            };

            m_ShowLabel = new UxmlBoolAttributeDescription
            {
                name = "show-label",
                defaultValue = true
            };

            m_ShowToggle = new UxmlBoolAttributeDescription
            {
                name = "show-toggle",
                defaultValue = true
            };

            m_ShowToggleBasedOnValue = new UxmlBoolAttributeDescription
            {
                name = "show-toggle-based-on-value",
                defaultValue = false
            };

            m_BindFoldoutBasedOnValue = new UxmlBoolAttributeDescription
            {
                name = "bind-foldout-based-on-value",
                defaultValue = true
            };
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            if(ve is FoldableField foldableField)
            {
                foldableField.showLabel = m_ShowLabel.GetValueFromBag(bag, cc);
                foldableField.showToggle = m_ShowToggle.GetValueFromBag(bag, cc);
                foldableField.showToggleBasedOnValue = m_ShowToggleBasedOnValue.GetValueFromBag(bag, cc);
                foldableField.bindFoldoutBasedOnValue = m_BindFoldoutBasedOnValue.GetValueFromBag(bag, cc);
                string inputBindingPathFromBag = m_InputBindingPath.GetValueFromBag(bag, cc);
                string inputLabelFromBag = m_InputLabel.GetValueFromBag(bag, cc);

                if (!string.IsNullOrEmpty(inputBindingPathFromBag))
                    foldableField.inputBindingPath = inputBindingPathFromBag;

                if (!string.IsNullOrEmpty(inputLabelFromBag))
                    foldableField.inputLabel = inputLabelFromBag;
            }
        }
    }

    public PropertyField inputField { get; private set; }
    
    /// <summary>
    /// Container of the inputField
    /// </summary>
    public VisualElement fieldContentContainer { get; private set; }
    public Toggle foldoutToggleField { get; private set; }

    public string inputBindingPath
    {
        get => inputField?.bindingPath;
        set
        {
            if(inputField != null)
                inputField.bindingPath = value;
        }
    }
    public string inputLabel
    {
        get => inputField?.label;
        set
        {
            if(inputField != null && showLabel)
                inputField.label = value;
        }
    }

    // This manages the input label
    private bool m_showLabel;
    public bool showLabel
    {
        get => m_showLabel;
        set
        {
            if(inputField != null)
            {
                if(value == true)
                    inputField.label = inputLabel;
                else
                    inputField.label = "";
            }

            m_showLabel = value;
        }
    }

    private bool m_showToggle;
    public bool showToggle
    {
        get => m_showToggle;
        set
        {
            ShowHideFoldoutWithToggle(value);
            m_showToggle = value;
        }
    }

    private bool m_showToggleBasedOnValue;
    private bool showToggleBasedOnValue
    {
        get => m_showToggleBasedOnValue;
        set
        {
            if(inputField != null)
            {
                inputField.UnregisterCallback<SerializedPropertyChangeEvent>(ShowFoldoutBasedOnValue);
                
                if(value == true)
                    inputField.RegisterValueChangeCallback(ShowFoldoutBasedOnValue);
            }

            m_showToggleBasedOnValue = value;
        }
    }

    /// <summary>
    /// Binds auto if its an Unity.Object
    /// </summary>
    private bool m_bindFoldoutBasedOnValue;
    private bool bindFoldoutBasedOnValue
    {
        get => m_bindFoldoutBasedOnValue;
        set
        {
            if (inputField != null)
            {
                inputField.UnregisterCallback<SerializedPropertyChangeEvent>(BindFoldoutBasedOnValue);

                if (value == true)
                    inputField.RegisterValueChangeCallback(BindFoldoutBasedOnValue);
            }

            m_bindFoldoutBasedOnValue = value;
        }
    }

    public FoldableField() : base()
    {
        // Create the FoldableField stylize to align the inputField with dropdownField button
        VisualElement fieldContainer = new()
        {
            name = "field-content",
            style = 
            {
                flexDirection = FlexDirection.Row
            }
        };

        fieldContentContainer = new()
        {
            name = "field-content-container",
            style =
            {
                flexShrink = 0,
                flexGrow = 1,
                flexBasis = 0
            }
        };

        // Toggle stylize to align with inputField
        foldoutToggleField = this.Q<Toggle>();
        foldoutToggleField.style.marginTop = 2;
        
        // Input
        inputField = new PropertyField
        {
            name = "input-field"
        };
        inputField.AddToClassList(BaseField<int>.inputUssClassName);

        // Changes toggle's parent and adds input field ( do you know how many hours i searched for this shit? who would know they implemented that behaviour inside fucking insert function >: )
        fieldContainer.Insert(0, foldoutToggleField);
        fieldContainer.Insert(1, fieldContentContainer);
        fieldContentContainer.Insert(0, inputField);
        this.hierarchy.Insert(0, fieldContainer);
    }

    private void BindFoldoutBasedOnValue(SerializedPropertyChangeEvent evt)
    {
        // Bind content container to information if its a UnityEngine.Object
        if (evt.changedProperty.boxedValue is UnityEngine.Object)
        {
            var newObjectReferenceSerialized = new SerializedObject(evt.changedProperty.boxedValue as UnityEngine.Object);
            contentContainer.Bind(newObjectReferenceSerialized);
        }
        else
            contentContainer.Unbind();
    }

    private void ShowFoldoutBasedOnValue(SerializedPropertyChangeEvent evt)
    {
        // When boxedValue is a value-type variable, the Bind and Unbind wont be called. That means user can bind other things to that foldout content
        if(evt.changedProperty.boxedValue != null && showToggle)
            ShowHideFoldoutWithToggle(true);
        else
            ShowHideFoldoutWithToggle(false);
    }

    private void ShowHideFoldoutWithToggle(bool show)
    {
        if(show)
        {
            // Show information(foldout) and toggle
            // Foldout changes the contentContainer display style for displaying correctly too
            if (foldoutToggleField.value == true)
                this.contentContainer.style.display = DisplayStyle.Flex;

            this.foldoutToggleField.style.display = DisplayStyle.Flex;
        }
        else
        {
            // Hide information(foldout) and toggle
            this.contentContainer.style.display = DisplayStyle.None;
            this.foldoutToggleField.style.display = DisplayStyle.None;
        }
    }

    public void BindToFoldout(SerializedObject serializedObject)
    {
        contentContainer.Bind(serializedObject);
    }
}
