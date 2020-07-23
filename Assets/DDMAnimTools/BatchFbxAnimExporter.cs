#if UNITY_EDITOR

using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BatchFbxAnimExporter : MonoBehaviour
{
    public const string ImportFolder = "FbxFiles";
    public const string ExportFolder = "Mecanim";
    
    [MenuItem("DDMAnimTools/1.FbxToMecanim")]
    public static void ExportFbxAnims()
    {
        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + ImportFolder, "*.fbx", SearchOption.AllDirectories);

        foreach (string fileName in fileEntries)
        {
            int assetPathIndex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathIndex);
            
            // Debug.LogError(localPath);

            string clipName = Path.GetFileNameWithoutExtension(localPath) + ".anim";
            string newpath = Path.GetDirectoryName(localPath).Replace(ImportFolder,ExportFolder);

            // Debug.LogError(newpath);

            if (!Directory.Exists(newpath))
            {
                Directory.CreateDirectory(newpath);
            }

            var allAssets = AssetDatabase.LoadAllAssetsAtPath(localPath);

            foreach (var ass in allAssets)
            {
                if (ass is AnimationClip)
                {
                    AnimationClip oriClip = (AnimationClip) ass;

                    //skip __preview__
                    if (oriClip.name.StartsWith("__preview"))
                    {
                        continue;
                    }

                    //Save the clip
                    AnimationClip copyClip = new AnimationClip();
                    // if (!Resources.Load(newpath + "/" + clipName))
                    // {
                    EditorUtility.CopySerialized(oriClip, copyClip);
                    AssetDatabase.CreateAsset(copyClip, newpath + "/" + oriClip.name + ".anim");

                    // AnimationClip clip = Resources.Load<AnimationClip>(newpath + "/" + clipName);
                    string conrollerPath = newpath + "/" + oriClip.name + ".controller";
                    var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath(conrollerPath);
                    var state = controller.AddMotion(copyClip);
                    // state.AddExitTransition(false);

                    string nameWithOutException = Path.GetFileNameWithoutExtension(oriClip.name);
                    // Debug.LogError(newpath);
                    string assetbundlePath = newpath.Replace("Assets\\" + ExportFolder + "\\", "Anim\\") + "\\" + nameWithOutException;
                    // Debug.LogError(assetbundlePath);

                    AssetImporter.GetAtPath(conrollerPath).SetAssetBundleNameAndVariant(assetbundlePath, "anim");
                }
            }
            
            // AnimationClip orgClip = (AnimationClip) AssetDatabase.LoadAssetAtPath(localPath, typeof(AnimationClip));

            AssetDatabase.Refresh();
        }
    } 
}
#endif
