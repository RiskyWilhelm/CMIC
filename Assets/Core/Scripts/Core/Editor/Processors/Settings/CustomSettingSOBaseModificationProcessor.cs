using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor;

public sealed partial class CustomSettingSOBaseModificationProcessor : AssetModificationProcessor
{
	// Update
	private static bool TryGetSettingAssetFromPath(string path, out CustomSettingSOBase asset)
	{
		asset = null;
		var assetType = AssetDatabase.GetMainAssetTypeAtPath(path);

		if ((assetType != null) && (typeof(CustomSettingSOBase).IsAssignableFrom(assetType)))
			asset = AssetDatabase.LoadAssetAtPath<CustomSettingSOBase>(path);

		return (asset != null);
	}

	private static void OnWillCreateAsset(string path)
	{
		EditorCoroutineUtility.StartCoroutineOwnerless(WaitCreation(path));
	}

    private static IEnumerator WaitCreation(string path)
    {
		yield return CoroutineUtils.WaitForFrames(20);
        var type = AssetDatabase.GetMainAssetTypeAtPath(path);

		if (type != null)
			OnCreatedAsset(path);
    }

    private static void OnCreatedAsset(string path)
    {
		if (TryGetSettingAssetFromPath(path, out CustomSettingSOBase setting))
			setting.OnCreatedAsset();
	}

	private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
	{
		if (TryGetSettingAssetFromPath(sourcePath, out CustomSettingSOBase setting))
			setting.OnWillMoveAsset();

		return AssetMoveResult.DidNotMove;
	}

	private static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions opt)
	{
		if (TryGetSettingAssetFromPath(path, out CustomSettingSOBase setting))
			setting.OnWillDeletedAsset();
		
		return AssetDeleteResult.DidNotDelete;
	}
}