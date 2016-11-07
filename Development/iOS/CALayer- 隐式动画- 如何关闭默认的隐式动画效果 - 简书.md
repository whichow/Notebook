[简]()
-   [** 首页](http://www.jianshu.com/)
-   [** 专题](http://www.jianshu.com/collections)
-   [** 发钱啦](http://www.jianshu.com/user_invitations)

[** 注册](http://www.jianshu.com/sign_up) [** 登录](http://www.jianshu.com/sign_in) [**]()

[**简****首页](http://www.jianshu.com/) [**专题](http://www.jianshu.com/collections) [**下载手机应用](http://www.jianshu.com/apps)
![114](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/425da682-cc46-4d54-9789-37c03dcb59f8.png)
简书

交流故事，沟通想法

![Download app qrcode](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/ad6dcad3-49f4-4800-86d4-c64ec41f1705.png)
[iOS](https://itunes.apple.com/cn/app/jian-shu/id888237539?ls=1&mt=8)· [Android](http://downloads.jianshu.io/apps/haruki/JianShu-1.11.2.apk)

[**显示模式](#view-mode-modal) [**登录](http://www.jianshu.com/sign_in)

[**](#) [**]() [**](http://www.jianshu.com/writer#/)
#### 下载简书移动应用

![Download app qrcode](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/ad6dcad3-49f4-4800-86d4-c64ec41f1705.png)

[**]() [**]()

[** 注册](http://www.jianshu.com/sign_up) [** 登录](http://www.jianshu.com/sign_in)

[** 添加关注](http://www.jianshu.com/sign_in)

[![100](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/361a7c9b-6fe8-4a41-9fd5-9dfceb6ebfa8.jpg)](http://www.jianshu.com/users/29e03e6ff407) 作者 [RedRain](http://www.jianshu.com/users/29e03e6ff407) 2016.04.04 15:26\*
写了50487字，被50人关注，获得了54个喜欢

字数932 阅读502 评论1 喜欢2

[**收藏文章](http://www.jianshu.com/sign_in) [** 分享]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/3d31f1ed-3cf2-47d9-8608-b11559f7b3ba.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/f6125daa-8b66-4c37-b687-1bf7dbe3796d.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/310c6f61-e924-4f44-9ae1-088f14763bd9.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/85d50b4d-79ab-4a19-9ef2-3766a9f7ec58.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/c0451f4e-f158-4d70-b85b-284f949ef635.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/668a48f0-e114-4b56-a063-c8a5af9d0ee5.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/c0c8fa6f-6e6c-4343-b4cc-5dbdc3684311.png)]()
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/868a3da8-cfe4-4baf-8e08-390b310804f6.png)]()

[RedRain的简书:http://www.jianshu.com/users/29e03e6ff407/latest\_articles](http://www.jianshu.com/users/29e03e6ff407/latest_articles)

CALayer
=======

-   在iOS中，你能看得见摸得着的东西基本上都是UIView，比如一个按钮、一个文本标签、一个文本输入框、一个图标等等，这些都是UIView
-   其实UIView之所以能显示在屏幕上，完全是因为它内部的一个图层
-   在创建UIView对象时，UIView内部会自动创建一个图层(即CALayer对象)，通过UIView的layer属性可以访问这个层
-   当UIView需要显示到屏幕上时，会调用drawRect:方法进行绘图，并且会将所有内容绘制在自己的图层上，绘图完毕后，系统会将图层拷贝到屏幕上，于是就完成了UIView的显示
-   换句话说，UIView本身不具备显示的功能，是它内部的层才有显示功能

CALayer的基本使用
-----------------

-   通过操作CALayer对象，可以很方便地调整UIView的一些外观属性，比如：
    -   阴影
    -   圆角大小
    -   边框宽度和颜色
-   还可以给图层添加动画，来实现一些比较炫酷的效果

CALayer的属性
-------------

``` hljs
宽度和高度
@property CGRect bounds;

位置(默认指中点，具体由anchorPoint决定)
@property CGPoint position;

锚点(x,y的范围都是0-1)，决定了position的含义
@property CGPoint anchorPoint;

背景颜色(CGColorRef类型)
@property CGColorRef backgroundColor;

形变属性
@property CATransform3D transform;

边框颜色(CGColorRef类型)
@property CGColorRef borderColor;

边框宽度
@property CGFloat borderWidth;

圆角半径
@property CGColorRef borderColor;

内容(比如设置为图片CGImageRef)
@property(retain) id contents;
```

关于CALayer的疑惑
-----------------

-   首先

    -   CALayer是定义在QuartzCore框架中的
    -   CGImageRef、CGColorRef两种数据类型是定义在CoreGraphics框架中的
    -   UIColor、UIImage是定义在UIKit框架中的
-   其次

    -   QuartzCore框架和CoreGraphics框架是可以跨平台使用的，在iOS和Mac OS X上都能使用
    -   但是UIKit只能在iOS中使用
-   为了保证可移植性，QuartzCore不能使用UIImage、UIColor，只能使用CGImageRef、CGColorRef

UIView和CALayer的选择
---------------------

-   通过CALayer，就能做出跟UIImageView一样的界面效果

-   既然CALayer和UIView都能实现相同的显示效果，那究竟该选择谁好呢？

    -   其实，对比CALayer，UIView多了一个事件处理的功能。也就是说，CALayer不能处理用户的触摸事件，而UIView可以
    -   所以，如果显示出来的东西需要跟用户进行交互的话，用UIView；如果不需要跟用户进行交互，用UIView或者CALayer都可以
    -   当然，CALayer的性能会高一些，因为它少了事件处理的功能，更加轻量级

隐式动画
--------

-   每一个UIView内部都默认关联着一个CALayer，我们可用称这个Layer为Root Layer（根层）

-   所有的非Root Layer，也就是手动创建的CALayer对象，都存在着隐式动画

-   什么是隐式动画？

    -   当对非Root Layer的部分属性进行修改时，默认会自动产生一些动画效果
    -   而这些属性称为Animatable Properties(可动画属性)
-   列举几个常见的Animatable Properties：

    -   bounds：用于设置CALayer的宽度和高度。修改这个属性会产生缩放动画
    -   backgroundColor：用于设置CALayer的背景色。修改这个属性会产生背景色的渐变动画
    -   position：用于设置CALayer的位置。修改这个属性会产生平移动画
-   可以通过动画事务(CATransaction)关闭默认的隐式动画效果

``` hljs
 [CATransaction begin];
 [CATransaction setDisableActions:YES];
 self.myview.layer.position = CGPointMake(10, 10);
 [CATransaction commit];
```

[** 推荐拓展阅读](http://www.jianshu.com/sign_in)

[** 著作权归作者所有]()

如果觉得我的文章对您有用，请随意打赏。您的支持将鼓励我继续创作！

[¥ 打赏支持](#pay-modal)

[** 喜欢](http://www.jianshu.com/sign_in)

2

[**分享到微博]() [**分享到微信](#share-weixin-modal)
[更多分享**]()
-   [** 下载长微博图片](http://cwb.assets.jianshu.io/notes/images/3460837/weibo/image_eb8484e52019.jpg)
-   [![Tweibo](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/310c6f61-e924-4f44-9ae1-088f14763bd9.png) 分享到腾讯微博]()
-   [![Qzone](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/85d50b4d-79ab-4a19-9ef2-3766a9f7ec58.png) 分享到QQ空间]()
-   [![Twitter](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/c0451f4e-f158-4d70-b85b-284f949ef635.png) 分享到Twitter]()
-   [![Facebook](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/668a48f0-e114-4b56-a063-c8a5af9d0ee5.png) 分享到Facebook]()
-   [![Google plus](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/c0c8fa6f-6e6c-4343-b4cc-5dbdc3684311.png) 分享到Google+]()
-   [![Douban](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/f6125daa-8b66-4c37-b687-1bf7dbe3796d.png) 分享到豆瓣]()

×

##### 打开微信“扫一扫”，打开网页后点击屏幕右上角分享按钮

![](data:image/png;base64,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)

![Tiny](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/tiny.gif)

![Tiny](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/tiny.gif)

×
### 喜欢的用户

-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/8a08458f-9f72-4b6c-bc90-5d0fec8a661b.jpg)](http://www.jianshu.com/users/74c11e3d829d) [wata](http://www.jianshu.com/users/74c11e3d829d) 2016.08.27 16:17
-   [![](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/5392fc3d-ad34-4a8f-a38f-658a143f1330.jpg)](http://www.jianshu.com/users/739f8d139f4a) [人生得意](http://www.jianshu.com/users/739f8d139f4a) 2016.05.17 14:10

1条评论 （ [按时间正序]()· [按时间倒序]()· [按喜欢排序]() ） [**添加新评论](http://www.jianshu.com/sign_in)

[![15](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/5392fc3d-ad34-4a8f-a38f-658a143f1330.jpg)](http://www.jianshu.com/users/739f8d139f4a)
[人生得意](http://www.jianshu.com/users/739f8d139f4a)

 2 楼 · [2016.05.17 14:10](http://www.jianshu.com/p/7d911645c244/comments/2418657#comment-2418657)

写的特别浅显易懂~~Thank you ！

[**喜欢(0)]() [回复]()

[登录后发表评论](http://www.jianshu.com/sign_in)

##### 被以下专题收入，发现更多相似内容：

-   [![180](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/be5e1621-58b7-4e40-a240-598608f57652.jpg)](http://www.jianshu.com/collection/976373a1bc07)
    ##### [动画](http://www.jianshu.com/collection/976373a1bc07)

    [** 添加关注](http://www.jianshu.com/sign_in) 4

    动画

    [94篇文章](http://www.jianshu.com/collection/976373a1bc07) · 4人关注

×

[](http://www.jianshu.com/users/29e03e6ff407)
![100](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/361a7c9b-6fe8-4a41-9fd5-9dfceb6ebfa8.jpg)

**如果觉得我的文章对您有用，请随意打赏。您的支持将鼓励我继续创作！**

打赏金额**

##### 选择支付方式：

微信支付

立即支付

×

### **打赏成功

![Complete pay](CALayer-%20隐式动画-%20如何关闭默认的隐式动画效果%20-%20简书_files/cb003f6f-975d-4566-b66e-091a8163401c.png)

[**]() [**]()

[宋体]() [黑体]()

[简]() [繁]()


