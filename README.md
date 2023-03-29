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

       *MaterialGenerator*
Documentation:

This is a Unity script that generates a material from a texture file located in a subdirectory of a specified target directory. The script loads the texture file, creates a new material with the Universal Render Pipeline/Lit shader, assigns the texture to the material's base map property, and saves the material asset to the Resources folder.

The script includes two public variables that can be configured in the Unity Editor to customize the functionality of the script:

targetDirectory: The target directory to search for subdirectories containing texture files.
textureName: The name of the texture file to load and assign to the material's base map property.
The script works by checking if the target directory exists, then getting the first subdirectory of the target directory. It then creates a new material with the name of the subdirectory and the Universal Render Pipeline/Lit shader. The script loads the texture file specified by the textureName variable, assigns it to the material's base map property, and saves the material asset to the Resources folder.

The script uses the Directory and File classes to search for subdirectories and texture files, and the AssetDatabase class to load and save assets. It also includes error handling and logging to help diagnose any issues that may arise during the material generation process.

To use the script, simply attach it to a GameObject in your Unity scene, configure the public variables as desired, and run the scene. The script will automatically generate a material using the first subdirectory found in the target directory and the specified texture file name. The material will be saved to the Resources folder and can be accessed in code using the Resources.Load function.
