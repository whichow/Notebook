在P/Invoke中如果想要将一个结构体作为参数传递需要注意：
使用`StructLayout`属性注明结构体在内存中的布局，`LayoutKind`有三种`Sequential`，`Explicit`，`Auto`。

使用`Auto`时，编译器会对结构体进行压缩优化，所以在向非托管代码传递结构体时不能使用`Auto`。

使用`LayoutKind.Sequential`默认以4字节方式对齐，可以使用`Pack`参数指定对齐方式。
```cpp
typedef struct
{
	LONG			nWidth;					//画面宽,单位像素.如果是音频数据则为0.
	LONG			nHeight;				//画面高,如果是音频数据则为0
	LONG			nStamp;					//时标信息,单位毫秒
	LONG			nType;					//视频帧类型,T_AUDIO16,T_RGB32,T_IYUV
	LONG			nFrameRate;				//编码时产生的图像帧率
}FRAME_INFO;
```
```csharp
[StructLayout(LayoutKind.Sequential, Pack=4)]
public struct FRAME_INFO
{
    public int nWidth;                    //画面宽,单位像素.如果是音频数据则为0.
    public int nHeight;                   //画面高,如果是音频数据则为0
    public int nStamp;                    //时标信息,单位毫秒
    public int nType;                     //视频帧类型,T_AUDIO16,T_RGB32,T_IYUV
    public int nFrameRate;				   //编码时产生的图像帧率 
}
```
在C#中没有联合体这个类型，如果遇到联合体时可以使用`LayoutKind.Explicit`，并使用`FieldOffset`手动指定字段在内存中的位置。
```cpp
typedef struct
{
    BYTE                sSerialNumber[DH_SERIALNO_LEN];     // 序列号
    BYTE                byAlarmInPortNum;                   // DVR报警输入个数
    BYTE                byAlarmOutPortNum;                  // DVR报警输出个数
    BYTE                byDiskNum;                          // DVR硬盘个数
    BYTE                byDVRType;                          // DVR类型,见枚举 NET_DEVICE_TYPE
    union
    {
        BYTE            byChanNum;                          // DVR通道个数,登陆成功时有效
        BYTE            byLeftLogTimes;                     // 当登陆失败原因为密码错误时,通过此参数通知用户,剩余登陆次数,为0时表示此参数无效
    };
} NET_DEVICEINFO;
```
```csharp
[StructLayout(LayoutKind.Explicit)]
public struct NET_DEVICEINFO
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    [FieldOffset(0)]
    public byte[] sSerialNumber;                    // 序列号
    [FieldOffset(48)]
    public byte byAlarmInPortNum;                   // DVR报警输入个数
    [FieldOffset(49)]
    public byte byAlarmOutPortNum;                  // DVR报警输出个数
    [FieldOffset(50)]
    public byte byDiskNum;                          // DVR硬盘个数
    [FieldOffset(51)]
    public byte byDVRType;                          // DVR类型,见枚举 NET_DEVICE_TYPE
    [FieldOffset(52)]
    public byte byChanNum;                          // DVR通道个数,登陆成功时有效
    [FieldOffset(52)]
    public byte byLeftLogTimes;                     // 当登陆失败原因为密码错误时,通过此参数通知用户,剩余登陆次数,为0时表示此参数无效
};
```
如果结构体中存在数组，需要使用`MarshalAs`属性，指定`UnmanagedType`为`ByValArray`并使用`SizeConst`注明数组的长度。

如果结构体中存在确定长度的字符数组，则指定`UnmanagedType`为`ByValTStr`并使用`SizeConst`注明数组的长度，使用`CharSet`注明字符串所使用的的字符集。
```cpp
struct StringInfoA {
   char *    f1;
   char      f2[256];
};
struct StringInfoW {
   WCHAR *   f1;
   WCHAR     f2[256];
   BSTR      f3;
};
struct StringInfoT {
   TCHAR *   f1;
   TCHAR     f2[256];
};
```
```csharp
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
struct StringInfoA {
   [MarshalAs(UnmanagedType.LPStr)] public String f1;
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;
}
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
struct StringInfoW {
   [MarshalAs(UnmanagedType.LPWStr)] public String f1;
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;
   [MarshalAs(UnmanagedType.BStr)] public String f3;
}
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
struct StringInfoT {
   [MarshalAs(UnmanagedType.LPTStr)] public String f1;
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;
}
```
有时候需要将一个固定长度的字符缓冲传递给非托管代码，这时候不能传递一个`string`类型，因为`string`中的内容是无法改变的，这时候就需要传递一个指定长度的`StringBuffer`。
```cpp
int GetWindowText(
HWND hWnd,        // Handle to window or control.
LPTStr lpString,  // Text buffer.
int nMaxCount     // Maximum number of characters to copy.
);
```
```csharp
public class Win32API {
[DllImport("User32.Dll")]
public static extern void GetWindowText(int h, StringBuilder s, 
int nMaxCount);
}
public class Window {
   internal int h;        // Internal handle to Window.
   public String GetText() {
      StringBuilder sb = new StringBuilder(256);
      Win32API.GetWindowText(h, sb, sb.Capacity + 1);
   return sb.ToString();
   }
}
```

如果传递的是结构体指针或者引用类型，调用时加上`ref`关键字，并使用`new`开辟内存空间。如果是在非托管代码中开辟的内存，则可以使用`out`关键字。

还有一种方式传递结构体，就是使用`IntPtr`类型，然后使用`Marshal.PtrToStructure`来获取结构体。

**参考**

[C#-StructLayoutAttribute(结构体布局)](http://blog.csdn.net/bigpudding24/article/details/50727792)

[LayoutKind Enumeration](https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.layoutkind(v=vs.110).aspx)

[Default Marshaling for Strings](https://msdn.microsoft.com/en-us/library/s9ts558h(v=vs.110).aspx)

[P/Invoke Tutorial: Passing parameters (Part 3)](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/)

[Interop with Native Libraries](http://www.mono-project.com/docs/advanced/pinvoke/)