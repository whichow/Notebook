```cs
public static Texture2D getTextureAtUrl (string url)
{
    Texture2D texture = new Texture2D(2,2);
    if (Application.platform == RuntimePlatform.WindowsEditor)
    {
        WWW request = new WWW("file://" + Application.streamingAssetsPath + "/" + url);
        while (!request.isDone) { }
        texture = request.textureNonReadable as Texture2D;
        return texture;
    } else if (Application.platform == RuntimePlatform.Android)
    {
        WWW request = new WWW("jar:file://" + Application.dataPath + "!/assets/" + url);
        while (!request.isDone) { }
        texture = request.textureNonReadable as Texture2D;
        return texture;
    } else if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
        WWW request = new WWW("file://" + Application.streamingAssetsPath + "/" + url);
        while (!request.isDone) { }
        texture = request.textureNonReadable as Texture2D;
        return texture;
    }
    return texture;
}
```
使用while循环虽然可以同步加载资源但是如果资源过大会导致程序卡死。

---

StreamingAssets在各平台中的位置

On a desktop computer (Mac OS or Windows) the location of the files can be obtained with the following code:
 - `path = Application.dataPath + "/StreamingAssets";`

On iOS, use:
 - `path = Application.dataPath + "/Raw";`

On Android, use:
 - `path = "jar:file://" + Application.dataPath + "!/assets/";`