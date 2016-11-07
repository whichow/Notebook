CAKeyframeAnimation 关键帧动画的用法 - 碧水蓝天 - 博客频道 - CSDN.NET
[CAKeyframeAnimation 关键帧动画的用法](http://blog.csdn.net/samuelltk/article/details/9048325)
==============================================================================================

.

2013-06-07 15:53 5122人阅读 [评论](http://blog.csdn.net/samuelltk/article/details/9048325#comments)(0) [收藏](# "收藏") [举报](http://blog.csdn.net/samuelltk/article/details/9048325#report "举报")

.

版权声明：本文为博主原创文章，未经博主允许不得转载。

一、原理

之所以叫做关键帧动画是因为，这个类可以实现，某一属性按照一串的数值进行动画，就好像制作动画的时候一帧一帧的制作一样。

一般使用的时候  首先通过 animationWithKeyPath 方法 创建一个CAKeyframeAnimation实例，

 

CAKeyframeAnimation 的一些比较重要的属性

1. path

这是一个 CGPathRef  对象，默认是空的，当我们创建好CAKeyframeAnimation的实例的时候，可以通过制定一个自己定义的path来让  某一个物体按照这个路径进行动画。这个值默认是nil  当其被设定的时候  values  这个属性就被覆盖 

2. values

一个数组，提供了一组关键帧的值，  当使用path的 时候 values的值自动被忽略。

下面是一个简单的例子  效果为动画的连续移动一个block到不同的位置

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

1.  CGMutablePathRef path = CGPathCreateMutable();  
2.  //将路径的起点定位到（50  120）    
3.  CGPathMoveToPoint(path,NULL,50.0,120.0);  
4.  //下面5行添加5条直线的路径到path中  
5.  CGPathAddLineToPoint(path, NULL, 60, 130);  
6.  CGPathAddLineToPoint(path, NULL, 70, 140);  
7.  CGPathAddLineToPoint(path, NULL, 80, 150);  
8.  CGPathAddLineToPoint(path, NULL, 90, 160);  
9.  CGPathAddLineToPoint(path, NULL, 100, 170);  
10. //下面四行添加四条曲线路径到path  
11. CGPathAddCurveToPoint(path,NULL,50.0,275.0,150.0,275.0,70.0,120.0);  
12. CGPathAddCurveToPoint(path,NULL,150.0,275.0,250.0,275.0,90.0,120.0);  
13. CGPathAddCurveToPoint(path,NULL,250.0,275.0,350.0,275.0,110.0,120.0);  
14. CGPathAddCurveToPoint(path,NULL,350.0,275.0,450.0,275.0,130.0,120.0);  
15. //以“position”为关键字  
16. 实例  
17. CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@"position"\];  
18. //设置path属性  
19. \[animation setPath:path\];  
20. \[animation setDuration:3.0\];  
21. //这句代码表示 是否动画回到原位  
22. //\[animation setAutoreverses:YES\];  
23. CFRelease(path);  
24. \[self.block.layer addAnimation:animation forKey:NULL\];  

运行后  block会先沿着直线移动，之后再沿着设定的曲线移动，完全按照我们设定的“关键帧”移动。

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

1.  CGPoint p1=CGPointMake(50, 120);  
2.  CGPoint p2=CGPointMake(80, 170);  
3.  CGPoint p3=CGPointMake(30, 100);  
4.  CGPoint p4=CGPointMake(100, 190);  
5.  CGPoint p5=CGPointMake(200, 10);  
6.  NSArray \*values=\[NSArray arrayWithObjects:\[NSValue valueWithCGPoint:p1\],\[NSValue valueWithCGPoint:p2\],\[NSValue valueWithCGPoint:p3\],\[NSValue valueWithCGPoint:p4\],\[NSValue valueWithCGPoint:p5\], nil\];  
7.  CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@"position"\];  
8.  \[animation setValues:values\];  
9.  \[animation setDuration:3.0\];  
10. \[animation setAutoreverses:YES\];  
11. \[self.block.layer addAnimation:animation forKey:NULL\];  

       也非常简单，到目前位置，只用到了CAKeyframeAnimation的两个关键属性就能完成动画，下面的一些属性提供了更加细致化，更加强大的功能。

