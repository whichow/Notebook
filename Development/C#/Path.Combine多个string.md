.Net 4之后可以直接连接任意多个字符串作为Path
```csharp
Path.Combine(path1, path2, path3, file);
```
可变参数加foreach实现
```csharp
public static string CombinePaths(string first, params string[] others)
{
    // Put error checking in here :)
    string path = first;
    foreach (string section in others)
    {
        path = Path.Combine(path, section);
    }
    return path;
}
```
扩展string的方法
```csharp
public static class StringExtension
{
    public static int CombinePath(this string str, string path)
    {
        return Path.Combine(str, path);
    }
}

//调用
path1.CombinePath(path2).CombinePath(path2).CombinePath(path3);
```