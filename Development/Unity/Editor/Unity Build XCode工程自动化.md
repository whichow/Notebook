我们在使用Unity Build XCode工程后，再从XCode工程编译时经常要修改plist文件，添加Framework或第三方库。如果Build的时候没有选择Append而是Replace的话，又要重新设置一遍。

那么有没有方法可以实现自动添加和修改我们所需要的东西呢，目前有两种自动实现方式

1.可以使用[XUPorter](https://github.com/onevcat/XUPorter)来完成这些工作，

2.从Unity5.0开始已经提供了这个功能，如果使用的是Unity4.x可以将https://bitbucket.org/Unity-Technologies/xcodeapi放到工程中。

这里使用第二种方式来实现，可以参考[Unity官方实现的例子](https://bitbucket.org/Unity-Technologies/iosnativecodesamples/src/a0bc90e7d6358e456caf25d717134864218740a7/NativeIntegration/Misc/UpdateXcodeProject/Assets/Editor/XcodeProjectUpdater.cs?at=stable&fileviewer=file-view-default)
```csharp
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using UnityEditor.iOS.Xcode;
using System.IO;

public class MyBuildPostprocessor {

	internal static void CopyAndReplaceDirectory(string srcPath, string dstPath)
	{
		if (Directory.Exists(dstPath))
			Directory.Delete(dstPath);
		if (File.Exists(dstPath))
			File.Delete(dstPath);

		Directory.CreateDirectory(dstPath);

		foreach (var file in Directory.GetFiles(srcPath))
			File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));

		foreach (var dir in Directory.GetDirectories(srcPath))
			CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
	}

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
	
		if (buildTarget == BuildTarget.iPhone) {
			string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
			
			PBXProject proj = new PBXProject();
			proj.ReadFromString(File.ReadAllText(projPath));

			string target = proj.TargetGuidByName("Unity-iPhone");

			// Add user packages to project. Most other source or resource files and packages 
			// can be added the same way.
			CopyAndReplaceDirectory("NativeAssets/TestLib.bundle", Path.Combine(path, "Frameworks/TestLib.bundle"));
			proj.AddFileToBuild(target, proj.AddFile("Frameworks/TestLib.bundle", 
													 "Frameworks/TestLib.bundle", PBXSourceTree.Source));
			
			CopyAndReplaceDirectory("NativeAssets/TestLib.framework", Path.Combine(path, "Frameworks/TestLib.framework"));
			proj.AddFileToBuild(target, proj.AddFile("Frameworks/TestLib.framework", 
													 "Frameworks/TestLib.framework", PBXSourceTree.Source));
		
			// Add custom system frameworks. Duplicate frameworks are ignored.
			// needed by our native plugin in Assets/Plugins/iOS
			proj.AddFrameworkToProject(target, "AssetsLibrary.framework", false /*not weak*/);

			// Add our framework directory to the framework include path
			proj.SetBuildProperty(target, "FRAMEWORK_SEARCH_PATHS", "$(inherited)");
			proj.AddBuildProperty(target, "FRAMEWORK_SEARCH_PATHS", "$(PROJECT_DIR)/Frameworks");

			// Set a custom link flag
			proj.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");

			File.WriteAllText(projPath, proj.WriteToString());
		}
	}
}

```
更多方法可以查看Unity文档[PBXProject](https://docs.unity3d.com/ScriptReference/iOS.Xcode.PBXProject.html)

**参考**

[Unity3D研究院之IOS全自动编辑framework、plist、oc代码（六十七）](http://www.xuanyusong.com/archives/2720)

[UnityでのXcode設定をUnityEditorのスクリプトだけで自動化する](http://cflat-inc.hatenablog.com/entry/2015/01/05/074442)

[自动修改 Unity3d 导出的 Xcode 项目](http://blog.mutoo.im/2015/09/using-postprocessbuild-for-unity-ios-project.html)