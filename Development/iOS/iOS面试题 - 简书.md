<div id="show-note-container">

<div id="flag" class="post-bg">

<div class="container">

<div class="article">

<div class="preview">

<div
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 1452px; line-height: 27.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;">

KVC的底层实现？ {#kvc的底层实现 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
---------------

当一个对象调用setValue方法时，方法内部会做以下操作：\
①检查是否存在相应key的set方法，如果存在，就调用set方法\
②如果set方法不存在，就会查找与key相同名称并且带下划线的成员属性，如果有，则直接给成员属性赋值\
③如果没有找到\_key,就会查找相同名称的属性key，如果有就直接赋值\
④如果还没找到，则调用valueForUndefinedKey:和setValue:forUndefinedKey:方法。\
这些方法的默认实现都是抛出异常，我们可以根据需要重写它们。

**block和**weak修饰符的区别？ {#block和weak修饰符的区别 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
-----------------------------

1.**block不管是ARC还是MRC模式下都可以使用，可以修饰对象，还可以修饰基本数据类型。\
2.**weak只能在ARC模式下使用，也只能修饰对象（NSString），不能修饰基本数据类型（int）。\
3.**block对象可以在block中被重新赋值，**weak不可以。

block和代理的区别，哪个更好？ {#block和代理的区别哪个更好 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
-----------------------------

代理回调更面向过程，block更面向结果。\
如果需要在执行的不同步骤时被通知，你就要使用代理。\
如果只需要请求的消息或者失败的详情，应该使用block。\
block更适合与状态无关的操作，比如被告知某些结果，block之间是不会相互影响的。\
但是代理更像一个生产流水线，每个回调方法是生产线上的一个处理步骤，一个回调的变动可能会引起另一个回调的变动。\
要是一个对象有超过一个的不同事件，应该使用代理。\
一个对象只有一个代理，要是某个对象是个单例对象，就不能使用代理。\
要是一个对象调用方法需要返回一些额外的信息，就可能需要使用代理。

UI控件为什么不用strong用weak？ {#ui控件为什么不用strong用weak style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
------------------------------

控制器有个强指针View属性，View属性指向内存中的一个UIView，UIView内部有一个强指针subviews属性，\
指向一个装着UIView全部的子控件的强指针数组，数组中又有强指针指向UIView中存在的子控件。\
所以，只要控制器在，View就在，View中的子控件就在，所以，ui控件没必要用强指针，用weak就可以。

自定义视图中重写layoutsubView需要调用父类的layoutsubView吗，为什么？ {#自定义视图中重写layoutsubview需要调用父类的layoutsubview吗为什么 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 86px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
--------------------------------------------------------------------

如果重写的控件是UIView不调用父类的layoutsubView也没关系，里面没有任何子控件，所以不会做什么事情。一般系统自带视图中有子控件的都会重写layoutSubviews方法，因此我们自定义系统自带控件并且重写layoutSubviews必须调用\[super
layoutSubviews\],先布局系统自带子控件的位置和尺寸，才设置我们自己的控件位置和尺寸。否则会发现想用系统自带视图的子控件的时候，会出现意想不到的效果。

NSString 的时候用copy和strong的区别？ {#nsstring-的时候用copy和strong的区别 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
-------------------------------------

OC中NSString为不可变字符串的时候，用copy和strong都是只分配一次内存，但是如果用copy的时候，需要先判断字符串是否是不可变字符串，如果是不可变字符串，就不再分配空间，如果是可变字符串才分配空间。如果程序中用到NSString的地方特别多，每一次都要先进行判断就会耗费性能，影响用户体验，用strong就不会再进行判断，所以，不可变字符串可以直接用strong。

</div>

</div>

</div>

</div>

</div>

</div>
