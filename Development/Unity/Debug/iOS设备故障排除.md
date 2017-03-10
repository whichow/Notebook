有时候你的游戏可以在Unity编辑器下正常运行，但是在iOS真机设备上却不能运行甚至不能启动。

## 游戏一段时间后停止响应，XCode状态栏上显示“interrupted”

可能发生的原因有很多，通常包括：

1. 像未初始化变量之类的脚本错误。
2. 使用第三方Thumb指令编译的原生库，这些库在iOS SDK链接的时候触发一个问题可能导致随机崩溃。
3. 使用值类型的泛型作为可序列化脚本属性参数。
4. 在托管代码裁剪启用的时候使用反射。
5. 原生插件接口中的错误(托管代码方法签名和原生代码函数签名不匹配)。XCode调试控制台经常可以检测到这些问题(XCode菜单:View > Debug Area > Activate Console)。

## XCode控制台显示“Program received gignal:"SIGBUS" or EXC_BAD_ACCESS”错误

这个消息通常当你的程序收到NullReferenceException的时候出现在iOS设备上。有两种方法弄清楚故障发生在哪：

**托管栈追踪**

Unity包含了基于软件的NullReferenceException处理。AOT编译器包含在每次方法或变量访问一个对象时对空引用的快速检查。这个特性影响脚本性能，这也是为什么它只在开发版本启用(在build setting对话框中启用"script debugging"选项)。如果设置好了并且故障在.NET代码中发生了，你将不会再看到EXC_BAD_ACCESS。取而代之的是.NET异常文本将打印在XCode控制台中(或者你的代码将在"catch"语句中处理它)。通常输出可能会是这样：
```
Unhandled Exception: System.NullReferenceException: A null value was found where an object instance was required.
  at DayController+$handleTimeOfDay$121+$.MoveNext () [0x0035a] in DayController.js:122 
```
这表示故障发生在工作在一个协程中的DayController类的handleTimeOfDay方法中。如果是一个脚本代码的话它通常还会告诉你确切的行数(例如，"DayController.js:122")。出现问题的代码可能是下面这行：
```
Instantiate(_imgwww.assetBundle.mainAsset);
```
这可能发生在，比如说，脚本在没有先检查有没有正确下载的情况下访问了asset bundle。

**原生栈追踪**

原生栈追踪有很多强大的工具来找出故障，但是使用它们需要一些专业知识。此外，你通常在不能在这些原生(内存硬件访问)故障发生后继续。要追踪一个原生栈，在XCode调试控制台中键入bt all。仔细检查打印的栈追踪 - 它们可能包含关于哪里出现错误的线索。你可能看到这些：
```
...
Thread 1 (thread 11523): 

1. 0 0x006267d0 in m_OptionsMenu_Start ()
1. 1 0x002e4160 in wrapper_runtime_invoke_object_runtime_invoke_void__this___object_intptr_intptr_intptr ()
1. 2 0x00a1dd64 in mono_jit_runtime_invoke (method=0x18b63bc, obj=0x5d10cb0, params=0x0, exc=0x2fffdd34) at /Users/mantasp/work/unity/unity-mono/External/Mono/mono/mono/mini/mini.c:4487
1. 3 0x0088481c in MonoBehaviour::InvokeMethodOrCoroutineChecked ()
...
```
首先你应该找到"Thread 1"的栈追踪，它在主线程中。栈追踪的第一行将指出错误发生在哪里。在这个例子中，追踪指出了NullReferenceException发生在"OptionMenu"脚本的"Start"方法中。仔细观察这个方法的实现将揭示出问题的原因。当假定了错误的初始化顺序时，NullReferenceException通常发生在Start方法中。在一些情况下，只有一部分栈追踪可以在调试控制台中看到：
```
Thread 1 (thread 11523): 

1. 0 0x0062564c in start ()
```
这表示原生符号在应用的Release版本中被裁剪了。跟着下面的步骤可以获取权不的栈追踪：
- 从设备中移除应用。
- 清除所有targets。
- Build然后运行。
- 得到上面所说的栈追踪。

## EXC_BAD_ACCESS发生在当一个外部库被链接到Unity iOS应用中的时候

这通常发生在当外部库由ARM Thumb指令集编译的情况下。目前这些库不兼容Unity。这个问题可以不使用Thumb指令集重新编译库来解决。你可以在库的XCode工程中照着下面的步骤来：

- 在XCode中，选择从菜单中选择"View">"Navigators">"Show Project Navigator"
- 选择"Unity-iPhone"工程，激活"Build Settings"标签
- 在搜索区域输入："Other C Flags"
- 添加-mno-thumb标记，重新编译库。

如果没有库源文件，你可以向提供商要一个non-thumb版本的库。

## Xcode调试控制台显示: ExecutionEngineException: Attempting to JIT compile method ‘(wrapper native-to-managed) Test:TestFunc (int)’ while running with –aot-only

当退管函数委托被传递到原生函数中，但是需要的包装代码在构建应用的时候没有生成，通常会收到这类消息。你可以通过添加"MonoPInvokeCallbackAttribute"自定义属性来告诉AOT编译器哪些方法需要作为委托被传递到原生代码中。

示例代码：
```csharp
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using AOT;

public class NewBehaviourScript : MonoBehaviour {
    [DllImport ("__Internal")]
    private static extern void DoSomething (NoParamDelegate del1, StringParamDelegate del2);

    delegate void NoParamDelegate ();
    delegate void StringParamDelegate (string str);
    
    [MonoPInvokeCallback(typeof(NoParamDelegate))]
    public static void NoParamCallback() {
        Debug.Log ("Hello from NoParamCallback");
    }
    
    [MonoPInvokeCallback(typeof(StringParamDelegate))]
    public static void StringParamCallback(string str) {
        Debug.Log(string.Format("Hello from StringParamCallback {0}", str));
    }

    // Use this for initialization
    void Start() {
        DoSomething(NoParamCallback, StringParamCallback);
    }
}
```

## Xcode报编译错误: “ld : unable to insert branch island. No insertion point available. for architecture armv7”, “clang: error: linker command failed with exit code 1 (use -v to see invocation)”

这个错误通常意味着有太多的代码在一个单独的模块中。通常由在构建的时候包括了许多脚本文件或很大的外部.Net程序集导致。在启用了script debugging的时候情况更严重，因为它在每个函数中添加了一些很轻量的说明，使得很容易达到这个限制。

在player setting中启用托管代码裁剪对这种这个问题可能有帮助，尤其是引入了很大的外部.NET程序集。但是如果问题依然存在，最好的解决办法是将你的脚本代码分离到多个程序集中。最简单的方式是将一些代码移动到Plugins文件夹。在这个文件夹中的代码将打包到不同的程序集中。
