Xcode程序打包 .ipa
[** 添加关注](http://www.jianshu.com/sign_in)

[![100](Xcode程序打包%20%20.ipa_files/100.gif)](http://www.jianshu.com/users/d4aa9ce4aa00) 作者 [\_李布斯](http://www.jianshu.com/users/d4aa9ce4aa00) 2015.05.12 10:25
写了7903字，被110人关注，获得了139个喜欢

Xcode程序打包 .ipa
==================

字数467 阅读1747 评论2 喜欢21

解析手机里面的其他app 软件的事相信大家都干过，小编就经常解析那些大型app 来“借用”他们的图片，最常用的工具就是 [iTools](http://rj.baidu.com/soft/detail/25844.html?ald)。当我们用iTools解析了某个app时会发现有个后缀为.ipa的文件，这个.ipa后缀的文件里面就包含我们想要的资源（**其实 .ipa包就类似安卓的 apk 包**）。 .ipa文件包除了包含app的资源，最大的用处是可以给已经**越狱过了的iPhone**直接安装该程序，这对软件开发过程中的测试工作起到了很大的作用，下面就教大家怎么来给程序打包成 .ipa 。

#### 方法（一）：

（1） 打开你需要打包的程序，选成真机模式。（不一定非要有真机，只需要选择真机的模式下就行）

![](Xcode程序打包%20%20.ipa_files/1240.png)
图1

（2）Edit scheme

![](Xcode程序打包%20%20.ipa_files/1240.png)
图2

（3） 选择 Release 模式

![](Xcode程序打包%20%20.ipa_files/1240.png)
图3

（4）commd + B  编译  (最好先 clean 下程序)

（5）编译完成后 会发现 Products 文件夹下的 .app 文件由红色变成了 黑色

![](Xcode程序打包%20%20.ipa_files/1240.png)
图4

（6）点击这个 .app 文件 show in finder 

![](Xcode程序打包%20%20.ipa_files/1240.png)
图5

（7）在桌面新建个 Payload 文件夹将.app 文件放进去，然后压缩改文件夹。

![](Xcode程序打包%20%20.ipa_files/1240.png)
图6

（8）压缩完之后才可以改成你想要的名字，改完名称后直接把.zip 后缀改成 .ipa 后缀 就ok 了。

![](Xcode程序打包%20%20.ipa_files/1240.png)
图7

### 方法（二）：

除了上面这种方法 我们还可以利用 iturns 来生成 .ipa 文件。

（1）打开 iturns 选择 应用程序：

![](Xcode程序打包%20%20.ipa_files/1240.png)
图8

（2）直接把  .app 包拖进去。

![](Xcode程序打包%20%20.ipa_files/1240.png)
图9

（3） 然后直接 show in finder  发现  iturns 已经帮我们打包好了。

![](Xcode程序打包%20%20.ipa_files/1240.png)
图10

![](Xcode程序打包%20%20.ipa_files/1240.png)
图11

打包好的 .ipa 包 只有在破解的 iPhone下 直接就可以安装了，本篇到此结束，希望可以帮助到大家。
-------------------------------------------------------------------------------------------


