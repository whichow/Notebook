深藏于每台iPhone光滑的屏幕之下，处于触摸屏与芯片之间，依偎在逻辑板之上的陀螺仪和加速器总是被众人所遗忘。

所以这些玩意拿来干嘛？当然是用来在旧式的点击和滑动之外开创新交互方式的啦，这里就要动用到Core Motion框架，这个东西能非常有效的驾驭住这些传感器。

对于使用了M7或者M8处理器的设备，Core Motion框架支持了一些预置的motion动作，比如脚步数、爬楼还有移动类型(行走、骑行等等)。

Core Motion可以让开发者从各个内置传感器那里获取未经修改的传感数据，并观测或响应设备各种运动和角度变化。这些传感器包括陀螺仪、加速器和磁力仪(罗盘)。

加速器和陀螺仪的数据都是描述沿着iOS设备三个方向轴上的位置，对于一个竖屏摆放的iPhone来说，X方向从设备的左边(负)到右边(正)，Y方向则是由设备的底部(-)到顶部(+)，而Z方向为垂直于屏幕由设备的背面(-)到正面(+)。

这些成组的数据根据不同的用法会有不同的表示方式，下面我们就开始来说一说。

![axes.png](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740167650216.png "1414740167650216.png")

**CoreMotionManager**

CoreMotionManager类能够使用到设备的所有移动数据(motion data)，Core Motion框架提供了两种对motion数据的操作方式，一个是"pull"，另一个是"push"，其中"pull"方式能够以CoreMotionManager的只读方式获取当前任何传感器状态或是组合数据。"push"方式则是以块或者闭包的形式收集到你想要得到的数据并且会在特定周期内得到实时的更新。

为了保证性能，苹果建议在使用CoreMotionManager的时候采用单件模式。

CoreMotionManager为四种motion数据类型的每一个都提供了统一的接口：accelerometer,gyro,magnetometer和deviceMotion。下面的例子演示了如何与陀螺仪交互的方式，当然如果是想跟其它设备交互的话只需要把下面的gyro替换成你想要使用的类型就行了。

**检测设备可用性**

[TABLE]

为了让事情在Swift和Objective-C之间变得简单且相同，这里就假设我们此前已经在所有示例中声明了一个manger实例作为视图控制器的属性。

**设置更新周期**

[TABLE]

这里的时间设置是NSTimeInterval类型，所以你需要将更新时间设置为秒级别的：这样会减缓响应的效率，不过能够有效的降低CPU的占用率。

**使用“pull”方式更新数据**

[TABLE]

在这段代码被调用之后，manger.gyroData即可随时可用，并反应当前设备陀螺仪数据。

**使用“push”方式更新数据**

[TABLE]

这段代码会根据给定的更新周期按一定频率被调用。

**停止更新**

[TABLE]

**使用加速器**

现在我们来试试为App的启动页添加一个有趣的功能，使得启动页的图片无论在设备如何倾斜的情况下都保持水平。

来思考一下下面的代码：

首先，我们需要检测确保我们设备上的加速器数据是可用的，然后指定一个频率很高的更新周期，接着在一个闭包中进行更新来旋转UIImageView属性。

[TABLE]

[TABLE]

每一个CMAccelerometerData包含了x,y,z三个值，每一个显示的是在该方向上的加速度，并以G为单位(G为重力加速度)。也就是说，如果你的设备保持静止然后竖直放置的话，加速度的值就是(0,-1,0)，而将其平放在桌面上就会是(0,0,-1)，而竖直向右倾斜45度的情况下，加速度的值则为(0.707,-0.707,0)。

![accelerometer.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740462245931.gif "1414740462245931.gif")

如上图，结果有些差强人意，你可以发现图片在旋转的时候会有一些抖动，而且移动设备的位置比起旋转设备而言，对加速器的影响可能更甚。这里可以依靠对读入的数据抽样取平均值来缓和问题，不过我们可以来看一看考虑进陀螺仪之后的效果。

**加入陀螺仪数据**

我们可以使用startGyroUpdates来获取无损的陀螺仪数据，不过在这里使用的是deviceMotion类型来获取加速器和陀螺仪的复合数据。通过使用陀螺仪，Core Motion能依靠重力加速度来区分用户的动作，     并且作为一个属性表示在我们从处理程序中获取的CMDeviceMotionData实例中。代码和第一个示例中的差不多：

[TABLE]

[TABLE]

来看看效果，会好得多：

![gravity.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740417191073.gif "1414740417191073.gif")

**UIClunkController敲击反应**

我们来试试别的，使用陀螺仪和加速器复合数据中的非重力部分来新添加一种交互方式。在这个示例中我们使用了CMDeviceMotionData中的userAcceleration属性，当用户将设备的左边缘敲击手掌的时候实现导航返回功能。