设定每一帧的时间

       默认情况下,一帧动画的播放,分割 的时间是动画的总时间除以帧数减去一。你可以通过下面的公式决定每帧动画的时间:总时间/(总帧数-1)。 例如,如果你指定了一个 5 帧,10 秒的动画,那么每帧的时间就是 2.5 秒钟:10/(5-1)=2.5。你可以做更多 的控制通过使用 keyTimes 关键字,你可以给每帧动画指定总时间之内的某个时间点。 

       通过设置属性keyTimes，能实现这个功能，这个属性是一个数组，其成员必须是NSNumber。

       同时 这个属性的设定值要与calculationMode属性相结合，同时他们有一定的规则，

The appropriate values in the `keyTimes` array are dependent on the `calculationMode` property.

-   If the calculationMode is set to `kCAAnimationLinear`, the first value in the array must be 0.0 and the last value must be 1.0. Values are interpolated between the specified key times.

-   If the calculationMode is set to `kCAAnimationDiscrete`, the first value in the array must be 0.0.

-   If the calculationMode is set to `kCAAnimationPaced` or `kCAAnimationCubicPaced`, the `keyTimes` array is ignored。

如果keyTimes的值不合法，或者不符合上面的规则，那么就会被忽略。

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](C:\Users\WH\AppData\Local\Temp\Wiz\ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  \[animation setCalculationMode:kCAAnimationLinear\];   

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  \[animation setKeyTimes:\[NSArray arrayWithObjects:\[NSNumber numberWithFloat:0.0\],\[NSNumber numberWithFloat:0.25\], \[NSNumber numberWithFloat:0.50\],\[NSNumber numberWithFloat:0.75\], \[NSNumber numberWithFloat:1.0\], nil\]\];  

### calculationMode

这个属性用来设定 关键帧中间的值是怎么被计算的

可选的值有

```
<span style="margin: 0px; padding: 0px; ">NSString * const kCAAnimationLinear;     默认是这种模式
NSString * const kCAAnimationDiscrete;   只展示关键帧的状态，没有中间过程，没有动画。
NSString * const kCAAnimationPaced;
NSString * const kCAAnimationCubic;
NSString * const kCAAnimationCubicPaced;</span>
```

```
<span style="margin: 0px; padding: 0px; ">关键帧动画的基础步骤</span>
```

1.决定你想要做动画的属性(例如,框架,背景,锚点,位置,边框,等等) 

2.在动画对象值的区域中,指定开始,结束,和中间的值。这些都是你的关键帧(看清单 4-2)
3.使用 duration 这个字段指定动画的时间
4.通常来讲,通过使用 times 这个字段,来给每帧动画指定一个时间。如果你没有指定这些,核心动画就会通过你在 values 这个字段指定的值分割出时间段。

5.通常,指定时间功能来控制步调。 这些都是你需要做的。你创建你的动画和增加他们到层中。调用-addAnimation 就开始了动画。 

二、举例使用

1.使用贝赛尔曲线路径的关键帧动画

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  UIBezierPath \*path = \[UIBezierPath bezierPath\];  
2.  \[path moveToPoint:CGPointMake(-40, 100)\];  
3.  \[path addLineToPoint:CGPointMake(360, 100)\];  
4.  \[path addLineToPoint:CGPointMake(360, 200)\];  
5.  \[path addLineToPoint:CGPointMake(-40, 200)\];  
6.  \[path addLineToPoint:CGPointMake(-40, 300)\];  
7.  \[path addLineToPoint:CGPointMake(360, 300)\];  
8.    
9.  CAKeyframeAnimation \*moveAnimation = \[CAKeyframeAnimation animationWithKeyPath:@"position"\];  
10. moveAnimation.path = path.CGPath;  
11. moveAnimation.duration = 8.0f;  
12. moveAnimation.rotationMode = kCAAnimationRotateAuto;  
13. \[shapeLayer addAnimation:moveAnimation forKey:@"moveAnimation"\];  

2.使用基于缩放的关键帧动画

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@"transform"\];  
2.    
3.  CATransform3D scale1 = CATransform3DMakeScale(0.5, 0.5, 1);  
4.  CATransform3D scale2 = CATransform3DMakeScale(1.2, 1.2, 1);  
5.  CATransform3D scale3 = CATransform3DMakeScale(0.9, 0.9, 1);  
6.  CATransform3D scale4 = CATransform3DMakeScale(1.0, 1.0, 1);  
7.    
8.  NSArray \*frameValues = \[NSArray arrayWithObjects:  
9.                          \[NSValue valueWithCATransform3D:scale1\],  
10.                         \[NSValue valueWithCATransform3D:scale2\],  
11.                         \[NSValue valueWithCATransform3D:scale3\],  
12.                         \[NSValue valueWithCATransform3D:scale4\],  
13.                         nil\];  
14.   
15. \[animation setValues:frameValues\];  
16.   
17. NSArray \*frameTimes = \[NSArray arrayWithObjects:  
18.                        \[NSNumber numberWithFloat:0.0\],  
19.                        \[NSNumber numberWithFloat:0.5\],  
20.                        \[NSNumber numberWithFloat:0.9\],  
21.                        \[NSNumber numberWithFloat:1.0\],  
22.                        nil\];  
23. \[animation setKeyTimes:frameTimes\];  
24.   
25. animation.fillMode = kCAFillModeForwards;  
26. animation.duration = .25;  
27.   
28. \[self addAnimation:animation forKey:@"DSPopUpAnimation"\];  

