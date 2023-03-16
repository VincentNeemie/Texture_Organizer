using UnityEngine;
using System.IO;
using UnityEditor;

public class MaterialGenerator : MonoBehaviour
{
    public string targetDirectory = "Materials";
    public string textureName = "albedo";

    void Start()
    {
        // Check for target directory
        string path = Application.dataPath + "/" + targetDirectory;
        if (!Directory.Exists(path))
        {
            Debug.LogError("Target directory does not exist: " + path);
            return;
        }

        // Get first subdirectory of target directory
        string[] subDirectories = Directory.GetDirectories(path);
        if (subDirectories.Length == 0)
        {
            Debug.LogError("No subdirectories found in target directory: " + path);
            return;
        }
        string subDirPath = subDirectories[0];
        string materialName = new DirectoryInfo(subDirPath).Name;

        // Create material
        Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        material.name = materialName;

        // Load texture and assign to material
        string texturePath = subDirPath + "/" + textureName + ".jpg";
        if (File.Exists(texturePath))
        {
            Texture2D texture = new Texture2D(2, 2);
            byte[] data = File.ReadAllBytes(texturePath);
            texture.LoadImage(data);
            material.SetTexture("_BaseMap", texture);
        }
        else
        {
            Debug.LogError("Texture not found: " + texturePath);
            return;
        }

        // Save material to Resources folder
        string resourcesPath = "Assets/Resources/" + targetDirectory + "/" + materialName + ".mat";
        if (!Directory.Exists(Path.GetDirectoryName(resourcesPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(resourcesPath));
        }
        AssetDatabase.CreateAsset(material, resourcesPath);

        // Refresh AssetDatabase to show new material in Unity Editor
        AssetDatabase.Refresh();
    }
}
