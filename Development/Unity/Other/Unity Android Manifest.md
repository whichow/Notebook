Unity处理Android Manifest步骤：

1.Unity使用自带的主Android Manifest

2.Unity查找所有的Android插件中的Android Manifest(AAR和Android库)

3.将插件中的Manifest合并到主Manifest中

4.Unity修改Manifest，自动添加权限，配置选项，特性和其他信息到Manifest中。

最终生成的AndroidManifest放在*Temp/StagingArea/AndroidManifest.xml*  