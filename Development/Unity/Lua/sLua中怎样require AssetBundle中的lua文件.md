首先我们在LuaState文件的init方法中可以看到重新定义了一系列lua中的函数，如print, dofile, loadfile等。我们注意到下面这几行
```cs
			pushcsfunction(L, loader);
			int loaderFunc = LuaDLL.lua_gettop(L);

			LuaDLL.lua_getglobal(L, "package");
#if LUA_5_3
			LuaDLL.lua_getfield(L, -1, "searchers");
#else
			LuaDLL.lua_getfield(L, -1, "loaders");
#endif
```
这里我们要先说一下lua require的处理流程
```
require的处理流程：
   require(modelname)
   require(在lua中它是ll_require函数)的查找顺序如下：
       a.首先在package.loaded查找modelname,如果该模块已经存在，就直接返回它的值
       b.在package.preload查找modelname, 如果preload存在，那么就把它作为loader，调用loader(L)
       c.根据package.path的模式查找lua库modelname，这个库是通过module函数定义的，对于顶层的lua库，文件名和库名是一 样的而且不需要调用显式地在lua文件中调用module函数(在ll_require函数中可以看到处理方式)，也就是说lua会根据lua文件直接完 成一个loader的初始化过程。
       d.根据package.cpath查找c库，这个库是符合lua的一些规范的(export具有一定特征的函数接口)，lua先已动态的方式加载该c库，然后在库中查找并调用相应名字的接口，例如:luaopen_hello_world
       e.已第一个"."为分割，将模块名划分为:(main, sub)的形式，根据package.cpath查找main，如果存在，就加载该库并查询相应的接口:luaopen_main_sub，例如：先查找 hello库，并查询luaopen_hello_world接口
       f.得到loder后，用modname作为唯一的参数调用该loader函数。当然参数是通过lua的栈传递的，所以loader的原型必须符合lua的规范:int LUA_FUNC(lua_State *L)
         
       ll_require会将这个loader的返回值符给package.loaded[modelname],如果loader不返回值同时 package.loaded[modelname]不存在时, ll_require就会把package.loaded[modelname]设为true。最后ll_reuqire把package.loaded [modelname]返回给调用者。
```
我们知道了require是通过package的loader来加载lua文件的，所以我们通过上面那几行代码重新定义loader。

接下来我们找到LuaState的loader方法，这是一个回调方法，在lua中require的时候就会调用这个方法。
```cs
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		internal static int loader(IntPtr L)
		{
			string fileName = LuaDLL.lua_tostring(L, 1);
			byte[] bytes = loadFile(fileName);
			if (bytes != null)
			{
				if (LuaDLL.luaL_loadbuffer(L, bytes, bytes.Length, "@" + fileName) == 0)
				{
					LuaObject.pushValue(L, true);
					LuaDLL.lua_insert(L, -2);
					return 2;
				}
				else
				{
					string errstr = LuaDLL.lua_tostring(L, -1);
					return LuaObject.error(L, errstr);
				}
			}
			LuaObject.pushValue(L, true);
			LuaDLL.lua_pushnil(L);
			return 2;
		}
```
我们可以看到通过loadFile这个方法加载了bytes，而bytes就是我们读取到的lua文件，最终将bytes传给lua。

我们进入到loadFile方法中看看是怎样加载lua文件的
```cs
		internal static byte[] loadFile(string fn)
		{
			try
			{
				byte[] bytes;
				if (loaderDelegate != null)
					bytes = loaderDelegate(fn);
				else
				{
#if !SLUA_STANDALONE
					fn = fn.Replace(".", "/");
					TextAsset asset = (TextAsset)Resources.Load(fn);
					if (asset == null)
						return null;
					bytes = asset.bytes;
#else
				    bytes = File.ReadAllBytes(fn);
#endif
				}
				return bytes;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
```
其中有一个loaderDelegate，当loaderDelegate为空的时候，会通过Resources或者File.ReadAllBytes来加载lua文件。我们可以通过loaderDelegate来自定义lua文件的加载过程，比如从AssetBundle中加载lua文件了。

[lua中的require机制](http://blog.chinaunix.net/uid-552961-id-2736410.html)