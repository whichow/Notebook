CAKeyframeAnimation 关键帧动画的用法 - 碧水蓝天 - 博客频道 - CSDN.NET
<div>

<div style="-evernote-webclip:true">

\
<div style="font-size: 16px">

<div>

<div
style="color:rgb(51, 51, 51);text-align:center;font-size:12px;font-family:Arial, Console, Verdana, &quot;Courier New&quot;;background:url(&quot;&quot;) 0px 20px repeat-x;">

<div style="background:url(&quot;&quot;) center top no-repeat;">

<div
style="overflow:hidden;border-radius:8px;text-align:left;background:rgb(255, 255, 255);">

<div style="overflow:hidden;border-radius:4px;">

<div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:6108px;">

<div
style="display:block;color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:20px;margin:5px 0px;font-family:&quot;Microsoft YaHei&quot;;border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:31px;">

<span
style="display:inline-block;width:19px;height:19px;margin:0px 2px 0px 0px;vertical-align:middle;background:url(&quot;&quot;) 0px 0px no-repeat;border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;"></span>
<span style="border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[CAKeyframeAnimation 关键帧动画的用法](http://blog.csdn.net/samuelltk/article/details/9048325)</span> {#cakeyframeanimation-关键帧动画的用法 style="font-size:20px;margin:0px;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(0, 0, 0);padding:0px;font-stretch:normal;font-weight:normal;font-family:"Microsoft YaHei";vertical-align:middle;font-variant:normal;font-style:normal;display:inline;box-shadow:none;"}
=========================================================================================================================================================================================================================

<span
style="color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-size:20px;font-family:&quot;Microsoft YaHei&quot;;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="border-bottom-width:1px;padding:0px 20px 5px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:12px;font-family:Arial;text-align:right;display:block;color:rgb(153, 153, 153);border-bottom-style:solid;border-bottom-color:rgb(237, 237, 237);margin:0px -20px;overflow:hidden;border:;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:22px;">

<div
style="border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:22px;">

<span
style="margin:0px 5px 0px 0px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">2013-06-07
15:53</span> <span title="阅读次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) left center no-repeat;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;">5122人阅读</span>
<span title="评论次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) left center no-repeat;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;">
[评论](http://blog.csdn.net/samuelltk/article/details/9048325#comments)(0)</span>
<span
style="margin:0px 5px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[收藏](# "收藏")</span> <span
style="margin:0px 5px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[举报](http://blog.csdn.net/samuelltk/article/details/9048325#report "举报")</span>

</div>

<span
style="color:rgb(153, 153, 153);font-style:normal;font-variant:normal;font-weight:normal;font-size:12px;font-family:Arial;text-align:right;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="padding:20px 0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:42px;">

版权声明：本文为博主原创文章，未经博主允许不得转载。

</div>

<div
style="font-family:Arial;margin:20px 0px 0px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:14px;font-style:normal;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:5672px;">

一、原理

之所以叫做关键帧动画是因为，这个类可以实现，某一属性按照一串的数值进行动画，就好像制作动画的时候一帧一帧的制作一样。

一般使用的时候  首先通过 animationWithKeyPath 方法
创建一个CAKeyframeAnimation实例，

 

CAKeyframeAnimation 的一些比较重要的属性

1\. path

这是一个 CGPathRef
 对象，默认是空的，当我们创建好CAKeyframeAnimation的实例的时候，可以通过制定一个自己定义的path来让
 某一个物体按照这个路径进行动画。<span
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">这个值默认是nil
 当其被设定的时候  values  这个属性就被覆盖 </span>

2\. values

一个数组，提供了一组关键帧的值，  当使用path的 时候
values的值自动被忽略。

下面是一个简单的例子  效果为动画的连续移动一个block到不同的位置

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:464px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:918px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGMutablePathRef path = CGPathCreateMutable();  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//将路径的起点定位到（50  120）  </span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathMoveToPoint(path,NULL,50.0,120.0);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//下面5行添加5条直线的路径到path中</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddLineToPoint(path, NULL, 60, 130);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddLineToPoint(path, NULL, 70, 140);  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddLineToPoint(path, NULL, 80, 150);  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddLineToPoint(path, NULL, 90, 160);  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddLineToPoint(path, NULL, 100, 170);  </span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//下面四行添加四条曲线路径到path</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,50.0,275.0,150.0,275.0,70.0,120.0);  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,150.0,275.0,250.0,275.0,90.0,120.0);  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,250.0,275.0,350.0,275.0,110.0,120.0);  </span>
14. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,350.0,275.0,450.0,275.0,130.0,120.0);  </span>
15. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//以“position”为关键字</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
16. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">实例  </span>
17. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"position"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
18. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//设置path属性</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
19. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setPath:path\];  </span>
20. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[animation setDuration:3.0\];  </span>
21. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//这句代码表示 是否动画回到原位</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
22. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//\[animation setAutoreverses:YES\];</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
23. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CFRelease(path);  </span>
24. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[self.block.layer addAnimation:animation forKey:NULL\];  </span>

