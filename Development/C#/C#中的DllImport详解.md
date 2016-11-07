C\#中的DllImport详解
C\#中的DllImport详解
--------------------

所属分类: [工作与学习](http://zhihuiqian.no10.cuttle.com.cn/list.asp?typeID=2) | 查看次数:495次 | 添加时间:2009-05-25 21:26:26

C\#中的DllImport详解
--------------------

添加时间:2009-05-25 21:26:26

  DllImport所在的名字空间 using System.Runtime.InteropServices;
  MSDN中对DllImportAttribute的解释是这样的：可将该属性应用于方法。DllImportAttribute 属性提供对从非托管 DLL 导出的函数进行调用所必需的信息。作为最低要求，必须提供包含入口点的 DLL 的名称。
  DllImport 属性定义如下：
   namespace System.Runtime.InteropServices
  {
  　 \[AttributeUsage(AttributeTargets.Method)\]
  　 public class DllImportAttribute: System.Attribute
  　 {
  　 　public DllImportAttribute(string dllName) {...}
  　 　public CallingConvention CallingConvention;
  　 　public CharSet CharSet;
  　　 public string EntryPoint;
  　 　public bool ExactSpelling;
  　 　public bool PreserveSig;
  　 　public bool SetLastError;
  　 　public string value { get {...} }
  　 }
  }  
  　　说明：  
  　　1、DllImport只能放置在方法声明上。 
  　　2、DllImport具有单个定位参数：指定包含被导入方法的 dll 名称的 dllName 参数。 
  　　3、DllImport具有五个命名参数：  
  　　　a、CallingConvention 参数指示入口点的调用约定。如果未指定 CallingConvention，则使用默认值 CallingConvention.Winapi。  
  　　　b、CharSet 参数指示用在入口点中的字符集。如果未指定 CharSet，则使用默认值 CharSet.Auto。 
  　　　c、EntryPoint 参数给出 dll 中入口点的名称。如果未指定 EntryPoint，则使用方法本身的名称。  
  　　　d、ExactSpelling 参数指示 EntryPoint 是否必须与指示的入口点的拼写完全匹配。如果未指定 ExactSpelling，则使用默认值 false。  
  　　　e、PreserveSig 参数指示方法的签名应当被保留还是被转换。当签名被转换时，它被转换为一个具有 HRESULT 返回值和该返回值的一个名为 retval 的附加输出参数的签名。如果未指定 PreserveSig，则使用默认值 true。  
  　　　f、SetLastError 参数指示方法是否保留 Win32"上一错误"。如果未指定 SetLastError，则使用默认值 false。  
  　　4、它是一次性属性类。  
  　　5、此外，用 DllImport 属性修饰的方法必须具有 extern 修饰符。

  DllImport的用法：
    DllImport("MyDllImport.dll")\]
    private static extern int mySum(int a,int b);

一 在C\#程序设计中使用Win32类库
常用对应类型：
1、DWORD 是 4 字节的整数，因此我们可以使用 int 或 uint 作为 C\# 对应类型。
2、bool 类型与 BOOL 对应。

