Android操作系统提供一个AssetManager类来加载这类Raw文件，在unity3d中可以直接通过unity提供的JNI封装来调用这些接口达到读取数据的目的。

```csharp
//取得应用的Activity 
var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
//从Activity取得AssetManager实例 
var assetManager = activity.Call<AndroidJavaObject>("getAssets"); 
//打开文件流 
var stream = assetManager.Call<AndroidJavaObject>("open", filePath); 
//获取文件长度 
var availableBytes = stream.Call<int>("available"); 
//取得InputStream.read的MethodID 
var clsPtr = AndroidJNI.FindClass("java.io.InputStream"); 
var METHOD_read = AndroidJNIHelper.GetMethodID(clsPtr, "read", "([B)I"); 
//申请一个Java ByteArray对象句柄 
var byteArray = AndroidJNI.NewByteArray(availableBytes); 
//调用方法 
int readCount = AndroidJNI.CallIntMethod(stream.GetRawObject(), METHOD_read, new[] { new jvalue() { l = byteArray } }); 
//从Java ByteArray中得到C# byte数组 
var bytes = AndroidJNI.FromByteArray(byteArray); 
//删除Java ByteArray对象句柄 
AndroidJNI.DeleteLocalRef(byteArray); 
//关闭文件流 
stream.Call("close"); 
stream.Dispose(); 
//返回结果 
return bytes;
```
