
AR目前主要分为两种类型
1. 基于位置的AR
2. 基于图像识别的AR

基于图像识别的AR又可以分为
- 有标记AR(Marker Based AR)
- 无标记AR(Markerless AR)

基于位置的AR一般是通过GPS获取位置信息，在手机的位置靠近某个地方位置的时候，AR的内容就会在手机上面出现。

有标记的AR会识别标记的内容和位置，当摄像头扫描并识别到标记的时候就会显示AR的内容。

无标记的AR是指没有事先指定任何特定的识别内容，基于图像识别技术，通过摄像头实时扫描场景中的内容并标记一些有用的信息，如地形，边缘等。

前段时间很火的Pokemon Go将基于位置的AR和无标记的AR相结合的一种思路

另外Sony手机自带的相机应用有使用到AR技术，使用的是smartAR的无标记AR库

目前有无标记AR特性的一些AR SDK有

[kudan](https://www.kudan.eu/download-kudan-ar-sdk/)

[Wikitude](https://www.wikitude.com/)

[SmartAR](http://www.sonydna.com/sdna/solution/SmartAR_SDK.html)

无标记AR的一些技术主要有SLAM算法

还有一种简单的方式来实现AR，就是通过陀螺仪检测水平面

[ポケモンGOのAR（拡張現実）はどうゆう仕組み？](http://kayabaakihiko.hatenablog.com/entry/2016/09/16/170646)