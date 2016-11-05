<div>

<div>

**为Android编译Java Plugin**

</div>

<div>

有多种方法可以创建一个Java插件并最终得到一个包含.class文件的.jar文件作为你的插件。一种途径是下载JDK，然后在命令行中使用javac来编译你的.java文件。这将会创建.class文件随后使用jar命令行将它们打包到一个.jar中。另一个选择是使用Eclipse
IDE和ADT。

</div>

<div>

\

</div>

<div>

**在native code中使用Java Plugin**

</div>

<div>

使用Java Native Interface (JNI)来访问Java code

</div>

<div>

要从native side找到Java code需要访问Java
VM。可以通过增加下面这个函数到C/C++代码中来实现：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
jint JNI_OnLoad(JavaVM* vm, void* reserved) {    JNIEnv* jni_env = 0;    vm->AttachCurrentThread(&jni_env, 0);    return JNI_VERSION_1_6;}
```

</div>

<div>

\

</div>

</div>

<div>

使用它可以找到类的定义，解析构造方法(&lt;init&gt;)和创建一个新的对象实例，示例如下：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
jobject createJavaObject(JNIEnv* jni_env) {    jclass cls_JavaClass = jni_env->FindClass("com/your/java/Class"); // find class definition    jmethodID mid_JavaClass = jni_env->GetMethodID (cls_JavaClass, "<init>", "()V"); // find constructor method    jobject obj_JavaClass = jni_env->NewObject(cls_JavaClass, mid_JavaClass); // create object instance    return jni_env->NewGlobalRef(obj_JavaClass); // return object with a global reference }
```

</div>

<div>

\

</div>

</div>

<div>

**通过帮助类来使用Java Plugin**

</div>

<div>

AndroidJNIHelper和AndroidJNI可以简化原生JNI的使用。

</div>

<div>

AndroidJavaObject和AndroidJavaClass自动做了大量工作并且使用了缓存来使得调用Java更加快速。AndroidJavaObject和AndroidJavaClass构建在AndroidJNIHelper和AndroidJNI之上，并且有大量自己的逻辑(用来自动化)。这些类也有static版本来访问Java类的静态成员。

</div>

<div>

\

</div>

<div>

AndroidJNI是对C中JNI调用的封装。这个类中的所有方法都是静态的并且是对JNI
1:1的映射。AndroidJNIHelper提供了对JNI操作，签名创建和方法查找的一些有用的方法。

</div>

<div>

AndroidJavaObject和AndroidJavaClass的实例分别有着和Java中java.lang.Object和java.lang.Class一对一的映射。它们基本上提供了对Java中的3种类型的操作：

</div>

-   调用一个方法(Call method)
-   获取一个字段的值(Get value)
-   设置一个字段的值(Set value)

<div>

调用分为两种类型的调用：调用一个'void'方法，和调用一个non-void返回类型的方法。non-void返回类型使用一个泛型用来表示返回的类型。Get和Set始终用一个泛型来表示字段类型。

</div>

<div>

\

</div>

<div>

示例1：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
//The comments describe what you would need to do if you were using raw JNIAndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string");// jni.FindClass("java.lang.String");// jni.GetMethodID(classID, "<init>", "(Ljava/lang/String;)V");// jni.NewStringUTF("some_string");// jni.NewObject(classID, methodID, javaString);int hash = jo.Call<int>("hashCode");// jni.GetMethodID(classID, "hashCode", "()I");// jni.CallIntMethod(objectID, methodID);
```

</div>

<div>

\

</div>

</div>

<div>

这里我们创建了一个java.lang.String的实例，实例化了一个字符串并且取得了该字符串的hash值。

</div>

<div>

AndroidJavaObject构造器至少需要一个参数，那就是我们想要构造的实例的类名。类名后面的参数都是用来构造这个对象的参数。随后的Call用来调用hashCode()方法返回一个'int'，这就是为什么我们要使用泛型方法的原因。

</div>

<div>

注意：你不能使用点号来实例化一个Java嵌套类。内部类必须使用\$分隔，并且使用点或者斜杠的格式。因此android.view.ViewGroup\$LayoutParams或
android/view/ViewGroup\$LayoutParams用来表示LayoutParams类嵌套在一个ViewGroup类中。

</div>

<div>

\

</div>

<div>

示例2：

</div>

<div>

展示了在C\#中怎样不使用插件来获取当前应用的cache目录

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");// jni.FindClass("com.unity3d.player.UnityPlayer");AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");// jni.GetStaticFieldID(classID, "Ljava/lang/Object;");// jni.GetStaticObjectField(classID, fieldID);// jni.FindClass("java.lang.Object");Debug.Log(jo.Call<AndroidJavaObject>("getCacheDir").Call<string>("getCanonicalPath"));// jni.GetMethodID(classID, "getCacheDir", "()Ljava/io/File;");// or any baseclass thereof!// jni.CallObjectMethod(objectID, methodID);// jni.FindClass("java.io.File");// jni.GetMethodID(classID, "getCanonicalPath", "()Ljava/lang/String;");// jni.CallObjectMethod(objectID, methodID);// jni.GetStringUTFChars(javaString);
```

</div>

<div>

\

</div>

</div>

<div>

本例中，我们使用AndroidJavaClass代替AndroidJavaObject，这是因为我们要访问一个com.unity3d.player.UnityPlayer的一个静态成员而不用创建一个新的对象(Android
UnityPlayer自动创建了这个实例)。然后我们访问其中的静态字段"currentActivity"，这次我们使用AndroidJavaObject作为泛型参数。这是因为实际字段的类型(android.app.Activity)是java.lang.Object的一个子类，任何非基本类型必须使用AndroidJavaObject来访问。字符串是一个例外，字符串可以直接访问，即使它在Java中不是一个基本类型。

