Unity的Debug.Log会消耗一定的性能，所以在正式发布版本中我们想将它去掉，有一种简单的方法可以实现
```cs
 #if DEVELOPMENT_BUILD
    Debug.logger.logEnabled=true;
 #else
    Debug.logger.logEnabled = false;
 #endif
```

还有一种使用Conditional的方式，但是会麻烦一点
```cs
#if RELEASE

using System.Diagnostics;
using UnityEngine;

public static class Debug
{
     [Conditional("RELEASE")] public static void Break(){}
     [Conditional("RELEASE")] public static void ClearDeveloperConsole(){}
     [Conditional("RELEASE")] public static void DebugBreak(){}
     [Conditional("RELEASE")] public static void DrawLine(Vector3 start, Vector3 end){}
     [Conditional("RELEASE")] public static void DrawLine(Vector3 start, Vector3 end, Color color){}
     [Conditional("RELEASE")] public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration){}
     [Conditional("RELEASE")] public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest){}
     [Conditional("RELEASE")] public static void DrawRay(Vector3 start, Vector3 dir){}
     [Conditional("RELEASE")] public static void DrawRay(Vector3 start, Vector3 dir, Color color){}
     [Conditional("RELEASE")] public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration){}
     [Conditional("RELEASE")] public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest){}

     [Conditional("RELEASE")] public static void Log(object message){}
     [Conditional("RELEASE")] public static void Log(object message, UnityEngine.Object context){}
     [Conditional("RELEASE")] public static void LogError(object message){}
     [Conditional("RELEASE")] public static void LogError(object message, UnityEngine.Object context){}
     [Conditional("RELEASE")] public static void LogException(System.Exception exception){}
     [Conditional("RELEASE")] public static void LogException(System.Exception exception, UnityEngine.Object context){}
     [Conditional("RELEASE")] public static void LogWarning(object message){}
     [Conditional("RELEASE")] public static void LogWarning(object message, UnityEngine.Object context){}
}
#endif
```

[How to disable all logging on release build?](http://answers.unity3d.com/questions/1301347/how-to-disable-all-logging-on-release-build.html)
[Debug.Log() in build](http://answers.unity3d.com/questions/126315/debuglog-in-build.html)