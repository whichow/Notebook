debug模块

### 获取函数名
```lua
local function myFunc()
    print(debug.getinfo(1, "n"));
    --或
    print(debug.getinfo(1).name);
end
myFunc()
```

### 获取所在文件和行
```lua
function getfunctionlocation()
    local w = debug.getinfo(2, "S")
    return w.short_src..":"..w.linedefined
end

print(getfunctionlocation()) --> foo.lua:6
```

### 打印堆栈信息
在我们调试Lua的时候经常需要知道一个函数在运行的时候被哪个函数调用了，这个时候堆栈信息就非常有用了，我们可以使用debug.traceback来追踪堆栈信息：
```lua
    print(debug.traceback());
```