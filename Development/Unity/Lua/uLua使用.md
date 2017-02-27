在Unity中使用uLua示例
```csharp
public LuaDemo:MonoBehaviour {
    void Start() { 
        //创建Lua环境
        LuaState lua = new LuaState();
        //执行Lua脚本
        lua.DoString(@"
            print("hello lua")
        ");
    }
}
```
如果想要在Lua中使用Unity中的类和方法，必须先创建LuaWrap和Binder，方法很简单，使用uLua自带的功能，在lua菜单中选择`Gen LuaWrap + Binder`等待创建完成就好了。

我们可以这样来使用
```csharp
public LuaDemo:MonoBehaviour {
    void Start() { 
        LuaState lua = new LuaState();
        lua.DoString(@"
            luanet.load_assembly('UnityEngine')
            GameObject = luanet.import_type('UnityEngine.GameObject')
            ParticleSystem = luanet.import_type('UnityEngine.ParticleSystem')
            
            local go = GameObject('NewGO')
            local ps = go:AddComponent(luanet.ctype(ParticleSystem))
            ps:Stop()
        ");
    }
}
```
通过这种方式，我们可以调用Unity中的类和方法，但是这种方法比较麻烦，可以看到我们需要先加载程序集，然后导入类型，这样才能调用。

uLua给我们提供了一个更友好的类来处理这些操作
```csharp
public LuaDemo:MonoBehaviour {
    void Start() {
        //这个类会帮我们处理之前所说的一些事情
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();
        //里面调用的还是LuaState.DoString
        mgr.DoString(@"
            ParticleSystem = UnityEngine.ParticleSystem
            local go = GameObject('NewGO')
            local ps = go:AddComponent(ParticleSystem.GetClassType())
            ps:Stop()
        ");
    }
}
```
下面我们来介绍怎样使用自定义的类，首先在Unity中创建一个名为Demo的C#脚本
```csharp
public class Demo:MonoBehaviour {
    public static void Echo(string msg) {
        Debug.Log(String.Format(">>Echo: {0}", msg));
    }

    public void ChangeName(string name) {
        gameObject.name = name;
    }
}
```
然后打开WrapFile.cs文件，在binds数组里添加一行
```csharp
_GT(typeof(Demo))
```
然后执行`Gen LuaWrap + Binder`，生成好后我们就可以在lua中使用了，记住每次修改了C#代码需要重新执行生成
```csharp
public LuaDemo:MonoBehaviour {
    void Start() { 
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();
        mgr.DoString(@"
            --调用类方法
            Demo.Echo("Hello Lua")
            local go = GameObject()
            local demo = go:AddComponent(Demo.GetClassType())
            --调用实例方法
            demo:ChangeName("LuaGO")
        ");
    }
}
```