Unity插件开发指南
**什么是插件**

用C，C++，Objective-C编写的native代码库

允许Unity C\#代码调用这些库

**为什么需要开发插件**

Unity3D不能做到的功能

重复利用现有的C/C++/Objective-C组件

跨设备，跨平台

安全问题

**接口**

和.Net中调用Unmanaged DLL类似

同步调用(Sync)

    调用函数得到返回值

异步调用(Async)

    使用UnitySendMessage

名字修饰(name mangling)问题

    使用extern "C"

    或  \_ZN·9funtown·7ios·6init·E

**为不同设备开发插件**

Compile time - iOS

    \#if UNITY\_IOS

    \#else

    \#endif

Compile time - Android

    \#if UNITY\_ANDROID

    \#else

    \#endif

Runtime - iOS

    if (Application.platform == RuntimePlatform.OSXPlayer)

Runtime - Android

    if (Application.platform == RuntimePlatform.Android)

**iOS Plugins**

C\# Dll Import

\[DllImport ("\_\_Internal")\]

private static extern void iosInit(bool cookie, bool logging, bool status, bool frictionlessRequests);

C/C++ Native Functions in xxx.mm

extern "C" {

void iosInit(bool \_cookie, bool \_logging, bool \_status, bool \_frictionlessRequests) {

        \[\[FbUnityInterface alloc\] initWithCookie:\_cookie logging:\_logging status:\_status frictionlessRequests:\_frictionlessRequests\];

    }

}

\#ifdef \_\_cplusplus

extern "C" {

\#endif

void UnitySendMessage(const char\* obj, const char\* method, const char\* msg);

\#ifdef \_\_cplusplus

}

\#endif

**iOS Tips**

不要每一帧调用插件，会影响性能

传递string应该使用UTF-8编码

使用容易编码和解码的包裹消息来跨语言，如Json,Query String

使用Xcode Editor来自动化编译

**Android Plugins**

C\# Dll Import

\[DllImport ("unityinapppurchase")\]

private static extern void androidFTInit (bool cookie, bool logging, bool status, bool frictionlessRequests);

C++ Native Functions in unityinapppurchase. so

extern "C" {

    void androidFTInit(bool \_cookie, bool \_logging, bool \_status, bool \_frictionlessRequests)              {

        LOGD("androidFTInit called");

    }

}

C\# Load Java Class

AndroidJavaClass jc= new AndroidJavaClass("tw.com.funtown.unity.FT");

jc.CallStatic("init", "");

jc.Call("say", "android");

string info = jc.GetStatic&lt;string&gt;("info");

string message = jc.Get&lt;string&gt;("message");

C\# Load Java Object

AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some string");

int length = jo.Call&lt;int&gt;("length");

string valueString = jo.CallStatic&lt;string&gt;("valueOf", 42.0);

Java Class

public class FT { 

    public static String info = "Welcome!";

    public String msg;

    public static void init(String params) {

        Log.d("FTUnitySDK", "init called with params: " + params); 

    }

    public void say(String msg) {

        message = msg;

        Log.d("FTUnitySDK", "Hello, " + message);

    }

}

Overwrite onActivityResult

public class FTUnityPlayerActivity extends UnityPlayerActivity {

    public void onActivityResult(int requestCode, int resultCode, Intent data)  {   

        Log.d("FTUnityPlayerActivity", "onActivityResult: requestCode: " + requestCode + ", resultCode:" + resultCode);  

    }

}

Modify your Manifest.xml Automatically

&lt;activity android:name="tw.com.funtown.unity.FTUnityPlayerActivity" &gt;

    &lt;intent-filter&gt;

        &lt;action android:name="android.intent.action.MAIN" /&gt;

        &lt;category android:name="android.intent.category.LAUNCHER" /&gt;

    &lt;/intent-filter&gt;

&lt;/activity&gt;

Call UnitySendMessage using JNI

bool retval=JniHelper::getStaticMethodInfo(t, "com/unity3d/player/UnityPlayer" ,"UnitySendMessage" ,"(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");

if(retval==false) return;

jstring objectStr = t.env-&gt;NewStringUTF(obj);

jstring methodStr = t.env-&gt;NewStringUTF(method);

jstring msgStr = t.env-&gt;NewStringUTF(msg);

t.env-&gt;CallStaticVoidMethod(t.classID,t.methodID,objectStr,methodStr,msgStr);

jthrowable exception = t.env-&gt;ExceptionOccurred();

if (exception) {

    t.env-&gt;ExceptionDescribe();

    t.env-&gt;DeleteLocalRef(exception);

    t.env-&gt;ExceptionClear();

} else {

}

//Please delete your allocated resource here

**Android Tips**

不要每一帧调用插件

在C\#中使用垃圾回收器 using(){...} 或 Dispose

把\*.jar,\*.so放在Assets/Plugins中

注意Android资源冲突问题


