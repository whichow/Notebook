1. 使用UnityEngine.StackTraceUtility
```cs
UnityEngine.StackTraceUtility.ExtractStackTrace ();
```

2. 使用System.Diagnostics.StackTrace
```cs
using System.Diagnostics;
using System.Text;

public class StackTraceUtil {

    public static void PrintStackTrace()
    {
        Debug.Log(GetStackTrace());
    }

    public static string GetStackTrace()
    {
        StackTrace st = new StackTrace(true);
        StringBuilder sb = new StringBuilder();
        sb.Append("StactTrack:\n");

        for (int i = 1; i < st.FrameCount; i++)
        {
            StackFrame sf = st.GetFrame(i);
            sb.Append("\t").Append(sf.GetMethod().Name).Append("(at ").Append(sf.GetFileName()).Append(":").Append(sf.GetFileLineNumber()).Append(")").Append("\n");
        }
        return sb.ToString();
    }
}
```

3. 使用System.Environment.StackTrace
```cs
Debug.Log(System.Environment.StackTrace);
```

注意：以上三种方法在不打开Development Build的时候都不会输出文件名及行数