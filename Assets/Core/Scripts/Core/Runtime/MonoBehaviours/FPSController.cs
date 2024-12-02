using UnityEngine;

public sealed partial class FPSController : MonoBehaviour
{
	[Min(10f)]
    public int desiredAmount = 144;

	public bool useScreenHZ;


	// Update
	private void Update()
	{
		if (useScreenHZ)
			UpdateByScreenHZ();
		else
			UpdateByDesiredAmount();
	}

	private void UpdateByScreenHZ()
	{
		if (Application.targetFrameRate != (int)Screen.currentResolution.refreshRateRatio.value)
			Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
	}

	private void UpdateByDesiredAmount()
	{
		if (Application.targetFrameRate != desiredAmount)
			Application.targetFrameRate = desiredAmount;
	}
}


#if UNITY_EDITOR

public sealed partial class FPSController
{ }


#endif
