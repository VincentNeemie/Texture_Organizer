# Texture Organizer
        *MaterialUpdater:
Documentation:

This is a Unity script that creates materials from a set of texture files located in subfolders of a specified root folder. The script loads the texture files, assigns them to the correct texture properties, creates a material with the correct rendering pipeline type, and saves the material asset in the same subfolder as the textures.

The script includes several public variables that can be configured in the Unity Editor to customize the functionality of the script:

rootFolderPath: The root folder to start searching for subfolders containing texture files.
renderingPipelineType: The rendering pipeline type to use for the materials (BuiltIn, Universal, or HighDefinition).
baseMapName: The name of the texture file that should be assigned to the material's base map property.
bumpMapName: The name of the texture file that should be assigned to the material's bump map property.
metallicGlossMapName: The name of the texture file that should be assigned to the material's metallic gloss map property.
parallaxMapName: The name of the texture file that should be assigned to the material's parallax map property.
maxSubfolders: The maximum number of subfolders to process.
The script works by iterating over all the subfolders in the specified root folder and loading the texture files in each subfolder. It then assigns the textures to the correct texture properties on a material, creates a material asset, and saves it in the same subfolder as the textures.

The script uses the AssetDatabase class to load and save assets, and the Directory class to search for subfolders and texture files. It also includes error handling and logging to help diagnose any issues that may arise during the material creation process.

To use the script, simply attach it to a GameObject in your Unity scene, configure the public variables as desired, and run the scene. The script will automatically iterate over the subfolders and create materials for each one.