3.使用基于路径的关键帧动画

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  CGMutablePathRef path = CGPathCreateMutable();  
2.    
3.  CGPathMoveToPoint(path, NULL, 50.0, 120.0);  
4.  CGPathAddCurveToPoint(path, NULL, 50.0, 275.0, 150.0, 275.0, 150.0, 120.0);  
5.  CGPathAddCurveToPoint(path,NULL,150.0,275.0,250.0,275.0,250.0,120.0);  
6.  CGPathAddCurveToPoint(path,NULL,250.0,275.0,350.0,275.0,350.0,120.0);  
7.  CGPathAddCurveToPoint(path,NULL,350.0,275.0,450.0,275.0,450.0,120.0);  
8.    
9.  CAKeyframeAnimation \*anim = \[CAKeyframeAnimation animationWithKeyPath:@"position"\];  
10. \[anim setPath:path\];  
11. \[anim setDuration:3.0\];  
12. \[anim setAutoreverses:YES\];  
13. CFRelease(path);  
14. \[self.layer addAnimation:anim forKey:@"path"\];  

4.使用基于位置点的关键桢动画

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  CGPoint pt0 = CGPointMake(50.0, 120.0);  
2.  CGPoint pt1 = CGPointMake(50.0, 275.0);  
3.  CGPoint pt2 = CGPointMake(150.0, 275.0);  
4.  CGPoint pt3 = CGPointMake(150.0, 120.0);  
5.  CGPoint pt4 = CGPointMake(150.0, 275.0);  
6.  CGPoint pt5 = CGPointMake(250.0, 275.0);  
7.  CGPoint pt6 = CGPointMake(250.0, 120.0);  
8.  CGPoint pt7 = CGPointMake(250.0, 275.0);  
9.  CGPoint pt8 = CGPointMake(350.0, 275.0);  
10. CGPoint pt9 = CGPointMake(350.0, 120.0);  
11. CGPoint pt10 = CGPointMake(350.0, 275.0);  
12. CGPoint pt11 = CGPointMake(450.0, 275.0);  
13. CGPoint pt12 = CGPointMake(450.0, 120.0);  
14. NSArray \*values = \[NSArray arrayWithObjects:  
15.                    \[NSValue valueWithCGPoint:pt0\],  
16.                    \[NSValue valueWithCGPoint:pt1\],  
17.                    \[NSValue valueWithCGPoint:pt2\],  
18.                    \[NSValue valueWithCGPoint:pt3\],  
19.                    \[NSValue valueWithCGPoint:pt4\],  
20.                    \[NSValue valueWithCGPoint:pt5\],  
21.                    \[NSValue valueWithCGPoint:pt6\],  
22.                    \[NSValue valueWithCGPoint:pt7\],  
23.                    \[NSValue valueWithCGPoint:pt8\],  
24.                    \[NSValue valueWithCGPoint:pt9\],  
25.                    \[NSValue valueWithCGPoint:pt10\],  
26.                    \[NSValue valueWithCGPoint:pt11\],  
27.                    \[NSValue valueWithCGPoint:pt12\], nil\];  
28. CAKeyframeAnimation \*anim = \[CAKeyframeAnimation animationWithKeyPath:@"position"\];  
29. \[anim setValues:values\];  
30. \[anim setDuration:3.0\];  
31. \[anim setAutoreverses:YES\];  
32.   
33. \[self.layer addAnimation:anim forKey:@"path"\];  

