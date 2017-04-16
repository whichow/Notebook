这个类中常量基本上根据注释和名字就都知道什么意思了，但是这几个常量十分重要，有必要分析一下。

### 1.DebugMode
对于LuaManager来说，如果值为true，那么lua代码的加载路径就为"LuaFramework/lua/"和"LuaFramework/Tolua/Lua/"这两个路径(也就是pc上的本地路径)，否则为Util.DataPath + "lua"(也就是手机上的沙盒路径)

### 2.ExampleMode
如果AppConst.ExampleMode为true，那么就会对"Assets/LuaFramework/Examples/Builds/"这个路径下的素材进行打包，打包到StreamingAssets这个目录下。这里我建议不要修改这个值(保持为true)，通过系列二的打包工具将素材的路径改了就可以了。

### 3.UpdateMode
如果为true，则会访问服务端进行下载更新

### 4.LuaBundleMode
如果AppConst.LuaBundleMode为true，那么就会对"LuaFramework/lua/"和"LuaFramework/Tolua/Lua/"这两个路径下的lua代码进行打包成.Unity3D，打包到StreamingAssets/lua/这个目录下；否则，就是将这两个路径的文件复制到目标目录下。如果要导出apk，那么要将这个值改为true；如果只是在编辑器上测试，可以改为false。