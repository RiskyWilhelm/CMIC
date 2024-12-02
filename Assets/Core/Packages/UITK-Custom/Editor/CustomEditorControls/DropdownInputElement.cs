using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class DropdownInputElement : VisualElement
{
	#region DropdownInputElement Class Names
	
	public static readonly string ussClassName = "dropdown_input-field";

	public static readonly string dropdownUssClassName = ussClassName + "-dropdown";
	public static readonly string dropdownIconUssClassName = dropdownUssClassName + "__icon";

	public static readonly string inputUssClassName = ussClassName + "__input";


	#endregion

	#region DropdownInputElement Inner Elements

	private VisualElement _contentContainer;

	public override VisualElement contentContainer => _contentContainer ?? base.contentContainer;

    public DropdownField DropdownElement
    { get; private set; }


	#endregion

	#region DropdownInputElement Attributes

	[UxmlAttribute]
	[Tooltip("Shows the elements based on dropdown value (string). In order to make this work, set the names of VisualElement's name (ID) inside contentContainer equal to choices")]
	public bool autoShowElements;


	#endregion


	// Initialize
	public DropdownInputElement()
	{
        // Self
		AddToClassList(ussClassName);
		styleSheets.Add(Resources.Load<StyleSheet>("CustomStyleSheet"));

		// Initialize inner parts
		InitializeDropdownElement();
        InitializeInputContainer();

		// Re-parent elements
		hierarchy.Add(DropdownElement);
		hierarchy.Add(_contentContainer);
	}

	private void InitializeDropdownElement()
    {
        // Container
		DropdownElement = new DropdownField()
		{
			name = "dropdown-field",
        };
		DropdownElement.ClearClassList();
		DropdownElement.AddToClassList(dropdownUssClassName);

		// Icon
		var dropdownElementVisualInput = DropdownElement.ElementAt(0);
		dropdownElementVisualInput.Clear();
		dropdownElementVisualInput.ClearClassList();
		dropdownElementVisualInput.AddToClassList(dropdownIconUssClassName);

		// Register callbacks
		DropdownElement.RegisterValueChangedCallback(OnDropdownValueChanged);
	}

	private void InitializeInputContainer()
	{
		// Container
		_contentContainer = new VisualElement()
		{
			name = "content-container"
		};
		_contentContainer.AddToClassList(inputUssClassName);
	}


	// Update
	private void OnDropdownValueChanged(ChangeEvent<string> evt)
		=> ShowElementBasedOnDropdown();

	private void ShowElementBasedOnDropdown()
	{
		if (!autoShowElements)
			return;

		var selectedElementName = DropdownElement.value;

		foreach (var iteratedElement in contentContainer.Children())
		{
			if (iteratedElement.name == selectedElementName)
				iteratedElement.style.display = DisplayStyle.Flex;
			else
				iteratedElement.style.display = DisplayStyle.None;
		}
	}
}