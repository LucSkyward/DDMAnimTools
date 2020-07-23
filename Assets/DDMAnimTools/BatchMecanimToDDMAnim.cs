#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAnimAsset : MonoBehaviour
{
    [MenuItem("DDMAnimTools/2.MecanimToDDMAnim")]
    public static void MecanimToDDMAnim()
    {
        string assetbundleBuildPath = Application.streamingAssetsPath;//Path.Combine(Application.streamingAssetsPath, "Anim/Test");
        
        FileUtil.DeleteFileOrDirectory(assetbundleBuildPath);
        Directory.CreateDirectory(assetbundleBuildPath);
        
        BuildPipeline.BuildAssetBundles(assetbundleBuildPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);

        AssetDatabase.Refresh();
        
        string[] fileEntries = Directory.GetFiles(assetbundleBuildPath, "*.*", SearchOption.AllDirectories);
        foreach (var fi in fileEntries)
        {
            if (Directory.Exists(fi))
            {
                //ignore dir
                continue;
            }
            if (!fi.EndsWith(".anim"))
            {
                FileUtil.DeleteFileOrDirectory(fi);
            }
        }
        
        AssetDatabase.Refresh();
    }
}
#endif