记住手中设备的X轴是穿过设备侧面的，并且向左为负值。假如设备感应到用户施加了一个向左大于2.5G的加速度，就会引发从栈堆中取出一个视图控制器界面。在这里比起前面的代码实现起来只用修改几行：

[TABLE]

[TABLE]

即刻见效：

![s.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740568323269.gif "1414740568323269.gif")

**获取Attitude**

我们可以通过使用陀螺仪的数据来获取更好的加速度数据，但是这并非唯一可用的改进——我们还可以获取设备在空间中的具体方位。在CMDeviceMotionData中有一个attitude属性，是一个CMAttitude类的实例。其中用了三种不同的方式表示了设备的方位：欧拉角，四元数和旋转矩阵，每一个都参考给定的坐标系。

**找到参考坐标系**

你可以设想一个根据设备某个方向来计算其他剩余角度的参考系，下面四中可用的参考系都假设设备平放在平面上，然后按照其指定的方向增加角度。

*CMAttitudeReferenceFrameXArbitraryZVertical* 描述的参考系默认设备平放(垂直于Z轴)，在X轴上取任意值。实际上当你开始刚开始对设备进行motion更新的时候X轴就被固定了。

*CMAttitudeReferenceFrameXArbitraryCorrectedZVertical* 本质上和上一个一样，不过这里还使用了罗盘来对陀螺仪的测量数据做了误差修正，当然对于CPU来说会增加一定的消耗(对电池也一样)。

*CMAttitudeReferenceFrameXMagneticNorthZVertical* 同样是默认设备平放，然后X轴(也就是设备的右侧)指向地磁北向。这一设置需要在使用前用设备画"8"字来校正罗盘。

*CMAttitudeReferenceFrameXTrueNorthZVertical* 和上面一个一样，不过这里参考的是真实的地磁北极，因此会需要使用位置数据和和罗盘。

对于我们想要实现的情况，默认的任意值参考系已经够用——一会儿你就知道为什么了。

**欧拉角**

三种表示方式中欧拉角是最容易理解的，它简单的描述了绕各坐标轴旋转的角度，这些坐标轴我们之前已经提到过。pitch是指绕X轴旋转，考虑设备平放，pitch增加则设备正面倾斜抬起，减小则后仰。roll是Y轴方向，增加则设备往右滚动，减少则往左。yaw是Z轴方向，逆时针方向增加，顺时针方向减少。

下述的这些值都是参考右手定则：右手虚握，大拇指竖起朝向任意轴的正方向，顺着剩余四指旋转方向为正，逆向为负。

**功能的实现**

现在我们来做一个你问我答形式的App界面，当屏幕旋转到面对被试者时只显示提示内容，而面对提问者的时候会自动切换到显示答案的界面。

根据参考系来计算切换会很麻烦，我们需要考虑设备的初始位置，然后才能定义设备正指向哪个方向，以及旋转到那一个角度才会被反过来。所以我们要用的方法是将一个CMAttitude实例保存起来，并以它算出一个欧拉角作为原点，之后所有的旋转都用multiplyByInverseOfAttitude()方法来换算方向。

当提问者点击按钮开始提问的时候我们就开始了交互过程——注意这里deviceMotion为initialAttitude使用到了"pull"方式。

[TABLE]

[TABLE]

接下来，调用我们熟悉的startDeviceMotionUpdates，计算一下由三个欧拉角描述的向量的大小，并作为切换视图的触发器。

[TABLE]

[TABLE]

一切实现完毕，现在我们来看看效果，就像下面这样根据旋转角度会自动切换界面了：

![ss.gif](详说CMDeviceMotion%20-%20CocoaChina_让移动开发更简单_files/1414740631251562.gif "1414740631251562.gif")

**延伸阅读**

此前我看过一些关于CMAttitude[四元数](http://en.wikipedia.org/wiki/Quaternions_and_spatial_rotation)和[旋转矩阵](http://en.wikipedia.org/wiki/Rotation_matrix)的介绍，也不是很详尽。四元数实际上有个很[有趣的来源](http://en.wikipedia.org/wiki/History_of_quaternions)，也许你会觉得这个条目够长够满足你。

**优化**

为了使代码的可读性更高，我们可以把所有有关CoreMotionManger的处理放到主队列中去。在实践中这样做会比让其在各自队列中调用好得多，起码不会让交互显得迟缓，不过我们需要回到主队列中更改一些元素。使用[NSOperationQueue](http://nshipster.com/nsoperation/)的addOperationWithblock方法即轻松实现：

[TABLE]

[TABLE]

要清楚并不是所有的交互都用Core Motion来实现就是最好的，通过motion来触发导航动作固然好不过也容易出现意外触发，漫无目的的动画也会让人产生审美疲劳。聪明的开发者取悦用户不应该依靠这些噱头，而是依靠合理的设计。

(本文由[Cocoachina](http://www.cocoachina.com/)翻译，转载请注明出处)


