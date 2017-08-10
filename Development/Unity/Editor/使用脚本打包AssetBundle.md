## 打包在编辑器中指定的AssetBundles

```cs
// Create an AssetBundle for Windows.
using UnityEngine;
using UnityEditor;

public class BuildAssetBundlesExample : MonoBehaviour
{
    [MenuItem("Example/Build Asset Bundles")]
    static void BuildABs()
    {
        // Put the bundles in a folder called "ABs" within the Assets folder.
        BuildPipeline.BuildAssetBundles("Assets/ABs", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
```

## 通过building map打包AssetBundles

```cs
using UnityEngine;
using UnityEditor;

public class BuildAssetBundlesBuildMapExample : MonoBehaviour
{
    [MenuItem("Example/Build Asset Bundles Using BuildMap")]
    static void BuildMapABs()
    {
        // Create the array of bundle build details.
        AssetBundleBuild[] buildMap = new AssetBundleBuild[2];

        buildMap[0].assetBundleName = "enemybundle";

        string[] enemyAssets = new string[2];
        enemyAssets[0] = "Assets/Textures/char_enemy_alienShip.jpg";
        enemyAssets[1] = "Assets/Textures/char_enemy_alienShip-damaged.jpg";

        buildMap[0].assetNames = enemyAssets;
        buildMap[1].assetBundleName = "herobundle";

        string[] heroAssets = new string[1];
        heroAssets[0] = "char_hero_beanMan";
        buildMap[1].assetNames = heroAssets;

        BuildPipeline.BuildAssetBundles("Assets/ABs", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
```