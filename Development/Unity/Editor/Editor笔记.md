使用Editor脚本创建GameObject后按Ctrl+S并不能保存当前场景，要使用

```
EditorSceneManager.MarkSceneDirty
```

或者

```
EditorSceneManager.MarkAllScenesDirty
```

后才能保存当前场景