</div>

<div>

\

</div>

<div>

示例3：

</div>

<div>

最后，这是一个使用UnitySendMessage来从Java传递数据到脚本代码中的技巧

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
using UnityEngine;public class NewBehaviourScript : MonoBehaviour {    void Start () {        AndroidJNIHelper.debug = true;        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {            jc.CallStatic("UnitySendMessage", "Main Camera", "JavaMessage", "whoowhoo");        }    }    void JavaMessage(string message) {        Debug.Log("message from java: " + message);    }}
```

</div>

<div>

\

</div>

</div>

<div>

Java类com.unity3d.player.UnityPlayer中有一个静态方法UnitySendMessage,等同于iOS
native sied的UnitySendMessage函数。它在Java中用来传递数据到脚本代码。

</div>

<div>

在这里，我们将从Java中调用"Main
Camera"物体上绑定的脚本中包含的"JavaMessage"方法。

</div>

<div>

\

</div>

<div>

对AndroidJavaObject或AndroidJavaClass的任何操作都会消耗大量的性能(因为JNI的原因)。为求性能和代码清晰，尽可能少的在managed和native/Java代码之间转换。

</div>

<div>

记住JNI帮助类会尽可能多的缓存数据来提高性能。

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
//The first time you call a Java function likeAndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string"); // somewhat expensiveint hash = jo.Call<int>("hashCode"); // first time - expensiveint hash = jo.Call<int>("hashCode"); // second time - not as expensive as we already know the java method and can call it directly
```

</div>

<div>

\

</div>

</div>

<div>

在使用完后Mono垃圾回收器应该释放所有创建的AndroidJavaObject和AndroidJavaClass实例，建议将它们放在using(){}语句中来确保尽可能快的被删除。

</div>

<div>

你也可以使用.Dispose()方法来确保没有Java对象残留。

</div>

<div>

\

</div>

<div>

**扩展UnityPlayerActivity Java代码**

</div>

<div>

在Unity Android中我们可以扩展标准的UnityPlayerActivity类(Unity
Player在Android中的基础Java类，就像AppController.mm在Unity iOS中)。

</div>

<div>

可以通过创建一个新的Activity继承自UnityPlayerActivity来重写其中Android
OS和Unity Android的交互(
UnityPlayerActivity.java在Mac中放在/Applications/Unity/Unity.app/Contents/PlaybackEngines/AndroidPlayer/src/com/unity3d/player下，在Windows中放在C:\\Program
Files\\Unity\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\src\\com\\unity3d\\player下)。

</div>

<div>

\

</div>

<div>

首先需要找到Unity
Android自带的classes.jar。它可以在安装目录中(通常在C:\\Program
Files\\Unity\\Editor\\Data (on Windows)或/Applications/Unity (on
Mac))的一个叫做PlaybackEngines/AndroidPlayer/Variations/mono or
il2cpp/Development or
Release/Classes/的子目录中找到。然后将classes.jar添加到类路径来编译新的Activity。产生的.class文件将被压缩成一个.jar文件，将它放在Assets-&gt;Plugins-&gt;Android文件夹中。因为manifest指定了启动时将加载哪个Activity所以也应该创建一个新的AndroidManifest.xml。这个AndroidManifest.xml也应该放在Assets-&gt;Plugins-&gt;Android文件夹中(自定义的manifest将会覆盖掉默认的Unity
Android manifest)。

</div>

<div>

\

</div>

<div>

下面是一个新Activity的示例，OverrideExample.java：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
package com.company.product;import com.unity3d.player.UnityPlayerActivity;import android.os.Bundle;import android.util.Log;public class OverrideExample extends UnityPlayerActivity {    protected void onCreate(Bundle savedInstanceState) {        // call UnityPlayerActivity.onCreate() super.onCreate(savedInstanceState);        // print debug message to logcat        Log.d("OverrideActivity", "onCreate called!");    }    public void onBackPressed() {        // instead of calling UnityPlayerActivity.onBackPressed() we just ignore the back button event        // super.onBackPressed();    }}
```

</div>

<div>

\

</div>

</div>

<div>

相应的AndroidManifest.xml会像这样：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
<?xml version="1.0" encoding="utf-8"?><manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.company.product">    <application android:icon="@drawable/app_icon" android:label="@string/app_name">        <activity android:name=".OverrideExample" android:label="@string/app_name" android:configChanges="fontScale|keyboard|keyboardHidden|locale|mnc|mcc|navigation|orientation|screenLayout|screenSize|smallestScreenSize|uiMode|touchscreen">            <intent-filter>                <action android:name="android.intent.action.MAIN" />                <category android:name="android.intent.category.LAUNCHER" />            </intent-filter>        </activity>    </application></manifest>
```

</div>

<div>

\

</div>

</div>

<div>

还可以创建UnityPlayerNativeActivity的子类。它的大部分效果和UnityPlayerActivity子类相同但是可以改善输入延时。注意NativityActivity在Gingerbread中被引入并且不能在旧的设备中运行。此后touch/motion事件将会在native
code中被处理Java
view通常将不会接收到这些事件。然而Unity中的一个转发机制可以允许这些事件传播到DalvikVM中。要允许这个机制，你需要修改manifest文件如下：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
<activity android:name=".OverrideExampleNative"><meta-data android:name="android.app.lib_name" android:value="unity" /> <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="true" />
```

</div>

<div>

\

</div>

</div>

<div>

将activity修改为我们的nativity
activity，增加了两个meta-data元素。第一个meta-data指定使用Unity库libunity.so。第二个表示允许事件转发。

</div>

</div>
