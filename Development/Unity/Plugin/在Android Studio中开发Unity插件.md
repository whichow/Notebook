在Android Studio中开发Unity插件
<div>

<div>

我们将定义一个函数DoSomething()使用Java
Log.i()输出一些信息，并且在Unity3D中调用这个函数

</div>

<div>

\

</div>

<div>

打开Android Studio，创建一个Empty Activity的Android工程(AndroidAddin)。

</div>

<div>

\

</div>

<div>

使用AndroidLib生成jar：

</div>

<div>

在Android
Studio中添加一个新的模块(AndroidLib)，通过菜单File-&gt;New-&gt;New
Module，选择Android Library。

</div>

<div>

将工程编译一下，确保所有工作正常。

</div>

<div>

在AndroidLib模块中，添加一个类叫做"AndroidLibHelper"。

</div>

<div>

在AndroidLibHelper类中添加一个函数DoSomethingInAndroid()：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

package com.androidaddin.androidlib;

</div>

<div>

import android.util.Log;

</div>

<div>

public class AndroidLibHelper {

</div>

<div>

    public static void DoSomethingInAndroid() {

</div>

<div>

        Log.i(“Unity”, “Hi, Somthing is done in Android”);

</div>

<div>

    }

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

为了确保能正常工作，在主app中，加上如下测试函数(如果找不到AndroidLibHelper类需要添加依赖)：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

@Override

</div>

<div>

protected void onCreate(Bundle savedInstanceState) {

</div>

<div>

    super.onCreate(savedInstanceState);

</div>

<div>

    setContentView(R.layout.activity\_main);

</div>

<div>

    AndroidLibHelper.DoSomethingInAndroid(); // Testing

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

运行这个App将在Logcat输出窗口中看到：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

… 15:59:57.276 12121-12121/com.xxx.xxx

</div>

<div>

I/Unity: Hi, Something is done in Android

</div>

</div>

<div>

\

</div>

<div>

编译AndroidLib模块，你将在androidlib-&gt;build-&gt;outputs-&gt;aar中看到.aar文件，其中包含了Java代码和Android资源文件。

</div>

<div>

解压\*-debug.aar文件，将看到一个只包含了Java代码的classes.jar文件。

</div>

<div>

\

</div>

<div>

使用JavaLib生成jar：

</div>

<div>

在Android Studio添加一个新的模块(JavaLib)，通过菜单File-&gt;New-&gt;New
Module，选择Java Library。

</div>

<div>

在JavaLib模块中，添加一个Java类。

</div>

<div>

编译JavaLib模块，在菜单中选择Build-&gt;Edit Libraries and Dependencies

</div>

<div>

添加JavaLib到app的依赖中，Gradle将会自动在javalib-&gt;build-&gt;libs文件夹中生成一个.jar文件。

</div>

<div>

\

</div>

<div>

将.jar文件放到Unity的Assets/Plugins/Android文件夹中。

</div>

<div>

创建一个脚本TestAndroidPlugin.cs绑定到camera上：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

public class TestAndroidPlugin : MonoBehaviour {

</div>

<div>

    void Start () {

</div>

<div>

        var jc = new
AndroidJavaClass("com.androidaddin.androidlib.AndroidLibHelper");

</div>

<div>

        jc.CallStatic("DoSomethingInAndroid");

</div>

<div>

    }

</div>

<div>

}

</div>

</div>

<div>

\

</div>

</div>
