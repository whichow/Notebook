C\#学习笔记
<div>

<div
style="margin: 0px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;">

<div>

**事件和委托：**

</div>

<div>

事件event是一种特殊的委托，加了event关键字后只能在该类中调用delegate，其他类中只能订阅(Subscribe,即+=）或取消订阅(Unsubscribe，即-=)该事件。

</div>

<div>

.net framework推荐使用了event关键字的delegate的原型最好类似delegate void
MyEventHandler(object sender, MyEventHandler e)。

</div>

<div>

**Stream：**

</div>

<div>

<span
style="color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">MemoryStream用来将数据转化为内存中的数据流，FileStream用来将文件转化为数据流。</span>

</div>

<div>

StreamReader、StreamWriter用来读取和写入如文本文件之类的基于文本的流，BinaryReader、BinaryWriter用来读取和写入二进制流。

</div>

<div>

**类型转换：**

</div>

<div>

可以使用BitConverter类。

</div>

<div>

**虚方法：**

</div>

<div>

默认情况下方法是非虚拟的，不能重写非虚拟方法。使用virtual关键字修饰的方法可以在子类中被重写，在子类中可以使用override关键字重写该方法。使用override会在该子类和继承于该子类及其派生类中覆盖掉改方法，使用new
关键字只会在该子类中隐藏基类中的方法。不加new或override关键字，编译器会发出警告，默认按new关键字执行。可以从子类中使用base关键字来调用基类方法。

</div>

<div>

**抽象方法和抽象类：**

</div>

<div>

使用abstract关键字来定义抽象类，抽象类中用abstract关键字来定义抽象方法，以abstract关键字定义的方法不能有实现，抽象类中可以有非抽象的方法，含有抽象方法的类一定是抽象类，继承抽象类的子类如果没有实现基类的抽象方法则也必须定义为抽象类。

</div>

<div>

**接口：**

</div>

<div>

接口使用interface关键字定义，接口中的方法都是抽象方法，接口中不能定义字段。

</div>

</div>

</div>
