Invoke时需要注意的问题
**DllImport：**

我们可以使用DllImport来导入非托管代码中的函数，例如：

[TABLE]

第一个参数为需要导入的dll名称，

EntryPoint指明dll中的函数入口，如果定义的函数名和dll中的函数名相同则可以不指定，

CharSet指明dll中字符的编码格式，默认为CharSet.Auto，

CallingConvention指明函数的调用方式，默认为CallingConvention.StdCall。

extern说明该函数是从C/C++导入的，函数必须为static。

**函数导出：**

我们使用\_\_declspec(dllexport)来导出函数，例如：

[TABLE]

extern "C"指明函数以C函数规范来编译和链接(C++为了实现函数重载会在编译时修改函数名)，

\_\_stdcall指明以StdCall(C/C++的默认方式为\_\_cdecl)方式调用函数，

我们可以使用宏定义来简化：

[TABLE]

**函数调用约定：**

Cdecl方式是C/C++语言的默认调用方式，StdCall是DllImport默认调用非托管函数的方式，所以在C\#中调用非托管的C/C++dll时需要指明调用方式为Cdecl，在DllImport中加上CallingConvention=CallingConvention.Cdecl。我们也可以在写dll时C/C++的函数声明中加上\_\_stdcall来告诉编译器使用StdCall的方式来编译，这样在调用时就可以不指明CallingConvention了。

**可变参数：**

当需要使用非托管dll中可变参数的方法时，例如：

[TABLE]

可以使用\_\_arglist关键字：

[TABLE]

需要显式指定 CallingConvention = CallingConvention.Cdecl，这样会由调用方清理堆栈，才能支持可变参数的方法。

调用方法时，也必须将可变参数用 \_\_arglist() 括起来：

[TABLE]

即使不传递任何可选参数，也必须写 \_\_arglist()。


