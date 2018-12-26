```c#
var sel = Selection.activeObject;
var path = AssetDatabase.GetAssetPath(sel);
if(Directory.Exists(path))
{
    DirectoryInfo info = new DirectoryInfo(path);
    Debug.Log(info.FullName);
}
if(File.Exists(path))
{
    FileInfo info = new FileInfo(path);
    Debug.Log(info.FullName);
}
```