5.使用基于旋转的关键桢动画

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  CAKeyframeAnimation \*keyAnim = \[CAKeyframeAnimation animationWithKeyPath:@"transform"\];  
2.               CATransform3D rotation1 = CATransform3DMakeRotation(30 \* M\_PI/180, 0, 0, -1);  
3.               CATransform3D rotation2 = CATransform3DMakeRotation(60 \* M\_PI/180, 0, 0, -1);  
4.               CATransform3D rotation3 = CATransform3DMakeRotation(90 \* M\_PI/180, 0, 0, -1);  
5.               CATransform3D rotation4 = CATransform3DMakeRotation(120 \* M\_PI/180, 0, 0, -1);  
6.               CATransform3D rotation5 = CATransform3DMakeRotation(150 \* M\_PI/180, 0, 0, -1);  
7.               CATransform3D rotation6 = CATransform3DMakeRotation(180 \* M\_PI/180, 0, 0, -1);  
8.                 
9.               \[keyAnim setValues:\[NSArray arrayWithObjects:  
10.                                  \[NSValue valueWithCATransform3D:rotation1\],  
11.                                  \[NSValue valueWithCATransform3D:rotation2\],  
12.                                  \[NSValue valueWithCATransform3D:rotation3\],  
13.                                  \[NSValue valueWithCATransform3D:rotation4\],  
14.                                  \[NSValue valueWithCATransform3D:rotation5\],  
15.                                  \[NSValue valueWithCATransform3D:rotation6\],  
16.                                  nil\]\];  
17.              \[keyAnim setKeyTimes:\[NSArray arrayWithObjects:  
18.                                    \[NSNumber numberWithFloat:0.0\],  
19.                                    \[NSNumber numberWithFloat:0.2f\],  
20.                                    \[NSNumber numberWithFloat:0.4f\],  
21.                                    \[NSNumber numberWithFloat:0.6f\],  
22.                                    \[NSNumber numberWithFloat:0.8f\],  
23.                                    \[NSNumber numberWithFloat:1.0f\],  
24.                                    nil\]\];  
25.              \[keyAnim setDuration:4\];  
26.              \[keyAnim setFillMode:kCAFillModeForwards\];  
27.              \[keyAnim setRemovedOnCompletion:NO\];  
28.              \[zhiZhenLayer addAnimation:keyAnim forKey:nil\];  

添加动画结束的delegate

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  CAKeyframeAnimation\* animation;  
2.      animation = \[CAKeyframeAnimation animation\];  
3.      animation.delegate = self;  
4.      \[animation setValue:@"aaa" forKey:@"TAG"\];  

**\[cpp\]** [view plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain") [copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")

 [![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png)](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg)](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")

1.  - (void)animationDidStop:(CAAnimation \*)anim finished:(BOOL)flag  
2.  {  
3.      NSString \*strTag = \[anim valueForKey:@"TAG"\];  
4.      if (\[strTag isEqualToString:@"aaa"\]) {  
5.          aniIsRuning = NO;  
6.      }  
7.  }  

[](http://blog.csdn.net/samuelltk/article/details/9048325#) [](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到QQ空间") [](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到新浪微博") [](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到腾讯微博") [](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到人人网") [](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到微信") .

顶  
0

&nbsp;
踩  
0

.

[ ](#)

[ ](#)

-   上一篇[iOS的三维透视投影](http://blog.csdn.net/samuelltk/article/details/9038723)
-   下一篇[IOS 4.0支持后台运行](http://blog.csdn.net/samuelltk/article/details/9054375)
-   .


