我们知道在移动设备中Unity是不会将Log输出到文件中的，有时候我们想知道在Crash的时候发生了什么，所以我们需要手动将Log写入文件中。Unity给我们提供了Log的回调接口让我们可以自己处理Log。

```csharp
public delegate void LogCallback(string condition, string stackTrace, LogType type);
```

```csharp
public class ExampleClass : MonoBehaviour {
    public string output = "";
    public string stack = "";
    public string logPath = "";

    void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }
    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }
    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString;
        stack = stackTrace;
        if(type == LogType.Error)
            output = output + "\n" + stack;
        File.WriteLine(logPath, output);
    }
}
```

有时候我们还想直接将Log输出到屏幕上，这样就可以不用控制台直接在运行的设备中查看Log
```csharp
public class ExampleClass : MonoBehaviour {
    public string output = "";
    public string stack = "";
    public Rect rect;

    void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }
    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }
    void OnGUI() {
        GUI.TextArea(rect, output);
    }
    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString;
        stack = stackTrace;
        if(type == LogType.Error)
            output = output + "\n" + stack;
    }
}
```

**参考**
[Unity3D研究院之IOS&Android收集Log文件（六十二）](http://www.xuanyusong.com/archives/2477)
[Application.LogCallback](https://docs.unity3d.com/ScriptReference/Application.LogCallback.html)