</div>

<span
style="color:rgb(51,51,51);font-family:verdana,Arial,Helvetica,sans-serif;font-size:14px;text-align:left;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">运行后
 block会先沿着直线移动，之后再沿着设定的曲线移动，完全按照我们设定的“关键帧”移动。</span>

<div
style="text-align:left;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:1483px;">

<span
style="font-family:verdana,Arial,Helvetica,sans-serif;color:#333333;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span>
<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:266px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:1444px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint p1=CGPointMake(50, 120);  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint p2=CGPointMake(80, 170);  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint p3=CGPointMake(30, 100);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint p4=CGPointMake(100, 190);  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint p5=CGPointMake(200, 10);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">NSArray \*values=\[NSArray arrayWithObjects:\[NSValue valueWithCGPoint:p1\],\[NSValue valueWithCGPoint:p2\],\[NSValue valueWithCGPoint:p3\],\[NSValue valueWithCGPoint:p4\],\[NSValue valueWithCGPoint:p5\], nil\];  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"position"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[animation setValues:values\];  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setDuration:3.0\];  </span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[animation setAutoreverses:YES\];  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[self.block.layer addAnimation:animation forKey:NULL\];  </span>

</div>

     
 也非常简单，到目前位置，只用到了CAKeyframeAnimation的两个关键属性就能完成动画，下面的一些属性提供了更加细致化，更加强大的功能。

<span
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">设定每一帧的时间</span>

<div title="Page 9"
style="padding:0px;color:rgb(51,51,51);font-size:14px;text-align:left;margin:0px;font-family:verdana,Arial,Helvetica,sans-serif;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:75px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:75px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:75px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:75px;">

       默认情况下,一帧动画的播放,分割
的时间是动画的总时间除以帧数减去一。你可以通过下面的公式决定每帧动画的时间:总时间/(总帧数-1)。
例如,如果你指定了一个 5 帧,10 秒的动画,那么每帧的时间就是 2.5
秒钟:10/(5-1)=2.5。你可以做更多 的控制通过使用 keyTimes
关键字,你可以给每帧动画指定总时间之内的某个时间点。 

</div>

</div>

</div>

</div>

     
 通过设置属性keyTimes，能实现这个功能，这个属性是一个数组，其成员必须是NSNumber。

       同时
这个属性的设定值要与calculationMode属性相结合，同时他们有一定的规则，

The appropriate values in
the `keyTimes`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"} array
are dependent on the <span
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">`calculationMode`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"}</span> property.

-   If the <span
    style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">calculationMode is
    set
    to `kCAAnimationLinear`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"}</span>,
    the first value in the array must be 0.0 and the last value must
    be 1.0. Values are interpolated between the specified key times.

-   If the <span
    style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">calculationMode is
    set
    to `kCAAnimationDiscrete`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"}</span>,
    the first value in the array must be 0.0.

-   If the <span
    style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">calculationMode is
    set
    to `kCAAnimationPaced`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"}</span> or `kCAAnimationCubicPaced`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"},
    the `keyTimes`{style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"} array
    is ignored。

如果keyTimes的值不合法，或者不符合上面的规则，那么就会被忽略。

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:50px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:2242px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](C:\Users\WH\AppData\Local\Temp\Wiz\ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setCalculationMode:kCAAnimationLinear\];   </span></span>

</div>

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:86px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:2311px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setKeyTimes:\[NSArray arrayWithObjects:\[NSNumber numberWithFloat:0.0\],\[NSNumber numberWithFloat:0.25\], \[NSNumber numberWithFloat:0.50\],\[NSNumber numberWithFloat:0.75\], \[NSNumber numberWithFloat:1.0\], nil\]\];  </span></span>

</div>

\
### calculationMode {#calculationmode style="border:0px none rgb(51, 51, 51);margin:0px;font-family:verdana,Arial,Helvetica,sans-serif;text-align:left;padding:0px;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;"}

这个属性用来设定 关键帧中间的值是怎么被计算的

可选的值有

