- 使用Unity命令行启动参数`-parentHWND <HWND> `这个参数可以使Unity程序嵌入到其他Windows应用程序的窗口中，使用这个参数需要将父程序的窗口句柄传给Unity应用程序。
```csharp
process = new Process(); 
process.StartInfo.FileName = "Child.exe";
process.StartInfo.Arguments = "-parentHWND " + panel1.Handle.ToInt32() + " " + Environment.CommandLine;
process.StartInfo.UseShellExecute = true;
process.StartInfo.CreateNoWindow = true; 
process.Start(); 
process.WaitForInputIdle(); 
EnumChildWindows(panel1.Handle, WindowEnum, IntPtr.Zero);
```
- 还有一种方法，使用`user32.dll`
```csharp
[DllImport("user32.dll")]
static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
private void button1_Click(object sender, EventArgs e)
{
    var clientApplication = Process.Start("C:/Users/ricardo.coelho/Desktop/Unity_VS_Test.exe");
    Thread.Sleep(500);
    SetParent(clientApplication.MainWindowHandle, panel1.Handle);
}
```

**参考**

[Command line arguments](https://docs.unity3d.com/Manual/CommandLineArguments.html)

[How can i run a Unity Game inside Visual Studio (2013)](http://stackoverflow.com/questions/29411583/how-can-i-run-a-unity-game-inside-visual-studio-2013)
