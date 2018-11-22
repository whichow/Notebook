
- 报错1 
```
Failed to compile resources with the following parameters:
-bootclasspath "E:\software\Android\AndroidSDK_ForUnity5\platforms\android-24\android.jar" -d "D:\h5\UnityProjects\IceClimber\Temp\StagingArea\bin\classes" -source 1.6 -target 1.6 -encoding UTF-8 "android\support\customtabs\R.java" "android\support\graphics\drawable\R.java" "android\support\graphics\drawable\animated\R.java" "android\support\v4\R.java" "android\support\v7\appcompat\R.java" "android\support\v7\cardview\R.java" "com\facebook\R.java" "com\facebook\android\R.java" "com\herofun\iceclimber\R.java"
```
解决方案: 
可能是jdk版本低了，使用jdk8解决。


- 报错2 
```
IOException: Failed to Move File / Directory from 'Temp/StagingArea\android-libraries\app-debug\classes.jar' to 'Temp/StagingArea\android-libraries\app-debug\libs\classes.jar'.
UnityEditor.Android.PostProcessor.Tasks.ProcessAAR.Execute (UnityEditor.Android.PostProcessor.PostProcessorContext context)
UnityEditor.Android.PostProcessor.PostProcessRunner.RunAllTasks (UnityEditor.Android.PostProcessor.PostProcessorContext context)
UnityEditor.Android.PostProcessAndroidPlayer.PostProcess (BuildTarget target, System.String stagingAreaData, System.String stagingArea, System.String playerPackage, System.String installPath, System.String companyName, System.String productName, BuildOptions options, UnityEditor.RuntimeClassRegistry usedClassRegistry)
UnityEditor.Android.AndroidBuildPostprocessor.PostProcess (BuildPostProcessArgs args)
UnityEditor.PostprocessBuildPlayer.Postprocess (BuildTarget target, System.String installPath, System.String companyName, System.String productName, Int32 width, Int32 height, System.String downloadWebplayerUrl, System.String manualDownloadWebplayerUrl, BuildOptions options, UnityEditor.RuntimeClassRegistry usedClassRegistry, UnityEditor.BuildReporting.BuildReport report) (at C:/buildslave/unity/build/Editor/Mono/BuildPipeline/PostprocessBuildPlayer.cs:186)
UnityEditor.HostView:OnGUI()
```
解决方案：删除aar中的libs/classes.jar

- 报错3 
```
Error: [Temp\StagingArea\AndroidManifest-main.xml:12, 
D:\h5\UnityProjects\Test\AARTest\Temp\StagingArea\android-libraries\app-debug\AndroidManifest.xml:3] 
Main manifest has <uses-sdk android:minSdkVersion='9'> but library uses minSdkVersion='15'
UnityEditor.HostView:OnGUI()
```
解决方案：在Unity的PlayerSetting中把minSdkVersion设成与第三方库中的minSdkVersion一致

- 报错4 
```
CommandInvokationFailure: Failed to re-package resources.
E:\software\Android\AndroidSDK_ForUnity5\build-tools\24.0.1\aapt.exe package
 --auto-add-overlay -v -f -m -J "gen" -M "AndroidManifest.xml" -S "res" -I 
 "E:\software\Android\AndroidSDK_ForUnity5\platforms\android-25\android.jar" 
 -F bin/resources.ap_ --extra-packages com.zwwx.game.gamesupport -S 
 "D:\h5\UnityProjects\Test\AARTest\Temp\StagingArea\android-libraries\app-debug\res"
 ```
错误原因：build-tools用的版本是24，platforms版本用的是android-25, 两个版本不一致导致报错。  
解决方案：使用platforms/android-24打包