示例一：调用 Beep() API 来发出声音
  Beep() 是在 kernel32.lib 中定义的，在MSDN 中的定义，Beep具有以下原型：
  BOOL Beep(DWORD dwFreq, // 声音频率
              DWORD dwDuration // 声音持续时间);
用 C\# 编写以下原型：
\[DllImport("kernel32.dll")\]
public static extern bool Beep(int frequency, int duration);

示例二：枚举类型和常量
  MessageBeep() 是在 user32.lib 中定义的，在MSDN 中的定义，MessageBeep具有以下原型：
  BOOL MessageBeep(UINT uType // 声音类型
                      );

用C\#编写一下原型：
public enum BeepType
{
　 SimpleBeep = -1,
　 IconAsterisk = 0x00000040,
　 IconExclamation = 0x00000030,
　 IconHand = 0x00000010,
　 IconQuestion = 0x00000020,
　 Ok = 0x00000000,
}
uType 参数实际上接受一组预先定义的常量，对于 uType 参数，使用 enum 类型是合乎情理的。
\[DllImport("user32.dll")\]
public static extern bool MessageBeep(BeepType beepType); 

示例三：处理结构
  有时我需要确定我笔记本的电池状况。Win32 为此提供了电源管理函数，搜索 MSDN 可以找到GetSystemPowerStatus() 函数。
  BOOL GetSystemPowerStatus(
　                             LPSYSTEM\_POWER\_STATUS lpSystemPowerStatus
                              );
  此函数包含指向某个结构的指针，我们尚未对此进行过处理。要处理结构，我们需要用 C\# 定义结构。我们从非托管的定义开始：
typedef struct \_SYSTEM\_POWER\_STATUS {
BYTE　 ACLineStatus;
BYTE　 BatteryFlag;
BYTE　 BatteryLifePercent;
BYTE　 Reserved1;
DWORD　BatteryLifeTime;
DWORD　BatteryFullLifeTime;
} SYSTEM\_POWER\_STATUS, \*LPSYSTEM\_POWER\_STATUS;
　　 然后，通过用 C\# 类型代替 C 类型来得到 C\# 版本。
struct SystemPowerStatus
{
　 byte ACLineStatus;
　 byte batteryFlag;
　 byte batteryLifePercent;
　 byte reserved1;
　 int batteryLifeTime;
　 int batteryFullLifeTime;
}
  这样，就可以方便地编写出 C\# 原型：
  \[DllImport("kernel32.dll")\]
  public static extern bool GetSystemPowerStatus(
　 ref SystemPowerStatus systemPowerStatus);
　　 在此原型中，我们用“ref”指明将传递结构指针而不是结构值。这是处理通过指针传递的结构的一般方法。
　　 此函数运行良好，但是最好将 ACLineStatus 和 batteryFlag 字段定义为 enum：
　　enum ACLineStatus: byte
　　 {
　　　 Offline = 0,
　　　 Online = 1,
　　　 Unknown = 255,
　　 }
　　 enum BatteryFlag: byte
　　 {
　　　 High = 1,
　　　 Low = 2,
　　　 Critical = 4,
　　　 Charging = 8,
　　　 NoSystemBattery = 128,
　　　 Unknown = 255,
　　 }
请注意，由于结构的字段是一些字节，因此我们使用 byte 作为该 enum 的基本类型

示例四：处理字符串

二 C\# 中调用C++代码
  int 类型
\[DllImport(“MyDLL.dll")\]
//返回个int 类型
public static extern int mySum (int a1,int b1);
//DLL中申明
extern “C” \_\_declspec(dllexport) int WINAPI mySum(int a2,int b2)
{
//a2 b2不能改变a1 b1
//a2=..
//b2=...
return a+b;
}

//参数传递int 类型
public static extern int mySum (ref int a1,ref int b1);
//DLL中申明
extern “C” \_\_declspec(dllexport) int WINAPI mySum(int \*a2,int \*b2)
{
//可以改变 a1, b1
\*a2=...
\*b2=...
return a+b;
}

DLL 需传入char \*类型
\[DllImport(“MyDLL.dll")\]
//传入值
public static extern int mySum (string astr1,string bstr1);
//DLL中申明
extern “C” \_\_declspec(dllexport) int WINAPI mySum(char \* astr2,char \* bstr2)
{
//改变astr2 bstr 2 ，astr1 bstr1不会被改变
return a+b;
}

DLL 需传出char \*类型
\[DllImport(“MyDLL.dll")\]
// 传出值
public static extern int mySum (StringBuilder abuf, StringBuilder bbuf );
//DLL中申明
extern “C” \_\_declspec(dllexport) int WINAPI mySum(char \* astr,char \* bstr)
{
//传出char \*　改变astr　bstr --&gt;abuf, bbuf可以被改变
return a+b;
}

DLL 回调函数

BOOL EnumWindows(WNDENUMPROC lpEnumFunc, LPARAM lParam)

using System;
using System.Runtime.InteropServices;
public delegate bool CallBack(int hwnd, int lParam); //定义委托函数类型
public class EnumReportApp
{
\[DllImport("user32")\]
public static extern int EnumWindows(CallBack x, int y);
public static void Main() {
CallBack myCallBack = new CallBack(EnumReportApp.Report); EnumWindows(myCallBack, 0);
}
public static bool Report(int hwnd, int lParam)
{
Console.Write("Window handle is ");
Console.WriteLine(hwnd); return true;
}
}

DLL 传递结构
BOOL PtInRect(const RECT \*lprc, POINT pt);

using System.Runtime.InteropServices;
\[StructLayout(LayoutKind.Sequential)\]
public struct Point {
public int x;
public int y;
}
\[StructLayout(LayoutKind.Explicit)\]
public struct Rect
{
\[FieldOffset(0)\] public int left;
\[FieldOffset(4)\] public int top;
\[FieldOffset(8)\] public int right;
\[FieldOffset(12)\] public int bottom;
}
Class XXXX {
\[DllImport("User32.dll")\]
public static extern bool PtInRect(ref Rect r, Point p);
}

[返回](http://zhihuiqian.no10.cuttle.com.cn/list.asp?typeID=2) [上一篇：新网站改版完成](http://zhihuiqian.no10.cuttle.com.cn/display.asp?typeID=2&newsID=385) [下一篇：C\#数组排序](http://zhihuiqian.no10.cuttle.com.cn/display.asp?typeID=2&newsID=350)