``` {style="margin-top:0px;white-space:pre-wrap;color:rgb(51, 51, 51);font-size:14px;text-align:left;background-color:rgb(255, 255, 255);word-wrap:break-word;margin-bottom:0px;padding:0px;border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;width:708px;height:150px;"}
<span style="margin: 0px; padding: 0px; ">NSString * const kCAAnimationLinear;     默认是这种模式
NSString * const kCAAnimationDiscrete;   只展示关键帧的状态，没有中间过程，没有动画。
NSString * const kCAAnimationPaced;
NSString * const kCAAnimationCubic;
NSString * const kCAAnimationCubicPaced;</span>
```

``` {style="margin-top:0px;white-space:pre-wrap;color:rgb(51, 51, 51);font-size:14px;text-align:left;background-color:rgb(255, 255, 255);word-wrap:break-word;margin-bottom:0px;padding:0px;border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;width:708px;height:25px;"}
<span style="margin: 0px; padding: 0px; ">关键帧动画的基础步骤</span>
```

<div title="Page 9"
style="padding:0px;color:rgb(51,51,51);font-size:14px;text-align:left;margin:0px;font-family:verdana,Arial,Helvetica,sans-serif;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:195px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:195px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:195px;">

<div
style="margin:0px;padding:0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:195px;">

1.决定你想要做动画的属性(例如,框架,背景,锚点,位置,边框,等等) 

2.在动画对象值的区域中,指定开始,结束,和中间的值。这些都是你的关键帧(看清单
4-2)\
3.使用 duration 这个字段指定动画的时间\
4.通常来讲,通过使用 times
这个字段,来给每帧动画指定一个时间。如果你没有指定这些,核心动画就会通过你在
values 这个字段指定的值分割出时间段。

5.通常,指定时间功能来控制步调。
这些都是你需要做的。你创建你的动画和增加他们到层中。调用-addAnimation
就开始了动画。 

</div>

</div>

</div>

</div>

</div>

\

二、举例使用

1.使用贝赛尔曲线路径的关键帧动画

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:266px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:3061px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">UIBezierPath \*path = \[UIBezierPath bezierPath\];  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[path moveToPoint:CGPointMake(-40, 100)\];  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[path addLineToPoint:CGPointMake(360, 100)\];  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[path addLineToPoint:CGPointMake(360, 200)\];  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[path addLineToPoint:CGPointMake(-40, 200)\];  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[path addLineToPoint:CGPointMake(-40, 300)\];  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[path addLineToPoint:CGPointMake(360, 300)\];  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*moveAnimation = \[CAKeyframeAnimation animationWithKeyPath:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"position"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">moveAnimation.path = path.CGPath;  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">moveAnimation.duration = 8.0f;  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">moveAnimation.rotationMode = kCAAnimationRotateAuto;  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[shapeLayer addAnimation:moveAnimation forKey:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"moveAnimation"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>

</div>

\
2.使用基于缩放的关键帧动画

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:536px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:3416px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*animation = \[CAKeyframeAnimation animationWithKeyPath:@</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"transform"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CATransform3D scale1 = CATransform3DMakeScale(0.5, 0.5, 1);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CATransform3D scale2 = CATransform3DMakeScale(1.2, 1.2, 1);  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CATransform3D scale3 = CATransform3DMakeScale(0.9, 0.9, 1);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CATransform3D scale4 = CATransform3DMakeScale(1.0, 1.0, 1);  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">NSArray \*frameValues = \[NSArray arrayWithObjects:  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                        \[NSValue valueWithCATransform3D:scale1\],  </span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                        \[NSValue valueWithCATransform3D:scale2\],  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                        \[NSValue valueWithCATransform3D:scale3\],  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                        \[NSValue valueWithCATransform3D:scale4\],  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                        nil\];  </span>
14. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
15. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setValues:frameValues\];  </span>
16. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
17. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">NSArray \*frameTimes = \[NSArray arrayWithObjects:  </span>
18. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                       \[NSNumber numberWithFloat:0.0\],  </span>
19. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                       \[NSNumber numberWithFloat:0.5\],  </span>
20. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                       \[NSNumber numberWithFloat:0.9\],  </span>
21. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                       \[NSNumber numberWithFloat:1.0\],  </span>
22. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                       nil\];  </span>
23. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[animation setKeyTimes:frameTimes\];  </span>
24. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
25. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">animation.fillMode = kCAFillModeForwards;  </span>
26. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">animation.duration = .25;  </span>
27. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span>
28. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[self addAnimation:animation forKey:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"DSPopUpAnimation"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\];  </span></span>

</div>

