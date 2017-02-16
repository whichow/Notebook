
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
