在Android Studio中开发Unity插件
我们将定义一个函数DoSomething()使用Java Log.i()输出一些信息，并且在Unity3D中调用这个函数

打开Android Studio，创建一个Empty Activity的Android工程(AndroidAddin)。

使用AndroidLib生成jar：

在Android Studio中添加一个新的模块(AndroidLib)，通过菜单File-&gt;New-&gt;New Module，选择Android Library。

将工程编译一下，确保所有工作正常。

在AndroidLib模块中，添加一个类叫做"AndroidLibHelper"。

在AndroidLibHelper类中添加一个函数DoSomethingInAndroid()：

package com.androidaddin.androidlib;

import android.util.Log;

public class AndroidLibHelper {

    public static void DoSomethingInAndroid() {

        Log.i(“Unity”, “Hi, Somthing is done in Android”);

    }

}

为了确保能正常工作，在主app中，加上如下测试函数(如果找不到AndroidLibHelper类需要添加依赖)：

@Override

protected void onCreate(Bundle savedInstanceState) {

    super.onCreate(savedInstanceState);

    setContentView(R.layout.activity\_main);

    AndroidLibHelper.DoSomethingInAndroid(); // Testing

}

运行这个App将在Logcat输出窗口中看到：

… 15:59:57.276 12121-12121/com.xxx.xxx

I/Unity: Hi, Something is done in Android

编译AndroidLib模块，你将在androidlib-&gt;build-&gt;outputs-&gt;aar中看到.aar文件，其中包含了Java代码和Android资源文件。

解压\*-debug.aar文件，将看到一个只包含了Java代码的classes.jar文件。

使用JavaLib生成jar：

在Android Studio添加一个新的模块(JavaLib)，通过菜单File-&gt;New-&gt;New Module，选择Java Library。

在JavaLib模块中，添加一个Java类。

编译JavaLib模块，在菜单中选择Build-&gt;Edit Libraries and Dependencies

添加JavaLib到app的依赖中，Gradle将会自动在javalib-&gt;build-&gt;libs文件夹中生成一个.jar文件。

将.jar文件放到Unity的Assets/Plugins/Android文件夹中。

创建一个脚本TestAndroidPlugin.cs绑定到camera上：

public class TestAndroidPlugin : MonoBehaviour {

    void Start () {

        var jc = new AndroidJavaClass("com.androidaddin.androidlib.AndroidLibHelper");

        jc.CallStatic("DoSomethingInAndroid");

    }

}


