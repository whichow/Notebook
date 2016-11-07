Unity程序在更换硬件，系统升级，显卡驱动升级时分辨率可能会出现一些问题，比如说分辨率发生变化并且在脚本中使用Screen.SetResolution修改也不起作用。
解决方案有如下几种：

1.修改注册表，将HKEY\_CURRENT\_USER -&gt;Software-&gt;""Company Name"-&gt;"Produc Name"删掉或者修改其中的Screenmanager Resolution Width和Height项。

2.加参数启动，如-popupwindow -screen-width 1920 -screen-height 1080

3.调用user32.dll，在WindowMod.cs中：

``` prettyprint
using System;using System.Collections;using System.Runtime.InteropServices;using System.Diagnostics;using UnityEngine;public class WindowMod: MonoBehaviour{  public Rect screenPosition;  [DllImport("user32.dll")]  static extern IntPtr SetWindowLong (IntPtr hwnd,int _nIndex ,int dwNewLong);  [DllImport("user32.dll")]  static extern bool SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);  [DllImport("user32.dll")]  static extern IntPtr GetForegroundWindow ();  // not used rigth now  //const uint SWP_NOMOVE = 0x2;  //const uint SWP_NOSIZE = 1;  //const uint SWP_NOZORDER = 0x4;  //const uint SWP_HIDEWINDOW = 0x0080;  const uint SWP_SHOWWINDOW = 0x0040;  const int GWL_STYLE = -16;  const int WS_BORDER = 1;  void Start ()  {    SetWindowLong(GetForegroundWindow (), GWL_STYLE, WS_BORDER);    bool result = SetWindowPos (GetForegroundWindow (), 0,(int)screenPosition.x,(int)screenPosition.y, (int)screenPosition.width,(int) screenPosition.height, SWP_SHOWWINDOW);  }}
```