3.使用基于路径的关键帧动画

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:284px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:4015px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGMutablePathRef path = CGPathCreateMutable();  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathMoveToPoint(path, NULL, 50.0, 120.0);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path, NULL, 50.0, 275.0, 150.0, 275.0, 150.0, 120.0);  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,150.0,275.0,250.0,275.0,250.0,120.0);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,250.0,275.0,350.0,275.0,350.0,120.0);  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPathAddCurveToPoint(path,NULL,350.0,275.0,450.0,275.0,450.0,120.0);  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*anim = \[CAKeyframeAnimation animationWithKeyPath:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"position"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[anim setPath:path\];  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[anim setDuration:3.0\];  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[anim setAutoreverses:YES\];  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CFRelease(path);  </span>
14. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[self.layer addAnimation:anim forKey:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"path"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\];  </span></span>

</div>

4.使用基于位置点的关键桢动画

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:626px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:4362px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt0 = CGPointMake(50.0, 120.0);  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt1 = CGPointMake(50.0, 275.0);  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt2 = CGPointMake(150.0, 275.0);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt3 = CGPointMake(150.0, 120.0);  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt4 = CGPointMake(150.0, 275.0);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt5 = CGPointMake(250.0, 275.0);  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt6 = CGPointMake(250.0, 120.0);  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt7 = CGPointMake(250.0, 275.0);  </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt8 = CGPointMake(350.0, 275.0);  </span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt9 = CGPointMake(350.0, 120.0);  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt10 = CGPointMake(350.0, 275.0);  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CGPoint pt11 = CGPointMake(450.0, 275.0);  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CGPoint pt12 = CGPointMake(450.0, 120.0);  </span>
14. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">NSArray \*values = \[NSArray arrayWithObjects:  </span>
15. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt0\],  </span>
16. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt1\],  </span>
17. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt2\],  </span>
18. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt3\],  </span>
19. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt4\],  </span>
20. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt5\],  </span>
21. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt6\],  </span>
22. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt7\],  </span>
23. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt8\],  </span>
24. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt9\],  </span>
25. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt10\],  </span>
26. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt11\],  </span>
27. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                   \[NSValue valueWithCGPoint:pt12\], nil\];  </span>
28. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CAKeyframeAnimation \*anim = \[CAKeyframeAnimation animationWithKeyPath:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"position"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\];  </span></span>
29. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[anim setValues:values\];  </span>
30. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\[anim setDuration:3.0\];  </span>
31. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[anim setAutoreverses:YES\];  </span>
32. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
33. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[self.layer addAnimation:anim forKey:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"path"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>

</div>

\
5.使用基于旋转的关键桢动画

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:536px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:5077px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation \*keyAnim = \[CAKeyframeAnimation animationWithKeyPath:@</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"transform"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">             CATransform3D rotation1 = CATransform3DMakeRotation(30 \* M\_PI/180, 0, 0, -1);  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             CATransform3D rotation2 = CATransform3DMakeRotation(60 \* M\_PI/180, 0, 0, -1);  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">             CATransform3D rotation3 = CATransform3DMakeRotation(90 \* M\_PI/180, 0, 0, -1);  </span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             CATransform3D rotation4 = CATransform3DMakeRotation(120 \* M\_PI/180, 0, 0, -1);  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">             CATransform3D rotation5 = CATransform3DMakeRotation(150 \* M\_PI/180, 0, 0, -1);  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             CATransform3D rotation6 = CATransform3DMakeRotation(180 \* M\_PI/180, 0, 0, -1);  </span>
8.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">               </span>
9.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             \[keyAnim setValues:\[NSArray arrayWithObjects:  </span>
10. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation1\],  </span>
11. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation2\],  </span>
12. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation3\],  </span>
13. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation4\],  </span>
14. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation5\],  </span>
15. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                 \[NSValue valueWithCATransform3D:rotation6\],  </span>
16. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                 nil\]\];  </span>
17. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             \[keyAnim setKeyTimes:\[NSArray arrayWithObjects:  </span>
18. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:0.0\],  </span>
19. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:0.2f\],  </span>
20. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:0.4f\],  </span>
21. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:0.6f\],  </span>
22. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:0.8f\],  </span>
23. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                   \[NSNumber numberWithFloat:1.0f\],  </span>
24. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                   nil\]\];  </span>
25. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             \[keyAnim setDuration:4\];  </span>
26. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">             \[keyAnim setFillMode:kCAFillModeForwards\];  </span>
27. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">             \[keyAnim setRemovedOnCompletion:NO\];  </span>
28. <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">             \[zhiZhenLayer addAnimation:keyAnim forKey:nil\];  </span>

</div>

\
添加动画结束的delegate

