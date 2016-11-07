在C\#中：

``` prettyprint
//定义delegatepublic delegate void ExportFinishedCallback ();//导入外部函数#if (UNITY_IPHONE || UNITY_IOS)[DllImport("__Internal", CharSet = CharSet.Auto)]public static extern void mergeAndSaveAudioVideo(string audioFilePath, string videoFilePath, string outputFilePath, ExportFinishedCallback onExportFinished);#endif//回调，第一种方式，直接传入回调函数//回调函数定义，如果编译的方式为IL2CPP而不是Mono2x的话需要加上MonoPInvokeCallback[MonoPInvokeCallback(typeof (ExportFinishedCallback ))]private static void OnExportFinished(){    Debug.Log( "____________Export Finished______________" );}//调用函数mergeAndSaveAudioVideo(audioPath, videoPath, outputPath, OnExportFinished);//回调，第二种方式，定义ExportFinishedCallback类型的参数传入pubic static ExportFinishedCallback callback;private void OnExportFinished(){    Debug.Log( "____________Export Finished_____________" );}//调用函数callback = OnExportFinished;mergeAndSaveAudioVideo(audioPath, videoPath, outputPath, callback);
```

在Objective-C中：

``` prettyprint
//定义回调函数指针typedef void (*ExportFinishedCallback)();//导出函数extern "C" void mergeAndSaveAudioVideo(const char* audioFilePath, const char* videoFilePath, const char* outputFilePath, ExportFinishedCallback onExportFinished);//调用回调函数onExportFinished();
```

注意事项：

在Native Code中需要采用全局或者静态变量的方式保持对象，否则可能在回调函数执行前对象就被自动释放而不能执行回调函数。

如果回调函数的参数中有数组，必须用 \[MarshalAs(UnmanagedType.LPArray, SizeConst = 23)\]标记参数，指定为数组且标记数组长度，如果调用时不能确定数组的长度，数组长度需要从Native Code中返回，在回调函数中通过获取IntPtr和数组长度这两个参数的方式来得到数组。


