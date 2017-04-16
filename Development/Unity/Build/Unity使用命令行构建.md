
我们除了可以在Unity Editor中来Build我们的程序外还可以使用Unity提供的命令行工具，这对于自动构建及持续集成来说非常有用，下面我们来看一下怎样使用命令行来构建一个Windows的应用程序。
```
"C:\Program Files (x86)\Unity5.3.4f1\Editor\Unity.exe" -batchmode -quit -projectPath "D:\Workspace\Projects\Unity\Ocean\ClientCode" -buildWindowsPlayer "D:\ClientCode\build.exe" -logFile "D:\log.txt"
```
参数说明：
- -batchmode 使用批处理模式运行Unity，这个模式不会弹出Unity窗口并排除任何人工的干预，如果后面跟了其他命令行参数，这个模式应该始终打开
- -quit 执行完后关闭Unity工程，Unity工程会一直在后台打开
- -projectPath 工程路径
- -buildWindowsPlayer 生成的可执行文件路径
- -logFile Log文件位置

如果要Build Android apk文件，将参数`-buildWindowsPlayer`替换成`-buildTarget Android`
```
"C:\Program Files (x86)\Unity5.3.4f1\Editor\Unity.exe" -batchmode -quit -projectPath "D:\Workspace\Projects\Unity\Ocean\ClientCode" -buildTarget Android "D:\ClientCode\build.apk"
```

使用代码来构建
```csharp
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;
using System.IO;

public class MyBuild {
	[MenuItem("Automation/Build Player")]
	public static void Perform() {
		string outputPath = GetArg("-outputPath");
		outputPath = !string.IsNullOrEmpty(outputPath) ? outputPath : @"D:\Android\build.apk";
		string dir = Path.GetDirectoryName(outputPath);
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
        //选择BuildSettings中所有场景的路径
        string[] scenePaths = EditorBuildSettings.scenes.Select (scene => scene.path).ToArray ();
        //Build Android apk
		BuildPipeline.BuildPlayer(scenePaths, outputPath, BuildTarget.Android, BuildOptions.None);
	}
    //获取命令行参数
	private static string GetArg(string name)
	{
		var args = System.Environment.GetCommandLineArgs();
		for (int i = 0; i < args.Length; i++)
		{
			if (args[i] == name && args.Length > i + 1)
			{
				return args[i + 1];
			}
		}
		return null;
	}
}

```
在命令行中运行
```
C:\Users\jiaki>"C:\Program Files (x86)\Unity5.3.4f1\Editor\Unity.exe" -batchmode -quit -projectPath "D:\Workspace\Projects\Unity\Demo\BuildTest" -executeMethod MyBuild.Perform -logFile "D:\log.txt"
```
参数说明：
- -executeMethod 执行一个我们在Unity中定义的方法，改方法必须是静态的，包含方法的文件要放在Editor文件夹中。

**参考**

[Command line arguments](https://docs.unity3d.com/Manual/CommandLineArguments.html)

[Getting started with Unity automation](https://effectiveunity.com/articles/getting-started-with-unity-automation/)

[Unity editor automation cheat sheet](https://effectiveunity.com/articles/unity-editor-automation-cheat-sheet/)

[Making most of Unity's command line](https://effectiveunity.com/articles/making-most-of-unitys-command-line/)