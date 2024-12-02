using System.Collections;

public static class CoroutineUtils
{
	public static IEnumerator WaitForFrames(int frameCount)
	{
		while (frameCount > 0)
		{
			frameCount--;
			yield return null;
		}
	}
}