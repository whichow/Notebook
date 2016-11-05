Apple在iOS 8中引入了依靠于Auto Layout(自动布局)和Size
Classes(尺寸类别)组合的自适应用户界面的概念。构建适配用不同尺寸的户界面在Apple在iOS
9中增加了slide over和split screen支持后开始变得更重要。

<span style="line-height: 1.6;">Size Classes</span>
---------------------------------------------------

<div>

<span style="line-height: 1.6;">你可以用在应用的界面的</span><span
style="line-height: 1.6;">水平(width)或垂直(height)方向使用这</span><span
style="line-height: 1.6;">两种size classes:</span>

</div>

<div>

-   <span style="line-height: 1.6;">**regular:**
    意味着你的界面有广阔的空间。</span>\
-   <span style="line-height: 1.6;">**compact:**
    意味着你的界面只有着非常局限的空间。</span>\

iPhone 6(s) Plus
----------------

</div>

<div>

iPhone 6(s) Plus是仅有的在横屏方向上有regular width的<span
style="line-height: 1.6;">iPhone</span><span
style="line-height: 1.6;">设备。最长的尺寸始终是regular，最短的尺寸始终是compact。</span>

</div>

<div>

![Size Classes iPhone 6
Plus](Size%20Class%20参考手册_files/0.6447534854523838.png){width="505"
height="320"}

</div>

其他所有iPhone型号
------------------

<div>

其他iPhone型号在横屏和竖屏情况下的size
classes是不一样的。设备最长的尺寸在竖屏时是regular但是在横屏时只有compact。

</div>

<div>

![Size Classes
iPhone](Size%20Class%20参考手册_files/0.7828464966733009.png){width="505"
height="318"}

</div>

iPad
----

<div>

<span
style="line-height: 1.6;">无论方向怎样，</span>全屏的iPad应用始终有着regular高度和宽度的size
classes。

</div>

<div>

![Size Classes
iPad](Size%20Class%20参考手册_files/0.7269298022147268.png){width="530"
height="320"}

</div>

iPad Split Screen 和 Slide Over
-------------------------------

<div>

多任务视图在iOS 9的引入使得iPad情况变得复杂。

</div>

<div>

![Size Classes Slide Over
Portrait](Size%20Class%20参考手册_files/0.7400253470987082.png){width="505"
height="466"}

![Size Classes Slide Over
Landscape](Size%20Class%20参考手册_files/0.7741418583318591.png){width="505"
height="346"}

![Size Classes Split
Screen](Size%20Class%20参考手册_files/0.9370545467827469.png){width="505"
height="349"}

</div>
