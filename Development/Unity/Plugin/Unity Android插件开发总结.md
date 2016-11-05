1.插件中如果有用到Unity提供的功能，需要在插件中添加Unity中的classes.jar包作为依赖，如扩展UnityPlayerActivity和使用UnitySendMessage方法
<div>

2.jar包如果有用到Android资源文件，需要将资源文件一同拷贝到Unity中，或者直接打包成.aar。

</div>

<div>

3.增加或修改Manifest.xml文件，如添加新的Activity或其他组件，配置所需要的权限。

</div>

<div>

4.在Unity中修改Bundle Identifier。

</div>
