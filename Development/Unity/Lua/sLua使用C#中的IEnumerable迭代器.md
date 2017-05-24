在sLua中提供了一个iter函数，其实现如下
```csharp
[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
static public int _iter(IntPtr l)
{
  object obj = checkObj(l, LuaDLL.lua_upvalueindex(1));
  IEnumerator it = (IEnumerator)obj;
  if (it.MoveNext())
  {
    pushVar(l, it.Current);
    return 1;
  }
  else
  {
    if (obj is IDisposable)
      (obj as IDisposable).Dispose();
  }
  return 0;
}

[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
static public int iter(IntPtr l)
{
  object o = checkObj(l, 1);
  if (o is IEnumerable)
  {
    IEnumerable e = o as IEnumerable;
    IEnumerator iter = e.GetEnumerator();
    pushValue(l, true);
    //the only upvalue
    pushLightObject(l, iter);
    LuaDLL.lua_pushcclosure(l, _iter, 1);
    return 2;
  }
  return error(l,"passed in object isn't enumerable");
}
```
使用方法如下
```lua
for element in Slua.iter(collection) do
  print(element)
end
```

[Iterator in Lua](http://haolly.com/iterator-in-lua/)