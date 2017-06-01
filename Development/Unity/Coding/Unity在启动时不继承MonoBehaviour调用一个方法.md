1. 使用`RuntimeInitializeOnLoadMethod`属性可以使一个类的方法在游戏启动时进行初始化调用
```cs
// Create a non-MonoBehaviour class which displays
// messages when a game is loaded.
using UnityEngine;

class MyClass
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After scene is loaded and game is running");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        Debug.Log("SecondMethod After scene is loaded and game is running.");
    }
}
```
方法调用在Awake之后进行

方法的调用的顺序不确定


2. 使用`PostProcessScene`属性时，当进入运行模式，Application.LoadLevel或Application.LoadLevelAdditive被调用时将会被调用
```cs
[PostProcessScene(2)]
public static void OnPostprocessScene()
{
    EveryplaySettings settings = EveryplaySettingsEditor.LoadEveryplaySettings();

    if (settings != null)
    {
        if (settings.earlyInitializerEnabled && settings.IsValid && settings.IsEnabled)
        {
            GameObject everyplayEarlyInitializer = new GameObject("EveryplayEarlyInitializer");
            everyplayEarlyInitializer.AddComponent<EveryplayEarlyInitializer>();
        }
    }
}
```
PostProcessScene属性有一个可选的参数用来指明调用顺序