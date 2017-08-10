# EditorBuildSettings

EditorBuildSettings.scenes用来管理需要Build的场景，在Unity编辑器中对应File->Build Settings中的Scenes In Build。

## 获取需要Build的Scene

```cs
string[] FindEnabledEditorScenes ()
{
    List<string> EditorScenes = new List<string> ();
    foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
        //场景没有被勾选
        if (!scene.enabled)
            continue;
        EditorScenes.Add (scene.path);
    }
    return EditorScenes.ToArray ();
}
```

## 设置需要Build的Scene

```cs
void SetEditorBuildSettingsScenes()
{
    List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
    //需要添加的场景路径
    string[] scenePaths = new [] {"Assets/Scene1.unity", "Assets/Scene2.unity"};
    foreach (var scenePath in scenePaths)
    {
        //添加场景勾选
        editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
    }
    //设置到BuildSettings中
    EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
}
```