- 报错5 
```
CommandInvokationFailure: Unable to merge android manifests. See the Console for more details. 
E:\software\Java\jdk8\bin\java.exe -Xmx2048M -Dcom.android.sdkmanager.toolsdir="E:\software\Android\AndroidSDK_ForUnity5\tools" -Dfile.encoding=UTF8 -jar "E:\software\Unity5_5\Editor\Data\PlaybackEngines\AndroidPlayer/Tools\sdktools.jar" -
stdout[
Warning: [Temp\StagingArea\AndroidManifest-main.xml:12, 
D:\h5\UnityProjects\Test\AARTest\Temp\StagingArea\android-libraries\app-debug\AndroidManifest.xml:3] 
Main manifest has <uses-sdk android:targetSdkVersion='23'> but library uses targetSdkVersion='25'
]
```
错误原因：第三方库与Unity中用的SDK的targetSdkVersion版本不一致。  
解决方案：Unity使用targetSdkVersion='25'打包。
Android SDK升级到以下版本
platforms/android-25、tools_r25.2.5-windows、build-tools_r25.0.2-windows
注意：最新版本的tools下没有android.bat命令，打包会报Error:Invalid command android错误

- 报错6 
```
CommandInvokationFailure: Unable to list target platforms. Please make sure the android sdk path is correct. See the Console for more details. 
E:\software\Java\jdk8\bin\java.exe -Xmx2048M -Dcom.android.sdkmanager.toolsdir="E:\software\Android\AndroidSDK\tools" -Dfile.encoding=UTF8 -jar "E:\software\Unity5_5\Editor\Data\PlaybackEngines\AndroidPlayer/Tools\sdktools.jar" -
stderr[
Error:Invalid command android
]
```
错误原因
新版本的tools下没有android.bat命令，所以打包时报Error:Invalid command android
解决方案
下个旧版本的tools再打包。tools_r25.2.5-windows.zip

- 报错7 
```
UnityException: Adding Android library projects failed!
UnityEditor.Android.AndroidLibraries.AddLibraryProject (System.String projectPropertiesPath)
UnityEditor.Android.AndroidLibraries.FindAndAddLibraryProjects (System.String searchPattern)
UnityEditor.Android.PostProcessor.Tasks.AddAndroidLibraries.Execute (UnityEditor.Android.PostProcessor.PostProcessorContext context)
UnityEditor.Android.PostProcessor.PostProcessRunner.RunAllTasks (UnityEditor.Android.PostProcessor.PostProcessorContext context)
```
原因：aar中的某些文件被删除了，比如aar中的AndroidManifest.xml被删除了。  
解决方案：重新生成个aar

- 报错8 
```
Error:Execution failed for task ':processReleaseGoogleServices'.
> No matching client found for package name 'com.zwwx.game.WinterJump'
```
原因：google-services.json中的包名与build.gradle中的包名不一致。  
解决方案：改成一致就行了。


- 报错9 
```
用gradle build打包时报以下错 
To run dex in process, the Gradle daemon needs a larger heap.
It currently has 1024 MB.
For faster builds, increase the maximum heap size for the Gradle daemon to at le
ast 1536 MB.
To do this set org.gradle.jvmargs=-Xmx1536M in the project gradle.properties.
For more information see https://docs.gradle.org/current/userguide/build_environ
ment.html
```
原因：gradle需要更大内存  
解决方案: 修改gradle-wrapper.properties文件。 
在gradle-wrapper.properties文件中添加一条配置 
set  org.gradle.jvmargs=-Xmx2048m -XX:MaxPermSize=2048m



- 报错10 
```
Parsing json file: D:\xxx\google-services.json
:processDebugGoogleServices FAILED
FAILURE: Build failed with an exception.
* What went wrong:
Execution failed for task ':processDebugGoogleServices'.
> No matching client found for package name 'com.xx.xxx.xxxxx'
* Try:
Run with --stacktrace option to get the stack trace. Run with --info or --debug option to get more log output.
```
原因：google-services.json中定义的包名与AndroidManifest.xml中定义的包名不一致。  
解决方案：包名改一致。



- 报错11 
```
Rejecting re-init on previously-faile d class java.lang.Class<com.helpshift.support.adapters.QuestionListAdapter>: java.lang.NoClassDefFoundError: Failed resolution of: Landroid/support/v7/widget/RecyclerView$Adapter;
```
解决方案: 删除libs下的android-support-v4.jar保留android-support-v7-appcompat.jar

- 报错12 
```
Cannot build to Android: CommandInvokationFailure: Android Asset Packaging Tool failed.  
```
原因：SteamingAssets里的文件名有中文，或者有过大文件  
解决方案：修改命名，删掉大文件。

[Unity打Android包报错总结](https://blog.csdn.net/qq_28775437/article/details/78605691)