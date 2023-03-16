using UnityEngine;
using UnityEditor;
using System.IO;

public enum RenderingPipelineType
{
    BuiltIn,
    Universal,
    HighDefinition
}

public class MaterialUpdater : MonoBehaviour
{
    // Public variable to specify the root folder to start searching for subfolders
    public string rootFolderPath;
    
    // Public variable to specify the rendering pipeline type
    public RenderingPipelineType renderingPipelineType;
    
    // Public variables to specify the texture names
    public string baseMapName;
    public string bumpMapName;
    public string metallicGlossMapName;
    public string parallaxMapName;

    // Public variable to specify the maximum number of subfolders to process
    public int maxSubfolders = 10;

    void Start()
    {
        // Get an array of all the subfolders in the root folder
        string[] subfolders = Directory.GetDirectories(rootFolderPath);

        // Iterate over the subfolders, up to the maximum number specified
        int numSubfolders = Mathf.Min(subfolders.Length, maxSubfolders);
        for (int i = 0; i < numSubfolders; i++)
        {
            // Get the current subfolder path
            string subfolderPath = subfolders[i];

            // Get an array of all the texture files in the subfolder
            string[] textureFiles = Directory.GetFiles(subfolderPath, "*.jpg");

            // Check if all the required texture files are present
            if (textureFiles.Length != 4)
            {
                Debug.LogError($"Subfolder {subfolderPath} is missing one or more required textures.");
                continue;
            }

            // Create an array to hold the textures
            Texture2D[] textures = new Texture2D[textureFiles.Length];

            // Iterate over the texture files and load them into the array
            for (int j = 0; j < textureFiles.Length; j++)
            {
                string textureFile = textureFiles[j];
                Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(textureFile);

                if (texture == null)
                {
                    Debug.LogError($"Missing texture: {textureFile}");
                    return;
                }

                // Assign the texture to the correct texture property based on its name
                if (texture.name.Contains(baseMapName))
                {
                    textures[0] = texture;
                }
                else if (texture.name.Contains(bumpMapName))
                {
                    textures[1] = texture;
                }
                else if (texture.name.Contains(metallicGlossMapName))
                {
                    textures[2] = texture;
                }
                else if (texture.name.Contains(parallaxMapName))
                {
                    textures[3] = texture;
                }
                else
                {
                    Debug.LogError($"Unknown texture name: {texture.name}");
                    return;
                }
            }

            // Create a material with the correct rendering pipeline type
            Material material = null;
            switch (renderingPipelineType)
            {
                case RenderingPipelineType.BuiltIn:
                    material = new Material(Shader.Find("Standard"));
                    break;
                case RenderingPipelineType.Universal:
                    material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                    break;
                case RenderingPipelineType.HighDefinition:
                    material = new Material(Shader.Find("HDRP/Lit"));
                    break;
                default:
                    Debug.LogError($"Unknown rendering pipeline type: {renderingPipelineType}");
                    return;
            }

            // Set the textures on the material
            material.SetTexture("_BaseMap", textures[0]);
            material.SetTexture("_BumpMap", textures[1]);
            material.SetTexture("_MetallicGlossMap", textures[2]);
            material.SetTexture("_ParallaxMap", textures[3]);

            // Create a material asset and save it in the same subfolder as the textures
            string materialName = new DirectoryInfo(subfolderPath).Name;
            AssetDatabase.CreateAsset(material, Path.Combine(subfolderPath, materialName + ".mat"));
            Debug.Log($"Created new material: {materialName}");
        }
    }
}
