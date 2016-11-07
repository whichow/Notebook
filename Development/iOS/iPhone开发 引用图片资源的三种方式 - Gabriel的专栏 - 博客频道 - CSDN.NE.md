iPhone开发 引用图片资源的三种方式 - Gabriel的专栏 - 博客频道 - CSDN.NET
[iPhone开发 引用图片资源的三种方式](http://blog.csdn.net/gf771115/article/details/6382381)
==========================================================================================

.

 标签： [iphone](http://www.csdn.net/tag/iphone)[image](http://www.csdn.net/tag/image)[path](http://www.csdn.net/tag/path)

2011-05-01 22:17 5131人阅读 [评论](http://blog.csdn.net/gf771115/article/details/6382381#comments)(3) [收藏](# "收藏") [举报](http://blog.csdn.net/gf771115/article/details/6382381#report "举报")

.

![](iPhone开发%20引用图片资源的三种方式%20-%20Gabriel的专栏%20-%20博客频道%20-%20CSDN.NE_files/category_icon.jpg) 分类：

 iOS / OC*（239）* ![](iPhone开发%20引用图片资源的三种方式%20-%20Gabriel的专栏%20-%20博客频道%20-%20CSDN.NE_files/1db119b0089be63f5674c35ec53f1d8f.jpg)

.

以一张图片为例 fakeXcode.png

下面以3种目录结构的方式引用这张图片：

 

1。直接拖进工程＋copy

image ＝ \[UIImage imageNamed: @"fakeXcode.png"\];

NSString \*path = \[\[NSBundle mainBundle\] pathForResource:@"fakeXcode" ofType:@"png"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

2.把文件夹拖进工程目录，然后拖进工程，create folder references for any added folder，（蓝色文件夹res）

image ＝ \[UIImage imageNamed: @"res/fakeXcode.png"\];

NSString \*path = \[\[NSBundle mainBundle\] pathForResource:@"fakeXcode.png" ofType:nil inDirectory:@"res"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

3.创建bundle，把资源放进bundle（白色bundle，res.bundle）

image ＝ \[UIImage imageNamed: @"es.bundle/fakeXcode.png"\];

NSString \*path = \[\[\[NSBundle mainBundle\] resourcePath\] stringByAppendingPathComponent:@"res.bundle/fakeXcode.png"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

个人认为第二种最方便, 可以创建蓝色文件夹. 达到资源分组的目的!

[](http://blog.csdn.net/gf771115/article/details/6382381#) [](http://blog.csdn.net/gf771115/article/details/6382381# "分享到QQ空间") [](http://blog.csdn.net/gf771115/article/details/6382381# "分享到新浪微博") [](http://blog.csdn.net/gf771115/article/details/6382381# "分享到腾讯微博") [](http://blog.csdn.net/gf771115/article/details/6382381# "分享到人人网") [](http://blog.csdn.net/gf771115/article/details/6382381# "分享到微信") .

顶  
0

&nbsp;
踩  
0

.

[ ](#)

[ ](#)

-   上一篇[Android布局整合include界面控件（重用布局）](http://blog.csdn.net/gf771115/article/details/6366654)
-   下一篇[iPhone的九宫格实现代码](http://blog.csdn.net/gf771115/article/details/6387178)
-   .

#### 我的同类文章

 iOS / OC*（239）*

-   *•*[IOS开发之语音合成（科大讯飞）详解](http://blog.csdn.net/gf771115/article/details/51544087 "IOS开发之语音合成（科大讯飞）详解")2016-05-31*阅读***268***•*[ios排序(对象排序，字母，数字)](http://blog.csdn.net/gf771115/article/details/51190715 "ios排序(对象排序，字母，数字)")2016-04-19*阅读***511***•*[\_\_block 与 \_\_weak的区别理解](http://blog.csdn.net/gf771115/article/details/50580294 "__block 与 __weak的区别理解")2016-01-25*阅读***691***•*[自动处理键盘事件的第三方库 IQKeyboardManager](http://blog.csdn.net/gf771115/article/details/50541078 "自动处理键盘事件的第三方库 IQKeyboardManager")2016-01-19*阅读***552***•*[微信分享屏蔽跳转appstore解决方法](http://blog.csdn.net/gf771115/article/details/50424164 "微信分享屏蔽跳转appstore解决方法")2015-12-29*阅读***2766***•*[苹果IOS开发者账号如何续费-Appstore](http://blog.csdn.net/gf771115/article/details/50206799 "苹果IOS开发者账号如何续费-Appstore")2015-12-07*阅读***901**

&nbsp;
-   *•*[iOS与Javascript交互实战](http://blog.csdn.net/gf771115/article/details/51201878 "iOS与Javascript交互实战")2016-04-20*阅读***589***•*[iPhone屏幕适配 程序启动后状态栏字体变大](http://blog.csdn.net/gf771115/article/details/50599320 "iPhone屏幕适配 程序启动后状态栏字体变大")2016-01-28*阅读***795***•*[object-c编程tips-jastor自动解析](http://blog.csdn.net/gf771115/article/details/50542885 "object-c编程tips-jastor自动解析")2016-01-19*阅读***460***•*[CocoaPods的安装使用和常见问题](http://blog.csdn.net/gf771115/article/details/50540398 "CocoaPods的安装使用和常见问题")2016-01-19*阅读***7039***•*[iOS开发～CocoaPods使用详细说明](http://blog.csdn.net/gf771115/article/details/50403253 "iOS开发～CocoaPods使用详细说明")2015-12-25*阅读***8575**

[更多文章](http://blog.csdn.net/gf771115/article/category/800366)


