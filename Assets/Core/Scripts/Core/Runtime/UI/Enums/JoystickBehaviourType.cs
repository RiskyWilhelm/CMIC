/// <summary> Defines how the onscreen stick will move relative to it's center of origin and the press position. </summary>
public enum JoystickBehaviourType
{
	/// <summary> The control's center of origin is fixed in the scene.
	/// The control will begin un-actuated at it's centered position and then move relative to the press motion. </summary>
	RelativePositionWithStaticOrigin,

	/// <summary> The control's center of origin is fixed in the scene.
	/// The control may begin from an actuated position to ensure it is always tracking the current press position. </summary>
	ExactPositionWithStaticOrigin,

	/// <summary> The control's center of origin is determined by the initial press position.
	/// The control will begin unactuated at this center position and then track the current press position. </summary>
	ExactPositionWithDynamicOrigin
}