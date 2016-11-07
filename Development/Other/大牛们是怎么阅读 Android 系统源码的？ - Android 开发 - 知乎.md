 [Android 开发](https://www.zhihu.com/topic/19555634)[Android系统源码](https://www.zhihu.com/topic/20044980)

大牛们是怎么阅读 Android 系统源码的？
-------------------------------------

最近想去深入学习下底层的东西。
看的哪一部分？有没有好的查看工具？ 心得体会...

[1 条评论 ](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

按投票排序[按时间排序](https://www.zhihu.com/question/19759722?sort=created)

### 31 个回答

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/ac46d484f_s.jpg)](https://www.zhihu.com/people/wangyulong)[王宇龙](https://www.zhihu.com/people/wangyulong)，程序员

收录于 编辑推荐•[939 人赞同](#)

 由于工作需要大量修改framework代码, 在AOSP(Android Open Source Project)源码上花费了不少功夫, Application端和Services端都看和改了不少.
如果只是想看看一些常用类的实现, 在Android包管理器里把源码下载下来, 随便一个IDE配好Source Code的path看就行.
但如果想深入的了解Android系统, 那么可以看下我的一些简单的总结.
知识
Java
-   Java是AOSP的主要语言之一. 没得说, 必需熟练掌握.

熟练的Android App开发
Linux
-   Android基于Linux的, 并且AOSP的推荐编译环境是Ubuntu 12.04. 所以熟练的使用并了解Linux这个系统是必不可少的. 如果你想了解偏底层的代码, 那么必需了解基本的Linux环境下的程序开发. 如果再深入到驱动层, 那么Kernel相关的知识也要具备.

Make
-   AOSP使用Make系统进行编译. 了解基本的Makefile编写会让你更清晰了解AOSP这个庞大的项目是如何构建起来的.

Git
-   AOSP使用git+repo进行源码管理. 这应该是程序员必备技能吧.

C++
-   Android系统的一些性能敏感模块及第三方库是用C++实现的, 比如: Input系统, Chromium项目(WebView的底层实现).

硬件
流畅的国际网络
-   AOSP代码下载需要你拥有一个流畅的国际网络. 如果在下载代码这一步就失去耐心的话, 那你肯定没有耐心去看那乱糟糟的AOSP代码. 另外, 好程序员应该都会需要一个流畅的Google.

一台运行Ubuntu 12.04的PC.
-   如果只是阅读源码而不做太多修改的话, 其实不需要太高的配置.

一台Nexus设备
-   AOSP项目默认只支持Nexus系列设备. 没有也没关系, 你依然可以读代码. 但如果你想在大牛之路走的更远, 还是改改代码, 然后刷机调试看看吧.

高品质USB线
-   要刷机时线坏了, 没有更窝心的事儿了.

软件
Ubuntu 12.04
-   官方推荐, 没得选.

Oracle Java 1.6
-   注意不要用OpenJDK. 这是个坑, 官方文档虽然有写, 但还是单独提一下.
-   安装:
        sudo apt-get install python-software-properties
        sudo add-apt-repository ppa:webupd8team/java
        sudo apt-get update
        sudo apt-get install oracle-java6-installer
        sudo apt-get install oracle-java6-set-default

Eclipse
估计会有不少人吐槽, 为什么要用这个老古董. 其实原因很简单, 合适. 刚开始搞AOSP时, 为了找到效率最优的工具, 我尝试过Eclipse, IntelliJ IDEA, Vim+Ctags, Sublime Text+Ctags. 最终结果还是Eclipse. 主要优点有:
-   有语法分析 (快速准确的类, 方法跳转).
-   支持C++ (IntelliJ的C++支持做的太慢了).
-   嵌入了DDMS, View Hierarchy等调试工具.

为了提高效率, 花5分钟背下常用快捷键非常非常值得.
调整好你的classpath, 不要导入无用的代码. 因为AOSP项目代码实在是太多了. 当你还不需要看C++代码时, 不要为项目添加C++支持, 建索引过程会让你崩溃.
Intellij IDEA
-   开发App必备. 当你要调试系统的某个功能是, 常常需要迅速写出一个调试用App, 这个时候老旧的Eclipse就不好用了. Itellij IDEA的xml自动补全非常给力.

巨人的肩膀
AOSP项目官方: [https://source.android.com/source/index.html...](https://link.zhihu.com/?target=https%3A//source.android.com/source/index.html)
-   这个一定要先读. 项目介绍, 代码下载, 环境搭建, 刷机方法, Eclipse配置都在这里. 这是一切的基础.

Android官方Training: [https://developer.android.com/training/index.html...](https://link.zhihu.com/?target=https%3A//developer.android.com/training/index.html)
-   这个其实是给App开发者看的. 但是里面也有不少关于系统机制的介绍, 值得细读.

老罗的Android之旅: [http://blog.csdn.net/luoshengyang...](https://link.zhihu.com/?target=http%3A//blog.csdn.net/luoshengyang)
此老罗非彼老罗. 罗升阳老师的博客非常有营养, 基本可以作为指引你开始阅读AOSP源码的教程. 你可以按照博客的时间顺序一篇篇挑需要的看.但这个系列的博客有些问题:
-   早期的博客是基于旧版本的Android;
-   大量的代码流程追踪. 读文章时你一定要清楚你在看的东西在整个系统处于什么样的位置.

Innost的专栏: [http://blog.csdn.net/innost](https://link.zhihu.com/?target=http%3A//blog.csdn.net/innost)
-   邓凡平老师也是为Android大牛, 博客同样很有营养. 但是不像罗升阳老师的那么系统. 更多的是一些技术点的深入探讨.

Android Issues: [http://code.google.com/p/android/issues/list...](https://link.zhihu.com/?target=http%3A//code.google.com/p/android/issues/list)
-   Android官方Issue列表. 我在开发过程中发现过一些奇怪的bug, 最后发现这里基本都有记录. 当然你可以提一些新的, 有没有人改就是另外一回事了.

Google: [https://www.google.com](https://link.zhihu.com/?target=https%3A//www.google.com)
-   一定要能流畅的使用这个工具. 大量的相关知识是没有人系统的总结的, 你需要自己搞定.

其它
代码组织
-   AOSP的编译单元不是和git项目一一对应的, 而是和Android.mk文件一一对应的. 善用mmm命令进行模块编译将节省你大量的时间.

Binder
-   这是Android最基础的进程间通讯. 在Application和System services之间大量使用. 你不仅要知道AIDL如何使用, 也要知道如何手写Binder接口. 这对你理解Android的Application和System services如何交互有非常重要的作用. Binder如何实现的倒不必着急看.

HAL
-   除非你对硬件特别感兴趣或者想去方案公司上班, 否则别花太多时间在这一层.

CyanogenMod
-   这是一个基于AOSP的第三方Rom. 从这个项目的wiki里你能学到很多AOSP官方没有告诉你的东西. 比如如何支持Nexus以外的设备.

DIA
-   这是一个Linux下画UML的工具, 能够帮你梳理看过的代码.

XDA
-   [http://www.xda-developers.com/](https://link.zhihu.com/?target=http%3A//www.xda-developers.com/)
-   这里有最新资讯和最有趣的论坛.

想到了再补充.

[]()
[]()
[]()[编辑于 2014-12-11](https://www.zhihu.com/question/19759722/answer/29213925)[72 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](#)知乎用户，懒..

收录于 编辑推荐•[558 人赞同](#)

 -----------------------------------------------------------------------------------------------------------------
这是前言
在Android系统源码上摸索4年，说说我的看法：
显然Eclipse不是阅读Android源码的好工具，不流畅，搜索低效，继承性关系/调用关系都无法有效查看。推荐Source Insight，在这个工具帮助下，你才可以驾驭巨大数量的Android 源码，你可以从容在Java，C++,C代码间遨游，你可以很快找到你需要的继承和调用关系。
顺便，现在东家是Linux+Samba+Windows的工作模式，Linux+Samba用于代码的同步/编译/管理，Windows做代码编辑。
你需要先理解下这个图：Application层就是一个个应用程序，很好理解。Framework提供一个java的运行环境以及对功能实现的封装，简单点说，你家装修总要留很多水电之类的接口吧！Runtime/ART是一个java虚拟机，因为Android上层不是java吗，需要再编译一次成为低级一点的语言识别。从Libraries那些名字也可以看出来，这里有很多高端大气库，它是功能实现区，多媒体编解码，浏览器渲染啊，数据库实现啦，很多很多。Kernel部分负责陪硬件大哥玩，你那些功能实现的区域最终都要调硬件吧，Kernel这家伙已经和硬件很熟了，你就直接通过它来和冷冰冰硬件大哥打交道吧！
![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/ffa1356b43c947758c41c8eac0ea4898_b.jpg)
好了，上面这些内容很好理解对不对，现在的问题是：当你拿到一份几G的源码，该从哪里开始呢？经过上面的前言的洗礼，你应该能够很好理解下面这部分了
-------------------------------------------------------------------------------------------------------------------
1.宏观上看，Android源码分为功能实现上的纵向，和功能拓展上的横向。在阅读源码时需要把握好着两个思路。
譬如你需要研究音频系统的实现原理，纵向：你需要从一个音乐的开始播放追踪，一路下来，你发现解码库的调用，共享内存的创建和使用，路由的切换，音频输入设备的开启，音频流的开始。
譬如你要看音频系统包括哪些内容，横向：通过Framework的接口，你会发现，音频系统主要包括：放音，录音，路由切换，音效处理等。
2.Android的功能模块绝大部分是C/S架构
你心里一定需要有这个层级关系，你需要思路清晰地找到Server的位置，它才是你需要攻破的城，上面的libraries是不是很亲切的样子？看完它长成啥样后，然后你才能发现HAL和Kernel一层层地剥离。
很多研究源码的同学兜兜转转，始终在JAVA层上，这是不科学的，要知道libraries才是它的精髓啊。
3.Android的底层是Linux Kernel。
在理解1,2后，还是需要对Kernel部分有个简单的理解，起码你要熟悉kernel的基础协议吧！你要能看懂电路图吧！你要熟悉设备的开启和关闭吧！你要熟悉调寄存器了吧！这方面的书太多了，我建议根据实例去阅读，它并不复杂，不需要一本本厚书来铺垫。
在libraries和kernel间，可能还会有个HAL的东东，其实它是对kernel层的封装，方便各个硬件的接口统一。这样，如果我换个硬件，不用跑了长得很复杂的libraries里面改了，kernel调试好了后，改改HAL就好了。
--------------------------------------------------------------------------------------------------------------------
好了，你现在是不是跃跃欲试准备去找个突破口准备进攻了，但是好像每个宝库的入口都挺难找了
我大概在三个月前阅读完Android UI系统的源码，这是Android最复杂的部分，我要简单说下过程。
我需要先找宝库入口，我要研究UI，首先要找什么和UI有亲戚关系吧！
View大神跳出来了，沿着它往下找找看，发现它在贴图在画各种形状，但是它在哪里画呢，马良也要纸吧？
很明显它就是某个宝藏，但是世人只是向我们描述了它有多美，却无人知在哪里？我们需要找一张地图罗。
开发Android的同学逃不掉Activity吧！它有个setcontentview的方法，从这个名字看好像它是把view和activity结合的地方。赶紧看它的实现和被调用。，然后我们就发现了Window，ViewRoot和WindowManager的身影，沿着WM和WMS我们就惊喜会发现了Surface，以及draw的函数，它居然在一个DeCorView上画东西哈。借助Source Insight， UI Java层的横向静态图呼之欲出了。
完成这个静态UML，我觉得我可以开始功能实现上追踪了，这部分主要是C++的代码（这也是我坚定劝阻的放弃Eclipse的原因），我沿着draw函数，看到了各个层级的关系，SurfaceSession的控制和事务处理，SharedBuffer读写控制，彪悍的SurfaceFlinger主宰一切，OpenGL ES的神笔马良。FrameBuffer和FrameBufferDevice的图像输出，LCD设备打开后，开始接收FBD发过来的一帧帧图像，神奇吧。
好吧，就这样，再往底层我爱莫能助了！

[]()
[]()
[]()[编辑于 2014-09-18](https://www.zhihu.com/question/19759722/answer/17019083)[34 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/7ded840bd_s.jpg)](https://www.zhihu.com/people/gracker)[高爷](https://www.zhihu.com/people/gracker)，多一点真诚 少一点套路

[22 人赞同](#)

工具:Android Studio
查看源码方法: [http://androidperformance.com/2015/01/16/view-android-source-code-with-androidstudio.html](https://link.zhihu.com/?target=http%3A//androidperformance.com/2015/01/16/view-android-source-code-with-androidstudio/)
看那一部分:
1.  Framework/base
2.  Package/apps
3.  art
4.  external

操作系统：推荐Linux，可以随时编译Android源码
测试机：推荐Nexus系列手机，编译源码后push进去可以随时验证。

[]()
[]()
[]()[编辑于 2015-11-25](https://www.zhihu.com/question/19759722/answer/46430218)[14 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/640dda607_s.jpg)](https://www.zhihu.com/people/____________________)[小湿妹](https://www.zhihu.com/people/____________________)，灌狸猿，厮碧池

[42 人赞同](#)

零、准备工作：
开发环境：建议在ubuntu（32/64位均可）下进行开发。
开发板：推荐cubieboard、pcduino
（资料开放，连相应的android源码以及硬件配置文件都有提供。
不推荐所谓的开源硬件Raspberry-Pi，毕竟Raspberry-Pi并不是真正的开源硬件。）
其他：串口线
强烈不推荐在windows环境下搞Android底层开发！！！
一个及格的Android工程师，就应该熟练在Linux环境下进行开发工作。
如果你不会“优雅”地使用Linux，不得不在windows下编辑代码，
恳请你记得设置编码utf-8！！！！！！！！！！
（怨念：每次编译固件看见乱码警告就各种强迫症啊摔ヽ(≧Д≦)ノ！尽管大多情况下不影响编译结果。）
一、编译器的选择：
阅读/编译代码：eclipse （Java）、vim+ctags+cscope（C/C++）
搜索代码：shell
例如命令1：grep "Telephoney" -rn ./\*
例如命令2：find -name Telephoney\*
等等等
不会用eclipse，请不要说他不好用！
eclipse是阅读framework代码以及系统应用的居家旅行杀人必备神器。
正确使用eclipse阅读Android源码：
1.复制eclipse的classpath到Android源码根目录
cp ~/android/development/ide/eclipse/.classpath ~/android
2.修改eclipse缓存设置
把eclipse.ini文件的3个值改为下面的值（不要盲目参考，需要根据自己机器情况来定）：
-Xms128m
-Xmx768m
-XX:MaxPermSize=512m
（mac路径：eclipse/Eclipse.app/Contents/MacOS/eclipse.ini）
3.导入eclipse代码风格
把android-formatting.xml和android.importorder导入Eclipse
~/android/development/ide/eclipse/android-formatting.xml
~/android/development/ide/eclipse/android.importorder
4.导入Android源码
新建Java Project（不是Android project），选择从已存在的工程导入，定位到Android源码的目录进行导入即可。
PS：eclipse只是阅读/编辑代码的工具，编译源码还是需要通过make命令在终端编译的。
二、知识储备：
编程语言什么的没什么好说。
着重提一个：设计模式
由于Android源代码用到各种各样的设计模式，如果不会设计模式，将会大大降低你的阅读理解速度。
三、网站资料：
[http://source.android.com/devices...](https://link.zhihu.com/?target=http%3A//source.android.com/devices)
android官方文档，很详细描述各模块的设计思路。
理解这个链接的内容，看个十遍八遍，一边看一边分析代码。
PS：由于比较笨(-’๏\_๏’-)，所以我当年是一边看一边翻译出来，大家也可以参考我这种方法，容易加深理解、印象
四、书刊资料：
邓凡平大神的《深入理解Android》系列
《深入理解Android：卷I/卷II》 \[Kindle电子书\] ~ 邓凡平
链接:[http://www.amazon.cn/dp/B00K6Y5OEM](https://link.zhihu.com/?target=http%3A//www.amazon.cn/dp/B00K6Y5OEM)
作者Blog：[http://blog.csdn.net/Innost/](https://link.zhihu.com/?target=http%3A//blog.csdn.net/Innost/)
五、学习方法：
要一下子把所有模仿都理解透，是件比较困难的事情。
可以分模块学习：
Telephoney
Audio & media
webkit & Browser
Wi-Fi & wpa supplicant
Dalvik
Display & Surface flinger
Camera
等等等
先吃饭，看心情再补(\*´・ｖ・)。。。

[]()
[]()
[]()[发布于 2014-08-13](https://www.zhihu.com/question/19759722/answer/29156462)[14 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/5665baf1d_s.jpg)](https://www.zhihu.com/people/duguguiyu)[范怀宇](https://www.zhihu.com/people/duguguiyu)，做广告是不是不好，我不会告诉你欢迎阅读…

[14 人赞同](#)

 Android源码两个部分看得最多，一个是packages，就是各个系统应用的实现，另外就是framework，框架层的实现。具体看什么就看你想了解什么。
工具eclipse也很好，build一下生成class path，各种转跳非常方便，不需要grep了。

[]()
[]()
[]()[发布于 2011-07-11](https://www.zhihu.com/question/19759722/answer/12873889)[2 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/3e620cb7a_s.jpg)](https://www.zhihu.com/people/wendel-stock)[Wendel Stock](https://www.zhihu.com/people/wendel-stock)，学EE的程序员

[2 人赞同](#)

[@王宇龙](https://www.zhihu.com/people/4d6200cf87fb52b9c80e41dc2a096b3e)[@墨小西](https://www.zhihu.com/people/c728907ade12812ce1b652defa50e8aa) 两位已经说的很全了，我就稍微补充点 答下题主的问题：
> 最近想去深入学习下底层的东西。看的哪一部分？

代码里面的部分，那就学学Linux Kernel，Bootloader，再底层的需要学些硬件驱动，一步一步来。
> 有没有好的查看工具？

Windows 下推荐SoureInsight，建个工程把AOSP 所有代码丢进去，几个月不用关掉，看到感兴趣的地方不停的往下追就好。当初就在这上面直接改代码，Ubuntu 开个窗口编译搞定，其实是懒得开IDE（逃

[]()
[]()
[]()[编辑于 2015-03-23](https://www.zhihu.com/question/19759722/answer/42791643)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/du-peng-xiao)[杜鹏霄](https://www.zhihu.com/people/du-peng-xiao)，it一小兵

[2 人赞同](#)

 因为工作原因，接触 Android 源码并且折腾的很早，也因为工作原因，无法有效的利用各种 IDE, 所以一直是用 VIM + grep 的方式。效率可能比较低下，但是读源码这种东西就是贵在坚持学习，看的时间长了，慢慢哪些代码在什么地方都大概能有印象，所以读和找起来就很方便。蛮羡慕会用 taglist 的，只是一直不大习惯使用。
再有比较关键的一点是多找一些身边喜欢学习的朋友交流，每个人看的可能都不一样，很多时候突破口就在抽烟聊天的时间讨论出来的。

[]()
[]()
[]()[发布于 2014-10-15](https://www.zhihu.com/question/19759722/answer/31910112)[1 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/af3e9a5e56ad657b20fa7528b8440ca7_s.jpg.png)](https://www.zhihu.com/people/droidyue)[技术小黑屋](https://www.zhihu.com/people/droidyue)，[http://droidyue.com/](https://link.zhihu.com/?target=http%3A//droidyue.com/)

[9 人赞同](#)

 使用[GrepCode.com](https://link.zhihu.com/?target=http%3A//grepcode.com/)查看API很方便。

[]()
[]()
[]()[发布于 2014-09-26](https://www.zhihu.com/question/19759722/answer/31054648)[1 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/pinxue)[品雪](https://www.zhihu.com/people/pinxue)，人生如梦

[2 人赞同](#)

 我觉得vim+tags已经很爽了，当然要是source insight出个Mac版本就更好了。

[]()
[]()
[]()[发布于 2011-07-11](https://www.zhihu.com/question/19759722/answer/12873649)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
匿名用户

[]()[5 人赞同](#)

分享自己总结的一些阅读源码的方法，需要注意的几个点可以注意下

做什么事情都要知道从那里开始，读程序也不例外。在c语言里,首先要找到main()函数，然后逐层去阅读，其他的程序无论是vb、delphi都要首先找到程序头，否则你是很难分析清楚程序的层次关系。

分层次阅读

　　在阅读代码的时候不要一头就扎下去，这样往往容易只见树木不见森林，阅读代码比较好的方法有一点象二叉树的广度优先的遍历。在程序主体一般会比较简 单，调用的函数会比较少，根据函数的名字以及层次关系一般可以确定每一个函数的大致用途，将你的理解作为注解写在这些函数的边上。当然很难一次就将全部注 解都写正确，有时候甚至可能是你猜测的结果，不过没有关系这些注解在阅读过程是不断修正的，直到你全部理解了代码为止。一般来说采用逐层阅读的方法可以是 你系统的理解保持在一个正确的方向上。避免一下子扎入到细节的问题上。在分层次阅读的时候要注意一个问题，就是将系统的函数和开发人员编写代码区分开。在 c, c++，java ,delphi中都有自己的系统函数，不要去阅读这些系统函数，除非你要学习他们的编程方法，否则只会浪费你的时间。将系统函数表示出来，注明它们的作用 即可，区分系统函数和自编函数有几个方法，一个是系统函数的编程风格一般会比较好，而自编的函数的编程风格一般比较会比较差。从变量名、行之间的缩进、注 解等方面一般可以分辨出来，另外一个是象ms c6++会在你编程的时候给你生成一大堆文件出来，其中有很多文件是你用不到了，可以根据文件名来区分一下时候是系统函数，最后如果你实在确定不了，那就 用开发系统的帮助系统去查一下函数名，对一下参数等来确定即可。

重复阅读

　　一次就可以将所有的代码都阅读明白的人是没有的。至少我还没有遇到过。反复的去阅读同一段代码有助于得代码的理解。一般来说，在第一次阅读代码的时候 你可以跳过很多一时不明白的代码段，只写一些简单的注解，在以后的重复阅读过程用，你对代码的理解会比上一次理解的更深刻，这样你可以修改那些注解错误的 地方和上一次没有理解的对方。一般来说，对代码阅读3，4次基本可以理解代码的含义和作用。

运行并修改代码

　　如果你的代码是可运行的，那么先让它运行起来，用单步跟踪的方法来阅读代码，会提高你的代码速度。代码通过看中间变量了解代码的含义,而且对 以后的修改会提供很大的帮助

　　用自己的代码代替原有代码，看效果，但在之前要保留源代码

　　600行的一个函数，阅读起来很困难，编程的人不是一个好的习惯。在阅读这个代码的时候将代码进行修改，变成了14个函数。每一个大约是40-50 行左右.

———————————————源码下载网站—————————————————————

跟你说几个我常用的源码下载网站

csdn（[中文IT社区](https://link.zhihu.com/?target=http%3A//www.csdn.net/)）它是集新闻、论坛、群组、Blog、文档、下载、读书、Tag、网摘、搜索、.NET、Java、游戏、视频、人才、外包、第二书店、《程序员》等多种项目于一体的大型综合性IT门户网站，源码只是其中的一项，但是很实用 里边有很多大牛。

DevStore（[源码下载](https://link.zhihu.com/?target=http%3A//www.devstore.cn/code/list/pn1-or0.html)）主要是开发者服务平台，汇集国内外众多第三方开发者服务，为开发者提供从设计开发到运营推广一站式的解决方案，源码和服务评测也是亮点，很专业，很实用，这里边聚集的都是开发者和PM，可以看看。

站长之家（[网站源码](https://link.zhihu.com/?target=http%3A//down.chinaz.com/)）针对个人站长，企业网管提供的资讯和源码，包含的语言和类型也比较多。

[]()
[]()
[]()[发布于 2014-11-21](https://www.zhihu.com/question/19759722/answer/33775396)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/30e58181f_s.jpg)](https://www.zhihu.com/people/guohai)[Hai Guo](https://www.zhihu.com/people/guohai)，do one thing, do it well

 工具就 vim + 一款自己熟悉的文本编辑器，关键是要选一个感兴趣的子系统/模块开始

[]()
[]()
[]()[发布于 2015-09-09](https://www.zhihu.com/question/19759722/answer/62895188)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/d5977288948f374da4e5bd46198bf288_s.jpg)](https://www.zhihu.com/people/yorkie)[Yorkie](https://www.zhihu.com/people/yorkie)，[http://github.com/yorkie](https://link.zhihu.com/?target=http%3A//github.com/yorkie)

[1 人赞同](#)

 之前好像就答过 目标导向是阅读一切源代码的不二法门 试试给android系统慢慢加一下小功能 先从ui开始 然后再往下深 期间没准有彩蛋 遇到bug之类的 修掉提交给google吧

[]()
[]()
[]()[发布于 2015-07-30](https://www.zhihu.com/question/19759722/answer/57001150)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/liaorui)[廖锐](https://www.zhihu.com/people/liaorui)，Java, Android, 享受编程

[4 人赞同](#)

 Eclipse里看最方便了。在Android SDK的platforms目录下建立sources文件夹，放入frameworks的源代码，Eclipse里就能自动打开源代码了。网上有很多具体的说明。
如果是看所有源码，包括底层C/C++源码，可以用lxr，变量函数查找和跳转都非常方便，但配置起来比较麻烦，需要多尝试。

[]()
[]()
[]()[发布于 2011-07-27](https://www.zhihu.com/question/19759722/answer/12966328)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/kpld)[李波](https://www.zhihu.com/people/kpld)，Linux爱好者

[2 人赞同](#)

 有没有用记事本的？我就用Notepad++和SublimeText来看。搜索用Everything和baregrep，以及Notepad++的搜索功能

[]()
[]()
[]()[发布于 2014-09-26](https://www.zhihu.com/question/19759722/answer/31049633)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/e40182016a9e09c8f9c82505d2c635f7_s.jpg.png)](https://www.zhihu.com/people/du9781123)[杜一](https://www.zhihu.com/people/du9781123)，不会做菜的码农不是好运营

[4 人赞同](#)

阅读别人的代码作为开发人员是一件经常要做的事情。一个是学习新的编程语言的时候通过阅读别人的代码是一个最好的学习方法，另外是积累编程经验。如果你有机会阅读一些操作系统的代码会帮助你理解一些基本的原理。还有就是在你作为一个质量保证人员或一个小领导的时候如果你要做白盒测试的时候没有阅读代码的能力是不能完成相应的任务。最后一个就是如果你中途接手一个项目的时候或给一个项目做售后服务的时候是要有阅读代码的能力的。

　　收集所有可能收集的材料

　　阅读代码要做的第一件事情是收集所有和项目相关的资料。比如你要做一个项目的售后服务，那么你首先要搞明白项目做什么用的，那么调研文档、概要设计文档、详细设计文档、测试文档、使用手册都是你要最先搞到手的。如果你是为了学习那么尽量收集和你的学习有关的资料，比如你想学习linux的文件系统的代码，那最好要找到linux的使用手册、以及文件系统设计的方法、数据结构的说明。(这些资料在书店里都可以找到)。

　　材料的种类分为几种类型

　　1.基础资料。

　　比如你阅读turbo c2的源代码你要有turbo c2的函数手册，使用手册等专业书籍，msc 6.0或者java 的话不但要有函数手册，还要有类库函数手册。这些资料都是你的基础资料。另外你要有一些关于uml的资料可以作为查询手册也是一个不错的选择

　　2.和程序相关的专业资料。

　　每一个程序都是和相关行业相关的。比如我阅读过一个关于气象分析方面的代码，因为里边用到了一个复杂的数据转换公式，所以不得不把自己的大学时候课本 找出来来复习一下高等数学的内容。如果你想阅读linux的文件管理的代码，那么找一本讲解linux文件系统的书对你的帮助会很大。

　　3.相关项目的文档资料

　　这一部分的资料分为两种，一个相关行业的资料，比如你要阅读一个税务系统的代码那么有一些财务/税务系统的专业资料和国家的相关的法律、法规的资料是 必不可少的。此外就是关于这个项目的需求分析报告、概要设计报告、详细设计报告，使用手册、测试报告等，尽量多收集对你以后的代码阅读是很重要的

　　知识准备

　　了解基础知识，不要上来就阅读代码，打好基础可以做到事半功倍的效果

　　留备份,构造可运行的环境

　　代码拿到手之后的第一件事情是先做备份，最好是刻在一个光盘上，在代码阅读的时候一点不动代码是很困难的一件事情，特别是你要做一些修改性或增强性维护的时候。而一旦做修改就可能发生问题，到时候要恢复是经常发生的事情，如果你不能很好的使用版本控制软件那么先留一个备份是一个最起码的要求了。

　　在做完备份之后最好给自己构造一个可运行的环境，当然可能会很麻烦，但可运行代码和不可运行的代码阅读起来难度会差很多的。所以多用一点时间搭建一个环境是很值得的，而且我们阅读代码主要是为了修改其中的问题或做移植操作。不能运行的代码除了可以学到一些技术以外，用处有限。

　　找开始的地方

　　做什么事情都要知道从那里开始，读程序也不例外。在c语言里,首先要找到main()函数，然后逐层去阅读，其他的程序无论是vb、delphi都要首先找到程序头，否则你是很难分析清楚程序的层次关系。

　　分层次阅读

　　在阅读代码的时候不要一头就扎下去，这样往往容易只见树木不见森林，阅读代码比较好的方法有一点象二叉树的广度优先的遍历。在程序主体一般会比较简 单，调用的函数会比较少，根据函数的名字以及层次关系一般可以确定每一个函数的大致用途，将你的理解作为注解写在这些函数的边上。当然很难一次就将全部注 解都写正确，有时候甚至可能是你猜测的结果，不过没有关系这些注解在阅读过程是不断修正的，直到你全部理解了代码为止。一般来说采用逐层阅读的方法可以是 你系统的理解保持在一个正确的方向上。避免一下子扎入到细节的问题上。在分层次阅读的时候要注意一个问题，就是将系统的函数和开发人员编写代码区分开。在 c, c++，java ,delphi中都有自己的系统函数，不要去阅读这些系统函数，除非你要学习他们的编程方法，否则只会浪费你的时间。将系统函数表示出来，注明它们的作用 即可，区分系统函数和自编函数有几个方法，一个是系统函数的编程风格一般会比较好，而自编的函数的编程风格一般比较会比较差。从变量名、行之间的缩进、注 解等方面一般可以分辨出来，另外一个是象ms c6++会在你编程的时候给你生成一大堆文件出来，其中有很多文件是你用不到了，可以根据文件名来区分一下时候是系统函数，最后如果你实在确定不了，那就 用开发系统的帮助系统去查一下函数名，对一下参数等来确定即可。

　　写注解

　　　　写注解是在阅读代码中最重要的一个步骤，在我们阅读的源代码一般来说是我们不熟悉的系统,阅读别人的代码一般会有几个问题，1搞明白别人的编程思想不 是一件很容易的事情，即使你知道这段程序的思路的时候也是一样。2阅读代码的时候代码量一般会比较大，如果不及时写注解往往会造成读明白了后边忘了前边的 现象。3阅读代码的时候难免会出现理解错误，如果没有及时的写注解很难及时的发现这些错误。4不写注解有时候你发生你很难确定一个函数你时候阅读过，它的功能是什么，经常会发生重复阅读、理解的现象。

　　好了，说一些写注解的基本方法：

1.猜测的去写，刚开始阅读一个代码的时候，你很难一下子就确定所有的函数的功能，不妨采用采用猜测的方法去写注解，根 据函数的名字、位置写一个大致的注解，当然一般会有错误，但你的注解实际是不但调整的，直到最后你理解了全部代码。

2.按功能去写，别把注解写成语法说明 书，千万别看到fopen就写打开文件，看到fread就写读数据，这样的注解一点用处都没有，而应该写在此处开发参数配置文件(\*\*\*\*。dat)读出 系统初始化参数。。。。。，这样才是有用的注解。

3.在写注解的使用另外要注意的一个问题是分清楚系统自动生成的代码和用户自 己开发的代码，一般来说没有必要写系统自动生成的代码。象delphi的代码，我们往往要自己编写一些自己的代码段，还要对一些系统自动生成的代码段进行 修改，这些代码在阅读过程是要写注解的，但有一些没有修改过的自动生成的代码就没有必要写注解了。

4.在主要代码段要写较为详细的注解。有一些函数或类在程序中起关键的作用，那么要写比较详细的注解。这样对你理解代码有很大的帮助。

5.对你理解起来比较困难的地方要写详细的注解，在这些地方往往会有一些编程的技巧。不理解这些编程技巧对你以后的理解或移植会有问题。

6.写中文注解。如果你的英文足够的好，不用看这条了，但很多的人英文实在不怎么样，那就写中文注解吧，我们写注解是为了加快自己的理解速度。中文在大多数的时候比英文更适应中国人。与其写一些谁也看不懂的英文注解还不如不写。

　　重复阅读

　　一次就可以将所有的代码都阅读明白的人是没有的。至少我还没有遇到过。反复的去阅读同一段代码有助于得代码的理解。一般来说，在第一次阅读代码的时候 你可以跳过很多一时不明白的代码段，只写一些简单的注解，在以后的重复阅读过程用，你对代码的理解会比上一次理解的更深刻，这样你可以修改那些注解错误的 地方和上一次没有理解的对方。一般来说，对代码阅读3，4次基本可以理解代码的含义和作用。

　　运行并修改代码

　　如果你的代码是可运行的，那么先让它运行起来，用单步跟踪的方法来阅读代码，会提高你的代码速度。代码通过看中间变量了解代码的含义,而且对 以后的修改会提供很大的帮助

　　用自己的代码代替原有代码，看效果，但在之前要保留源代码

　　600行的一个函数，阅读起来很困难，编程的人不是一个好的习惯。在阅读这个代码的时候将代码进行修改，变成了14个函数。每一个大约是40-50 行左右.

[]()
[]()
[]()[发布于 2015-02-04](https://www.zhihu.com/question/19759722/answer/38891812)[1 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
匿名用户

[]()[7 人赞同](#)

 这个问题最好玩的地方就是在于一堆人喜欢东扯一点西扯一点 , 最后说拿eclipse来看看源码吧= =
真好玩.

[]()
[]()
[]()[发布于 2014-09-13](https://www.zhihu.com/question/19759722/answer/30474623)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/holly-lee)[Holly Lee](https://www.zhihu.com/people/holly-lee)，码农. 大多数时候在为五斗米折腰, 偶尔会…

[6 人赞同](#)

 vim+grep. 读任何代码都是一样的. android 并没什么特殊的

[]()
[]()
[]()[发布于 2011-07-11](https://www.zhihu.com/question/19759722/answer/12873608)[4 条评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/0b833c792_s.jpg)](https://www.zhihu.com/people/border)[JiangBian](https://www.zhihu.com/people/border)，关注Android, Golang

[3 人赞同](#)

 vim+tags+cscope+grep

[]()
[]()
[]()[发布于 2011-07-14](https://www.zhihu.com/question/19759722/answer/12898996)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[](https://www.zhihu.com/people/heng-liu)[heng liu](https://www.zhihu.com/people/heng-liu)，曾经很骄傲

[2 人赞同](#)

 emacs gtags ggtags

[]()
[]()
[]()[发布于 2014-08-12](https://www.zhihu.com/question/19759722/answer/29115160)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[]()

[]()
[]()[![](大牛们是怎么阅读%20Android%20系统源码的？%20-%20Android%20开发%20-%20知乎_files/176fa8b74221ebe7ccc265a0b2fc991b_s.jpg)](https://www.zhihu.com/people/pilu-66)[pilu](https://www.zhihu.com/people/pilu-66)，RTFSC

[1 人赞同](#)

 多年的Android经验建议，debug, debug & debug!
动态跟踪android framework代码，属于service实现的相关代码就attach到systemserver上
比你看死代码强N倍！

[]()
[]()
[]()[发布于 2016-04-26](https://www.zhihu.com/question/19759722/answer/97331110)[添加评论](https://www.zhihu.com/question/19759722#)[感谢](https://www.zhihu.com/question/19759722#)[](https://www.zhihu.com/question/19759722#)
分享

[收藏](https://www.zhihu.com/question/19759722#)•[没有帮助](https://www.zhihu.com/question/19759722#)•[举报](https://www.zhihu.com/question/19759722#)•[作者保留权利](https://www.zhihu.com/terms#sec-licence-1)

[更多]()[]()
[]()
[]()
我来回答这个问题

[]()
[]()
[]()
[]()

[]()

[]()

 

 

 

写回答…

[我要回答](#)

****************************************

********************[
]()********************

****************************************


