我们知道在Unity中可以使用delegate或Lambda表达式来给Button添加事件，那么在Lua中怎样给uGUI中的Button添加点击事件呢。

有人可能会在C#中封装一层再给Lua调用，如
```csharp
using UnityEngine;
using LuaInterface;
using UnityEngine.UI;

public class UIEvent
{
    //添加监听
    public static void AddButtonClick(GameObject go, LuaFunction luafunc, LuaTable luaValue)
    {
        if (go == null || luafunc == null) return;
        go.GetComponent<Button>().onClick.AddListener
        (
            delegate () { luafunc.Call(luaValue); }
        );
    }

    //清除监听
    public static void ClearButtonClick(GameObject go)
    {
        if (go == null) return;
        go.GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
```
在lua中添加点击事件
```lua
function MainPanel:Init()
	local btn = self.transform:FindChild("Button").gameObject
	UIEvent.AddButtonClick(btn, self.Back, self)
end
 
function MainPanel:Back()
    --具体实现
end
```
---
其实我们完全可以在Lua中来实现这一功能

第一种方法，使用匿名函数
```lua
self.gameObject:GetComponent("Button").onClick:AddListener(function()
    --具体实现
end)
```
第二种方法，使用闭包
```lua
self.gameObject:GetComponent("Button").onClick:AddListener(self:ShowPanel());

function MainPanel:ShowPanel()
    return function ()
        --具体实现
    end
end
```
第三种方法，返回一个函数，其实也是闭包
```lua
self.gameObject:GetComponent("Button").onClick:AddListener(function()
    return self:Back()
end)

function MainPanel:Back()
    --具体实现
end
```

