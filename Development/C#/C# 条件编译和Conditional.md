使用条件编译如果判断失败则代码不会编译到IL中
使用Conditional的代码会编译到IL中，但是调用方法时将会被忽略

例子:
```cs
#if DEBUG
    public void DoSomething() { }
#endif

    public void Foo()
    {
#if DEBUG
        DoSomething(); //This works, but looks FUGLY
#endif
    }
```

```cs
[Conditional("DEBUG")]
public void DoSomething() { }

public void Foo()
{
    DoSomething(); //Code compiles and is cleaner, DoSomething always
                   //exists, however this is only called during DEBUG.
}
```

[#if DEBUG vs. Conditional(“DEBUG”)](https://stackoverflow.com/questions/3788605/if-debug-vs-conditionaldebug)