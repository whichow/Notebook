<div class="middle clearfix">

<div class="m-wrap">

<div class="detail-left float-l">

<div class="detail-main">

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 8016px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

深藏于每台iPhone光滑的屏幕之下，处于触摸屏与芯片之间，依偎在逻辑板之上的陀螺仪和加速器总是被众人所遗忘。

所以这些玩意拿来干嘛？当然是用来在旧式的点击和滑动之外开创新交互方式的啦，这里就要动用到Core
Motion框架，这个东西能非常有效的驾驭住这些传感器。

对于使用了M7或者M8处理器的设备，Core
Motion框架支持了一些预置的motion动作，比如脚步数、爬楼还有移动类型(行走、骑行等等)。

Core
Motion可以让开发者从各个内置传感器那里获取未经修改的传感数据，并观测或响应设备各种运动和角度变化。这些传感器包括陀螺仪、加速器和磁力仪(罗盘)。

加速器和陀螺仪的数据都是描述沿着iOS设备三个方向轴上的位置，对于一个竖屏摆放的iPhone来说，X方向从设备的左边(负)到右边(正)，Y方向则是由设备的底部(-)到顶部(+)，而Z方向为垂直于屏幕由设备的背面(-)到正面(+)。

这些成组的数据根据不同的用法会有不同的表示方式，下面我们就开始来说一说。

![axes.png](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740167650216.png "1414740167650216.png")

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**CoreMotionManager**</span>

CoreMotionManager类能够使用到设备的所有移动数据(motion data)，Core
Motion框架提供了两种对motion数据的操作方式，一个是"pull"，另一个是"push"，其中"pull"方式能够以CoreMotionManager的只读方式获取当前任何传感器状态或是组合数据。"push"方式则是以块或者闭包的形式收集到你想要得到的数据并且会在特定周期内得到实时的更新。

为了保证性能，苹果建议在使用CoreMotionManager的时候采用单件模式。

CoreMotionManager为四种motion数据类型的每一个都提供了统一的接口：accelerometer,gyro,magnetometer和deviceMotion。下面的例子演示了如何与陀螺仪交互的方式，当然如果是想跟其它设备交互的话只需要把下面的gyro替换成你想要使用的类型就行了。

**检测设备可用性**

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 45px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 45px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 45px; left: 0p |
| 175, 175) none 0px; padding: 0px 7px | x; line-height: 15.4px; margin: 0px; |
|  0px 14px; text-align: right; text-d |  outline: rgb(37, 37, 37) none 0px;  |
| ecoration: none; white-space: pre; w | padding: 0px; position: relative; ri |
| idth: 8px; background: none 0% 0% /  | ght: 0px; text-align: left; text-dec |
| auto repeat scroll padding-box borde | oration: none; top: 0px; width: 671p |
| r-box rgb(255, 255, 255);">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 643px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `let manager = CoreMotionManager()`{ |
| r-box rgb(255, 255, 255);">          | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| 2                                    | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| </div>                               | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
| <div                                 | -height: 15.4px; margin: 0px; paddin |
| style="color: rgb(175, 175, 175); di | g: 0px; text-align: left; text-decor |
| splay: block; font-style: normal; fo | ation: none; white-space: pre;"}`if` |
| nt-variant: normal; font-weight: nor | {style="border: 0px none rgb(0, 102, |
| mal; font-stretch: normal; font-size |  153); color: rgb(0, 102, 153); disp |
| : 14px; font-family: Consolas, &quot | lay: inline; font-style: normal; fon |
| ;Bitstream Vera Sans Mono&quot;, &qu | t-variant: normal; font-weight: bold |
| ot;Courier New&quot;, Courier, monos | ; font-stretch: normal; font-size: 1 |
| pace; height: 15px; line-height: 15. | 4px; font-family: Consolas, "Bitstre |
| 4px; margin: 0px; outline: rgb(175,  | am Vera Sans Mono", "Courier New", C |
| 175, 175) none 0px; padding: 0px 7px | ourier, monospace; line-height: 15.4 |
|  0px 14px; text-align: right; text-d | px; margin: 0px; outline: rgb(0, 102 |
| ecoration: none; white-space: pre; w | , 153) none 0px; padding: 0px; text- |
| idth: 8px; background: none 0% 0% /  | align: left; text-decoration: none;  |
| auto repeat scroll padding-box borde | white-space: pre;"} `manager.gyroAva |
| r-box rgb(255, 255, 255);">          | ilable {`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
| 3                                    | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
| </div>                               | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}                               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `     `{style="border: 0px none rgb( |
|                                      | 37, 37, 37); color: rgb(37, 37, 37); |
|                                      |  display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; outline: rgb |
|                                      | (37, 37, 37) none 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}`// ...`{st |
|                                      | yle="border: 0px none rgb(0, 130, 0) |
|                                      | ; color: rgb(0, 130, 0); display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; outline: rgb(0, 130, 0)  |
|                                      | none 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

为了让事情在Swift和Objective-C之间变得简单且相同，这里就假设我们此前已经在所有示例中声明了一个manger实例作为视图控制器的属性。

**设置更新周期**

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 15px; left: 0p |
| 175, 175) none 0px; padding: 0px 7px | x; line-height: 15.4px; margin: 0px; |
|  0px 14px; text-align: right; text-d |  outline: rgb(37, 37, 37) none 0px;  |
| ecoration: none; white-space: pre; w | padding: 0px; position: relative; ri |
| idth: 8px; background: none 0% 0% /  | ght: 0px; text-align: left; text-dec |
| auto repeat scroll padding-box borde | oration: none; top: 0px; width: 671p |
| r-box rgb(255, 255, 255);">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `manager.gyroUpdateInterval = 0.1`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

这里的时间设置是NSTimeInterval类型，所以你需要将更新时间设置为秒级别的：这样会减缓响应的效率，不过能够有效的降低CPU的占用率。

**使用“pull”方式更新数据**

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 15px; left: 0p |
| 175, 175) none 0px; padding: 0px 7px | x; line-height: 15.4px; margin: 0px; |
|  0px 14px; text-align: right; text-d |  outline: rgb(37, 37, 37) none 0px;  |
| ecoration: none; white-space: pre; w | padding: 0px; position: relative; ri |
| idth: 8px; background: none 0% 0% /  | ght: 0px; text-align: left; text-dec |
| auto repeat scroll padding-box borde | oration: none; top: 0px; width: 671p |
| r-box rgb(255, 255, 255);">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `manager.startGyroUpdates()`{style=" |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

在这段代码被调用之后，manger.gyroData即可随时可用，并反应当前设备陀螺仪数据。

**使用“push”方式更新数据**

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 60px; left: 0p |
| 175, 175) none 0px; padding: 0px 7px | x; line-height: 15.4px; margin: 0px; |
|  0px 14px; text-align: right; text-d |  outline: rgb(37, 37, 37) none 0px;  |
| ecoration: none; white-space: pre; w | padding: 0px; position: relative; ri |
| idth: 8px; background: none 0% 0% /  | ght: 0px; text-align: left; text-dec |
| auto repeat scroll padding-box borde | oration: none; top: 0px; width: 671p |
| r-box rgb(255, 255, 255);">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 643px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `let queue = NSOperationQueue.mainQu |
| r-box rgb(255, 255, 255);">          | euemanager.startGyroUpdatesToQueue(q |
|                                      | ueue) {`{style="display: inline; fon |
| 2                                    | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
| </div>                               | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
| <div                                 | ono", "Courier New", Courier, monosp |
| style="color: rgb(175, 175, 175); di | ace; line-height: 15.4px; margin: 0p |
| splay: block; font-style: normal; fo | x; padding: 0px; text-align: left; t |
| nt-variant: normal; font-weight: nor | ext-decoration: none; white-space: p |
| mal; font-stretch: normal; font-size | re;"}                                |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 643px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `    `{style="border: 0px none rgb(3 |
| ;Bitstream Vera Sans Mono&quot;, &qu | 7, 37, 37); color: rgb(37, 37, 37);  |
| ot;Courier New&quot;, Courier, monos | display: inline; font-style: normal; |
| pace; height: 15px; line-height: 15. |  font-variant: normal; font-weight:  |
| 4px; margin: 0px; outline: rgb(175,  | normal; font-stretch: normal; font-s |
| 175, 175) none 0px; padding: 0px 7px | ize: 14px; font-family: Consolas, "B |
|  0px 14px; text-align: right; text-d | itstream Vera Sans Mono", "Courier N |
| ecoration: none; white-space: pre; w | ew", Courier, monospace; line-height |
| idth: 8px; background: none 0% 0% /  | : 15.4px; margin: 0px; outline: rgb( |
| auto repeat scroll padding-box borde | 37, 37, 37) none 0px; padding: 0px;  |
| r-box rgb(255, 255, 255);">          | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`(data, erro |
| 4                                    | r) `{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
| </div>                               | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`in`{style="border: 0px none rgb(0, |
|                                      |  102, 153); color: rgb(0, 102, 153); |
|                                      |  display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  bold; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; outline: rgb(0 |
|                                      | , 102, 153) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`// ...`{sty |
|                                      | le="border: 0px none rgb(0, 130, 0); |
|                                      |  color: rgb(0, 130, 0); display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; outline: rgb(0, 130, 0) n |
|                                      | one 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

这段代码会根据给定的更新周期按一定频率被调用。

**停止更新**

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 15px; left: 0p |
| 175, 175) none 0px; padding: 0px 7px | x; line-height: 15.4px; margin: 0px; |
|  0px 14px; text-align: right; text-d |  outline: rgb(37, 37, 37) none 0px;  |
| ecoration: none; white-space: pre; w | padding: 0px; position: relative; ri |
| idth: 8px; background: none 0% 0% /  | ght: 0px; text-align: left; text-dec |
| auto repeat scroll padding-box borde | oration: none; top: 0px; width: 671p |
| r-box rgb(255, 255, 255);">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `manager.stopGyroUpdates()`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**使用加速器**</span>

现在我们来试试为App的启动页添加一个有趣的功能，使得启动页的图片无论在设备如何倾斜的情况下都保持水平。

来思考一下下面的代码：

