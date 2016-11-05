Invoke时需要注意的问题
<div>

<div>

**DllImport：**

</div>

<div>

我们可以使用DllImport来导入非托管代码中的函数，例如：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| \[DllImport("Win32DLL.dll", EntryPoint = "add", CharSet = CharSet.Auto,  |
| CallingConvention = CallingConvention.StdCall)\]                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| public static extern int AddNumber(int x, int y);                        |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

第一个参数为需要导入的dll名称，

</div>

<div>

EntryPoint指明dll中的函数入口，如果定义的函数名和dll中的函数名相同则可以不指定，

</div>

<div>

CharSet指明dll中字符的编码格式，默认为CharSet.Auto，

</div>

<div>

CallingConvention指明函数的调用方式，默认为CallingConvention.StdCall。

</div>

<div>

\

</div>

<div>

extern说明该函数是从C/C++导入的，函数必须为static。

</div>

<div>

\

</div>

<div>

**函数导出：**

</div>

<div>

我们使用\_\_declspec(dllexport)来导出函数，例如：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| extern "C" \_\_declspec(dllexport) int \_\_stdcall add(int x,int y);     |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

extern
"C"指明函数以C函数规范来编译和链接(C++为了实现函数重载会在编译时修改函数名)，

</div>

<div>

\_\_stdcall指明以StdCall(C/C++的默认方式为\_\_cdecl)方式调用函数，

</div>

<div>

我们可以使用宏定义来简化：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| \#define DllExport \_\_declspec((dllexport)                              |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

\

</div>

<div>

**函数调用约定：**

</div>

<div>

Cdecl方式是C/C++语言的默认调用方式，StdCall是DllImport默认调用非托管函数的方式，所以在C\#中调用非托管的C/C++dll时需要指明调用方式为Cdecl，在DllImport中加上CallingConvention=CallingConvention.Cdecl。我们也可以在写dll时C/C++的函数声明中加上\_\_stdcall来告诉编译器使用StdCall的方式来编译，这样在调用时就可以不指明CallingConvention了。

</div>

<div>

\

</div>

<div>

**可变参数：**

</div>

<div>

当需要使用非托管dll中可变参数的方法时，例如：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| int printf(const char \* format, ...);                                   |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

可以使用\_\_arglist关键字：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| \[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)\] |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| public static extern int printf(string format, \_\_arglist);             |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

需要显式指定 CallingConvention =
CallingConvention.Cdecl，这样会由调用方清理堆栈，才能支持可变参数的方法。

</div>

<div>

调用方法时，也必须将可变参数用 \_\_arglist() 括起来：

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| printf("Hello %s! is %d x %c\\n", \_\_arglist("World", 6, '7')); //      |
| Hello World! is 6 x 7                                                    |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

即使不传递任何可选参数，也必须写 \_\_arglist()。

</div>

</div>
