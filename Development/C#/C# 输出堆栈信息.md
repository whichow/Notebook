使用[StackTrace](http://msdn.microsoft.com/en-us/library/system.diagnostics.stacktrace.aspx)和[StackFrame](http://msdn.microsoft.com/en-us/library/system.diagnostics.stackframe.aspx)类:
```cs
StackTrace st = new StackTrace(new StackFrame(true));
Console.WriteLine(" Stack trace for current level: {0}", st.ToString());
StackFrame sf = st.GetFrame(0);
Console.WriteLine(" File: {0}", sf.GetFileName());
Console.WriteLine(" Method: {0}", sf.GetMethod().Name);
Console.WriteLine(" Line Number: {0}", sf.GetFileLineNumber());
Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());
```
.NET 4.5以后可以使用[Caller Information](https://msdn.microsoft.com/en-us/library/hh534540(v=vs.110).aspx)
```cs
public void Log(string message,
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
{
    // Do logging
}
```

[Do \_\_LINE\_\_ \_\_FILE\_\_ equivalents exist in C#?](https://stackoverflow.com/questions/696218/do-line-file-equivalents-exist-in-c)