首先，我们需要检测确保我们设备上的加速器数据是可用的，然后指定一个频率很高的更新周期，接着在一个闭包中进行更新来旋转UIImageView属性。

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 135px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 118px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 135px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 675 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 647px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Swift`{style="border: 0px none rg |
| r-box rgb(255, 255, 255);">          | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 647px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `if`{style="border: 0px none rgb(0,  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 102, 153); color: rgb(0, 102, 153);  |
| ot;Courier New&quot;, Courier, monos | display: inline; font-style: normal; |
| pace; height: 15px; line-height: 15. |  font-variant: normal; font-weight:  |
| 4px; margin: 0px; outline: rgb(175,  | bold; font-stretch: normal; font-siz |
| 175, 175) none 0px; padding: 0px 7px | e: 14px; font-family: Consolas, "Bit |
|  0px 14px; text-align: right; text-d | stream Vera Sans Mono", "Courier New |
| ecoration: none; white-space: pre; w | ", Courier, monospace; line-height:  |
| idth: 8px; background: none 0% 0% /  | 15.4px; margin: 0px; outline: rgb(0, |
| auto repeat scroll padding-box borde |  102, 153) none 0px; padding: 0px; t |
| r-box rgb(255, 255, 255);">          | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"} `manager.acc |
| 4                                    | elerometerAvailable {`{style="displa |
|                                      | y: inline; font-style: normal; font- |
| </div>                               | variant: normal; font-weight: normal |
|                                      | ; font-stretch: normal; font-size: 1 |
| <div                                 | 4px; font-family: Consolas, "Bitstre |
| style="color: rgb(175, 175, 175); di | am Vera Sans Mono", "Courier New", C |
| splay: block; font-style: normal; fo | ourier, monospace; line-height: 15.4 |
| nt-variant: normal; font-weight: nor | px; margin: 0px; padding: 0px; text- |
| mal; font-stretch: normal; font-size | align: left; text-decoration: none;  |
| : 14px; font-family: Consolas, &quot | white-space: pre;"}                  |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | </div>                               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | <div                                 |
| 175, 175) none 0px; padding: 0px 7px | style="border: 0px none rgb(37, 37,  |
|  0px 14px; text-align: right; text-d | 37); color: rgb(37, 37, 37); display |
| ecoration: none; white-space: pre; w | : block; font-style: normal; font-va |
| idth: 8px; background: none 0% 0% /  | riant: normal; font-weight: normal;  |
| auto repeat scroll padding-box borde | font-stretch: normal; font-size: 14p |
| r-box rgb(255, 255, 255);">          | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| 5                                    | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| </div>                               | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
| <div                                 | align: left; text-decoration: none;  |
| style="color: rgb(175, 175, 175); di | white-space: pre; width: 647px; back |
| splay: block; font-style: normal; fo | ground: none 0% 0% / auto repeat scr |
| nt-variant: normal; font-weight: nor | oll padding-box border-box rgb(255,  |
| mal; font-stretch: normal; font-size | 255, 255);">                         |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | `    `{style="border: 0px none rgb(3 |
| ot;Courier New&quot;, Courier, monos | 7, 37, 37); color: rgb(37, 37, 37);  |
| pace; height: 15px; line-height: 15. | display: inline; font-style: normal; |
| 4px; margin: 0px; outline: rgb(175,  |  font-variant: normal; font-weight:  |
| 175, 175) none 0px; padding: 0px 7px | normal; font-stretch: normal; font-s |
|  0px 14px; text-align: right; text-d | ize: 14px; font-family: Consolas, "B |
| ecoration: none; white-space: pre; w | itstream Vera Sans Mono", "Courier N |
| idth: 8px; background: none 0% 0% /  | ew", Courier, monospace; line-height |
| auto repeat scroll padding-box borde | : 15.4px; margin: 0px; outline: rgb( |
| r-box rgb(255, 255, 255);">          | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| 6                                    | one; white-space: pre;"}`manager.acc |
|                                      | elerometerUpdateInterval = 0.01`{sty |
| </div>                               | le="display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
| <div                                 | ht: normal; font-stretch: normal; fo |
| style="color: rgb(175, 175, 175); di | nt-size: 14px; font-family: Consolas |
| splay: block; font-style: normal; fo | , "Bitstream Vera Sans Mono", "Couri |
| nt-variant: normal; font-weight: nor | er New", Courier, monospace; line-he |
| mal; font-stretch: normal; font-size | ight: 15.4px; margin: 0px; padding:  |
| : 14px; font-family: Consolas, &quot | 0px; text-align: left; text-decorati |
| ;Bitstream Vera Sans Mono&quot;, &qu | on: none; white-space: pre;"}        |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | </div>                               |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | <div                                 |
|  0px 14px; text-align: right; text-d | style="border: 0px none rgb(37, 37,  |
| ecoration: none; white-space: pre; w | 37); color: rgb(37, 37, 37); display |
| idth: 8px; background: none 0% 0% /  | : block; font-style: normal; font-va |
| auto repeat scroll padding-box borde | riant: normal; font-weight: normal;  |
| r-box rgb(255, 255, 255);">          | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| 7                                    | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| </div>                               |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| <div                                 | ) none 0px; padding: 0px 14px; text- |
| style="color: rgb(175, 175, 175); di | align: left; text-decoration: none;  |
| splay: block; font-style: normal; fo | white-space: pre; width: 647px; back |
| nt-variant: normal; font-weight: nor | ground: none 0% 0% / auto repeat scr |
| mal; font-stretch: normal; font-size | oll padding-box border-box rgb(255,  |
| : 14px; font-family: Consolas, &quot | 255, 255);">                         |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | `    `{style="border: 0px none rgb(3 |
| pace; height: 15px; line-height: 15. | 7, 37, 37); color: rgb(37, 37, 37);  |
| 4px; margin: 0px; outline: rgb(175,  | display: inline; font-style: normal; |
| 175, 175) none 0px; padding: 0px 7px |  font-variant: normal; font-weight:  |
|  0px 14px; text-align: right; text-d | normal; font-stretch: normal; font-s |
| ecoration: none; white-space: pre; w | ize: 14px; font-family: Consolas, "B |
| idth: 8px; background: none 0% 0% /  | itstream Vera Sans Mono", "Courier N |
| auto repeat scroll padding-box borde | ew", Courier, monospace; line-height |
| r-box rgb(255, 255, 255);">          | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 8                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`manager.sta |
| </div>                               | rtAccelerometerUpdatesToQueue(NSOper |
|                                      | ationQueue.mainQueue()) {`{style="di |
| <div                                 | splay: inline; font-style: normal; f |
| style="color: rgb(175, 175, 175); di | ont-variant: normal; font-weight: no |
| splay: block; font-style: normal; fo | rmal; font-stretch: normal; font-siz |
| nt-variant: normal; font-weight: nor | e: 14px; font-family: Consolas, "Bit |
| mal; font-stretch: normal; font-size | stream Vera Sans Mono", "Courier New |
| : 14px; font-family: Consolas, &quot | ", Courier, monospace; line-height:  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 15.4px; margin: 0px; padding: 0px; t |
| ot;Courier New&quot;, Courier, monos | ext-align: left; text-decoration: no |
| pace; height: 15px; line-height: 15. | ne; white-space: pre;"}              |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 8px; background: none 0% 0% /  | style="border: 0px none rgb(37, 37,  |
| auto repeat scroll padding-box borde | 37); color: rgb(37, 37, 37); display |
| r-box rgb(255, 255, 255);">          | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 9                                    | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`[weak s |
|                                      | elf] (data: CMAccelerometerData!, er |
|                                      | ror: NSError!) `{style="display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; padding: 0px; text-align: |
|                                      |  left; text-decoration: none; white- |
|                                      | space: pre;"}`in`{style="border: 0px |
|                                      |  none rgb(0, 102, 153); color: rgb(0 |
|                                      | , 102, 153); display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: bold; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; ou |
|                                      | tline: rgb(0, 102, 153) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`let rot |
|                                      | ation = atan2(data.acceleration.x, d |
|                                      | ata.acceleration.y) - M_PI`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`self?.i |
|                                      | mageView.transform = CGAffineTransfo |
|                                      | rmMakeRotation(CGFloat(rotation))`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 152px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 135px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 135px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 706 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 678px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Objective-C`{style="border: 0px n |
| r-box rgb(255, 255, 255);">          | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 678px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `RotationViewController * __weak wea |
| ;Bitstream Vera Sans Mono&quot;, &qu | kSelf = self;`{style="display: inlin |
| ot;Courier New&quot;, Courier, monos | e; font-style: normal; font-variant: |
| pace; height: 15px; line-height: 15. |  normal; font-weight: normal; font-s |
| 4px; margin: 0px; outline: rgb(175,  | tretch: normal; font-size: 14px; fon |
| 175, 175) none 0px; padding: 0px 7px | t-family: Consolas, "Bitstream Vera  |
|  0px 14px; text-align: right; text-d | Sans Mono", "Courier New", Courier,  |
| ecoration: none; white-space: pre; w | monospace; line-height: 15.4px; marg |
| idth: 8px; background: none 0% 0% /  | in: 0px; padding: 0px; text-align: l |
| auto repeat scroll padding-box borde | eft; text-decoration: none; white-sp |
| r-box rgb(255, 255, 255);">          | ace: pre;"}`if`{style="border: 0px n |
|                                      | one rgb(0, 102, 153); color: rgb(0,  |
| 4                                    | 102, 153); display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
| </div>                               | nt-weight: bold; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
| <div                                 | solas, "Bitstream Vera Sans Mono", " |
| style="color: rgb(175, 175, 175); di | Courier New", Courier, monospace; li |
| splay: block; font-style: normal; fo | ne-height: 15.4px; margin: 0px; outl |
| nt-variant: normal; font-weight: nor | ine: rgb(0, 102, 153) none 0px; padd |
| mal; font-stretch: normal; font-size | ing: 0px; text-align: left; text-dec |
| : 14px; font-family: Consolas, &quot | oration: none; white-space: pre;"} ` |
| ;Bitstream Vera Sans Mono&quot;, &qu | (manager.accelerometerAvailable) {`{ |
| ot;Courier New&quot;, Courier, monos | style="display: inline; font-style:  |
| pace; height: 15px; line-height: 15. | normal; font-variant: normal; font-w |
| 4px; margin: 0px; outline: rgb(175,  | eight: normal; font-stretch: normal; |
| 175, 175) none 0px; padding: 0px 7px |  font-size: 14px; font-family: Conso |
|  0px 14px; text-align: right; text-d | las, "Bitstream Vera Sans Mono", "Co |
| ecoration: none; white-space: pre; w | urier New", Courier, monospace; line |
| idth: 8px; background: none 0% 0% /  | -height: 15.4px; margin: 0px; paddin |
| auto repeat scroll padding-box borde | g: 0px; text-align: left; text-decor |
| r-box rgb(255, 255, 255);">          | ation: none; white-space: pre;"}     |
|                                      |                                      |
| 5                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| <div                                 | 37); color: rgb(37, 37, 37); display |
| style="color: rgb(175, 175, 175); di | : block; font-style: normal; font-va |
| splay: block; font-style: normal; fo | riant: normal; font-weight: normal;  |
| nt-variant: normal; font-weight: nor | font-stretch: normal; font-size: 14p |
| mal; font-stretch: normal; font-size | x; font-family: Consolas, &quot;Bits |
| : 14px; font-family: Consolas, &quot | tream Vera Sans Mono&quot;, &quot;Co |
| ;Bitstream Vera Sans Mono&quot;, &qu | urier New&quot;, Courier, monospace; |
| ot;Courier New&quot;, Courier, monos |  height: 15px; line-height: 15.4px;  |
| pace; height: 15px; line-height: 15. | margin: 0px; outline: rgb(37, 37, 37 |
| 4px; margin: 0px; outline: rgb(175,  | ) none 0px; padding: 0px 14px; text- |
| 175, 175) none 0px; padding: 0px 7px | align: left; text-decoration: none;  |
|  0px 14px; text-align: right; text-d | white-space: pre; width: 678px; back |
| ecoration: none; white-space: pre; w | ground: none 0% 0% / auto repeat scr |
| idth: 8px; background: none 0% 0% /  | oll padding-box border-box rgb(255,  |
| auto repeat scroll padding-box borde | 255, 255);">                         |
| r-box rgb(255, 255, 255);">          |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
| 6                                    | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
| </div>                               |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| <div                                 | ize: 14px; font-family: Consolas, "B |
| style="color: rgb(175, 175, 175); di | itstream Vera Sans Mono", "Courier N |
| splay: block; font-style: normal; fo | ew", Courier, monospace; line-height |
| nt-variant: normal; font-weight: nor | : 15.4px; margin: 0px; outline: rgb( |
| mal; font-stretch: normal; font-size | 37, 37, 37) none 0px; padding: 0px;  |
| : 14px; font-family: Consolas, &quot | text-align: left; text-decoration: n |
| ;Bitstream Vera Sans Mono&quot;, &qu | one; white-space: pre;"}`manager.acc |
| ot;Courier New&quot;, Courier, monos | elerometerUpdateInterval = 0.01f;`{s |
| pace; height: 15px; line-height: 15. | tyle="display: inline; font-style: n |
| 4px; margin: 0px; outline: rgb(175,  | ormal; font-variant: normal; font-we |
| 175, 175) none 0px; padding: 0px 7px | ight: normal; font-stretch: normal;  |
|  0px 14px; text-align: right; text-d | font-size: 14px; font-family: Consol |
| ecoration: none; white-space: pre; w | as, "Bitstream Vera Sans Mono", "Cou |
| idth: 8px; background: none 0% 0% /  | rier New", Courier, monospace; line- |
| auto repeat scroll padding-box borde | height: 15.4px; margin: 0px; padding |
| r-box rgb(255, 255, 255);">          | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
| 7                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="border: 0px none rgb(37, 37,  |
| style="color: rgb(175, 175, 175); di | 37); color: rgb(37, 37, 37); display |
| splay: block; font-style: normal; fo | : block; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: normal;  |
| mal; font-stretch: normal; font-size | font-stretch: normal; font-size: 14p |
| : 14px; font-family: Consolas, &quot | x; font-family: Consolas, &quot;Bits |
| ;Bitstream Vera Sans Mono&quot;, &qu | tream Vera Sans Mono&quot;, &quot;Co |
| ot;Courier New&quot;, Courier, monos | urier New&quot;, Courier, monospace; |
| pace; height: 15px; line-height: 15. |  height: 15px; line-height: 15.4px;  |
| 4px; margin: 0px; outline: rgb(175,  | margin: 0px; outline: rgb(37, 37, 37 |
| 175, 175) none 0px; padding: 0px 7px | ) none 0px; padding: 0px 14px; text- |
|  0px 14px; text-align: right; text-d | align: left; text-decoration: none;  |
| ecoration: none; white-space: pre; w | white-space: pre; width: 678px; back |
| idth: 8px; background: none 0% 0% /  | ground: none 0% 0% / auto repeat scr |
| auto repeat scroll padding-box borde | oll padding-box border-box rgb(255,  |
| r-box rgb(255, 255, 255);">          | 255, 255);">                         |
|                                      |                                      |
| 8                                    | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
| </div>                               | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| <div                                 | normal; font-stretch: normal; font-s |
| style="color: rgb(175, 175, 175); di | ize: 14px; font-family: Consolas, "B |
| splay: block; font-style: normal; fo | itstream Vera Sans Mono", "Courier N |
| nt-variant: normal; font-weight: nor | ew", Courier, monospace; line-height |
| mal; font-stretch: normal; font-size | : 15.4px; margin: 0px; outline: rgb( |
| : 14px; font-family: Consolas, &quot | 37, 37, 37) none 0px; padding: 0px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | text-align: left; text-decoration: n |
| ot;Courier New&quot;, Courier, monos | one; white-space: pre;"}`[manager st |
| pace; height: 15px; line-height: 15. | artAccelerometerUpdatesToQueue:[NSOp |
| 4px; margin: 0px; outline: rgb(175,  | erationQueue mainQueue]`{style="disp |
| 175, 175) none 0px; padding: 0px 7px | lay: inline; font-style: normal; fon |
|  0px 14px; text-align: right; text-d | t-variant: normal; font-weight: norm |
| ecoration: none; white-space: pre; w | al; font-stretch: normal; font-size: |
| idth: 8px; background: none 0% 0% /  |  14px; font-family: Consolas, "Bitst |
| auto repeat scroll padding-box borde | ream Vera Sans Mono", "Courier New", |
| r-box rgb(255, 255, 255);">          |  Courier, monospace; line-height: 15 |
|                                      | .4px; margin: 0px; padding: 0px; tex |
| 9                                    | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
| </div>                               |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 678px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `                              `{sty |
|                                      | le="border: 0px none rgb(37, 37, 37) |
|                                      | ; color: rgb(37, 37, 37); display: i |
|                                      | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}`withHandler:^(CMAccel |
|                                      | erometerData *data, NSError *error)  |
|                                      | {`{style="display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 678px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`double  |
|                                      | rotation = atan2(data.acceleration.x |
|                                      | , data.acceleration.y) - M_PI;`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 678px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`weakSel |
|                                      | f.imageView.transform = CGAffineTran |
|                                      | sformMakeRotation(rotation);`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 678px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 678px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

每一个CMAccelerometerData包含了x,y,z三个值，每一个显示的是在该方向上的加速度，并以G为单位(G为重力加速度)。也就是说，如果你的设备保持静止然后竖直放置的话，加速度的值就是(0,-1,0)，而将其平放在桌面上就会是(0,0,-1)，而竖直向右倾斜45度的情况下，加速度的值则为(0.707,-0.707,0)。

![accelerometer.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740462245931.gif "1414740462245931.gif")

如上图，结果有些差强人意，你可以发现图片在旋转的时候会有一些抖动，而且移动设备的位置比起旋转设备而言，对加速器的影响可能更甚。这里可以依靠对读入的数据抽样取平均值来缓和问题，不过我们可以来看一看考虑进陀螺仪之后的效果。

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**加入陀螺仪数据**</span>

我们可以使用startGyroUpdates来获取无损的陀螺仪数据，不过在这里使用的是deviceMotion类型来获取加速器和陀螺仪的复合数据。通过使用陀螺仪，Core
Motion能依靠重力加速度来区分用户的动作，    
并且作为一个属性表示在我们从处理程序中获取的CMDeviceMotionData实例中。代码和第一个示例中的差不多：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 135px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 118px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 135px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 675 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 647px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Swift`{style="border: 0px none rg |
| r-box rgb(255, 255, 255);">          | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 647px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `if`{style="border: 0px none rgb(0,  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 102, 153); color: rgb(0, 102, 153);  |
| ot;Courier New&quot;, Courier, monos | display: inline; font-style: normal; |
| pace; height: 15px; line-height: 15. |  font-variant: normal; font-weight:  |
| 4px; margin: 0px; outline: rgb(175,  | bold; font-stretch: normal; font-siz |
| 175, 175) none 0px; padding: 0px 7px | e: 14px; font-family: Consolas, "Bit |
|  0px 14px; text-align: right; text-d | stream Vera Sans Mono", "Courier New |
| ecoration: none; white-space: pre; w | ", Courier, monospace; line-height:  |
| idth: 8px; background: none 0% 0% /  | 15.4px; margin: 0px; outline: rgb(0, |
| auto repeat scroll padding-box borde |  102, 153) none 0px; padding: 0px; t |
| r-box rgb(255, 255, 255);">          | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"} `manager.dev |
| 4                                    | iceMotionAvailable {`{style="display |
|                                      | : inline; font-style: normal; font-v |
| </div>                               | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
| <div                                 | px; font-family: Consolas, "Bitstrea |
| style="color: rgb(175, 175, 175); di | m Vera Sans Mono", "Courier New", Co |
| splay: block; font-style: normal; fo | urier, monospace; line-height: 15.4p |
| nt-variant: normal; font-weight: nor | x; margin: 0px; padding: 0px; text-a |
| mal; font-stretch: normal; font-size | lign: left; text-decoration: none; w |
| : 14px; font-family: Consolas, &quot | hite-space: pre;"}                   |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | </div>                               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | <div                                 |
| 175, 175) none 0px; padding: 0px 7px | style="border: 0px none rgb(37, 37,  |
|  0px 14px; text-align: right; text-d | 37); color: rgb(37, 37, 37); display |
| ecoration: none; white-space: pre; w | : block; font-style: normal; font-va |
| idth: 8px; background: none 0% 0% /  | riant: normal; font-weight: normal;  |
| auto repeat scroll padding-box borde | font-stretch: normal; font-size: 14p |
| r-box rgb(255, 255, 255);">          | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| 5                                    | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| </div>                               | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
| <div                                 | align: left; text-decoration: none;  |
| style="color: rgb(175, 175, 175); di | white-space: pre; width: 647px; back |
| splay: block; font-style: normal; fo | ground: none 0% 0% / auto repeat scr |
| nt-variant: normal; font-weight: nor | oll padding-box border-box rgb(255,  |
| mal; font-stretch: normal; font-size | 255, 255);">                         |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | `    `{style="border: 0px none rgb(3 |
| ot;Courier New&quot;, Courier, monos | 7, 37, 37); color: rgb(37, 37, 37);  |
| pace; height: 15px; line-height: 15. | display: inline; font-style: normal; |
| 4px; margin: 0px; outline: rgb(175,  |  font-variant: normal; font-weight:  |
| 175, 175) none 0px; padding: 0px 7px | normal; font-stretch: normal; font-s |
|  0px 14px; text-align: right; text-d | ize: 14px; font-family: Consolas, "B |
| ecoration: none; white-space: pre; w | itstream Vera Sans Mono", "Courier N |
| idth: 8px; background: none 0% 0% /  | ew", Courier, monospace; line-height |
| auto repeat scroll padding-box borde | : 15.4px; margin: 0px; outline: rgb( |
| r-box rgb(255, 255, 255);">          | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| 6                                    | one; white-space: pre;"}`manager.dev |
|                                      | iceMotionUpdateInterval = 0.01`{styl |
| </div>                               | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
| <div                                 | t: normal; font-stretch: normal; fon |
| style="color: rgb(175, 175, 175); di | t-size: 14px; font-family: Consolas, |
| splay: block; font-style: normal; fo |  "Bitstream Vera Sans Mono", "Courie |
| nt-variant: normal; font-weight: nor | r New", Courier, monospace; line-hei |
| mal; font-stretch: normal; font-size | ght: 15.4px; margin: 0px; padding: 0 |
| : 14px; font-family: Consolas, &quot | px; text-align: left; text-decoratio |
| ;Bitstream Vera Sans Mono&quot;, &qu | n: none; white-space: pre;"}         |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | </div>                               |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | <div                                 |
|  0px 14px; text-align: right; text-d | style="border: 0px none rgb(37, 37,  |
| ecoration: none; white-space: pre; w | 37); color: rgb(37, 37, 37); display |
| idth: 8px; background: none 0% 0% /  | : block; font-style: normal; font-va |
| auto repeat scroll padding-box borde | riant: normal; font-weight: normal;  |
| r-box rgb(255, 255, 255);">          | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| 7                                    | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| </div>                               |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| <div                                 | ) none 0px; padding: 0px 14px; text- |
| style="color: rgb(175, 175, 175); di | align: left; text-decoration: none;  |
| splay: block; font-style: normal; fo | white-space: pre; width: 647px; back |
| nt-variant: normal; font-weight: nor | ground: none 0% 0% / auto repeat scr |
| mal; font-stretch: normal; font-size | oll padding-box border-box rgb(255,  |
| : 14px; font-family: Consolas, &quot | 255, 255);">                         |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | `    `{style="border: 0px none rgb(3 |
| pace; height: 15px; line-height: 15. | 7, 37, 37); color: rgb(37, 37, 37);  |
| 4px; margin: 0px; outline: rgb(175,  | display: inline; font-style: normal; |
| 175, 175) none 0px; padding: 0px 7px |  font-variant: normal; font-weight:  |
|  0px 14px; text-align: right; text-d | normal; font-stretch: normal; font-s |
| ecoration: none; white-space: pre; w | ize: 14px; font-family: Consolas, "B |
| idth: 8px; background: none 0% 0% /  | itstream Vera Sans Mono", "Courier N |
| auto repeat scroll padding-box borde | ew", Courier, monospace; line-height |
| r-box rgb(255, 255, 255);">          | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 8                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`manager.sta |
| </div>                               | rtDeviceMotionUpdatesToQueue(NSOpera |
|                                      | tionQueue.mainQueue()) {`{style="dis |
| <div                                 | play: inline; font-style: normal; fo |
| style="color: rgb(175, 175, 175); di | nt-variant: normal; font-weight: nor |
| splay: block; font-style: normal; fo | mal; font-stretch: normal; font-size |
| nt-variant: normal; font-weight: nor | : 14px; font-family: Consolas, "Bits |
| mal; font-stretch: normal; font-size | tream Vera Sans Mono", "Courier New" |
| : 14px; font-family: Consolas, &quot | , Courier, monospace; line-height: 1 |
| ;Bitstream Vera Sans Mono&quot;, &qu | 5.4px; margin: 0px; padding: 0px; te |
| ot;Courier New&quot;, Courier, monos | xt-align: left; text-decoration: non |
| pace; height: 15px; line-height: 15. | e; white-space: pre;"}               |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 8px; background: none 0% 0% /  | style="border: 0px none rgb(37, 37,  |
| auto repeat scroll padding-box borde | 37); color: rgb(37, 37, 37); display |
| r-box rgb(255, 255, 255);">          | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 9                                    | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`[weak s |
|                                      | elf] (data: CMDeviceMotionData!, err |
|                                      | or: NSError!) `{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}`in`{style="border: 0px  |
|                                      | none rgb(0, 102, 153); color: rgb(0, |
|                                      |  102, 153); display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: bold; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; out |
|                                      | line: rgb(0, 102, 153) none 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`let rot |
|                                      | ation = atan2(data.gravity.x, data.g |
|                                      | ravity.y) - M_PI`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`self?.i |
|                                      | mageView.transform = CGAffineTransfo |
|                                      | rmMakeRotation(CGFloat(rotation))`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 647px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 152px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 135px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 135px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 737 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 709px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Objective-C`{style="border: 0px n |
| r-box rgb(255, 255, 255);">          | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 709px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `RotationViewController * __weak wea |
| ;Bitstream Vera Sans Mono&quot;, &qu | kSelf = self;`{style="display: inlin |
| ot;Courier New&quot;, Courier, monos | e; font-style: normal; font-variant: |
| pace; height: 15px; line-height: 15. |  normal; font-weight: normal; font-s |
| 4px; margin: 0px; outline: rgb(175,  | tretch: normal; font-size: 14px; fon |
| 175, 175) none 0px; padding: 0px 7px | t-family: Consolas, "Bitstream Vera  |
|  0px 14px; text-align: right; text-d | Sans Mono", "Courier New", Courier,  |
| ecoration: none; white-space: pre; w | monospace; line-height: 15.4px; marg |
| idth: 8px; background: none 0% 0% /  | in: 0px; padding: 0px; text-align: l |
| auto repeat scroll padding-box borde | eft; text-decoration: none; white-sp |
| r-box rgb(255, 255, 255);">          | ace: pre;"}`if`{style="border: 0px n |
|                                      | one rgb(0, 102, 153); color: rgb(0,  |
| 4                                    | 102, 153); display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
| </div>                               | nt-weight: bold; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
| <div                                 | solas, "Bitstream Vera Sans Mono", " |
| style="color: rgb(175, 175, 175); di | Courier New", Courier, monospace; li |
| splay: block; font-style: normal; fo | ne-height: 15.4px; margin: 0px; outl |
| nt-variant: normal; font-weight: nor | ine: rgb(0, 102, 153) none 0px; padd |
| mal; font-stretch: normal; font-size | ing: 0px; text-align: left; text-dec |
| : 14px; font-family: Consolas, &quot | oration: none; white-space: pre;"} ` |
| ;Bitstream Vera Sans Mono&quot;, &qu | (manager.deviceMotionAvailable) {`{s |
| ot;Courier New&quot;, Courier, monos | tyle="display: inline; font-style: n |
| pace; height: 15px; line-height: 15. | ormal; font-variant: normal; font-we |
| 4px; margin: 0px; outline: rgb(175,  | ight: normal; font-stretch: normal;  |
| 175, 175) none 0px; padding: 0px 7px | font-size: 14px; font-family: Consol |
|  0px 14px; text-align: right; text-d | as, "Bitstream Vera Sans Mono", "Cou |
| ecoration: none; white-space: pre; w | rier New", Courier, monospace; line- |
| idth: 8px; background: none 0% 0% /  | height: 15.4px; margin: 0px; padding |
| auto repeat scroll padding-box borde | : 0px; text-align: left; text-decora |
| r-box rgb(255, 255, 255);">          | tion: none; white-space: pre;"}      |
|                                      |                                      |
| 5                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| <div                                 | 37); color: rgb(37, 37, 37); display |
| style="color: rgb(175, 175, 175); di | : block; font-style: normal; font-va |
| splay: block; font-style: normal; fo | riant: normal; font-weight: normal;  |
| nt-variant: normal; font-weight: nor | font-stretch: normal; font-size: 14p |
| mal; font-stretch: normal; font-size | x; font-family: Consolas, &quot;Bits |
| : 14px; font-family: Consolas, &quot | tream Vera Sans Mono&quot;, &quot;Co |
| ;Bitstream Vera Sans Mono&quot;, &qu | urier New&quot;, Courier, monospace; |
| ot;Courier New&quot;, Courier, monos |  height: 15px; line-height: 15.4px;  |
| pace; height: 15px; line-height: 15. | margin: 0px; outline: rgb(37, 37, 37 |
| 4px; margin: 0px; outline: rgb(175,  | ) none 0px; padding: 0px 14px; text- |
| 175, 175) none 0px; padding: 0px 7px | align: left; text-decoration: none;  |
|  0px 14px; text-align: right; text-d | white-space: pre; width: 709px; back |
| ecoration: none; white-space: pre; w | ground: none 0% 0% / auto repeat scr |
| idth: 8px; background: none 0% 0% /  | oll padding-box border-box rgb(255,  |
| auto repeat scroll padding-box borde | 255, 255);">                         |
| r-box rgb(255, 255, 255);">          |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
| 6                                    | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
| </div>                               |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| <div                                 | ize: 14px; font-family: Consolas, "B |
| style="color: rgb(175, 175, 175); di | itstream Vera Sans Mono", "Courier N |
| splay: block; font-style: normal; fo | ew", Courier, monospace; line-height |
| nt-variant: normal; font-weight: nor | : 15.4px; margin: 0px; outline: rgb( |
| mal; font-stretch: normal; font-size | 37, 37, 37) none 0px; padding: 0px;  |
| : 14px; font-family: Consolas, &quot | text-align: left; text-decoration: n |
| ;Bitstream Vera Sans Mono&quot;, &qu | one; white-space: pre;"}`manager.dev |
| ot;Courier New&quot;, Courier, monos | iceMotionUpdateInterval = 0.01f;`{st |
| pace; height: 15px; line-height: 15. | yle="display: inline; font-style: no |
| 4px; margin: 0px; outline: rgb(175,  | rmal; font-variant: normal; font-wei |
| 175, 175) none 0px; padding: 0px 7px | ght: normal; font-stretch: normal; f |
|  0px 14px; text-align: right; text-d | ont-size: 14px; font-family: Consola |
| ecoration: none; white-space: pre; w | s, "Bitstream Vera Sans Mono", "Cour |
| idth: 8px; background: none 0% 0% /  | ier New", Courier, monospace; line-h |
| auto repeat scroll padding-box borde | eight: 15.4px; margin: 0px; padding: |
| r-box rgb(255, 255, 255);">          |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
| 7                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="border: 0px none rgb(37, 37,  |
| style="color: rgb(175, 175, 175); di | 37); color: rgb(37, 37, 37); display |
| splay: block; font-style: normal; fo | : block; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: normal;  |
| mal; font-stretch: normal; font-size | font-stretch: normal; font-size: 14p |
| : 14px; font-family: Consolas, &quot | x; font-family: Consolas, &quot;Bits |
| ;Bitstream Vera Sans Mono&quot;, &qu | tream Vera Sans Mono&quot;, &quot;Co |
| ot;Courier New&quot;, Courier, monos | urier New&quot;, Courier, monospace; |
| pace; height: 15px; line-height: 15. |  height: 15px; line-height: 15.4px;  |
| 4px; margin: 0px; outline: rgb(175,  | margin: 0px; outline: rgb(37, 37, 37 |
| 175, 175) none 0px; padding: 0px 7px | ) none 0px; padding: 0px 14px; text- |
|  0px 14px; text-align: right; text-d | align: left; text-decoration: none;  |
| ecoration: none; white-space: pre; w | white-space: pre; width: 709px; back |
| idth: 8px; background: none 0% 0% /  | ground: none 0% 0% / auto repeat scr |
| auto repeat scroll padding-box borde | oll padding-box border-box rgb(255,  |
| r-box rgb(255, 255, 255);">          | 255, 255);">                         |
|                                      |                                      |
| 8                                    | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
| </div>                               | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| <div                                 | normal; font-stretch: normal; font-s |
| style="color: rgb(175, 175, 175); di | ize: 14px; font-family: Consolas, "B |
| splay: block; font-style: normal; fo | itstream Vera Sans Mono", "Courier N |
| nt-variant: normal; font-weight: nor | ew", Courier, monospace; line-height |
| mal; font-stretch: normal; font-size | : 15.4px; margin: 0px; outline: rgb( |
| : 14px; font-family: Consolas, &quot | 37, 37, 37) none 0px; padding: 0px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | text-align: left; text-decoration: n |
| ot;Courier New&quot;, Courier, monos | one; white-space: pre;"}`[manager st |
| pace; height: 15px; line-height: 15. | artDeviceMotionUpdatesToQueue:[NSOpe |
| 4px; margin: 0px; outline: rgb(175,  | rationQueue mainQueue]`{style="displ |
| 175, 175) none 0px; padding: 0px 7px | ay: inline; font-style: normal; font |
|  0px 14px; text-align: right; text-d | -variant: normal; font-weight: norma |
| ecoration: none; white-space: pre; w | l; font-stretch: normal; font-size:  |
| idth: 8px; background: none 0% 0% /  | 14px; font-family: Consolas, "Bitstr |
| auto repeat scroll padding-box borde | eam Vera Sans Mono", "Courier New",  |
| r-box rgb(255, 255, 255);">          | Courier, monospace; line-height: 15. |
|                                      | 4px; margin: 0px; padding: 0px; text |
| 9                                    | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}                 |
| </div>                               |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `                                    |
|                                      |     `{style="border: 0px none rgb(37 |
|                                      | , 37, 37); color: rgb(37, 37, 37); d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; outline: rgb(3 |
|                                      | 7, 37, 37) none 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`withHandler: |
|                                      | ^(CMDeviceMotion *data, NSError *err |
|                                      | or) {`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`double  |
|                                      | rotation = atan2(data.gravity.x, dat |
|                                      | a.gravity.y) - M_PI;`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`weakSel |
|                                      | f.imageView.transform = CGAffineTran |
|                                      | sformMakeRotation(rotation);`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

来看看效果，会好得多：

![gravity.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740417191073.gif "1414740417191073.gif")

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**UIClunkController敲击反应**</span>

我们来试试别的，使用陀螺仪和加速器复合数据中的非重力部分来新添加一种交互方式。在这个示例中我们使用了CMDeviceMotionData中的userAcceleration属性，当用户将设备的左边缘敲击手掌的时候实现导航返回功能。

记住手中设备的X轴是穿过设备侧面的，并且向左为负值。假如设备感应到用户施加了一个向左大于2.5G的加速度，就会引发从栈堆中取出一个视图控制器界面。在这里比起前面的代码实现起来只用修改几行：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 150px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 150px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 150px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 16px; background: none 0% 0% / | ight: 0px; text-align: left; text-de |
|  auto repeat scroll padding-box bord | coration: none; top: 0px; width: 663 |
| er-box rgb(255, 255, 255);">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 635px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `//Swift`{style="border: 0px none rg |
| er-box rgb(255, 255, 255);">         | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 635px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `if`{style="border: 0px none rgb(0,  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 102, 153); color: rgb(0, 102, 153);  |
| ot;Courier New&quot;, Courier, monos | display: inline; font-style: normal; |
| pace; height: 15px; line-height: 15. |  font-variant: normal; font-weight:  |
| 4px; margin: 0px; outline: rgb(175,  | bold; font-stretch: normal; font-siz |
| 175, 175) none 0px; padding: 0px 7px | e: 14px; font-family: Consolas, "Bit |
|  0px 14px; text-align: right; text-d | stream Vera Sans Mono", "Courier New |
| ecoration: none; white-space: pre; w | ", Courier, monospace; line-height:  |
| idth: 16px; background: none 0% 0% / | 15.4px; margin: 0px; outline: rgb(0, |
|  auto repeat scroll padding-box bord |  102, 153) none 0px; padding: 0px; t |
| er-box rgb(255, 255, 255);">         | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"} `manager.dev |
| 4                                    | iceMotionAvailable {`{style="display |
|                                      | : inline; font-style: normal; font-v |
| </div>                               | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
| <div                                 | px; font-family: Consolas, "Bitstrea |
| style="color: rgb(175, 175, 175); di | m Vera Sans Mono", "Courier New", Co |
| splay: block; font-style: normal; fo | urier, monospace; line-height: 15.4p |
| nt-variant: normal; font-weight: nor | x; margin: 0px; padding: 0px; text-a |
| mal; font-stretch: normal; font-size | lign: left; text-decoration: none; w |
| : 14px; font-family: Consolas, &quot | hite-space: pre;"}                   |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | </div>                               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | <div                                 |
| 175, 175) none 0px; padding: 0px 7px | style="border: 0px none rgb(37, 37,  |
|  0px 14px; text-align: right; text-d | 37); color: rgb(37, 37, 37); display |
| ecoration: none; white-space: pre; w | : block; font-style: normal; font-va |
| idth: 16px; background: none 0% 0% / | riant: normal; font-weight: normal;  |
|  auto repeat scroll padding-box bord | font-stretch: normal; font-size: 14p |
| er-box rgb(255, 255, 255);">         | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| 5                                    | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| </div>                               | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
| <div                                 | align: left; text-decoration: none;  |
| style="color: rgb(175, 175, 175); di | white-space: pre; width: 635px; back |
| splay: block; font-style: normal; fo | ground: none 0% 0% / auto repeat scr |
| nt-variant: normal; font-weight: nor | oll padding-box border-box rgb(255,  |
| mal; font-stretch: normal; font-size | 255, 255);">                         |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | `    `{style="border: 0px none rgb(3 |
| ot;Courier New&quot;, Courier, monos | 7, 37, 37); color: rgb(37, 37, 37);  |
| pace; height: 15px; line-height: 15. | display: inline; font-style: normal; |
| 4px; margin: 0px; outline: rgb(175,  |  font-variant: normal; font-weight:  |
| 175, 175) none 0px; padding: 0px 7px | normal; font-stretch: normal; font-s |
|  0px 14px; text-align: right; text-d | ize: 14px; font-family: Consolas, "B |
| ecoration: none; white-space: pre; w | itstream Vera Sans Mono", "Courier N |
| idth: 16px; background: none 0% 0% / | ew", Courier, monospace; line-height |
|  auto repeat scroll padding-box bord | : 15.4px; margin: 0px; outline: rgb( |
| er-box rgb(255, 255, 255);">         | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| 6                                    | one; white-space: pre;"}`manager.dev |
|                                      | iceMotionUpdateInterval = 0.02`{styl |
| </div>                               | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
| <div                                 | t: normal; font-stretch: normal; fon |
| style="color: rgb(175, 175, 175); di | t-size: 14px; font-family: Consolas, |
| splay: block; font-style: normal; fo |  "Bitstream Vera Sans Mono", "Courie |
| nt-variant: normal; font-weight: nor | r New", Courier, monospace; line-hei |
| mal; font-stretch: normal; font-size | ght: 15.4px; margin: 0px; padding: 0 |
| : 14px; font-family: Consolas, &quot | px; text-align: left; text-decoratio |
| ;Bitstream Vera Sans Mono&quot;, &qu | n: none; white-space: pre;"}         |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | </div>                               |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | <div                                 |
|  0px 14px; text-align: right; text-d | style="border: 0px none rgb(37, 37,  |
| ecoration: none; white-space: pre; w | 37); color: rgb(37, 37, 37); display |
| idth: 16px; background: none 0% 0% / | : block; font-style: normal; font-va |
|  auto repeat scroll padding-box bord | riant: normal; font-weight: normal;  |
| er-box rgb(255, 255, 255);">         | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| 7                                    | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| </div>                               |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| <div                                 | ) none 0px; padding: 0px 14px; text- |
| style="color: rgb(175, 175, 175); di | align: left; text-decoration: none;  |
| splay: block; font-style: normal; fo | white-space: pre; width: 635px; back |
| nt-variant: normal; font-weight: nor | ground: none 0% 0% / auto repeat scr |
| mal; font-stretch: normal; font-size | oll padding-box border-box rgb(255,  |
| : 14px; font-family: Consolas, &quot | 255, 255);">                         |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | `    `{style="border: 0px none rgb(3 |
| pace; height: 15px; line-height: 15. | 7, 37, 37); color: rgb(37, 37, 37);  |
| 4px; margin: 0px; outline: rgb(175,  | display: inline; font-style: normal; |
| 175, 175) none 0px; padding: 0px 7px |  font-variant: normal; font-weight:  |
|  0px 14px; text-align: right; text-d | normal; font-stretch: normal; font-s |
| ecoration: none; white-space: pre; w | ize: 14px; font-family: Consolas, "B |
| idth: 16px; background: none 0% 0% / | itstream Vera Sans Mono", "Courier N |
|  auto repeat scroll padding-box bord | ew", Courier, monospace; line-height |
| er-box rgb(255, 255, 255);">         | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 8                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`manager.sta |
| </div>                               | rtDeviceMotionUpdatesToQueue(NSOpera |
|                                      | tionQueue.mainQueue()) {`{style="dis |
| <div                                 | play: inline; font-style: normal; fo |
| style="color: rgb(175, 175, 175); di | nt-variant: normal; font-weight: nor |
| splay: block; font-style: normal; fo | mal; font-stretch: normal; font-size |
| nt-variant: normal; font-weight: nor | : 14px; font-family: Consolas, "Bits |
| mal; font-stretch: normal; font-size | tream Vera Sans Mono", "Courier New" |
| : 14px; font-family: Consolas, &quot | , Courier, monospace; line-height: 1 |
| ;Bitstream Vera Sans Mono&quot;, &qu | 5.4px; margin: 0px; padding: 0px; te |
| ot;Courier New&quot;, Courier, monos | xt-align: left; text-decoration: non |
| pace; height: 15px; line-height: 15. | e; white-space: pre;"}               |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 16px; background: none 0% 0% / | style="border: 0px none rgb(37, 37,  |
|  auto repeat scroll padding-box bord | 37); color: rgb(37, 37, 37); display |
| er-box rgb(255, 255, 255);">         | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 9                                    | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| <div                                 |  height: 15px; line-height: 15.4px;  |
| style="color: rgb(175, 175, 175); di | margin: 0px; outline: rgb(37, 37, 37 |
| splay: block; font-style: normal; fo | ) none 0px; padding: 0px 14px; text- |
| nt-variant: normal; font-weight: nor | align: left; text-decoration: none;  |
| mal; font-stretch: normal; font-size | white-space: pre; width: 635px; back |
| : 14px; font-family: Consolas, &quot | ground: none 0% 0% / auto repeat scr |
| ;Bitstream Vera Sans Mono&quot;, &qu | oll padding-box border-box rgb(255,  |
| ot;Courier New&quot;, Courier, monos | 255, 255);">                         |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | `        `{style="border: 0px none r |
| 175, 175) none 0px; padding: 0px 7px | gb(37, 37, 37); color: rgb(37, 37, 3 |
|  0px 14px; text-align: right; text-d | 7); display: inline; font-style: nor |
| ecoration: none; white-space: pre; w | mal; font-variant: normal; font-weig |
| idth: 16px; background: none 0% 0% / | ht: normal; font-stretch: normal; fo |
|  auto repeat scroll padding-box bord | nt-size: 14px; font-family: Consolas |
| er-box rgb(255, 255, 255);">         | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
| 10                                   | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
| </div>                               | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`[weak s |
|                                      | elf] (data: CMDeviceMotion!, error:  |
|                                      | NSError!) `{style="display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}`in`{style="border: 0px none |
|                                      |  rgb(0, 102, 153); color: rgb(0, 102 |
|                                      | , 153); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: bold; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; outline |
|                                      | : rgb(0, 102, 153) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 635px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`if`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `data.userAccelerati |
|                                      | on.x < -2.5 {`{style="display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 635px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`sel |
|                                      | f?.navigationController?.popViewCont |
|                                      | rollerAnimated(`{style="display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; padding: 0px; text-align: |
|                                      |  left; text-decoration: none; white- |
|                                      | space: pre;"}`true`{style="border: 0 |
|                                      | px none rgb(0, 102, 153); color: rgb |
|                                      | (0, 102, 153); display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: bold; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | outline: rgb(0, 102, 153) none 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}`)`{style="display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}                                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 635px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 635px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 635px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 167px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 150px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 150px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 16px; background: none 0% 0% / | ight: 0px; text-align: left; text-de |
|  auto repeat scroll padding-box bord | coration: none; top: 0px; width: 737 |
| er-box rgb(255, 255, 255);">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 709px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `//Objective-C`{style="border: 0px n |
| er-box rgb(255, 255, 255);">         | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 709px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `ClunkViewController * __weak weakSe |
| ;Bitstream Vera Sans Mono&quot;, &qu | lf = self;`{style="display: inline;  |
| ot;Courier New&quot;, Courier, monos | font-style: normal; font-variant: no |
| pace; height: 15px; line-height: 15. | rmal; font-weight: normal; font-stre |
| 4px; margin: 0px; outline: rgb(175,  | tch: normal; font-size: 14px; font-f |
| 175, 175) none 0px; padding: 0px 7px | amily: Consolas, "Bitstream Vera San |
|  0px 14px; text-align: right; text-d | s Mono", "Courier New", Courier, mon |
| ecoration: none; white-space: pre; w | ospace; line-height: 15.4px; margin: |
| idth: 16px; background: none 0% 0% / |  0px; padding: 0px; text-align: left |
|  auto repeat scroll padding-box bord | ; text-decoration: none; white-space |
| er-box rgb(255, 255, 255);">         | : pre;"}`if`{style="border: 0px none |
|                                      |  rgb(0, 102, 153); color: rgb(0, 102 |
| 4                                    | , 153); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
| </div>                               | weight: bold; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
| <div                                 | as, "Bitstream Vera Sans Mono", "Cou |
| style="color: rgb(175, 175, 175); di | rier New", Courier, monospace; line- |
| splay: block; font-style: normal; fo | height: 15.4px; margin: 0px; outline |
| nt-variant: normal; font-weight: nor | : rgb(0, 102, 153) none 0px; padding |
| mal; font-stretch: normal; font-size | : 0px; text-align: left; text-decora |
| : 14px; font-family: Consolas, &quot | tion: none; white-space: pre;"} `(ma |
| ;Bitstream Vera Sans Mono&quot;, &qu | nager.deviceMotionAvailable) {`{styl |
| ot;Courier New&quot;, Courier, monos | e="display: inline; font-style: norm |
| pace; height: 15px; line-height: 15. | al; font-variant: normal; font-weigh |
| 4px; margin: 0px; outline: rgb(175,  | t: normal; font-stretch: normal; fon |
| 175, 175) none 0px; padding: 0px 7px | t-size: 14px; font-family: Consolas, |
|  0px 14px; text-align: right; text-d |  "Bitstream Vera Sans Mono", "Courie |
| ecoration: none; white-space: pre; w | r New", Courier, monospace; line-hei |
| idth: 16px; background: none 0% 0% / | ght: 15.4px; margin: 0px; padding: 0 |
|  auto repeat scroll padding-box bord | px; text-align: left; text-decoratio |
| er-box rgb(255, 255, 255);">         | n: none; white-space: pre;"}         |
|                                      |                                      |
| 5                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| <div                                 | 37); color: rgb(37, 37, 37); display |
| style="color: rgb(175, 175, 175); di | : block; font-style: normal; font-va |
| splay: block; font-style: normal; fo | riant: normal; font-weight: normal;  |
| nt-variant: normal; font-weight: nor | font-stretch: normal; font-size: 14p |
| mal; font-stretch: normal; font-size | x; font-family: Consolas, &quot;Bits |
| : 14px; font-family: Consolas, &quot | tream Vera Sans Mono&quot;, &quot;Co |
| ;Bitstream Vera Sans Mono&quot;, &qu | urier New&quot;, Courier, monospace; |
| ot;Courier New&quot;, Courier, monos |  height: 15px; line-height: 15.4px;  |
| pace; height: 15px; line-height: 15. | margin: 0px; outline: rgb(37, 37, 37 |
| 4px; margin: 0px; outline: rgb(175,  | ) none 0px; padding: 0px 14px; text- |
| 175, 175) none 0px; padding: 0px 7px | align: left; text-decoration: none;  |
|  0px 14px; text-align: right; text-d | white-space: pre; width: 709px; back |
| ecoration: none; white-space: pre; w | ground: none 0% 0% / auto repeat scr |
| idth: 16px; background: none 0% 0% / | oll padding-box border-box rgb(255,  |
|  auto repeat scroll padding-box bord | 255, 255);">                         |
| er-box rgb(255, 255, 255);">         |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
| 6                                    | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
| </div>                               |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| <div                                 | ize: 14px; font-family: Consolas, "B |
| style="color: rgb(175, 175, 175); di | itstream Vera Sans Mono", "Courier N |
| splay: block; font-style: normal; fo | ew", Courier, monospace; line-height |
| nt-variant: normal; font-weight: nor | : 15.4px; margin: 0px; outline: rgb( |
| mal; font-stretch: normal; font-size | 37, 37, 37) none 0px; padding: 0px;  |
| : 14px; font-family: Consolas, &quot | text-align: left; text-decoration: n |
| ;Bitstream Vera Sans Mono&quot;, &qu | one; white-space: pre;"}`manager.dev |
| ot;Courier New&quot;, Courier, monos | iceMotionUpdateInterval = 0.01f;`{st |
| pace; height: 15px; line-height: 15. | yle="display: inline; font-style: no |
| 4px; margin: 0px; outline: rgb(175,  | rmal; font-variant: normal; font-wei |
| 175, 175) none 0px; padding: 0px 7px | ght: normal; font-stretch: normal; f |
|  0px 14px; text-align: right; text-d | ont-size: 14px; font-family: Consola |
| ecoration: none; white-space: pre; w | s, "Bitstream Vera Sans Mono", "Cour |
| idth: 16px; background: none 0% 0% / | ier New", Courier, monospace; line-h |
|  auto repeat scroll padding-box bord | eight: 15.4px; margin: 0px; padding: |
| er-box rgb(255, 255, 255);">         |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
| 7                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="border: 0px none rgb(37, 37,  |
| style="color: rgb(175, 175, 175); di | 37); color: rgb(37, 37, 37); display |
| splay: block; font-style: normal; fo | : block; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: normal;  |
| mal; font-stretch: normal; font-size | font-stretch: normal; font-size: 14p |
| : 14px; font-family: Consolas, &quot | x; font-family: Consolas, &quot;Bits |
| ;Bitstream Vera Sans Mono&quot;, &qu | tream Vera Sans Mono&quot;, &quot;Co |
| ot;Courier New&quot;, Courier, monos | urier New&quot;, Courier, monospace; |
| pace; height: 15px; line-height: 15. |  height: 15px; line-height: 15.4px;  |
| 4px; margin: 0px; outline: rgb(175,  | margin: 0px; outline: rgb(37, 37, 37 |
| 175, 175) none 0px; padding: 0px 7px | ) none 0px; padding: 0px 14px; text- |
|  0px 14px; text-align: right; text-d | align: left; text-decoration: none;  |
| ecoration: none; white-space: pre; w | white-space: pre; width: 709px; back |
| idth: 16px; background: none 0% 0% / | ground: none 0% 0% / auto repeat scr |
|  auto repeat scroll padding-box bord | oll padding-box border-box rgb(255,  |
| er-box rgb(255, 255, 255);">         | 255, 255);">                         |
|                                      |                                      |
| 8                                    | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
| </div>                               | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| <div                                 | normal; font-stretch: normal; font-s |
| style="color: rgb(175, 175, 175); di | ize: 14px; font-family: Consolas, "B |
| splay: block; font-style: normal; fo | itstream Vera Sans Mono", "Courier N |
| nt-variant: normal; font-weight: nor | ew", Courier, monospace; line-height |
| mal; font-stretch: normal; font-size | : 15.4px; margin: 0px; outline: rgb( |
| : 14px; font-family: Consolas, &quot | 37, 37, 37) none 0px; padding: 0px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | text-align: left; text-decoration: n |
| ot;Courier New&quot;, Courier, monos | one; white-space: pre;"}`[manager st |
| pace; height: 15px; line-height: 15. | artDeviceMotionUpdatesToQueue:[NSOpe |
| 4px; margin: 0px; outline: rgb(175,  | rationQueue mainQueue]`{style="displ |
| 175, 175) none 0px; padding: 0px 7px | ay: inline; font-style: normal; font |
|  0px 14px; text-align: right; text-d | -variant: normal; font-weight: norma |
| ecoration: none; white-space: pre; w | l; font-stretch: normal; font-size:  |
| idth: 16px; background: none 0% 0% / | 14px; font-family: Consolas, "Bitstr |
|  auto repeat scroll padding-box bord | eam Vera Sans Mono", "Courier New",  |
| er-box rgb(255, 255, 255);">         | Courier, monospace; line-height: 15. |
|                                      | 4px; margin: 0px; padding: 0px; text |
| 9                                    | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}                 |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="color: rgb(175, 175, 175); di | <div                                 |
| splay: block; font-style: normal; fo | style="border: 0px none rgb(37, 37,  |
| nt-variant: normal; font-weight: nor | 37); color: rgb(37, 37, 37); display |
| mal; font-stretch: normal; font-size | : block; font-style: normal; font-va |
| : 14px; font-family: Consolas, &quot | riant: normal; font-weight: normal;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | font-stretch: normal; font-size: 14p |
| ot;Courier New&quot;, Courier, monos | x; font-family: Consolas, &quot;Bits |
| pace; height: 15px; line-height: 15. | tream Vera Sans Mono&quot;, &quot;Co |
| 4px; margin: 0px; outline: rgb(175,  | urier New&quot;, Courier, monospace; |
| 175, 175) none 0px; padding: 0px 7px |  height: 15px; line-height: 15.4px;  |
|  0px 14px; text-align: right; text-d | margin: 0px; outline: rgb(37, 37, 37 |
| ecoration: none; white-space: pre; w | ) none 0px; padding: 0px 14px; text- |
| idth: 16px; background: none 0% 0% / | align: left; text-decoration: none;  |
|  auto repeat scroll padding-box bord | white-space: pre; width: 709px; back |
| er-box rgb(255, 255, 255);">         | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
| 10                                   | 255, 255);">                         |
|                                      |                                      |
| </div>                               | `                                    |
|                                      |     `{style="border: 0px none rgb(37 |
|                                      | , 37, 37); color: rgb(37, 37, 37); d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; outline: rgb(3 |
|                                      | 7, 37, 37) none 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`withHandler: |
|                                      | ^(CMDeviceMotion *data, NSError *err |
|                                      | or) {`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`if`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `(data.userAccelerat |
|                                      | ion.x < -2.5f) {`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`[we |
|                                      | akSelf.navigationController popViewC |
|                                      | ontrollerAnimated:YES];`{style="disp |
|                                      | lay: inline; font-style: normal; fon |
|                                      | t-variant: normal; font-weight: norm |
|                                      | al; font-stretch: normal; font-size: |
|                                      |  14px; font-family: Consolas, "Bitst |
|                                      | ream Vera Sans Mono", "Courier New", |
|                                      |  Courier, monospace; line-height: 15 |
|                                      | .4px; margin: 0px; padding: 0px; tex |
|                                      | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 709px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

即刻见效：

![s.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740568323269.gif "1414740568323269.gif")

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**获取Attitude**</span>

我们可以通过使用陀螺仪的数据来获取更好的加速度数据，但是这并非唯一可用的改进——我们还可以获取设备在空间中的具体方位。在CMDeviceMotionData中有一个attitude属性，是一个CMAttitude类的实例。其中用了三种不同的方式表示了设备的方位：欧拉角，四元数和旋转矩阵，每一个都参考给定的坐标系。

**找到参考坐标系**

你可以设想一个根据设备某个方向来计算其他剩余角度的参考系，下面四中可用的参考系都假设设备平放在平面上，然后按照其指定的方向增加角度。

*CMAttitudeReferenceFrameXArbitraryZVertical*
描述的参考系默认设备平放(垂直于Z轴)，在X轴上取任意值。实际上当你开始刚开始对设备进行motion更新的时候X轴就被固定了。

*CMAttitudeReferenceFrameXArbitraryCorrectedZVertical*
本质上和上一个一样，不过这里还使用了罗盘来对陀螺仪的测量数据做了误差修正，当然对于CPU来说会增加一定的消耗(对电池也一样)。

*CMAttitudeReferenceFrameXMagneticNorthZVertical*
同样是默认设备平放，然后X轴(也就是设备的右侧)指向地磁北向。这一设置需要在使用前用设备画"8"字来校正罗盘。

*CMAttitudeReferenceFrameXTrueNorthZVertical*
和上面一个一样，不过这里参考的是真实的地磁北极，因此会需要使用位置数据和和罗盘。

对于我们想要实现的情况，默认的任意值参考系已经够用——一会儿你就知道为什么了。

**欧拉角**

三种表示方式中欧拉角是最容易理解的，它简单的描述了绕各坐标轴旋转的角度，这些坐标轴我们之前已经提到过。pitch是指绕X轴旋转，考虑设备平放，pitch增加则设备正面倾斜抬起，减小则后仰。roll是Y轴方向，增加则设备往右滚动，减少则往左。yaw是Z轴方向，逆时针方向增加，顺时针方向减少。

下述的这些值都是参考右手定则：右手虚握，大拇指竖起朝向任意轴的正方向，顺着剩余四指旋转方向为正，逆向为负。

**功能的实现**

现在我们来做一个你问我答形式的App界面，当屏幕旋转到面对被试者时只显示提示内容，而面对提问者的时候会自动切换到显示答案的界面。

根据参考系来计算切换会很麻烦，我们需要考虑设备的初始位置，然后才能定义设备正指向哪个方向，以及旋转到那一个角度才会被反过来。所以我们要用的方法是将一个CMAttitude实例保存起来，并以它算出一个欧拉角作为原点，之后所有的旋转都用multiplyByInverseOfAttitude()方法来换算方向。

当提问者点击按钮开始提问的时候我们就开始了交互过程——注意这里deviceMotion为initialAttitude使用到了"pull"方式。

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 137px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 120px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 914 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 886px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Swift`{style="border: 0px none rg |
| r-box rgb(255, 255, 255);">          | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 886px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `// get magnitude of vector via Pyth |
| ;Bitstream Vera Sans Mono&quot;, &qu | agorean theorem`{style="border: 0px  |
| ot;Courier New&quot;, Courier, monos | none rgb(0, 130, 0); color: rgb(0, 1 |
| pace; height: 15px; line-height: 15. | 30, 0); display: inline; font-style: |
| 4px; margin: 0px; outline: rgb(175,  |  normal; font-variant: normal; font- |
| 175, 175) none 0px; padding: 0px 7px | weight: normal; font-stretch: normal |
|  0px 14px; text-align: right; text-d | ; font-size: 14px; font-family: Cons |
| ecoration: none; white-space: pre; w | olas, "Bitstream Vera Sans Mono", "C |
| idth: 8px; background: none 0% 0% /  | ourier New", Courier, monospace; lin |
| auto repeat scroll padding-box borde | e-height: 15.4px; margin: 0px; outli |
| r-box rgb(255, 255, 255);">          | ne: rgb(0, 130, 0) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
| 4                                    | tion: none; white-space: pre;"}      |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); color: rgb(37, 37, 37); display |
| nt-variant: normal; font-weight: nor | : block; font-style: normal; font-va |
| mal; font-stretch: normal; font-size | riant: normal; font-weight: normal;  |
| : 14px; font-family: Consolas, &quot | font-stretch: normal; font-size: 14p |
| ;Bitstream Vera Sans Mono&quot;, &qu | x; font-family: Consolas, &quot;Bits |
| ot;Courier New&quot;, Courier, monos | tream Vera Sans Mono&quot;, &quot;Co |
| pace; height: 15px; line-height: 15. | urier New&quot;, Courier, monospace; |
| 4px; margin: 0px; outline: rgb(175,  |  height: 15px; line-height: 15.4px;  |
| 175, 175) none 0px; padding: 0px 7px | margin: 0px; outline: rgb(37, 37, 37 |
|  0px 14px; text-align: right; text-d | ) none 0px; padding: 0px 14px; text- |
| ecoration: none; white-space: pre; w | align: left; text-decoration: none;  |
| idth: 8px; background: none 0% 0% /  | white-space: pre; width: 886px; back |
| auto repeat scroll padding-box borde | ground: none 0% 0% / auto repeat scr |
| r-box rgb(255, 255, 255);">          | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
| 5                                    |                                      |
|                                      | `func magnitudeFromAttitude(attitude |
| </div>                               | : CMAttitude) -> Double {`{style="di |
|                                      | splay: inline; font-style: normal; f |
| <div                                 | ont-variant: normal; font-weight: no |
| style="color: rgb(175, 175, 175); di | rmal; font-stretch: normal; font-siz |
| splay: block; font-style: normal; fo | e: 14px; font-family: Consolas, "Bit |
| nt-variant: normal; font-weight: nor | stream Vera Sans Mono", "Courier New |
| mal; font-stretch: normal; font-size | ", Courier, monospace; line-height:  |
| : 14px; font-family: Consolas, &quot | 15.4px; margin: 0px; padding: 0px; t |
| ;Bitstream Vera Sans Mono&quot;, &qu | ext-align: left; text-decoration: no |
| ot;Courier New&quot;, Courier, monos | ne; white-space: pre;"}              |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | </div>                               |
| 175, 175) none 0px; padding: 0px 7px |                                      |
|  0px 14px; text-align: right; text-d | <div                                 |
| ecoration: none; white-space: pre; w | style="border: 0px none rgb(37, 37,  |
| idth: 8px; background: none 0% 0% /  | 37); color: rgb(37, 37, 37); display |
| auto repeat scroll padding-box borde | : block; font-style: normal; font-va |
| r-box rgb(255, 255, 255);">          | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
| 6                                    | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| </div>                               | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| <div                                 | margin: 0px; outline: rgb(37, 37, 37 |
| style="color: rgb(175, 175, 175); di | ) none 0px; padding: 0px 14px; text- |
| splay: block; font-style: normal; fo | align: left; text-decoration: none;  |
| nt-variant: normal; font-weight: nor | white-space: pre; width: 886px; back |
| mal; font-stretch: normal; font-size | ground: none 0% 0% / auto repeat scr |
| : 14px; font-family: Consolas, &quot | oll padding-box border-box rgb(255,  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 255, 255);">                         |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | `    `{style="border: 0px none rgb(3 |
| 4px; margin: 0px; outline: rgb(175,  | 7, 37, 37); color: rgb(37, 37, 37);  |
| 175, 175) none 0px; padding: 0px 7px | display: inline; font-style: normal; |
|  0px 14px; text-align: right; text-d |  font-variant: normal; font-weight:  |
| ecoration: none; white-space: pre; w | normal; font-stretch: normal; font-s |
| idth: 8px; background: none 0% 0% /  | ize: 14px; font-family: Consolas, "B |
| auto repeat scroll padding-box borde | itstream Vera Sans Mono", "Courier N |
| r-box rgb(255, 255, 255);">          | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
| 7                                    | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| </div>                               | one; white-space: pre;"}`return`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
| <div                                 | ); color: rgb(0, 102, 153); display: |
| style="color: rgb(175, 175, 175); di |  inline; font-style: normal; font-va |
| splay: block; font-style: normal; fo | riant: normal; font-weight: bold; fo |
| nt-variant: normal; font-weight: nor | nt-stretch: normal; font-size: 14px; |
| mal; font-stretch: normal; font-size |  font-family: Consolas, "Bitstream V |
| : 14px; font-family: Consolas, &quot | era Sans Mono", "Courier New", Couri |
| ;Bitstream Vera Sans Mono&quot;, &qu | er, monospace; line-height: 15.4px;  |
| ot;Courier New&quot;, Courier, monos | margin: 0px; outline: rgb(0, 102, 15 |
| pace; height: 15px; line-height: 15. | 3) none 0px; padding: 0px; text-alig |
| 4px; margin: 0px; outline: rgb(175,  | n: left; text-decoration: none; whit |
| 175, 175) none 0px; padding: 0px 7px | e-space: pre;"} `sqrt(pow(attitude.r |
|  0px 14px; text-align: right; text-d | oll, 2) + pow(attitude.yaw, 2) + pow |
| ecoration: none; white-space: pre; w | (attitude.pitch, 2))}`{style="displa |
| idth: 8px; background: none 0% 0% /  | y: inline; font-style: normal; font- |
| auto repeat scroll padding-box borde | variant: normal; font-weight: normal |
| r-box rgb(255, 255, 255);">          | ; font-stretch: normal; font-size: 1 |
|                                      | 4px; font-family: Consolas, "Bitstre |
| 8                                    | am Vera Sans Mono", "Courier New", C |
|                                      | ourier, monospace; line-height: 15.4 |
| </div>                               | px; margin: 0px; padding: 0px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre;"}`// initial confi |
|                                      | gurationvar `{style="border: 0px non |
|                                      | e rgb(0, 130, 0); color: rgb(0, 130, |
|                                      |  0); display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(0, 130, 0) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 886px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `initialAttitude = manager.deviceMot |
|                                      | ion.attitude`{style="display: inline |
|                                      | ; font-style: normal; font-variant:  |
|                                      | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
|                                      | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
|                                      | onospace; line-height: 15.4px; margi |
|                                      | n: 0px; padding: 0px; text-align: le |
|                                      | ft; text-decoration: none; white-spa |
|                                      | ce: pre;"}                           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 886px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `var`{style="border: 0px none rgb(0, |
|                                      |  102, 153); color: rgb(0, 102, 153); |
|                                      |  display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  bold; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; outline: rgb(0 |
|                                      | , 102, 153) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"} `showingPro |
|                                      | mpt = `{style="display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}`false`{style="border: 0px none  |
|                                      | rgb(0, 102, 153); color: rgb(0, 102, |
|                                      |  153); display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: bold; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(0, 102, 153) none 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`// tr |
|                                      | igger values - a gap so there isn't  |
|                                      | a flicker zone`{style="border: 0px n |
|                                      | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; outlin |
|                                      | e: rgb(0, 130, 0) none 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 886px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `let showPromptTrigger = 1.0`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 886px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `let showAnswerTrigger = 0.8`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 167px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 150px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 150px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 16px; background: none 0% 0% / | ight: 0px; text-align: left; text-de |
|  auto repeat scroll padding-box bord | coration: none; top: 0px; width: 767 |
| er-box rgb(255, 255, 255);">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 739px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `//Objective-C`{style="border: 0px n |
| er-box rgb(255, 255, 255);">         | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 739px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `// --- class method to get magnitud |
| ;Bitstream Vera Sans Mono&quot;, &qu | e of vector via Pythagorean theorem+ |
| ot;Courier New&quot;, Courier, monos |  `{style="border: 0px none rgb(0, 13 |
| pace; height: 15px; line-height: 15. | 0, 0); color: rgb(0, 130, 0); displa |
| 4px; margin: 0px; outline: rgb(175,  | y: inline; font-style: normal; font- |
| 175, 175) none 0px; padding: 0px 7px | variant: normal; font-weight: normal |
|  0px 14px; text-align: right; text-d | ; font-stretch: normal; font-size: 1 |
| ecoration: none; white-space: pre; w | 4px; font-family: Consolas, "Bitstre |
| idth: 16px; background: none 0% 0% / | am Vera Sans Mono", "Courier New", C |
|  auto repeat scroll padding-box bord | ourier, monospace; line-height: 15.4 |
| er-box rgb(255, 255, 255);">         | px; margin: 0px; outline: rgb(0, 130 |
|                                      | , 0) none 0px; padding: 0px; text-al |
| 4                                    | ign: left; text-decoration: none; wh |
|                                      | ite-space: pre;"}                    |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="color: rgb(175, 175, 175); di | <div                                 |
| splay: block; font-style: normal; fo | style="border: 0px none rgb(37, 37,  |
| nt-variant: normal; font-weight: nor | 37); color: rgb(37, 37, 37); display |
| mal; font-stretch: normal; font-size | : block; font-style: normal; font-va |
| : 14px; font-family: Consolas, &quot | riant: normal; font-weight: normal;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | font-stretch: normal; font-size: 14p |
| ot;Courier New&quot;, Courier, monos | x; font-family: Consolas, &quot;Bits |
| pace; height: 15px; line-height: 15. | tream Vera Sans Mono&quot;, &quot;Co |
| 4px; margin: 0px; outline: rgb(175,  | urier New&quot;, Courier, monospace; |
| 175, 175) none 0px; padding: 0px 7px |  height: 15px; line-height: 15.4px;  |
|  0px 14px; text-align: right; text-d | margin: 0px; outline: rgb(37, 37, 37 |
| ecoration: none; white-space: pre; w | ) none 0px; padding: 0px 14px; text- |
| idth: 16px; background: none 0% 0% / | align: left; text-decoration: none;  |
|  auto repeat scroll padding-box bord | white-space: pre; width: 739px; back |
| er-box rgb(255, 255, 255);">         | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
| 5                                    | 255, 255);">                         |
|                                      |                                      |
| </div>                               | `(double)magnitudeFromAttitude:(CMAt |
|                                      | titude *)attitude {`{style="display: |
| <div                                 |  inline; font-style: normal; font-va |
| style="color: rgb(175, 175, 175); di | riant: normal; font-weight: normal;  |
| splay: block; font-style: normal; fo | font-stretch: normal; font-size: 14p |
| nt-variant: normal; font-weight: nor | x; font-family: Consolas, "Bitstream |
| mal; font-stretch: normal; font-size |  Vera Sans Mono", "Courier New", Cou |
| : 14px; font-family: Consolas, &quot | rier, monospace; line-height: 15.4px |
| ;Bitstream Vera Sans Mono&quot;, &qu | ; margin: 0px; padding: 0px; text-al |
| ot;Courier New&quot;, Courier, monos | ign: left; text-decoration: none; wh |
| pace; height: 15px; line-height: 15. | ite-space: pre;"}                    |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 16px; background: none 0% 0% / | style="border: 0px none rgb(37, 37,  |
|  auto repeat scroll padding-box bord | 37); color: rgb(37, 37, 37); display |
| er-box rgb(255, 255, 255);">         | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 6                                    | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| <div                                 |  height: 15px; line-height: 15.4px;  |
| style="color: rgb(175, 175, 175); di | margin: 0px; outline: rgb(37, 37, 37 |
| splay: block; font-style: normal; fo | ) none 0px; padding: 0px 14px; text- |
| nt-variant: normal; font-weight: nor | align: left; text-decoration: none;  |
| mal; font-stretch: normal; font-size | white-space: pre; width: 739px; back |
| : 14px; font-family: Consolas, &quot | ground: none 0% 0% / auto repeat scr |
| ;Bitstream Vera Sans Mono&quot;, &qu | oll padding-box border-box rgb(255,  |
| ot;Courier New&quot;, Courier, monos | 255, 255);">                         |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | `    `{style="border: 0px none rgb(3 |
| 175, 175) none 0px; padding: 0px 7px | 7, 37, 37); color: rgb(37, 37, 37);  |
|  0px 14px; text-align: right; text-d | display: inline; font-style: normal; |
| ecoration: none; white-space: pre; w |  font-variant: normal; font-weight:  |
| idth: 16px; background: none 0% 0% / | normal; font-stretch: normal; font-s |
|  auto repeat scroll padding-box bord | ize: 14px; font-family: Consolas, "B |
| er-box rgb(255, 255, 255);">         | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| 7                                    | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| </div>                               | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`return`{sty |
| <div                                 | le="border: 0px none rgb(0, 102, 153 |
| style="color: rgb(175, 175, 175); di | ); color: rgb(0, 102, 153); display: |
| splay: block; font-style: normal; fo |  inline; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: bold; fo |
| mal; font-stretch: normal; font-size | nt-stretch: normal; font-size: 14px; |
| : 14px; font-family: Consolas, &quot |  font-family: Consolas, "Bitstream V |
| ;Bitstream Vera Sans Mono&quot;, &qu | era Sans Mono", "Courier New", Couri |
| ot;Courier New&quot;, Courier, monos | er, monospace; line-height: 15.4px;  |
| pace; height: 15px; line-height: 15. | margin: 0px; outline: rgb(0, 102, 15 |
| 4px; margin: 0px; outline: rgb(175,  | 3) none 0px; padding: 0px; text-alig |
| 175, 175) none 0px; padding: 0px 7px | n: left; text-decoration: none; whit |
|  0px 14px; text-align: right; text-d | e-space: pre;"} `sqrt(pow(attitude.r |
| ecoration: none; white-space: pre; w | oll, 2.0f) + pow(attitude.yaw, 2.0f) |
| idth: 16px; background: none 0% 0% / |  + pow(attitude.pitch, 2.0f));`{styl |
|  auto repeat scroll padding-box bord | e="display: inline; font-style: norm |
| er-box rgb(255, 255, 255);">         | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
| 8                                    | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
| </div>                               | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
| <div                                 | px; text-align: left; text-decoratio |
| style="color: rgb(175, 175, 175); di | n: none; white-space: pre;"}         |
| splay: block; font-style: normal; fo |                                      |
| nt-variant: normal; font-weight: nor | </div>                               |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | <div                                 |
| ;Bitstream Vera Sans Mono&quot;, &qu | style="border: 0px none rgb(37, 37,  |
| ot;Courier New&quot;, Courier, monos | 37); color: rgb(37, 37, 37); display |
| pace; height: 15px; line-height: 15. | : block; font-style: normal; font-va |
| 4px; margin: 0px; outline: rgb(175,  | riant: normal; font-weight: normal;  |
| 175, 175) none 0px; padding: 0px 7px | font-stretch: normal; font-size: 14p |
|  0px 14px; text-align: right; text-d | x; font-family: Consolas, &quot;Bits |
| ecoration: none; white-space: pre; w | tream Vera Sans Mono&quot;, &quot;Co |
| idth: 16px; background: none 0% 0% / | urier New&quot;, Courier, monospace; |
|  auto repeat scroll padding-box bord |  height: 15px; line-height: 15.4px;  |
| er-box rgb(255, 255, 255);">         | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
| 9                                    | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
| </div>                               | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
| <div                                 | 255, 255);">                         |
| style="color: rgb(175, 175, 175); di |                                      |
| splay: block; font-style: normal; fo | `}`{style="display: inline; font-sty |
| nt-variant: normal; font-weight: nor | le: normal; font-variant: normal; fo |
| mal; font-stretch: normal; font-size | nt-weight: normal; font-stretch: nor |
| : 14px; font-family: Consolas, &quot | mal; font-size: 14px; font-family: C |
| ;Bitstream Vera Sans Mono&quot;, &qu | onsolas, "Bitstream Vera Sans Mono", |
| ot;Courier New&quot;, Courier, monos |  "Courier New", Courier, monospace;  |
| pace; height: 15px; line-height: 15. | line-height: 15.4px; margin: 0px; pa |
| 4px; margin: 0px; outline: rgb(175,  | dding: 0px; text-align: left; text-d |
| 175, 175) none 0px; padding: 0px 7px | ecoration: none; white-space: pre;"} |
|  0px 14px; text-align: right; text-d | `// --- In @IBAction handler`{style= |
| ecoration: none; white-space: pre; w | "border: 0px none rgb(0, 130, 0); co |
| idth: 16px; background: none 0% 0% / | lor: rgb(0, 130, 0); display: inline |
|  auto repeat scroll padding-box bord | ; font-style: normal; font-variant:  |
| er-box rgb(255, 255, 255);">         | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
| 10                                   | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
| </div>                               | onospace; line-height: 15.4px; margi |
|                                      | n: 0px; outline: rgb(0, 130, 0) none |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}                             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `// initial configuration`{style="bo |
|                                      | rder: 0px none rgb(0, 130, 0); color |
|                                      | : rgb(0, 130, 0); display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
|                                      | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
|                                      |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
|                                      | 0px; outline: rgb(0, 130, 0) none 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `CMAttitude *initialAttitude = manag |
|                                      | er.deviceMotion.attitude;`{style="di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `__block BOOL showingPrompt = NO;`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}`// t |
|                                      | rigger values - a gap so there isn't |
|                                      |  a flicker zone`{style="border: 0px  |
|                                      | none rgb(0, 130, 0); color: rgb(0, 1 |
|                                      | 30, 0); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(0, 130, 0) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `double showPromptTrigger = 1.0f;`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 739px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `double showAnswerTrigger = 0.8f;`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

接下来，调用我们熟悉的startDeviceMotionUpdates，计算一下由三个欧拉角描述的向量的大小，并作为切换视图的触发器。

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 362px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 345px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 345px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 16px; background: none 0% 0% / | ight: 0px; text-align: left; text-de |
|  auto repeat scroll padding-box bord | coration: none; top: 0px; width: 118 |
| er-box rgb(255, 255, 255);">         | 3px;">                               |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 1155px; bac |
| 175, 175) none 0px; padding: 0px 7px | kground: none 0% 0% / auto repeat sc |
|  0px 14px; text-align: right; text-d | roll padding-box border-box rgb(255, |
| ecoration: none; white-space: pre; w |  255, 255);">                        |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `//Swift`{style="border: 0px none rg |
| er-box rgb(255, 255, 255);">         | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 1155px; bac |
| style="color: rgb(175, 175, 175); di | kground: none 0% 0% / auto repeat sc |
| splay: block; font-style: normal; fo | roll padding-box border-box rgb(255, |
| nt-variant: normal; font-weight: nor |  255, 255);">                        |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `if`{style="border: 0px none rgb(0,  |
| ;Bitstream Vera Sans Mono&quot;, &qu | 102, 153); color: rgb(0, 102, 153);  |
| ot;Courier New&quot;, Courier, monos | display: inline; font-style: normal; |
| pace; height: 15px; line-height: 15. |  font-variant: normal; font-weight:  |
| 4px; margin: 0px; outline: rgb(175,  | bold; font-stretch: normal; font-siz |
| 175, 175) none 0px; padding: 0px 7px | e: 14px; font-family: Consolas, "Bit |
|  0px 14px; text-align: right; text-d | stream Vera Sans Mono", "Courier New |
| ecoration: none; white-space: pre; w | ", Courier, monospace; line-height:  |
| idth: 16px; background: none 0% 0% / | 15.4px; margin: 0px; outline: rgb(0, |
|  auto repeat scroll padding-box bord |  102, 153) none 0px; padding: 0px; t |
| er-box rgb(255, 255, 255);">         | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"} `manager.dev |
| 4                                    | iceMotionAvailable {`{style="display |
|                                      | : inline; font-style: normal; font-v |
| </div>                               | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
| <div                                 | px; font-family: Consolas, "Bitstrea |
| style="color: rgb(175, 175, 175); di | m Vera Sans Mono", "Courier New", Co |
| splay: block; font-style: normal; fo | urier, monospace; line-height: 15.4p |
| nt-variant: normal; font-weight: nor | x; margin: 0px; padding: 0px; text-a |
| mal; font-stretch: normal; font-size | lign: left; text-decoration: none; w |
| : 14px; font-family: Consolas, &quot | hite-space: pre;"}                   |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | </div>                               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | <div                                 |
| 175, 175) none 0px; padding: 0px 7px | style="border: 0px none rgb(37, 37,  |
|  0px 14px; text-align: right; text-d | 37); color: rgb(37, 37, 37); display |
| ecoration: none; white-space: pre; w | : block; font-style: normal; font-va |
| idth: 16px; background: none 0% 0% / | riant: normal; font-weight: normal;  |
|  auto repeat scroll padding-box bord | font-stretch: normal; font-size: 14p |
| er-box rgb(255, 255, 255);">         | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| 5                                    | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| </div>                               | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
| <div                                 | align: left; text-decoration: none;  |
| style="color: rgb(175, 175, 175); di | white-space: pre; width: 1155px; bac |
| splay: block; font-style: normal; fo | kground: none 0% 0% / auto repeat sc |
| nt-variant: normal; font-weight: nor | roll padding-box border-box rgb(255, |
| mal; font-stretch: normal; font-size |  255, 255);">                        |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | `    `{style="border: 0px none rgb(3 |
| ot;Courier New&quot;, Courier, monos | 7, 37, 37); color: rgb(37, 37, 37);  |
| pace; height: 15px; line-height: 15. | display: inline; font-style: normal; |
| 4px; margin: 0px; outline: rgb(175,  |  font-variant: normal; font-weight:  |
| 175, 175) none 0px; padding: 0px 7px | normal; font-stretch: normal; font-s |
|  0px 14px; text-align: right; text-d | ize: 14px; font-family: Consolas, "B |
| ecoration: none; white-space: pre; w | itstream Vera Sans Mono", "Courier N |
| idth: 16px; background: none 0% 0% / | ew", Courier, monospace; line-height |
|  auto repeat scroll padding-box bord | : 15.4px; margin: 0px; outline: rgb( |
| er-box rgb(255, 255, 255);">         | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| 6                                    | one; white-space: pre;"}`manager.sta |
|                                      | rtDeviceMotionUpdatesToQueue(NSOpera |
| </div>                               | tionQueue.mainQueue()) {`{style="dis |
|                                      | play: inline; font-style: normal; fo |
| <div                                 | nt-variant: normal; font-weight: nor |
| style="color: rgb(175, 175, 175); di | mal; font-stretch: normal; font-size |
| splay: block; font-style: normal; fo | : 14px; font-family: Consolas, "Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono", "Courier New" |
| mal; font-stretch: normal; font-size | , Courier, monospace; line-height: 1 |
| : 14px; font-family: Consolas, &quot | 5.4px; margin: 0px; padding: 0px; te |
| ;Bitstream Vera Sans Mono&quot;, &qu | xt-align: left; text-decoration: non |
| ot;Courier New&quot;, Courier, monos | e; white-space: pre;"}               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | </div>                               |
| 175, 175) none 0px; padding: 0px 7px |                                      |
|  0px 14px; text-align: right; text-d | <div                                 |
| ecoration: none; white-space: pre; w | style="border: 0px none rgb(37, 37,  |
| idth: 16px; background: none 0% 0% / | 37); color: rgb(37, 37, 37); display |
|  auto repeat scroll padding-box bord | : block; font-style: normal; font-va |
| er-box rgb(255, 255, 255);">         | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
| 7                                    | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| </div>                               | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| <div                                 | margin: 0px; outline: rgb(37, 37, 37 |
| style="color: rgb(175, 175, 175); di | ) none 0px; padding: 0px 14px; text- |
| splay: block; font-style: normal; fo | align: left; text-decoration: none;  |
| nt-variant: normal; font-weight: nor | white-space: pre; width: 1155px; bac |
| mal; font-stretch: normal; font-size | kground: none 0% 0% / auto repeat sc |
| : 14px; font-family: Consolas, &quot | roll padding-box border-box rgb(255, |
| ;Bitstream Vera Sans Mono&quot;, &qu |  255, 255);">                        |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | `        `{style="border: 0px none r |
| 4px; margin: 0px; outline: rgb(175,  | gb(37, 37, 37); color: rgb(37, 37, 3 |
| 175, 175) none 0px; padding: 0px 7px | 7); display: inline; font-style: nor |
|  0px 14px; text-align: right; text-d | mal; font-variant: normal; font-weig |
| ecoration: none; white-space: pre; w | ht: normal; font-stretch: normal; fo |
| idth: 16px; background: none 0% 0% / | nt-size: 14px; font-family: Consolas |
|  auto repeat scroll padding-box bord | , "Bitstream Vera Sans Mono", "Couri |
| er-box rgb(255, 255, 255);">         | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
| 8                                    | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
| </div>                               | n: none; white-space: pre;"}`[weak s |
|                                      | elf] (data: CMDeviceMotion!, error:  |
| <div                                 | NSError!) `{style="display: inline;  |
| style="color: rgb(175, 175, 175); di | font-style: normal; font-variant: no |
| splay: block; font-style: normal; fo | rmal; font-weight: normal; font-stre |
| nt-variant: normal; font-weight: nor | tch: normal; font-size: 14px; font-f |
| mal; font-stretch: normal; font-size | amily: Consolas, "Bitstream Vera San |
| : 14px; font-family: Consolas, &quot | s Mono", "Courier New", Courier, mon |
| ;Bitstream Vera Sans Mono&quot;, &qu | ospace; line-height: 15.4px; margin: |
| ot;Courier New&quot;, Courier, monos |  0px; padding: 0px; text-align: left |
| pace; height: 15px; line-height: 15. | ; text-decoration: none; white-space |
| 4px; margin: 0px; outline: rgb(175,  | : pre;"}`in`{style="border: 0px none |
| 175, 175) none 0px; padding: 0px 7px |  rgb(0, 102, 153); color: rgb(0, 102 |
|  0px 14px; text-align: right; text-d | , 153); display: inline; font-style: |
| ecoration: none; white-space: pre; w |  normal; font-variant: normal; font- |
| idth: 16px; background: none 0% 0% / | weight: bold; font-stretch: normal;  |
|  auto repeat scroll padding-box bord | font-size: 14px; font-family: Consol |
| er-box rgb(255, 255, 255);">         | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
| 9                                    | height: 15.4px; margin: 0px; outline |
|                                      | : rgb(0, 102, 153) none 0px; padding |
| </div>                               | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
| <div                                 |                                      |
| style="color: rgb(175, 175, 175); di | </div>                               |
| splay: block; font-style: normal; fo |                                      |
| nt-variant: normal; font-weight: nor | <div                                 |
| mal; font-stretch: normal; font-size | style="border: 0px none rgb(37, 37,  |
| : 14px; font-family: Consolas, &quot | 37); color: rgb(37, 37, 37); display |
| ;Bitstream Vera Sans Mono&quot;, &qu | : block; font-style: normal; font-va |
| ot;Courier New&quot;, Courier, monos | riant: normal; font-weight: normal;  |
| pace; height: 15px; line-height: 15. | font-stretch: normal; font-size: 14p |
| 4px; margin: 0px; outline: rgb(175,  | x; font-family: Consolas, &quot;Bits |
| 175, 175) none 0px; padding: 0px 7px | tream Vera Sans Mono&quot;, &quot;Co |
|  0px 14px; text-align: right; text-d | urier New&quot;, Courier, monospace; |
| ecoration: none; white-space: pre; w |  height: 15px; line-height: 15.4px;  |
| idth: 16px; background: none 0% 0% / | margin: 0px; outline: rgb(37, 37, 37 |
|  auto repeat scroll padding-box bord | ) none 0px; padding: 0px 14px; text- |
| er-box rgb(255, 255, 255);">         | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
| 10                                   | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
| </div>                               |  255, 255);">                        |
|                                      |                                      |
| <div                                 | `        `{style="border: 0px none r |
| style="color: rgb(175, 175, 175); di | gb(37, 37, 37); color: rgb(37, 37, 3 |
| splay: block; font-style: normal; fo | 7); display: inline; font-style: nor |
| nt-variant: normal; font-weight: nor | mal; font-variant: normal; font-weig |
| mal; font-stretch: normal; font-size | ht: normal; font-stretch: normal; fo |
| : 14px; font-family: Consolas, &quot | nt-size: 14px; font-family: Consolas |
| ;Bitstream Vera Sans Mono&quot;, &qu | , "Bitstream Vera Sans Mono", "Couri |
| ot;Courier New&quot;, Courier, monos | er New", Courier, monospace; line-he |
| pace; height: 15px; line-height: 15. | ight: 15.4px; margin: 0px; outline:  |
| 4px; margin: 0px; outline: rgb(175,  | rgb(37, 37, 37) none 0px; padding: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; text-align: left; text-decoratio |
|  0px 14px; text-align: right; text-d | n: none; white-space: pre;"}`// tran |
| ecoration: none; white-space: pre; w | slate the attitude`{style="border: 0 |
| idth: 16px; background: none 0% 0% / | px none rgb(0, 130, 0); color: rgb(0 |
|  auto repeat scroll padding-box bord | , 130, 0); display: inline; font-sty |
| er-box rgb(255, 255, 255);">         | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
| 11                                   | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
| </div>                               |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; ou |
| <div                                 | tline: rgb(0, 130, 0) none 0px; padd |
| style="color: rgb(175, 175, 175); di | ing: 0px; text-align: left; text-dec |
| splay: block; font-style: normal; fo | oration: none; white-space: pre;"}   |
| nt-variant: normal; font-weight: nor |                                      |
| mal; font-stretch: normal; font-size | </div>                               |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | <div                                 |
| ot;Courier New&quot;, Courier, monos | style="border: 0px none rgb(37, 37,  |
| pace; height: 15px; line-height: 15. | 37); color: rgb(37, 37, 37); display |
| 4px; margin: 0px; outline: rgb(175,  | : block; font-style: normal; font-va |
| 175, 175) none 0px; padding: 0px 7px | riant: normal; font-weight: normal;  |
|  0px 14px; text-align: right; text-d | font-stretch: normal; font-size: 14p |
| ecoration: none; white-space: pre; w | x; font-family: Consolas, &quot;Bits |
| idth: 16px; background: none 0% 0% / | tream Vera Sans Mono&quot;, &quot;Co |
|  auto repeat scroll padding-box bord | urier New&quot;, Courier, monospace; |
| er-box rgb(255, 255, 255);">         |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| 12                                   | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| </div>                               | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
| <div                                 | roll padding-box border-box rgb(255, |
| style="color: rgb(175, 175, 175); di |  255, 255);">                        |
| splay: block; font-style: normal; fo |                                      |
| nt-variant: normal; font-weight: nor | `        `{style="border: 0px none r |
| mal; font-stretch: normal; font-size | gb(37, 37, 37); color: rgb(37, 37, 3 |
| : 14px; font-family: Consolas, &quot | 7); display: inline; font-style: nor |
| ;Bitstream Vera Sans Mono&quot;, &qu | mal; font-variant: normal; font-weig |
| ot;Courier New&quot;, Courier, monos | ht: normal; font-stretch: normal; fo |
| pace; height: 15px; line-height: 15. | nt-size: 14px; font-family: Consolas |
| 4px; margin: 0px; outline: rgb(175,  | , "Bitstream Vera Sans Mono", "Couri |
| 175, 175) none 0px; padding: 0px 7px | er New", Courier, monospace; line-he |
|  0px 14px; text-align: right; text-d | ight: 15.4px; margin: 0px; outline:  |
| ecoration: none; white-space: pre; w | rgb(37, 37, 37) none 0px; padding: 0 |
| idth: 16px; background: none 0% 0% / | px; text-align: left; text-decoratio |
|  auto repeat scroll padding-box bord | n: none; white-space: pre;"}`data.at |
| er-box rgb(255, 255, 255);">         | titude.multiplyByInverseOfAttitude(i |
|                                      | nitialAttitude)`{style="display: inl |
| 13                                   | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
| </div>                               | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
| <div                                 | a Sans Mono", "Courier New", Courier |
| style="color: rgb(175, 175, 175); di | , monospace; line-height: 15.4px; ma |
| splay: block; font-style: normal; fo | rgin: 0px; padding: 0px; text-align: |
| nt-variant: normal; font-weight: nor |  left; text-decoration: none; white- |
| mal; font-stretch: normal; font-size | space: pre;"}                        |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 14                                   |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 1155px; bac |
| style="color: rgb(175, 175, 175); di | kground: none 0% 0% / auto repeat sc |
| splay: block; font-style: normal; fo | roll padding-box border-box rgb(255, |
| nt-variant: normal; font-weight: nor |  255, 255);">                        |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `        `{style="border: 0px none r |
| ;Bitstream Vera Sans Mono&quot;, &qu | gb(37, 37, 37); color: rgb(37, 37, 3 |
| ot;Courier New&quot;, Courier, monos | 7); display: inline; font-style: nor |
| pace; height: 15px; line-height: 15. | mal; font-variant: normal; font-weig |
| 4px; margin: 0px; outline: rgb(175,  | ht: normal; font-stretch: normal; fo |
| 175, 175) none 0px; padding: 0px 7px | nt-size: 14px; font-family: Consolas |
|  0px 14px; text-align: right; text-d | , "Bitstream Vera Sans Mono", "Couri |
| ecoration: none; white-space: pre; w | er New", Courier, monospace; line-he |
| idth: 16px; background: none 0% 0% / | ight: 15.4px; margin: 0px; outline:  |
|  auto repeat scroll padding-box bord | rgb(37, 37, 37) none 0px; padding: 0 |
| er-box rgb(255, 255, 255);">         | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// calc |
| 15                                   | ulate magnitude of the change from o |
|                                      | ur initial attitude`{style="border:  |
| </div>                               | 0px none rgb(0, 130, 0); color: rgb( |
|                                      | 0, 130, 0); display: inline; font-st |
| <div                                 | yle: normal; font-variant: normal; f |
| style="color: rgb(175, 175, 175); di | ont-weight: normal; font-stretch: no |
| splay: block; font-style: normal; fo | rmal; font-size: 14px; font-family:  |
| nt-variant: normal; font-weight: nor | Consolas, "Bitstream Vera Sans Mono" |
| mal; font-stretch: normal; font-size | , "Courier New", Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  line-height: 15.4px; margin: 0px; o |
| ;Bitstream Vera Sans Mono&quot;, &qu | utline: rgb(0, 130, 0) none 0px; pad |
| ot;Courier New&quot;, Courier, monos | ding: 0px; text-align: left; text-de |
| pace; height: 15px; line-height: 15. | coration: none; white-space: pre;"}  |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 16px; background: none 0% 0% / | style="border: 0px none rgb(37, 37,  |
|  auto repeat scroll padding-box bord | 37); color: rgb(37, 37, 37); display |
| er-box rgb(255, 255, 255);">         | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 16                                   | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| <div                                 |  height: 15px; line-height: 15.4px;  |
| style="color: rgb(175, 175, 175); di | margin: 0px; outline: rgb(37, 37, 37 |
| splay: block; font-style: normal; fo | ) none 0px; padding: 0px 14px; text- |
| nt-variant: normal; font-weight: nor | align: left; text-decoration: none;  |
| mal; font-stretch: normal; font-size | white-space: pre; width: 1155px; bac |
| : 14px; font-family: Consolas, &quot | kground: none 0% 0% / auto repeat sc |
| ;Bitstream Vera Sans Mono&quot;, &qu | roll padding-box border-box rgb(255, |
| ot;Courier New&quot;, Courier, monos |  255, 255);">                        |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | `        `{style="border: 0px none r |
| 175, 175) none 0px; padding: 0px 7px | gb(37, 37, 37); color: rgb(37, 37, 3 |
|  0px 14px; text-align: right; text-d | 7); display: inline; font-style: nor |
| ecoration: none; white-space: pre; w | mal; font-variant: normal; font-weig |
| idth: 16px; background: none 0% 0% / | ht: normal; font-stretch: normal; fo |
|  auto repeat scroll padding-box bord | nt-size: 14px; font-family: Consolas |
| er-box rgb(255, 255, 255);">         | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
| 17                                   | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
| </div>                               | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`let mag |
| <div                                 | nitude = magnitudeFromAttitude(data. |
| style="color: rgb(175, 175, 175); di | attitude) ?? 0`{style="display: inli |
| splay: block; font-style: normal; fo | ne; font-style: normal; font-variant |
| nt-variant: normal; font-weight: nor | : normal; font-weight: normal; font- |
| mal; font-stretch: normal; font-size | stretch: normal; font-size: 14px; fo |
| : 14px; font-family: Consolas, &quot | nt-family: Consolas, "Bitstream Vera |
| ;Bitstream Vera Sans Mono&quot;, &qu |  Sans Mono", "Courier New", Courier, |
| ot;Courier New&quot;, Courier, monos |  monospace; line-height: 15.4px; mar |
| pace; height: 15px; line-height: 15. | gin: 0px; padding: 0px; text-align:  |
| 4px; margin: 0px; outline: rgb(175,  | left; text-decoration: none; white-s |
| 175, 175) none 0px; padding: 0px 7px | pace: pre;"}                         |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | </div>                               |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | <div                                 |
| er-box rgb(255, 255, 255);">         | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
| 18                                   | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| </div>                               | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| <div                                 | tream Vera Sans Mono&quot;, &quot;Co |
| style="color: rgb(175, 175, 175); di | urier New&quot;, Courier, monospace; |
| splay: block; font-style: normal; fo |  height: 15px; line-height: 15.4px;  |
| nt-variant: normal; font-weight: nor | margin: 0px; outline: rgb(37, 37, 37 |
| mal; font-stretch: normal; font-size | ) none 0px; padding: 0px 14px; text- |
| : 14px; font-family: Consolas, &quot | align: left; text-decoration: none;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | white-space: pre; width: 1155px; bac |
| ot;Courier New&quot;, Courier, monos | kground: none 0% 0% / auto repeat sc |
| pace; height: 15px; line-height: 15. | roll padding-box border-box rgb(255, |
| 4px; margin: 0px; outline: rgb(175,  |  255, 255);">                        |
| 175, 175) none 0px; padding: 0px 7px |                                      |
|  0px 14px; text-align: right; text-d | `        `{style="border: 0px none r |
| ecoration: none; white-space: pre; w | gb(37, 37, 37); color: rgb(37, 37, 3 |
| idth: 16px; background: none 0% 0% / | 7); display: inline; font-style: nor |
|  auto repeat scroll padding-box bord | mal; font-variant: normal; font-weig |
| er-box rgb(255, 255, 255);">         | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
| 19                                   | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
| </div>                               | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
| <div                                 | px; text-align: left; text-decoratio |
| style="color: rgb(175, 175, 175); di | n: none; white-space: pre;"}`// show |
| splay: block; font-style: normal; fo |  the prompt`{style="border: 0px none |
| nt-variant: normal; font-weight: nor |  rgb(0, 130, 0); color: rgb(0, 130,  |
| mal; font-stretch: normal; font-size | 0); display: inline; font-style: nor |
| : 14px; font-family: Consolas, &quot | mal; font-variant: normal; font-weig |
| ;Bitstream Vera Sans Mono&quot;, &qu | ht: normal; font-stretch: normal; fo |
| ot;Courier New&quot;, Courier, monos | nt-size: 14px; font-family: Consolas |
| pace; height: 15px; line-height: 15. | , "Bitstream Vera Sans Mono", "Couri |
| 4px; margin: 0px; outline: rgb(175,  | er New", Courier, monospace; line-he |
| 175, 175) none 0px; padding: 0px 7px | ight: 15.4px; margin: 0px; outline:  |
|  0px 14px; text-align: right; text-d | rgb(0, 130, 0) none 0px; padding: 0p |
| ecoration: none; white-space: pre; w | x; text-align: left; text-decoration |
| idth: 16px; background: none 0% 0% / | : none; white-space: pre;"}          |
|  auto repeat scroll padding-box bord |                                      |
| er-box rgb(255, 255, 255);">         | </div>                               |
|                                      |                                      |
| 20                                   | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 1155px; bac |
| 175, 175) none 0px; padding: 0px 7px | kground: none 0% 0% / auto repeat sc |
|  0px 14px; text-align: right; text-d | roll padding-box border-box rgb(255, |
| ecoration: none; white-space: pre; w |  255, 255);">                        |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `        `{style="border: 0px none r |
| er-box rgb(255, 255, 255);">         | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
| 21                                   | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
| </div>                               | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
| <div                                 | er New", Courier, monospace; line-he |
| style="color: rgb(175, 175, 175); di | ight: 15.4px; margin: 0px; outline:  |
| splay: block; font-style: normal; fo | rgb(37, 37, 37) none 0px; padding: 0 |
| nt-variant: normal; font-weight: nor | px; text-align: left; text-decoratio |
| mal; font-stretch: normal; font-size | n: none; white-space: pre;"}`if`{sty |
| : 14px; font-family: Consolas, &quot | le="border: 0px none rgb(0, 102, 153 |
| ;Bitstream Vera Sans Mono&quot;, &qu | ); color: rgb(0, 102, 153); display: |
| ot;Courier New&quot;, Courier, monos |  inline; font-style: normal; font-va |
| pace; height: 15px; line-height: 15. | riant: normal; font-weight: bold; fo |
| 4px; margin: 0px; outline: rgb(175,  | nt-stretch: normal; font-size: 14px; |
| 175, 175) none 0px; padding: 0px 7px |  font-family: Consolas, "Bitstream V |
|  0px 14px; text-align: right; text-d | era Sans Mono", "Courier New", Couri |
| ecoration: none; white-space: pre; w | er, monospace; line-height: 15.4px;  |
| idth: 16px; background: none 0% 0% / | margin: 0px; outline: rgb(0, 102, 15 |
|  auto repeat scroll padding-box bord | 3) none 0px; padding: 0px; text-alig |
| er-box rgb(255, 255, 255);">         | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `!showingPrompt && m |
| 22                                   | agnitude > showPromptTrigger {`{styl |
|                                      | e="display: inline; font-style: norm |
| </div>                               | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
| <div                                 | t-size: 14px; font-family: Consolas, |
| style="color: rgb(175, 175, 175); di |  "Bitstream Vera Sans Mono", "Courie |
| splay: block; font-style: normal; fo | r New", Courier, monospace; line-hei |
| nt-variant: normal; font-weight: nor | ght: 15.4px; margin: 0px; padding: 0 |
| mal; font-stretch: normal; font-size | px; text-align: left; text-decoratio |
| : 14px; font-family: Consolas, &quot | n: none; white-space: pre;"}         |
| ;Bitstream Vera Sans Mono&quot;, &qu |                                      |
| ot;Courier New&quot;, Courier, monos | </div>                               |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | <div                                 |
| 175, 175) none 0px; padding: 0px 7px | style="border: 0px none rgb(37, 37,  |
|  0px 14px; text-align: right; text-d | 37); color: rgb(37, 37, 37); display |
| ecoration: none; white-space: pre; w | : block; font-style: normal; font-va |
| idth: 16px; background: none 0% 0% / | riant: normal; font-weight: normal;  |
|  auto repeat scroll padding-box bord | font-stretch: normal; font-size: 14p |
| er-box rgb(255, 255, 255);">         | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
| 23                                   | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
| </div>                               | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`if` |
|                                      | {style="border: 0px none rgb(0, 102, |
|                                      |  153); color: rgb(0, 102, 153); disp |
|                                      | lay: inline; font-style: normal; fon |
|                                      | t-variant: normal; font-weight: bold |
|                                      | ; font-stretch: normal; font-size: 1 |
|                                      | 4px; font-family: Consolas, "Bitstre |
|                                      | am Vera Sans Mono", "Courier New", C |
|                                      | ourier, monospace; line-height: 15.4 |
|                                      | px; margin: 0px; outline: rgb(0, 102 |
|                                      | , 153) none 0px; padding: 0px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre;"} `let promptViewC |
|                                      | ontroller = self?.storyboard?.instan |
|                                      | tiateViewControllerWithIdentifier(`{ |
|                                      | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`"Pr |
|                                      | omptViewController"`{style="border:  |
|                                      | 0px none rgb(0, 0, 255); color: rgb( |
|                                      | 0, 0, 255); display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(0, 0, 255) none 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}` |
|                                      | ) as? PromptViewController {`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `                `{style="border: 0p |
|                                      | x none rgb(37, 37, 37); color: rgb(3 |
|                                      | 7, 37, 37); display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(37, 37, 37) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `showingPrompt = `{style="display: i |
|                                      | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}`true`{style="border: |
|                                      |  0px none rgb(0, 102, 153); color: r |
|                                      | gb(0, 102, 153); display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: bold; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; outline: rgb(0, 102, 153) none 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `                `{style="border: 0p |
|                                      | x none rgb(37, 37, 37); color: rgb(3 |
|                                      | 7, 37, 37); display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(37, 37, 37) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `promptViewController.modalTransitio |
|                                      | nStyle = UIModalTransitionStyle.Cros |
|                                      | sDissolve`{style="display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
|                                      | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
|                                      |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}                              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `                `{style="border: 0p |
|                                      | x none rgb(37, 37, 37); color: rgb(3 |
|                                      | 7, 37, 37); display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(37, 37, 37) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `self!.presentViewController(promptV |
|                                      | iewController, animated: `{style="di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`true`{style= |
|                                      | "border: 0px none rgb(0, 102, 153);  |
|                                      | color: rgb(0, 102, 153); display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: bold; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; outline: rgb(0, 102, 153)  |
|                                      | none 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}`, completion: nil)`{sty |
|                                      | le="display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; padding:  |
|                                      | 0px; text-align: left; text-decorati |
|                                      | on: none; white-space: pre;"}        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`}`{ |
|                                      | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// hide |
|                                      |  the prompt`{style="border: 0px none |
|                                      |  rgb(0, 130, 0); color: rgb(0, 130,  |
|                                      | 0); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 130, 0) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`if`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `showingPrompt && ma |
|                                      | gnitude < showAnswerTrigger {`{style |
|                                      | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`sho |
|                                      | wingPrompt = `{style="display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}`false`{style="border: 0p |
|                                      | x none rgb(0, 102, 153); color: rgb( |
|                                      | 0, 102, 153); display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: bold; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(0, 102, 153) none 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }                                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`sel |
|                                      | f?.dismissViewControllerAnimated(`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}`true |
|                                      | `{style="border: 0px none rgb(0, 102 |
|                                      | , 153); color: rgb(0, 102, 153); dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: bol |
|                                      | d; font-stretch: normal; font-size:  |
|                                      | 14px; font-family: Consolas, "Bitstr |
|                                      | eam Vera Sans Mono", "Courier New",  |
|                                      | Courier, monospace; line-height: 15. |
|                                      | 4px; margin: 0px; outline: rgb(0, 10 |
|                                      | 2, 153) none 0px; padding: 0px; text |
|                                      | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}`, completion: n |
|                                      | il)`{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }                                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1155px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 347px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 330px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 330px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 16px; background: none 0% 0% / | ight: 0px; text-align: left; text-de |
|  auto repeat scroll padding-box bord | coration: none; top: 0px; width: 112 |
| er-box rgb(255, 255, 255);">         | 9px;">                               |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 1101px; bac |
| 175, 175) none 0px; padding: 0px 7px | kground: none 0% 0% / auto repeat sc |
|  0px 14px; text-align: right; text-d | roll padding-box border-box rgb(255, |
| ecoration: none; white-space: pre; w |  255, 255);">                        |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `//Objective-C`{style="border: 0px n |
| er-box rgb(255, 255, 255);">         | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 1101px; bac |
| style="color: rgb(175, 175, 175); di | kground: none 0% 0% / auto repeat sc |
| splay: block; font-style: normal; fo | roll padding-box border-box rgb(255, |
| nt-variant: normal; font-weight: nor |  255, 255);">                        |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `FacingViewController * __weak weakS |
| ;Bitstream Vera Sans Mono&quot;, &qu | elf = self;`{style="display: inline; |
| ot;Courier New&quot;, Courier, monos |  font-style: normal; font-variant: n |
| pace; height: 15px; line-height: 15. | ormal; font-weight: normal; font-str |
| 4px; margin: 0px; outline: rgb(175,  | etch: normal; font-size: 14px; font- |
| 175, 175) none 0px; padding: 0px 7px | family: Consolas, "Bitstream Vera Sa |
|  0px 14px; text-align: right; text-d | ns Mono", "Courier New", Courier, mo |
| ecoration: none; white-space: pre; w | nospace; line-height: 15.4px; margin |
| idth: 16px; background: none 0% 0% / | : 0px; padding: 0px; text-align: lef |
|  auto repeat scroll padding-box bord | t; text-decoration: none; white-spac |
| er-box rgb(255, 255, 255);">         | e: pre;"}`if`{style="border: 0px non |
|                                      | e rgb(0, 102, 153); color: rgb(0, 10 |
| 4                                    | 2, 153); display: inline; font-style |
|                                      | : normal; font-variant: normal; font |
| </div>                               | -weight: bold; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| <div                                 | las, "Bitstream Vera Sans Mono", "Co |
| style="color: rgb(175, 175, 175); di | urier New", Courier, monospace; line |
| splay: block; font-style: normal; fo | -height: 15.4px; margin: 0px; outlin |
| nt-variant: normal; font-weight: nor | e: rgb(0, 102, 153) none 0px; paddin |
| mal; font-stretch: normal; font-size | g: 0px; text-align: left; text-decor |
| : 14px; font-family: Consolas, &quot | ation: none; white-space: pre;"} `(m |
| ;Bitstream Vera Sans Mono&quot;, &qu | anager.deviceMotionAvailable) {`{sty |
| ot;Courier New&quot;, Courier, monos | le="display: inline; font-style: nor |
| pace; height: 15px; line-height: 15. | mal; font-variant: normal; font-weig |
| 4px; margin: 0px; outline: rgb(175,  | ht: normal; font-stretch: normal; fo |
| 175, 175) none 0px; padding: 0px 7px | nt-size: 14px; font-family: Consolas |
|  0px 14px; text-align: right; text-d | , "Bitstream Vera Sans Mono", "Couri |
| ecoration: none; white-space: pre; w | er New", Courier, monospace; line-he |
| idth: 16px; background: none 0% 0% / | ight: 15.4px; margin: 0px; padding:  |
|  auto repeat scroll padding-box bord | 0px; text-align: left; text-decorati |
| er-box rgb(255, 255, 255);">         | on: none; white-space: pre;"}        |
|                                      |                                      |
| 5                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| <div                                 | 37); color: rgb(37, 37, 37); display |
| style="color: rgb(175, 175, 175); di | : block; font-style: normal; font-va |
| splay: block; font-style: normal; fo | riant: normal; font-weight: normal;  |
| nt-variant: normal; font-weight: nor | font-stretch: normal; font-size: 14p |
| mal; font-stretch: normal; font-size | x; font-family: Consolas, &quot;Bits |
| : 14px; font-family: Consolas, &quot | tream Vera Sans Mono&quot;, &quot;Co |
| ;Bitstream Vera Sans Mono&quot;, &qu | urier New&quot;, Courier, monospace; |
| ot;Courier New&quot;, Courier, monos |  height: 15px; line-height: 15.4px;  |
| pace; height: 15px; line-height: 15. | margin: 0px; outline: rgb(37, 37, 37 |
| 4px; margin: 0px; outline: rgb(175,  | ) none 0px; padding: 0px 14px; text- |
| 175, 175) none 0px; padding: 0px 7px | align: left; text-decoration: none;  |
|  0px 14px; text-align: right; text-d | white-space: pre; width: 1101px; bac |
| ecoration: none; white-space: pre; w | kground: none 0% 0% / auto repeat sc |
| idth: 16px; background: none 0% 0% / | roll padding-box border-box rgb(255, |
|  auto repeat scroll padding-box bord |  255, 255);">                        |
| er-box rgb(255, 255, 255);">         |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
| 6                                    | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
| </div>                               |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| <div                                 | ize: 14px; font-family: Consolas, "B |
| style="color: rgb(175, 175, 175); di | itstream Vera Sans Mono", "Courier N |
| splay: block; font-style: normal; fo | ew", Courier, monospace; line-height |
| nt-variant: normal; font-weight: nor | : 15.4px; margin: 0px; outline: rgb( |
| mal; font-stretch: normal; font-size | 37, 37, 37) none 0px; padding: 0px;  |
| : 14px; font-family: Consolas, &quot | text-align: left; text-decoration: n |
| ;Bitstream Vera Sans Mono&quot;, &qu | one; white-space: pre;"}`[manager st |
| ot;Courier New&quot;, Courier, monos | artDeviceMotionUpdatesToQueue:[NSOpe |
| pace; height: 15px; line-height: 15. | rationQueue mainQueue]`{style="displ |
| 4px; margin: 0px; outline: rgb(175,  | ay: inline; font-style: normal; font |
| 175, 175) none 0px; padding: 0px 7px | -variant: normal; font-weight: norma |
|  0px 14px; text-align: right; text-d | l; font-stretch: normal; font-size:  |
| ecoration: none; white-space: pre; w | 14px; font-family: Consolas, "Bitstr |
| idth: 16px; background: none 0% 0% / | eam Vera Sans Mono", "Courier New",  |
|  auto repeat scroll padding-box bord | Courier, monospace; line-height: 15. |
| er-box rgb(255, 255, 255);">         | 4px; margin: 0px; padding: 0px; text |
|                                      | -align: left; text-decoration: none; |
| 7                                    |  white-space: pre;"}                 |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); color: rgb(37, 37, 37); display |
| nt-variant: normal; font-weight: nor | : block; font-style: normal; font-va |
| mal; font-stretch: normal; font-size | riant: normal; font-weight: normal;  |
| : 14px; font-family: Consolas, &quot | font-stretch: normal; font-size: 14p |
| ;Bitstream Vera Sans Mono&quot;, &qu | x; font-family: Consolas, &quot;Bits |
| ot;Courier New&quot;, Courier, monos | tream Vera Sans Mono&quot;, &quot;Co |
| pace; height: 15px; line-height: 15. | urier New&quot;, Courier, monospace; |
| 4px; margin: 0px; outline: rgb(175,  |  height: 15px; line-height: 15.4px;  |
| 175, 175) none 0px; padding: 0px 7px | margin: 0px; outline: rgb(37, 37, 37 |
|  0px 14px; text-align: right; text-d | ) none 0px; padding: 0px 14px; text- |
| ecoration: none; white-space: pre; w | align: left; text-decoration: none;  |
| idth: 16px; background: none 0% 0% / | white-space: pre; width: 1101px; bac |
|  auto repeat scroll padding-box bord | kground: none 0% 0% / auto repeat sc |
| er-box rgb(255, 255, 255);">         | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
| 8                                    |                                      |
|                                      | `                                    |
| </div>                               |     `{style="border: 0px none rgb(37 |
|                                      | , 37, 37); color: rgb(37, 37, 37); d |
| <div                                 | isplay: inline; font-style: normal;  |
| style="color: rgb(175, 175, 175); di | font-variant: normal; font-weight: n |
| splay: block; font-style: normal; fo | ormal; font-stretch: normal; font-si |
| nt-variant: normal; font-weight: nor | ze: 14px; font-family: Consolas, "Bi |
| mal; font-stretch: normal; font-size | tstream Vera Sans Mono", "Courier Ne |
| : 14px; font-family: Consolas, &quot | w", Courier, monospace; line-height: |
| ;Bitstream Vera Sans Mono&quot;, &qu |  15.4px; margin: 0px; outline: rgb(3 |
| ot;Courier New&quot;, Courier, monos | 7, 37, 37) none 0px; padding: 0px; t |
| pace; height: 15px; line-height: 15. | ext-align: left; text-decoration: no |
| 4px; margin: 0px; outline: rgb(175,  | ne; white-space: pre;"}`withHandler: |
| 175, 175) none 0px; padding: 0px 7px | ^(CMDeviceMotion *data, NSError *err |
|  0px 14px; text-align: right; text-d | or) {`{style="display: inline; font- |
| ecoration: none; white-space: pre; w | style: normal; font-variant: normal; |
| idth: 16px; background: none 0% 0% / |  font-weight: normal; font-stretch:  |
|  auto repeat scroll padding-box bord | normal; font-size: 14px; font-family |
| er-box rgb(255, 255, 255);">         | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
| 9                                    | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
| </div>                               | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
| <div                                 |                                      |
| style="color: rgb(175, 175, 175); di | </div>                               |
| splay: block; font-style: normal; fo |                                      |
| nt-variant: normal; font-weight: nor | <div                                 |
| mal; font-stretch: normal; font-size | style="border: 0px none rgb(37, 37,  |
| : 14px; font-family: Consolas, &quot | 37); color: rgb(37, 37, 37); display |
| ;Bitstream Vera Sans Mono&quot;, &qu | : block; font-style: normal; font-va |
| ot;Courier New&quot;, Courier, monos | riant: normal; font-weight: normal;  |
| pace; height: 15px; line-height: 15. | font-stretch: normal; font-size: 14p |
| 4px; margin: 0px; outline: rgb(175,  | x; font-family: Consolas, &quot;Bits |
| 175, 175) none 0px; padding: 0px 7px | tream Vera Sans Mono&quot;, &quot;Co |
|  0px 14px; text-align: right; text-d | urier New&quot;, Courier, monospace; |
| ecoration: none; white-space: pre; w |  height: 15px; line-height: 15.4px;  |
| idth: 16px; background: none 0% 0% / | margin: 0px; outline: rgb(37, 37, 37 |
|  auto repeat scroll padding-box bord | ) none 0px; padding: 0px 14px; text- |
| er-box rgb(255, 255, 255);">         | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
| 10                                   | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
| </div>                               |  255, 255);">                        |
|                                      |                                      |
| <div                                 | `        `{style="border: 0px none r |
| style="color: rgb(175, 175, 175); di | gb(37, 37, 37); color: rgb(37, 37, 3 |
| splay: block; font-style: normal; fo | 7); display: inline; font-style: nor |
| nt-variant: normal; font-weight: nor | mal; font-variant: normal; font-weig |
| mal; font-stretch: normal; font-size | ht: normal; font-stretch: normal; fo |
| : 14px; font-family: Consolas, &quot | nt-size: 14px; font-family: Consolas |
| ;Bitstream Vera Sans Mono&quot;, &qu | , "Bitstream Vera Sans Mono", "Couri |
| ot;Courier New&quot;, Courier, monos | er New", Courier, monospace; line-he |
| pace; height: 15px; line-height: 15. | ight: 15.4px; margin: 0px; outline:  |
| 4px; margin: 0px; outline: rgb(175,  | rgb(37, 37, 37) none 0px; padding: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; text-align: left; text-decoratio |
|  0px 14px; text-align: right; text-d | n: none; white-space: pre;"}`// tran |
| ecoration: none; white-space: pre; w | slate the attitude`{style="border: 0 |
| idth: 16px; background: none 0% 0% / | px none rgb(0, 130, 0); color: rgb(0 |
|  auto repeat scroll padding-box bord | , 130, 0); display: inline; font-sty |
| er-box rgb(255, 255, 255);">         | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
| 11                                   | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
| </div>                               |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; ou |
| <div                                 | tline: rgb(0, 130, 0) none 0px; padd |
| style="color: rgb(175, 175, 175); di | ing: 0px; text-align: left; text-dec |
| splay: block; font-style: normal; fo | oration: none; white-space: pre;"}   |
| nt-variant: normal; font-weight: nor |                                      |
| mal; font-stretch: normal; font-size | </div>                               |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | <div                                 |
| ot;Courier New&quot;, Courier, monos | style="border: 0px none rgb(37, 37,  |
| pace; height: 15px; line-height: 15. | 37); color: rgb(37, 37, 37); display |
| 4px; margin: 0px; outline: rgb(175,  | : block; font-style: normal; font-va |
| 175, 175) none 0px; padding: 0px 7px | riant: normal; font-weight: normal;  |
|  0px 14px; text-align: right; text-d | font-stretch: normal; font-size: 14p |
| ecoration: none; white-space: pre; w | x; font-family: Consolas, &quot;Bits |
| idth: 16px; background: none 0% 0% / | tream Vera Sans Mono&quot;, &quot;Co |
|  auto repeat scroll padding-box bord | urier New&quot;, Courier, monospace; |
| er-box rgb(255, 255, 255);">         |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| 12                                   | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| </div>                               | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
| <div                                 | roll padding-box border-box rgb(255, |
| style="color: rgb(175, 175, 175); di |  255, 255);">                        |
| splay: block; font-style: normal; fo |                                      |
| nt-variant: normal; font-weight: nor | `        `{style="border: 0px none r |
| mal; font-stretch: normal; font-size | gb(37, 37, 37); color: rgb(37, 37, 3 |
| : 14px; font-family: Consolas, &quot | 7); display: inline; font-style: nor |
| ;Bitstream Vera Sans Mono&quot;, &qu | mal; font-variant: normal; font-weig |
| ot;Courier New&quot;, Courier, monos | ht: normal; font-stretch: normal; fo |
| pace; height: 15px; line-height: 15. | nt-size: 14px; font-family: Consolas |
| 4px; margin: 0px; outline: rgb(175,  | , "Bitstream Vera Sans Mono", "Couri |
| 175, 175) none 0px; padding: 0px 7px | er New", Courier, monospace; line-he |
|  0px 14px; text-align: right; text-d | ight: 15.4px; margin: 0px; outline:  |
| ecoration: none; white-space: pre; w | rgb(37, 37, 37) none 0px; padding: 0 |
| idth: 16px; background: none 0% 0% / | px; text-align: left; text-decoratio |
|  auto repeat scroll padding-box bord | n: none; white-space: pre;"}`[data.a |
| er-box rgb(255, 255, 255);">         | ttitude multiplyByInverseOfAttitude: |
|                                      | initialAttitude];`{style="display: i |
| 13                                   | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
| </div>                               | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
| <div                                 | era Sans Mono", "Courier New", Couri |
| style="color: rgb(175, 175, 175); di | er, monospace; line-height: 15.4px;  |
| splay: block; font-style: normal; fo | margin: 0px; padding: 0px; text-alig |
| nt-variant: normal; font-weight: nor | n: left; text-decoration: none; whit |
| mal; font-stretch: normal; font-size | e-space: pre;"}                      |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 16px; background: none 0% 0% / | font-stretch: normal; font-size: 14p |
|  auto repeat scroll padding-box bord | x; font-family: Consolas, &quot;Bits |
| er-box rgb(255, 255, 255);">         | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 14                                   |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 1101px; bac |
| style="color: rgb(175, 175, 175); di | kground: none 0% 0% / auto repeat sc |
| splay: block; font-style: normal; fo | roll padding-box border-box rgb(255, |
| nt-variant: normal; font-weight: nor |  255, 255);">                        |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `        `{style="border: 0px none r |
| ;Bitstream Vera Sans Mono&quot;, &qu | gb(37, 37, 37); color: rgb(37, 37, 3 |
| ot;Courier New&quot;, Courier, monos | 7); display: inline; font-style: nor |
| pace; height: 15px; line-height: 15. | mal; font-variant: normal; font-weig |
| 4px; margin: 0px; outline: rgb(175,  | ht: normal; font-stretch: normal; fo |
| 175, 175) none 0px; padding: 0px 7px | nt-size: 14px; font-family: Consolas |
|  0px 14px; text-align: right; text-d | , "Bitstream Vera Sans Mono", "Couri |
| ecoration: none; white-space: pre; w | er New", Courier, monospace; line-he |
| idth: 16px; background: none 0% 0% / | ight: 15.4px; margin: 0px; outline:  |
|  auto repeat scroll padding-box bord | rgb(37, 37, 37) none 0px; padding: 0 |
| er-box rgb(255, 255, 255);">         | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// calc |
| 15                                   | ulate magnitude of the change from o |
|                                      | ur initial attitude`{style="border:  |
| </div>                               | 0px none rgb(0, 130, 0); color: rgb( |
|                                      | 0, 130, 0); display: inline; font-st |
| <div                                 | yle: normal; font-variant: normal; f |
| style="color: rgb(175, 175, 175); di | ont-weight: normal; font-stretch: no |
| splay: block; font-style: normal; fo | rmal; font-size: 14px; font-family:  |
| nt-variant: normal; font-weight: nor | Consolas, "Bitstream Vera Sans Mono" |
| mal; font-stretch: normal; font-size | , "Courier New", Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  line-height: 15.4px; margin: 0px; o |
| ;Bitstream Vera Sans Mono&quot;, &qu | utline: rgb(0, 130, 0) none 0px; pad |
| ot;Courier New&quot;, Courier, monos | ding: 0px; text-align: left; text-de |
| pace; height: 15px; line-height: 15. | coration: none; white-space: pre;"}  |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 16px; background: none 0% 0% / | style="border: 0px none rgb(37, 37,  |
|  auto repeat scroll padding-box bord | 37); color: rgb(37, 37, 37); display |
| er-box rgb(255, 255, 255);">         | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 16                                   | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| <div                                 |  height: 15px; line-height: 15.4px;  |
| style="color: rgb(175, 175, 175); di | margin: 0px; outline: rgb(37, 37, 37 |
| splay: block; font-style: normal; fo | ) none 0px; padding: 0px 14px; text- |
| nt-variant: normal; font-weight: nor | align: left; text-decoration: none;  |
| mal; font-stretch: normal; font-size | white-space: pre; width: 1101px; bac |
| : 14px; font-family: Consolas, &quot | kground: none 0% 0% / auto repeat sc |
| ;Bitstream Vera Sans Mono&quot;, &qu | roll padding-box border-box rgb(255, |
| ot;Courier New&quot;, Courier, monos |  255, 255);">                        |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | `        `{style="border: 0px none r |
| 175, 175) none 0px; padding: 0px 7px | gb(37, 37, 37); color: rgb(37, 37, 3 |
|  0px 14px; text-align: right; text-d | 7); display: inline; font-style: nor |
| ecoration: none; white-space: pre; w | mal; font-variant: normal; font-weig |
| idth: 16px; background: none 0% 0% / | ht: normal; font-stretch: normal; fo |
|  auto repeat scroll padding-box bord | nt-size: 14px; font-family: Consolas |
| er-box rgb(255, 255, 255);">         | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
| 17                                   | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
| </div>                               | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`double  |
| <div                                 | magnitude = [FacingViewController ma |
| style="color: rgb(175, 175, 175); di | gnitudeFromAttitude:data.attitude];` |
| splay: block; font-style: normal; fo | {style="display: inline; font-style: |
| nt-variant: normal; font-weight: nor |  normal; font-variant: normal; font- |
| mal; font-stretch: normal; font-size | weight: normal; font-stretch: normal |
| : 14px; font-family: Consolas, &quot | ; font-size: 14px; font-family: Cons |
| ;Bitstream Vera Sans Mono&quot;, &qu | olas, "Bitstream Vera Sans Mono", "C |
| ot;Courier New&quot;, Courier, monos | ourier New", Courier, monospace; lin |
| pace; height: 15px; line-height: 15. | e-height: 15.4px; margin: 0px; paddi |
| 4px; margin: 0px; outline: rgb(175,  | ng: 0px; text-align: left; text-deco |
| 175, 175) none 0px; padding: 0px 7px | ration: none; white-space: pre;"}    |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | </div>                               |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | <div                                 |
| er-box rgb(255, 255, 255);">         | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
| 18                                   | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| </div>                               | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| <div                                 | tream Vera Sans Mono&quot;, &quot;Co |
| style="color: rgb(175, 175, 175); di | urier New&quot;, Courier, monospace; |
| splay: block; font-style: normal; fo |  height: 15px; line-height: 15.4px;  |
| nt-variant: normal; font-weight: nor | margin: 0px; outline: rgb(37, 37, 37 |
| mal; font-stretch: normal; font-size | ) none 0px; padding: 0px 14px; text- |
| : 14px; font-family: Consolas, &quot | align: left; text-decoration: none;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | white-space: pre; width: 1101px; bac |
| ot;Courier New&quot;, Courier, monos | kground: none 0% 0% / auto repeat sc |
| pace; height: 15px; line-height: 15. | roll padding-box border-box rgb(255, |
| 4px; margin: 0px; outline: rgb(175,  |  255, 255);">                        |
| 175, 175) none 0px; padding: 0px 7px |                                      |
|  0px 14px; text-align: right; text-d | `        `{style="border: 0px none r |
| ecoration: none; white-space: pre; w | gb(37, 37, 37); color: rgb(37, 37, 3 |
| idth: 16px; background: none 0% 0% / | 7); display: inline; font-style: nor |
|  auto repeat scroll padding-box bord | mal; font-variant: normal; font-weig |
| er-box rgb(255, 255, 255);">         | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
| 19                                   | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
| </div>                               | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
| <div                                 | px; text-align: left; text-decoratio |
| style="color: rgb(175, 175, 175); di | n: none; white-space: pre;"}`// show |
| splay: block; font-style: normal; fo |  the prompt`{style="border: 0px none |
| nt-variant: normal; font-weight: nor |  rgb(0, 130, 0); color: rgb(0, 130,  |
| mal; font-stretch: normal; font-size | 0); display: inline; font-style: nor |
| : 14px; font-family: Consolas, &quot | mal; font-variant: normal; font-weig |
| ;Bitstream Vera Sans Mono&quot;, &qu | ht: normal; font-stretch: normal; fo |
| ot;Courier New&quot;, Courier, monos | nt-size: 14px; font-family: Consolas |
| pace; height: 15px; line-height: 15. | , "Bitstream Vera Sans Mono", "Couri |
| 4px; margin: 0px; outline: rgb(175,  | er New", Courier, monospace; line-he |
| 175, 175) none 0px; padding: 0px 7px | ight: 15.4px; margin: 0px; outline:  |
|  0px 14px; text-align: right; text-d | rgb(0, 130, 0) none 0px; padding: 0p |
| ecoration: none; white-space: pre; w | x; text-align: left; text-decoration |
| idth: 16px; background: none 0% 0% / | : none; white-space: pre;"}          |
|  auto repeat scroll padding-box bord |                                      |
| er-box rgb(255, 255, 255);">         | </div>                               |
|                                      |                                      |
| 20                                   | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 1101px; bac |
| 175, 175) none 0px; padding: 0px 7px | kground: none 0% 0% / auto repeat sc |
|  0px 14px; text-align: right; text-d | roll padding-box border-box rgb(255, |
| ecoration: none; white-space: pre; w |  255, 255);">                        |
| idth: 16px; background: none 0% 0% / |                                      |
|  auto repeat scroll padding-box bord | `        `{style="border: 0px none r |
| er-box rgb(255, 255, 255);">         | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
| 21                                   | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
| </div>                               | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
| <div                                 | er New", Courier, monospace; line-he |
| style="color: rgb(175, 175, 175); di | ight: 15.4px; margin: 0px; outline:  |
| splay: block; font-style: normal; fo | rgb(37, 37, 37) none 0px; padding: 0 |
| nt-variant: normal; font-weight: nor | px; text-align: left; text-decoratio |
| mal; font-stretch: normal; font-size | n: none; white-space: pre;"}`if`{sty |
| : 14px; font-family: Consolas, &quot | le="border: 0px none rgb(0, 102, 153 |
| ;Bitstream Vera Sans Mono&quot;, &qu | ); color: rgb(0, 102, 153); display: |
| ot;Courier New&quot;, Courier, monos |  inline; font-style: normal; font-va |
| pace; height: 15px; line-height: 15. | riant: normal; font-weight: bold; fo |
| 4px; margin: 0px; outline: rgb(175,  | nt-stretch: normal; font-size: 14px; |
| 175, 175) none 0px; padding: 0px 7px |  font-family: Consolas, "Bitstream V |
|  0px 14px; text-align: right; text-d | era Sans Mono", "Courier New", Couri |
| ecoration: none; white-space: pre; w | er, monospace; line-height: 15.4px;  |
| idth: 16px; background: none 0% 0% / | margin: 0px; outline: rgb(0, 102, 15 |
|  auto repeat scroll padding-box bord | 3) none 0px; padding: 0px; text-alig |
| er-box rgb(255, 255, 255);">         | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `(!showingPrompt &&  |
| 22                                   | (magnitude > showPromptTrigger)) {`{ |
|                                      | style="display: inline; font-style:  |
| </div>                               | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`sho |
|                                      | wingPrompt = YES;`{style="display: i |
|                                      | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`Pro |
|                                      | mptViewController *promptViewControl |
|                                      | ler = [weakSelf.storyboard instantia |
|                                      | teViewControllerWithIdentifier:@`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`"Prom |
|                                      | ptViewController"`{style="border: 0p |
|                                      | x none rgb(0, 0, 255); color: rgb(0, |
|                                      |  0, 255); display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; out |
|                                      | line: rgb(0, 0, 255) none 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}`]; |
|                                      | `{style="display: inline; font-style |
|                                      | : normal; font-variant: normal; font |
|                                      | -weight: normal; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
|                                      | solas, "Bitstream Vera Sans Mono", " |
|                                      | Courier New", Courier, monospace; li |
|                                      | ne-height: 15.4px; margin: 0px; padd |
|                                      | ing: 0px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre;"}   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`pro |
|                                      | mptViewController.modalTransitionSty |
|                                      | le = UIModalTransitionStyleCrossDiss |
|                                      | olve;`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`[we |
|                                      | akSelf presentViewController:promptV |
|                                      | iewController animated:YES completio |
|                                      | n:nil];`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// hide |
|                                      |  the prompt`{style="border: 0px none |
|                                      |  rgb(0, 130, 0); color: rgb(0, 130,  |
|                                      | 0); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 130, 0) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`if`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `(showingPrompt && ( |
|                                      | magnitude < showAnswerTrigger)) {`{s |
|                                      | tyle="display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`sho |
|                                      | wingPrompt = NO;`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `            `{style="border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(37, 37, 37) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`[we |
|                                      | akSelf dismissViewControllerAnimated |
|                                      | :YES completion:nil];`{style="displa |
|                                      | y: inline; font-style: normal; font- |
|                                      | variant: normal; font-weight: normal |
|                                      | ; font-stretch: normal; font-size: 1 |
|                                      | 4px; font-family: Consolas, "Bitstre |
|                                      | am Vera Sans Mono", "Courier New", C |
|                                      | ourier, monospace; line-height: 15.4 |
|                                      | px; margin: 0px; padding: 0px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`}`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 1101px; bac |
|                                      | kground: none 0% 0% / auto repeat sc |
|                                      | roll padding-box border-box rgb(255, |
|                                      |  255, 255);">                        |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

一切实现完毕，现在我们来看看效果，就像下面这样根据旋转角度会自动切换界面了：

![ss.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740631251562.gif "1414740631251562.gif")

**延伸阅读**

此前我看过一些关于CMAttitude[四元数](http://en.wikipedia.org/wiki/Quaternions_and_spatial_rotation)和[旋转矩阵](http://en.wikipedia.org/wiki/Rotation_matrix)的介绍，也不是很详尽。四元数实际上有个很[有趣的来源](http://en.wikipedia.org/wiki/History_of_quaternions)，也许你会觉得这个条目够长够满足你。

<span
style="border: 0px none rgb(0, 176, 80); color: rgb(0, 176, 80); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(0, 176, 80) none 0px; padding: 0px; text-decoration: none;">**优化**</span>

为了使代码的可读性更高，我们可以把所有有关CoreMotionManger的处理放到主队列中去。在实践中这样做会比让其在各自队列中调用好得多，起码不会让交互显得迟缓，不过我们需要回到主队列中更改一些元素。使用[NSOperationQueue](http://nshipster.com/nsoperation/)的addOperationWithblock方法即轻松实现：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 120px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 671 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 643px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Swift`{style="border: 0px none rg |
| r-box rgb(255, 255, 255);">          | b(0, 130, 0); color: rgb(0, 130, 0); |
|                                      |  display: inline; font-style: normal |
| 2                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="color: rgb(175, 175, 175); di | t: 15.4px; margin: 0px; outline: rgb |
| splay: block; font-style: normal; fo | (0, 130, 0) none 0px; padding: 0px;  |
| nt-variant: normal; font-weight: nor | text-align: left; text-decoration: n |
| mal; font-stretch: normal; font-size | one; white-space: pre;"}             |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 643px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `let queue = NSOperationQueue()manag |
| ;Bitstream Vera Sans Mono&quot;, &qu | er.startDeviceMotionUpdatesToQueue(q |
| ot;Courier New&quot;, Courier, monos | ueue) {`{style="display: inline; fon |
| pace; height: 15px; line-height: 15. | t-style: normal; font-variant: norma |
| 4px; margin: 0px; outline: rgb(175,  | l; font-weight: normal; font-stretch |
| 175, 175) none 0px; padding: 0px 7px | : normal; font-size: 14px; font-fami |
|  0px 14px; text-align: right; text-d | ly: Consolas, "Bitstream Vera Sans M |
| ecoration: none; white-space: pre; w | ono", "Courier New", Courier, monosp |
| idth: 8px; background: none 0% 0% /  | ace; line-height: 15.4px; margin: 0p |
| auto repeat scroll padding-box borde | x; padding: 0px; text-align: left; t |
| r-box rgb(255, 255, 255);">          | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
| 4                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="border: 0px none rgb(37, 37,  |
| style="color: rgb(175, 175, 175); di | 37); color: rgb(37, 37, 37); display |
| splay: block; font-style: normal; fo | : block; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: normal;  |
| mal; font-stretch: normal; font-size | font-stretch: normal; font-size: 14p |
| : 14px; font-family: Consolas, &quot | x; font-family: Consolas, &quot;Bits |
| ;Bitstream Vera Sans Mono&quot;, &qu | tream Vera Sans Mono&quot;, &quot;Co |
| ot;Courier New&quot;, Courier, monos | urier New&quot;, Courier, monospace; |
| pace; height: 15px; line-height: 15. |  height: 15px; line-height: 15.4px;  |
| 4px; margin: 0px; outline: rgb(175,  | margin: 0px; outline: rgb(37, 37, 37 |
| 175, 175) none 0px; padding: 0px 7px | ) none 0px; padding: 0px 14px; text- |
|  0px 14px; text-align: right; text-d | align: left; text-decoration: none;  |
| ecoration: none; white-space: pre; w | white-space: pre; width: 643px; back |
| idth: 8px; background: none 0% 0% /  | ground: none 0% 0% / auto repeat scr |
| auto repeat scroll padding-box borde | oll padding-box border-box rgb(255,  |
| r-box rgb(255, 255, 255);">          | 255, 255);">                         |
|                                      |                                      |
| 5                                    | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
| </div>                               | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| <div                                 | normal; font-stretch: normal; font-s |
| style="color: rgb(175, 175, 175); di | ize: 14px; font-family: Consolas, "B |
| splay: block; font-style: normal; fo | itstream Vera Sans Mono", "Courier N |
| nt-variant: normal; font-weight: nor | ew", Courier, monospace; line-height |
| mal; font-stretch: normal; font-size | : 15.4px; margin: 0px; outline: rgb( |
| : 14px; font-family: Consolas, &quot | 37, 37, 37) none 0px; padding: 0px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | text-align: left; text-decoration: n |
| ot;Courier New&quot;, Courier, monos | one; white-space: pre;"}`[weak self] |
| pace; height: 15px; line-height: 15. |  (data: CMDeviceMotion!, error: NSEr |
| 4px; margin: 0px; outline: rgb(175,  | ror!) `{style="display: inline; font |
| 175, 175) none 0px; padding: 0px 7px | -style: normal; font-variant: normal |
|  0px 14px; text-align: right; text-d | ; font-weight: normal; font-stretch: |
| ecoration: none; white-space: pre; w |  normal; font-size: 14px; font-famil |
| idth: 8px; background: none 0% 0% /  | y: Consolas, "Bitstream Vera Sans Mo |
| auto repeat scroll padding-box borde | no", "Courier New", Courier, monospa |
| r-box rgb(255, 255, 255);">          | ce; line-height: 15.4px; margin: 0px |
|                                      | ; padding: 0px; text-align: left; te |
| 6                                    | xt-decoration: none; white-space: pr |
|                                      | e;"}`in`{style="border: 0px none rgb |
| </div>                               | (0, 102, 153); color: rgb(0, 102, 15 |
|                                      | 3); display: inline; font-style: nor |
| <div                                 | mal; font-variant: normal; font-weig |
| style="color: rgb(175, 175, 175); di | ht: bold; font-stretch: normal; font |
| splay: block; font-style: normal; fo | -size: 14px; font-family: Consolas,  |
| nt-variant: normal; font-weight: nor | "Bitstream Vera Sans Mono", "Courier |
| mal; font-stretch: normal; font-size |  New", Courier, monospace; line-heig |
| : 14px; font-family: Consolas, &quot | ht: 15.4px; margin: 0px; outline: rg |
| ;Bitstream Vera Sans Mono&quot;, &qu | b(0, 102, 153) none 0px; padding: 0p |
| ot;Courier New&quot;, Courier, monos | x; text-align: left; text-decoration |
| pace; height: 15px; line-height: 15. | : none; white-space: pre;"}          |
| 4px; margin: 0px; outline: rgb(175,  |                                      |
| 175, 175) none 0px; padding: 0px 7px | </div>                               |
|  0px 14px; text-align: right; text-d |                                      |
| ecoration: none; white-space: pre; w | <div                                 |
| idth: 8px; background: none 0% 0% /  | style="border: 0px none rgb(37, 37,  |
| auto repeat scroll padding-box borde | 37); color: rgb(37, 37, 37); display |
| r-box rgb(255, 255, 255);">          | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
| 7                                    | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
| </div>                               | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| <div                                 |  height: 15px; line-height: 15.4px;  |
| style="color: rgb(175, 175, 175); di | margin: 0px; outline: rgb(37, 37, 37 |
| splay: block; font-style: normal; fo | ) none 0px; padding: 0px 14px; text- |
| nt-variant: normal; font-weight: nor | align: left; text-decoration: none;  |
| mal; font-stretch: normal; font-size | white-space: pre; width: 643px; back |
| : 14px; font-family: Consolas, &quot | ground: none 0% 0% / auto repeat scr |
| ;Bitstream Vera Sans Mono&quot;, &qu | oll padding-box border-box rgb(255,  |
| ot;Courier New&quot;, Courier, monos | 255, 255);">                         |
| pace; height: 15px; line-height: 15. |                                      |
| 4px; margin: 0px; outline: rgb(175,  | `    `{style="border: 0px none rgb(3 |
| 175, 175) none 0px; padding: 0px 7px | 7, 37, 37); color: rgb(37, 37, 37);  |
|  0px 14px; text-align: right; text-d | display: inline; font-style: normal; |
| ecoration: none; white-space: pre; w |  font-variant: normal; font-weight:  |
| idth: 8px; background: none 0% 0% /  | normal; font-stretch: normal; font-s |
| auto repeat scroll padding-box borde | ize: 14px; font-family: Consolas, "B |
| r-box rgb(255, 255, 255);">          | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| 8                                    | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| </div>                               | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`// motion p |
|                                      | rocessing here`{style="border: 0px n |
|                                      | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; outlin |
|                                      | e: rgb(0, 130, 0) none 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSOperation |
|                                      | Queue.mainQueue().addOperationWithBl |
|                                      | ock {`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// upda |
|                                      | te UI here`{style="border: 0px none  |
|                                      | rgb(0, 130, 0); color: rgb(0, 130, 0 |
|                                      | ); display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; outline: r |
|                                      | gb(0, 130, 0) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}`{style="d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 643px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 137px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255);">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="color: rgb(175, 175, 175); di | style="border: 0px none rgb(37, 37,  |
| splay: block; font-style: normal; fo | 37); bottom: 0px; color: rgb(37, 37, |
| nt-variant: normal; font-weight: nor |  37); display: block; font-style: no |
| mal; font-stretch: normal; font-size | rmal; font-variant: normal; font-wei |
| : 14px; font-family: Consolas, &quot | ght: normal; font-stretch: normal; f |
| ;Bitstream Vera Sans Mono&quot;, &qu | ont-size: 14px; font-family: Consola |
| ot;Courier New&quot;, Courier, monos | s, &quot;Bitstream Vera Sans Mono&qu |
| pace; height: 15px; line-height: 15. | ot;, &quot;Courier New&quot;, Courie |
| 4px; margin: 0px; outline: rgb(175,  | r, monospace; height: 120px; left: 0 |
| 175, 175) none 0px; padding: 0px 7px | px; line-height: 15.4px; margin: 0px |
|  0px 14px; text-align: right; text-d | ; outline: rgb(37, 37, 37) none 0px; |
| ecoration: none; white-space: pre; w |  padding: 0px; position: relative; r |
| idth: 8px; background: none 0% 0% /  | ight: 0px; text-align: left; text-de |
| auto repeat scroll padding-box borde | coration: none; top: 0px; width: 829 |
| r-box rgb(255, 255, 255);">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
| </div>                               | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="color: rgb(175, 175, 175); di | font-stretch: normal; font-size: 14p |
| splay: block; font-style: normal; fo | x; font-family: Consolas, &quot;Bits |
| nt-variant: normal; font-weight: nor | tream Vera Sans Mono&quot;, &quot;Co |
| mal; font-stretch: normal; font-size | urier New&quot;, Courier, monospace; |
| : 14px; font-family: Consolas, &quot |  height: 15px; line-height: 15.4px;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | margin: 0px; outline: rgb(37, 37, 37 |
| ot;Courier New&quot;, Courier, monos | ) none 0px; padding: 0px 14px; text- |
| pace; height: 15px; line-height: 15. | align: left; text-decoration: none;  |
| 4px; margin: 0px; outline: rgb(175,  | white-space: pre; width: 801px; back |
| 175, 175) none 0px; padding: 0px 7px | ground: none 0% 0% / auto repeat scr |
|  0px 14px; text-align: right; text-d | oll padding-box border-box rgb(255,  |
| ecoration: none; white-space: pre; w | 255, 255);">                         |
| idth: 8px; background: none 0% 0% /  |                                      |
| auto repeat scroll padding-box borde | `//Objective-C`{style="border: 0px n |
| r-box rgb(255, 255, 255);">          | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
| 2                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="color: rgb(175, 175, 175); di | -height: 15.4px; margin: 0px; outlin |
| splay: block; font-style: normal; fo | e: rgb(0, 130, 0) none 0px; padding: |
| nt-variant: normal; font-weight: nor |  0px; text-align: left; text-decorat |
| mal; font-stretch: normal; font-size | ion: none; white-space: pre;"}       |
| : 14px; font-family: Consolas, &quot |                                      |
| ;Bitstream Vera Sans Mono&quot;, &qu | </div>                               |
| ot;Courier New&quot;, Courier, monos |                                      |
| pace; height: 15px; line-height: 15. | <div                                 |
| 4px; margin: 0px; outline: rgb(175,  | style="border: 0px none rgb(37, 37,  |
| 175, 175) none 0px; padding: 0px 7px | 37); color: rgb(37, 37, 37); display |
|  0px 14px; text-align: right; text-d | : block; font-style: normal; font-va |
| ecoration: none; white-space: pre; w | riant: normal; font-weight: normal;  |
| idth: 8px; background: none 0% 0% /  | font-stretch: normal; font-size: 14p |
| auto repeat scroll padding-box borde | x; font-family: Consolas, &quot;Bits |
| r-box rgb(255, 255, 255);">          | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
| 3                                    |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
| </div>                               | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
| <div                                 | white-space: pre; width: 801px; back |
| style="color: rgb(175, 175, 175); di | ground: none 0% 0% / auto repeat scr |
| splay: block; font-style: normal; fo | oll padding-box border-box rgb(255,  |
| nt-variant: normal; font-weight: nor | 255, 255);">                         |
| mal; font-stretch: normal; font-size |                                      |
| : 14px; font-family: Consolas, &quot | `NSOperationQueue *queue = [[NSOpera |
| ;Bitstream Vera Sans Mono&quot;, &qu | tionQueue alloc] init];[manager star |
| ot;Courier New&quot;, Courier, monos | tDeviceMotionUpdatesToQueue:queue`{s |
| pace; height: 15px; line-height: 15. | tyle="display: inline; font-style: n |
| 4px; margin: 0px; outline: rgb(175,  | ormal; font-variant: normal; font-we |
| 175, 175) none 0px; padding: 0px 7px | ight: normal; font-stretch: normal;  |
|  0px 14px; text-align: right; text-d | font-size: 14px; font-family: Consol |
| ecoration: none; white-space: pre; w | as, "Bitstream Vera Sans Mono", "Cou |
| idth: 8px; background: none 0% 0% /  | rier New", Courier, monospace; line- |
| auto repeat scroll padding-box borde | height: 15.4px; margin: 0px; padding |
| r-box rgb(255, 255, 255);">          | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
| 4                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="border: 0px none rgb(37, 37,  |
| style="color: rgb(175, 175, 175); di | 37); color: rgb(37, 37, 37); display |
| splay: block; font-style: normal; fo | : block; font-style: normal; font-va |
| nt-variant: normal; font-weight: nor | riant: normal; font-weight: normal;  |
| mal; font-stretch: normal; font-size | font-stretch: normal; font-size: 14p |
| : 14px; font-family: Consolas, &quot | x; font-family: Consolas, &quot;Bits |
| ;Bitstream Vera Sans Mono&quot;, &qu | tream Vera Sans Mono&quot;, &quot;Co |
| ot;Courier New&quot;, Courier, monos | urier New&quot;, Courier, monospace; |
| pace; height: 15px; line-height: 15. |  height: 15px; line-height: 15.4px;  |
| 4px; margin: 0px; outline: rgb(175,  | margin: 0px; outline: rgb(37, 37, 37 |
| 175, 175) none 0px; padding: 0px 7px | ) none 0px; padding: 0px 14px; text- |
|  0px 14px; text-align: right; text-d | align: left; text-decoration: none;  |
| ecoration: none; white-space: pre; w | white-space: pre; width: 801px; back |
| idth: 8px; background: none 0% 0% /  | ground: none 0% 0% / auto repeat scr |
| auto repeat scroll padding-box borde | oll padding-box border-box rgb(255,  |
| r-box rgb(255, 255, 255);">          | 255, 255);">                         |
|                                      |                                      |
| 5                                    | `                             `{styl |
|                                      | e="border: 0px none rgb(37, 37, 37); |
| </div>                               |  color: rgb(37, 37, 37); display: in |
|                                      | line; font-style: normal; font-varia |
| <div                                 | nt: normal; font-weight: normal; fon |
| style="color: rgb(175, 175, 175); di | t-stretch: normal; font-size: 14px;  |
| splay: block; font-style: normal; fo | font-family: Consolas, "Bitstream Ve |
| nt-variant: normal; font-weight: nor | ra Sans Mono", "Courier New", Courie |
| mal; font-stretch: normal; font-size | r, monospace; line-height: 15.4px; m |
| : 14px; font-family: Consolas, &quot | argin: 0px; outline: rgb(37, 37, 37) |
| ;Bitstream Vera Sans Mono&quot;, &qu |  none 0px; padding: 0px; text-align: |
| ot;Courier New&quot;, Courier, monos |  left; text-decoration: none; white- |
| pace; height: 15px; line-height: 15. | space: pre;"}`withHandler:^(CMDevice |
| 4px; margin: 0px; outline: rgb(175,  | Motion *data, NSError *error) {`{sty |
| 175, 175) none 0px; padding: 0px 7px | le="display: inline; font-style: nor |
|  0px 14px; text-align: right; text-d | mal; font-variant: normal; font-weig |
| ecoration: none; white-space: pre; w | ht: normal; font-stretch: normal; fo |
| idth: 8px; background: none 0% 0% /  | nt-size: 14px; font-family: Consolas |
| auto repeat scroll padding-box borde | , "Bitstream Vera Sans Mono", "Couri |
| r-box rgb(255, 255, 255);">          | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; padding:  |
| 6                                    | 0px; text-align: left; text-decorati |
|                                      | on: none; white-space: pre;"}        |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="color: rgb(175, 175, 175); di | <div                                 |
| splay: block; font-style: normal; fo | style="border: 0px none rgb(37, 37,  |
| nt-variant: normal; font-weight: nor | 37); color: rgb(37, 37, 37); display |
| mal; font-stretch: normal; font-size | : block; font-style: normal; font-va |
| : 14px; font-family: Consolas, &quot | riant: normal; font-weight: normal;  |
| ;Bitstream Vera Sans Mono&quot;, &qu | font-stretch: normal; font-size: 14p |
| ot;Courier New&quot;, Courier, monos | x; font-family: Consolas, &quot;Bits |
| pace; height: 15px; line-height: 15. | tream Vera Sans Mono&quot;, &quot;Co |
| 4px; margin: 0px; outline: rgb(175,  | urier New&quot;, Courier, monospace; |
| 175, 175) none 0px; padding: 0px 7px |  height: 15px; line-height: 15.4px;  |
|  0px 14px; text-align: right; text-d | margin: 0px; outline: rgb(37, 37, 37 |
| ecoration: none; white-space: pre; w | ) none 0px; padding: 0px 14px; text- |
| idth: 8px; background: none 0% 0% /  | align: left; text-decoration: none;  |
| auto repeat scroll padding-box borde | white-space: pre; width: 801px; back |
| r-box rgb(255, 255, 255);">          | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
| 7                                    | 255, 255);">                         |
|                                      |                                      |
| </div>                               | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
| <div                                 | display: inline; font-style: normal; |
| style="color: rgb(175, 175, 175); di |  font-variant: normal; font-weight:  |
| splay: block; font-style: normal; fo | normal; font-stretch: normal; font-s |
| nt-variant: normal; font-weight: nor | ize: 14px; font-family: Consolas, "B |
| mal; font-stretch: normal; font-size | itstream Vera Sans Mono", "Courier N |
| : 14px; font-family: Consolas, &quot | ew", Courier, monospace; line-height |
| ;Bitstream Vera Sans Mono&quot;, &qu | : 15.4px; margin: 0px; outline: rgb( |
| ot;Courier New&quot;, Courier, monos | 37, 37, 37) none 0px; padding: 0px;  |
| pace; height: 15px; line-height: 15. | text-align: left; text-decoration: n |
| 4px; margin: 0px; outline: rgb(175,  | one; white-space: pre;"}`// motion p |
| 175, 175) none 0px; padding: 0px 7px | rocessing here`{style="border: 0px n |
|  0px 14px; text-align: right; text-d | one rgb(0, 130, 0); color: rgb(0, 13 |
| ecoration: none; white-space: pre; w | 0, 0); display: inline; font-style:  |
| idth: 8px; background: none 0% 0% /  | normal; font-variant: normal; font-w |
| auto repeat scroll padding-box borde | eight: normal; font-stretch: normal; |
| r-box rgb(255, 255, 255);">          |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| 8                                    | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; outlin |
| </div>                               | e: rgb(0, 130, 0) none 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 801px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`[[NSOperati |
|                                      | onQueue mainQueue] addOperationWithB |
|                                      | lock:^{`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 801px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `        `{style="border: 0px none r |
|                                      | gb(37, 37, 37); color: rgb(37, 37, 3 |
|                                      | 7); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(37, 37, 37) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`// upda |
|                                      | te UI here`{style="border: 0px none  |
|                                      | rgb(0, 130, 0); color: rgb(0, 130, 0 |
|                                      | ); display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; outline: r |
|                                      | gb(0, 130, 0) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 801px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`}];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="border: 0px none rgb(37, 37,  |
|                                      | 37); color: rgb(37, 37, 37); display |
|                                      | : block; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, &quot;Bits |
|                                      | tream Vera Sans Mono&quot;, &quot;Co |
|                                      | urier New&quot;, Courier, monospace; |
|                                      |  height: 15px; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(37, 37, 37 |
|                                      | ) none 0px; padding: 0px 14px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre; width: 801px; back |
|                                      | ground: none 0% 0% / auto repeat scr |
|                                      | oll padding-box border-box rgb(255,  |
|                                      | 255, 255);">                         |
|                                      |                                      |
|                                      | `}];`{style="display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}                                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

要清楚并不是所有的交互都用Core
Motion来实现就是最好的，通过motion来触发导航动作固然好不过也容易出现意外触发，漫无目的的动画也会让人产生审美疲劳。聪明的开发者取悦用户不应该依靠这些噱头，而是依靠合理的设计。

(本文由[Cocoachina](http://www.cocoachina.com/)翻译，转载请注明出处)

</div>

</div>

</div>

</div>

</div>
