# C#调用C++ DLL注意事项

`__declspec`用来声明DLL中的导入导出函数，如：`__declspec(dllexport)`和`__declspec(dllimport)`。

使用Visual Studio来创建DLL会自动定义一个宏`MYPROJECT_EXPORTS`，"MYPROJECT"是你的项目的名字，我们可以这样来使用
```cpp
#ifdef MYPROJECT_EXPORTS
#define MYPROJECT_API __declspec(dllexport)
#else
#define MYPROJECT_API __declspec(dllimport)
#endif
```

`__cdecl`和`__stdcall`等都是函数的调用规范，规定了参数出入栈的顺序和方法。

`__cdecl`是C语言默认的函数调用方法，`__stdcall`是C++的标准调用方式，所以我们创建和使用DLL的时候必须统一调用方式。

DLL中
```cpp
//定义一个宏方便修改
#define CALL_METHOD __stdcall

MYPROJECT_API void CALL_METHOD Init(const char* devIp, const unsigned short port, const char* userName, const char* password);
MYPROJECT_API void CALL_METHOD Stop();
```
C#中
```csharp
//使用DllImport来导入DLL中的函数并注明调用方式
[DllImport("MyProject.dll", CallingConvention = CallingConvention.StdCall)]
public static extern int Init(string devIp, int port, string userName, string password);
//C#默认使用StdCall，可以省略
[DllImport("MyProject.dll")]
public static extern void Stop();
```

`extern "C"`，C++因为函数重载的问题在编译函数的时候会加上一些奇怪的字符，所以在调用DLL的时候会出现找不到函数的问题，`extern "C"`告诉编译器按照C语言的方式编译C++函数。
```cpp
extern "C" MYPROJECT_API void CALL_METHOD Stop();
```
如果有多个函数，可以这样写
```cpp
#ifdef __cplusplus
extern "C" {
#endif
	MYPROJECT_API void CALL_METHOD Init(const char* devIp, const unsigned short port, const char* userName, const char* password);
	MYPROJECT_API void CALL_METHOD Stop();
#ifdef __cplusplus
}
#endif
```

回调函数，我们有时候需要将回调函数传入DLL中，在C++中一般使用typedef的方式定义，在C#中可以使用delegate来定义回调函数，注意这里也需要统一函数的调用规范。

DLL中
```cpp
//定义一个宏方便修改
#define CALLBACK __stdcall
//使用__stdcall方式
typedef void(CALLBACK *DecodeCallback)(int width, int height, long size, char* buf);

#ifdef __cplusplus
extern "C" {
#endif
	MYPROJECT_API void CALL_METHOD Init(const char* devIp, const unsigned short port, const char* userName, const char* password);
	MYPROJECT_API void CALL_METHOD RegisterCallBack(DecodeCallback callback);
	MYPROJECT_API void CALL_METHOD Stop();
#ifdef __cplusplus
}
#endif
```
C#中
```csharp
//使用StdCall方式
[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public delegate void DecodeCallback(int width, int height, int size, IntPtr buf);

[DllImport("MyProject.dll")]
public static extern void RegisterCallBack(DecodeCallback callback);
```

>尤其要注意的是，如果调用的DLL还引用了其他的DLL，如果其他的DLL缺失或有问题则会出现找不到你写的DLL的情况，在这被坑了，一直以为自己写的DLL有问题。

**参考**

[编写和使用DLL时，常用的关键字 extern "C"，__declspec，__cdecl，__stdcall](http://blog.csdn.net/bobbypeng/article/details/6427441)
[演练：创建和使用动态链接库 (C++)](https://msdn.microsoft.com/zh-cn/library/ms235636.aspx)
[How to make a callback to C# from C/C++ code](https://www.codeproject.com/Tips/318140/How-to-make-a-callback-to-Csharp-from-C-Cplusplus)