<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:104px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:5716px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CAKeyframeAnimation\* animation;  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    animation = \[CAKeyframeAnimation animation\];  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    animation.delegate = self;  </span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    \[animation setValue:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"aaa"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"> forKey:@</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"TAG"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\];  </span></span>

</div>

\
<div
style="background-color:rgb(231, 229, 220);font-family:Consolas, &quot;Courier New&quot;, Courier, mono, serif;width:700.906px;overflow:auto;padding-top:1px;text-align:left;box-shadow:none;font-size:12px;position:relative;overflow-y:hidden;overflow-x:auto;border:0px none rgb(51, 51, 51);background-image:none;margin:18px 0px;height:158px;">

<div
style="padding-left:45px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:655.906px;height:31px;">

<div
style="border-left-width:3px;padding:3px 8px 10px 10px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:9px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;font-style:normal;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);border:;background-image:none;box-shadow:none;width:634.906px;height:18px;">

**\[cpp\]** [view
plain](http://blog.csdn.net/samuelltk/article/details/9048325# "view plain")<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[copy](http://blog.csdn.net/samuelltk/article/details/9048325# "copy")</span>
<div
style="position:absolute;left:621px;top:5883px;width:18px;height:18px;z-index:99;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">

<div align="middle"
style="background-color:rgb(255, 255, 255);border:0px none rgb(192, 192, 192);background-image:none;box-shadow:none;width:18px;height:18px;">

</div>

</div>

<span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![在CODE上查看代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/CODE_ico.png){width="12"
height="12"}](https://code.csdn.net/snippets/573909 "在CODE上查看代码片")</span><span
style="border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[![派生到我的代码片](CAKeyframeAnimation%20关键帧动画的用法%20-%20碧水蓝天%20-%20博客频道%20-%20CSDN._files/ico_fork.svg){width="12"
height="12"}](https://code.csdn.net/snippets/573909/fork "派生到我的代码片")</span>

</div>

</div>

1.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">- (</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(255, 255, 255);font-weight:bold;background-image:none;box-shadow:none;">void</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)animationDidStop:(CAAnimation \*)anim finished:(</span><span
    style="margin:0px;padding:0px;border:0px none rgb(46, 139, 87);color:rgb(46, 139, 87);background-color:rgb(255, 255, 255);font-weight:bold;background-image:none;box-shadow:none;">BOOL</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)flag  </span></span>
2.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">{  </span>
3.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    NSString \*strTag = \[anim valueForKey:@<span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"TAG"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
4.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(248, 248, 248);font-weight:bold;background-image:none;box-shadow:none;">if</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"> (\[strTag isEqualToString:@</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"aaa"</span><span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">\]) {  </span></span>
5.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">        aniIsRuning = NO;  </span>
6.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    }  </span>
7.  <span
    style="margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">}  </span>

</div>

\
\

\

</div>

<div
style="zoom:1;float:right;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:138px;height:28px;">

[](http://blog.csdn.net/samuelltk/article/details/9048325#)
[](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到QQ空间")
[](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到新浪微博")
[](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到腾讯微博")
[](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到人人网")
[](http://blog.csdn.net/samuelltk/article/details/9048325# "分享到微信")
<span
style="visibility:hidden;display:block;height:0px;clear:both;">.</span>

</div>

<div
style="text-align:center;display:block;width:182px;margin:0px auto;padding:30px 0px 15px;clear:both;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;height:72px;">

顶
:   0

<!-- -->

踩
:   0

<span
style="text-align:center;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:14px;">

[ ](#)

</div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:14px;">

[ ](#)

</div>

-   <span
    style="margin-right:7px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);font-size:14px;float:left;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);border:0px none rgb(255, 255, 255);background-repeat:no-repeat;background-position:9px 8px;box-shadow:none;">上一篇</span>[iOS的三维透视投影](http://blog.csdn.net/samuelltk/article/details/9038723)
-   <span
    style="margin-right:7px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);font-size:14px;float:left;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);border:0px none rgb(255, 255, 255);background-repeat:no-repeat;background-position:9px -22px;box-shadow:none;">下一篇</span>[IOS
    4.0支持后台运行](http://blog.csdn.net/samuelltk/article/details/9054375)
-   <span
    style="color:rgb(102, 102, 102);font-style:normal;font-variant:normal;font-weight:normal;font-size:14px;font-family:&quot;Microsoft YaHei&quot;, Arial, Helvetica, sans-serif;display:block;height:0px;clear:both;visibility:hidden;">.</span>

<div
style="clear:both;height:10px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;">

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>

</div>
