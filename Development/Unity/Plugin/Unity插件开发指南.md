Unity插件开发指南
<div>

<div>

**什么是插件**

</div>

<div>

用C，C++，Objective-C编写的native代码库

</div>

<div>

允许Unity C\#代码调用这些库

</div>

<div>

\

</div>

<div>

**为什么需要开发插件**

</div>

<div>

Unity3D不能做到的功能

</div>

<div>

重复利用现有的C/C++/Objective-C组件

</div>

<div>

跨设备，跨平台

</div>

<div>

安全问题

</div>

<div>

\

</div>

<div>

**接口**

</div>

<div>

和.Net中调用Unmanaged DLL类似

</div>

<div>

同步调用(Sync)

</div>

<div>

    调用函数得到返回值

</div>

<div>

异步调用(Async)

</div>

<div>

    使用UnitySendMessage

</div>

<div>

名字修饰(name mangling)问题

</div>

<div>

    使用extern "C"

</div>

<div>

    或  \_ZN·9funtown·7ios·6init·E

</div>

<div>

\

</div>

<div>

**为不同设备开发插件**

</div>

<div>

Compile time - iOS

</div>

<div>

    \#if UNITY\_IOS

</div>

<div>

    \#else

</div>

<div>

    \#endif

</div>

<div>

Compile time - Android

</div>

<div>

    \#if UNITY\_ANDROID

</div>

<div>

    \#else

</div>

<div>

    \#endif

</div>

<div>

Runtime - iOS

</div>

<div>

    if (Application.platform == RuntimePlatform.OSXPlayer)

</div>

<div>

Runtime - Android

</div>

<div>

    if (Application.platform == RuntimePlatform.Android)

</div>

<div>

\

</div>

<div>

**iOS Plugins**

</div>

<div>

C\# Dll Import

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\[DllImport ("\_\_Internal")\]

</div>

<div>

private static extern void iosInit(bool cookie, bool logging, bool
status, bool frictionlessRequests);

</div>

</div>

<div>

\

</div>

<div>

C/C++ Native Functions in xxx.mm

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

extern "C" {

</div>

<div>

void iosInit(bool \_cookie, bool \_logging, bool \_status, bool
\_frictionlessRequests) {

</div>

<div>

        \[\[FbUnityInterface alloc\] initWithCookie:\_cookie
logging:\_logging status:\_status
frictionlessRequests:\_frictionlessRequests\];

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

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\#ifdef \_\_cplusplus

</div>

<div>

extern "C" {

</div>

<div>

\#endif

</div>

<div>

void UnitySendMessage(const char\* obj, const char\* method, const
char\* msg);

</div>

<div>

\#ifdef \_\_cplusplus

</div>

<div>

}

</div>

<div>

\#endif

</div>

</div>

<div>

\

</div>

<div>

**iOS Tips**

</div>

<div>

不要每一帧调用插件，会影响性能

</div>

<div>

传递string应该使用UTF-8编码

</div>

<div>

使用容易编码和解码的包裹消息来跨语言，如Json,Query String

</div>

<div>

使用Xcode Editor来自动化编译

</div>

<div>

\

</div>

<div>

**Android Plugins**

</div>

<div>

C\# Dll Import

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\[DllImport ("unityinapppurchase")\]

</div>

<div>

private static extern void androidFTInit (bool cookie, bool logging,
bool status, bool frictionlessRequests);

</div>

</div>

<div>

\

</div>

<div>

C++ Native Functions in unityinapppurchase. so

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

extern "C" {

</div>

<div>

    void androidFTInit(bool \_cookie, bool \_logging, bool \_status,
bool \_frictionlessRequests)              {

</div>

<div>

        LOGD("androidFTInit called");

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

C\# Load Java Class

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

AndroidJavaClass jc= new AndroidJavaClass("tw.com.funtown.unity.FT");

</div>

<div>

jc.CallStatic("init", "");

</div>

<div>

jc.Call("say", "android");

</div>

<div>

string info = jc.GetStatic&lt;string&gt;("info");

</div>

<div>

string message = jc.Get&lt;string&gt;("message");

</div>

</div>

<div>

\

</div>

<div>

C\# Load Java Object

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some string");

</div>

<div>

int length = jo.Call&lt;int&gt;("length");

</div>

<div>

string valueString = jo.CallStatic&lt;string&gt;("valueOf", 42.0);

</div>

</div>

<div>

\

</div>

<div>

Java Class

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

public class FT { 

</div>

<div>

    public static String info = "Welcome!";

</div>

<div>

    public String msg;

</div>

<div>

    public static void init(String params) {

</div>

<div>

        Log.d("FTUnitySDK", "init called with params: " + params); 

</div>

<div>

    }

</div>

<div>

    public void say(String msg) {

</div>

<div>

        message = msg;

</div>

<div>

        Log.d("FTUnitySDK", "Hello, " + message);

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

Overwrite onActivityResult

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

public class FTUnityPlayerActivity extends UnityPlayerActivity {

</div>

<div>

    public void onActivityResult(int requestCode, int resultCode, Intent
data)  {   

</div>

<div>

        Log.d("FTUnityPlayerActivity", "onActivityResult: requestCode: "
+ requestCode + ", resultCode:" + resultCode);  

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

Modify your Manifest.xml Automatically

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

&lt;activity android:name="tw.com.funtown.unity.FTUnityPlayerActivity"
&gt;

</div>

<div>

    &lt;intent-filter&gt;

</div>

<div>

        &lt;action android:name="android.intent.action.MAIN" /&gt;

</div>

<div>

        &lt;category android:name="android.intent.category.LAUNCHER"
/&gt;

</div>

<div>

    &lt;/intent-filter&gt;

</div>

<div>

&lt;/activity&gt;

</div>

</div>

<div>

\

</div>

<div>

Call UnitySendMessage using JNI

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

bool retval=JniHelper::getStaticMethodInfo(t,
"com/unity3d/player/UnityPlayer" ,"UnitySendMessage"
,"(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");

</div>

<div>

if(retval==false) return;

</div>

<div>

jstring objectStr = t.env-&gt;NewStringUTF(obj);

</div>

<div>

jstring methodStr = t.env-&gt;NewStringUTF(method);

</div>

<div>

jstring msgStr = t.env-&gt;NewStringUTF(msg);

</div>

<div>

t.env-&gt;CallStaticVoidMethod(t.classID,t.methodID,objectStr,methodStr,msgStr);

</div>

<div>

jthrowable exception = t.env-&gt;ExceptionOccurred();

</div>

<div>

if (exception) {

</div>

<div>

    t.env-&gt;ExceptionDescribe();

</div>

<div>

    t.env-&gt;DeleteLocalRef(exception);

</div>

<div>

    t.env-&gt;ExceptionClear();

</div>

<div>

} else {

</div>

<div>

}

</div>

<div>

//Please delete your allocated resource here

</div>

</div>

<div>

\

</div>

<div>

**Android Tips**

</div>

<div>

不要每一帧调用插件

</div>

<div>

在C\#中使用垃圾回收器 using(){...} 或 Dispose

</div>

<div>

把\*.jar,\*.so放在Assets/Plugins中

</div>

<div>

注意Android资源冲突问题

</div>

</div>
