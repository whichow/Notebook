> [最近我写了关于在Photoshop中创作你的2D内容和导出的设置](http://blogs.unity3d.com/2013/05/17/a-good-workflow-to-smoothly-import-2d-content-into-unity-part-i-authoring-and-exporting/) 今天的文章将介绍将文件导入Unity。您可以在帖子末尾找到一个链接来下载所有文件。 

**从我们离开的地方开始**

Unity会愉快地导入我们的图像和XML文件，但默认情况下，图像将作为普通纹理导入，XML文件将作为文本资源导入。所以我们需要在Unity中编写一个导入程序来处理我们游戏的文件。 

你可能会认为编写一个[AssetPostprocessor](http://docs.unity3d.com/Documentation/ScriptReference/AssetPostprocessor.html)是一条可行的路线，你这么想是可以理解的。使用AssetPostprocessor的问题在于我们在这种情况下所能做的事情受到限制，并且它不会允许我们创建一个我们需要做的新材质。所以答案只是编写一个编辑脚本来做我们想做的事情。 

我们的导入脚本需要做：

- 加载和反序列化导出的XML元数据，
- 更改我们图像的纹理导入设置，以便我们可以处理它们， 
- 创建纹理图集并将我们的所有纹理打包进去，
- 为我们的每个图像创建网格资源，
- 创建GameObjects引用这些网格，
- 并创建一个场景来保存我们的GameObjects。

**编写编辑器脚本**
和导出脚本一样，你可以从这里下载导入脚本。它应该放置在一个名为“Editor”的文件夹中，以便它能够正常工作。 

如果你之前没有写过编辑器脚本，你就没有充分利用Unity最强大的功能之一。编辑器脚本是普通脚本的超集，所以如果你已经知道如何编写游戏脚本，你也已经了解编辑器脚本的基础知识。 

编辑器脚本基本上以三种方式与常规游戏脚本区分开来。 首先，编辑器脚本必须放在一个名为“Editor”的文件夹中，或者它的一个子文件夹。其次，在脚本文件的顶部加上下面这行： 

```
using UnityEditor;
```

最后，为了编辑脚本被调用，它必须来自Editor，EditorWindow，ScriptableWizard等编辑器子类之一。你可以使用不从这些类派生的类，但是如果您想要接收事件并进行交互，这些类以类似于MonoBehaviour的方式进行。出于我们的目的，我们将使用通用编辑器基类。 

```
public class HogImporter : Editor
{
        ...
}
```

就像导出脚本一样我们不会逐行来过，因为这个文件有很好的注释，但让我们看看一些更有趣的部分。

首先，我们需要一些方法来调用我们的导入器，所以我们将它放在Unity内的Assets菜单中，如下所示： 

```
[MenuItem("Assets/Create/Import HOG Scene...")]
static public void ImportHogSceneMenuItem()
{
        ...
}
```

所以现在我们在Assets菜单中选择时，可以执行一个脚本，所以现在我们所要做的就是做一些有用的事情。

 我们要做的第一件事就是将XML文件转换为更可用的内容，如数据类。当我们编写导出器时，我们将数据组织成一组逻辑元素，以便它可以轻松映射到数据类中。我们的数据类如下所示，并且在结构和数据类型中匹配我们的XML文件： 

```
public class HogScene
{
        public Layer[] layers;
        public enum LayerStatus { Active, Found };
        public enum LayerType { Custom, Item, Scenery };
        public class Layer
        {
                public LayerType type;
                public string name;
                public LayerStatus layerStatus;
                public Rect bounds;
                public Image[] images;
        }

        public enum ImageType { Hotspot, Obscured, Whole, Shadow, Custom, Count };
        public class Image
        {
                public ImageType type;
                public string name;
                public float x;
                public float y;
                public float z;
        }
}
```

要将XML文件实际转换为数据类，我们使用内置的.NET序列化方法。 

```
HogScene hogScene = (HogScene)DeserializeXml(assetPath, typeof(HogScene));
...
static private object DeserializeXml(string filePath, System.Type type)
{
        object instance = null;
        StreamReader xmlFile = File.OpenText(filePath);
        if(xmlFile != null)
        {
                string xml = xmlFile.ReadToEnd();
                if((xml != null) && (xml.ToString() != ""))
                {
                        XmlSerializer xs = new XmlSerializer(type);
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] byteArray = encoding.GetBytes(xml);
                        MemoryStream memoryStream = new MemoryStream(byteArray);
                        XmlTextWriter xmlTextWriter =
                                new XmlTextWriter(memoryStream, Encoding.UTF8);
                        if(xmlTextWriter != null)
                        {
                                instance = xs.Deserialize(memoryStream);
                        }
                }
        }
        xmlFile.Close();
        return instance;
}
```

由于我们将使用代码创建场景，因此用户可能已经打开了这个场景，或者另一个场景，我们需要确保他们有机会保存更改。要做到这一点，我们调用： 

```
if(EditorApplication.SaveCurrentSceneIfUserWantsTo() == false)
{
        return;
}
```

然后，我们只需创建一个新场景，如果已经存在，先删除旧场景： 

```
string scenePath = baseDirectory + baseFilename + " Scene.unity";
if(File.Exists(scenePath) == true)
{
        File.Delete(scenePath);
        AssetDatabase.Refresh();
}
// now create a new scene
EditorApplication.NewScene();
```

接下来是修复纹理导入设置。默认情况下，纹理不可读，我们需要读它们才能将它们放入图集。虽然我们到了这里，但我们还需要更改其他一些设置。 

```
List<Texture2D> textureList = new List<Texture2D>();
for(int layerIndex = 0; layerIndex &lt; hogScene.layers.Length; layerIndex++)
{
        for(int imageIndex = 0;
                imageIndex < hogScene.layers[layerIndex].images.Length;
                imageIndex++)
        {
                // we need to fixup all images that were exported from PS
                string texturePathName = baseDirectory +
                        hogScene.layers[layerIndex].images[imageIndex].name;
                Texture2D inputTexture =
                        (Texture2D)AssetDatabase.LoadAssetAtPath(
                        texturePathName, typeof(Texture2D));
                // modify the importer settings
                TextureImporter textureImporter =
                        AssetImporter.GetAtPath(texturePathName) as TextureImporter;
                textureImporter.mipmapEnabled = false;
                textureImporter.isReadable = true;
                textureImporter.npotScale = TextureImporterNPOTScale.None;
                textureImporter.wrapMode = TextureWrapMode.Clamp;
                textureImporter.filterMode = FilterMode.Point;
                ...
        }
}
```

现在我们准备创建新的图集材质，纹理并将所有内容都打包进去。 

```
// create material
string materialPath = baseDirectory + baseFilename + " Material.mat";
// remove previous one if it exists
if(File.Exists(materialPath) == true)
{
        File.Delete(materialPath);
        AssetDatabase.Refresh();
}
// make a material and link it to atlas, save that too
Material material = new Material(Shader.Find("Transparent/Diffuse"));
AssetDatabase.CreateAsset(material, materialPath);
AssetDatabase.Refresh();
// load it back
material = (Material)AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material));
// make a new atlas texture
Texture2D atlas = new Texture2D(2048, 2048);
// to make an atlas we need an array instead of a list
Texture2D[] textureArray = textureList.ToArray();
// pack it with all the textures we have
Rect[] atlasRects = atlas.PackTextures(textureArray, 0, 2048);
// save it to disk
byte[] atlasPng = atlas.EncodeToPNG();
string atlasPath = baseDirectory + baseFilename + " Atlas.png";
if(File.Exists(atlasPath) == true)
{
        File.Delete(atlasPath);
        AssetDatabase.Refresh();
}
File.WriteAllBytes(atlasPath, atlasPng);
```

由于我们已经创建了所有我们需要的基本部分，现在我们可以遍历这些图像，创建网格，创建GameObjects并将它们放入场景中。这是相当数量的代码，因此它不会被完全复述，但最有趣的部分是在Unity中创建2D精灵。你可能会惊讶地发现它的简单和容易。我使用了一个简单的函数来处理Unity中所有2D内容，它看起来像下面这样。 

```
static private void ConfigureGo(GameObject go, Texture2D texture, Material material,
Rect uvRect, string meshPath)
{
        // create meshFilter if new
        MeshFilter meshFilter = (MeshFilter)go.GetComponent(typeof(MeshFilter));
        if(meshFilter == null)
        {
                meshFilter = (MeshFilter)go.AddComponent(typeof(MeshFilter));
        }
        // create mesh if new
        Mesh mesh = meshFilter.sharedMesh;
        if(mesh == null)
        {
                mesh = new Mesh();
        }
        mesh.Clear();
 
        // setup rendering
        MeshRenderer meshRenderer =
                (MeshRenderer)go.GetComponent(typeof(MeshRenderer));
        if(meshRenderer == null)
        {
                meshRenderer =
                        (MeshRenderer)go.AddComponent(typeof(MeshRenderer));
        }
        meshRenderer.renderer.material = material;
        // create the mesh geometry
        // Unity winding order is counter-clockwise when viewed
        // from behind and facing forward (away)
        // Unity winding order is clockwise when viewed
        // from behind and facing behind
        // 1---2
        // | / |
        // | / |
        // 0---3
        Vector3[] newVertices;
        int[] newTriangles;
        Vector2[] uvs;
 
        float hExtent = texture.width * 0.5f;
        float vExtent = texture.height * 0.5f;
 
        newVertices = new Vector3[4];
        newVertices[0] = new Vector3(-hExtent, -vExtent, 0);
        newVertices[1] = new Vector3(-hExtent, vExtent, 0);
        newVertices[2] = new Vector3(hExtent, vExtent, 0);
        newVertices[3] = new Vector3(hExtent, -vExtent, 0);
 
        newTriangles = new int[] { 0, 1, 2, 0, 2, 3 };
        uvs = new Vector2[4];
        uvs[0] = new Vector2(uvRect.x, uvRect.y);
        uvs[1] = new Vector2(uvRect.x, uvRect.y + uvRect.height);
        uvs[2] = new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height);
        uvs[3] = new Vector2(uvRect.x + uvRect.width, uvRect.y);
        Color[] vertColors = new Color[4];
        vertColors[0] = Color.white;
        vertColors[1] = Color.white;
        vertColors[2] = Color.white;
        vertColors[3] = Color.white;
 
        // update the mesh
        mesh.vertices = newVertices;
        mesh.colors = vertColors;
        mesh.uv = uvs;
        mesh.triangles = newTriangles;
        // generate some some normals for the mesh
        mesh.normals = new Vector3[4];
        mesh.RecalculateNormals();
 
        if(File.Exists(meshPath) == true)
        {
                File.Delete(meshPath);
                AssetDatabase.Refresh();
        }
        AssetDatabase.CreateAsset(mesh, meshPath);
        AssetDatabase.Refresh();
        meshFilter.sharedMesh = mesh;
        // add collider
        go.AddComponent(typeof(MeshCollider));
}
```

这看起来好像很多代码，但实际上它非常简单直接。 最后，在我们构建了所有2D精灵资源之后，我们只需简单地修复相机，以使它像我们最初使用的Photoshop一样呈现完美的场景像素。 

```
// setup our game camera
Camera.main.gameObject.AddComponent<HOGController>();
position = Vector3.zero;
position.z = -hogScene.layers.Length;
Camera.main.transform.position = position;
Camera.main.isOrthoGraphic = true;
Camera.main.orthographicSize = (768.0f/2.0f);
Camera.main.nearClipPlane = 1;
Camera.main.farClipPlane = hogScene.layers.Length + 1;
RenderSettings.ambientLight = Color.white;
```

当你浏览导入脚本之后你应该很快能够理解它。

如果一切顺利，在运行导入器脚本之后，您应该看到完全在Unity中编写并运行的场景。 

![Hog-in-Unity-cropped](https://blogs.unity3d.com/wp-content/uploads/2013/05/Hog-in-Unity-cropped1.jpg)

[你可以下载一个包含这篇文章中所有文件的包](https://dl.dropboxusercontent.com/u/46030326/Unity%20Talks/HOG%20Tutorial.unitypackage)