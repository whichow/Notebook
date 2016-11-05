Unity添加Android插件
<div>

<div>

unity3d游戏接入有两种情况：

</div>

<div>

    1）一种是通过导出Android项目，然后编译游戏；

</div>

<div>

    2）另一种是直接在unity editor中编译游戏。

</div>

<div>

\

</div>

<div>

1.unity3d导出Android项目接入

</div>

<div>

如果游戏是通过导出Android项目编译的，接入方法和前面介绍的一般Android项目接入方法相同，按照之前介绍的方法接入即可。

</div>

<div>

\

</div>

<div>

2.unity editor中直接编译接入

</div>

<div>

如果游戏直接在unity editor中编译，接入方法有点特别，下面介绍如何在unity
editor中直接编译接入方法。

</div>

<div>

\

</div>

<div>

首先需要有一个Android lib project。
如果还没有，就从空白Unity项目导出一个Android lib
project。如果已经接入了其它的SDK，可以在原有的project
中做相应的修改。具体步骤如下：

</div>

<div>

\

</div>

<div>

1）Android lib project的package name 必须和Unity的 Bundle
Identifier一样（如果已经接入其它SDK跳过）；

</div>

<div>

\

</div>

<div>

2\) 拷贝RecNow.jar到project的libs
目录下；如果libs目录下没有unity-classes.jar，就从Unity的安装目录找到class.jar复制到libs目录下，Mac下classes.jar的路径是/Applications/Unity/Unity.app/Contents/PlaybackEngines/AndroidPlayer/bin/classes.jar，Windows下classes.jar的路径是Unity\\Editor\\Data\\PlaybackEngines\\androidplayer\\bin\\classes.jar；

</div>

<div>

\

</div>

<div>

\

</div>

<div>

3\) 修改AndroidManifest.xml: 参考之前的说明；

</div>

<div>

\

</div>

<div>

4\) 修改launcher Activity的onCreate方法: 参考之前的说明；

</div>

<div>

\

</div>

<div>

5\) 编译project ；

</div>

<div>

\

</div>

<div>

6\) 在project 目录下执行:

</div>

<div>

\

</div>

<div>

    jar -cvfM unity-plugins.jar -C bin/classes/ .

</div>

<div>

\

</div>

<div>

7\) 拷贝unity-plugins.jar 到Unity项目的
Assets/Plugins/Android/libs目录下；

</div>

<div>

\

</div>

<div>

8）拷贝project的AndroidManifest.xml到Unity项目的
Assets/Plugins/Android目录下；

</div>

<div>

\

</div>

<div>

9）拷贝RecNow/libs/RecNow.jar
到Unity项目的Assets/Plugins/Android/libs目录下；

</div>

<div>

\

</div>

<div>

10）拷贝RecNow/depends/lib/librecnow.so
到Unity项目的Assets/Plugins/Android/libs/armeabi-v7a 目录下；

</div>

<div>

\

</div>

<div>

11）拷贝RecNow/asssets/recnow到Unity项目的Assets/Plugins/Android/assets目录下；

</div>

<div>

\

</div>

<div>

\

</div>

</div>
