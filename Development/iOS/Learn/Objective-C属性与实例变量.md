<div>

<div>

很早之前，我们为接口同时声明了属性和底层实例变量，那时，属性是oc语言的一个新的机制，并且要求你必须声明与之对应的实例变量，例如：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@interface MyViewController :UIViewController{    UIButton *myButton;}@property (nonatomic, retain) UIButton *myButton;@end
```

</div>

<div>

后来，可以使用@synthesize关键字让编译器来合成getter和setter方法，并且生成实例变量。

</div>

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@interface MyViewController :UIViewController@property (nonatomic, retain) UIButton *myButton;@end
@implementation@synthesize myButton;...@end
```

</div>

</div>

<div>

在Xcode 4.4和
LLVM2.0之后，定义属性时编译器会自动合成getter和setter方法，并且创建一个以下划线开头的实例变量。

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@interface MyViewController :UIViewController@property (nonatomic, retain) UIButton *myButton;@end
```

</div>

</div>

<div>

推荐使用这种方式。<span
style="line-height: 1.6;">因为编译器会自动为你生成以下划线开头的实例变量\_myButton，不需要自己手动再去写实例变量。而且也不需要在.m文件中写@synthesize
myButton；也会自动为你生成setter，getter方法。</span>@synthesize的作用就是让编译器为你自动生成setter与getter方法<span
style="line-height: 1.6;">。</span>

</div>

<div>

\

</div>

<div>

实例变量不能用self.来引用，<span
style="line-height: 1.6;">例如在</span><span
style="line-height: 1.6;">.h文件</span><span
style="line-height: 1.6;">中有如下代码：</span>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@interface MyViewController :UIViewController{    NSString *name;}@end
```

</div>

<div>

<span style="line-height: 1.6;">.m文件中，self.name
这样的表达式是错误的。xcode会提示你使用-&gt;,改成self-&gt;name就可以了。因为oc中点表达式是表示调用方法，而上面的代码中没有name这个方法。但是可以直接使用name这个变量。</span>\

</div>

</div>

<div>

 

</div>

<div>

oc语法关于点表达式的说明："点表达式(.)看起来与C语言中的结构体访问以及java语言汇总的对象访问有点类似，其实这是oc的设计人员有意为之。如果点表达式出现在等号
＝
左边，该属性名称的setter方法将被调用。如果点表达式出现在右边，该属性名称的getter方法将被调用。"

</div>

<div>

 

</div>

<div>

所以在oc中点表达式其实就是调用对象的setter和getter方法的一种快捷方式，例如：<span
style="line-height: 1.6;">view.backgroundColor = \[UIColor
greenColor\] </span><span style="line-height: 1.6;">等价于 </span><span
style="line-height: 1.6;">\[view
setBackgroundColor:greenColor\]</span><span style="line-height: 1.6;">;
 UIColor \*color = view.background 等价于 UIColor \*color = \[view
backgroundColor\];</span>

</div>

<div>

\

</div>

<div>

<div>

@synthesize 还有一个作用，可以指定与属性对应的实例变量，例如@synthesize
myButton =
xxx；那么self.myButton其实是操作的实例变量xxx，而不是\_myButton了。

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@synthesize myButton = xxx;
```

</div>

<div>

<span
style="line-height: 1.6;">这样写了之后，那么编译器会自动生成xxx的实例变量，以及相应的getter和setter方法。注意：\_myButton这个实例变量是不存在的，因为自动生成的实例变量为xxx而不是\_myButton，所以现在@synthesize的作用就相当于指定实例变量；</span>\

</div>

</div>

</div>

<div>

\

</div>

<div>

如果自定义了setter方法，编译器是不会自动生成实例变量的，例如：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
@implementation PlayViewController@property(nonatomic, strong) AVPlayer *player;- (AVPlayer *)player {    return _player;}- (void)setPlayer:(AVPlayer *)player {    _player = player;}@end
```

</div>

<div>

编译器会报错 “Use of undeclared identifier
'\_player'”，必须手动定义实例变量

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
{    AVPlayer *_player;}
```

</div>

<div>

\

</div>

</div>

<div>

***注意：***

</div>

<div>

\

</div>

<div>

不要在init和dealloc中使用属性，因为这时候对象是否存在并不确定，给对象发消息不一定成功。

</div>

<div>

在getter和setter方法中也是不能使用属性来访问的，否则会造成getter和setter的无限递归调用。

</div>

<div>

\

</div>

<div>

在类的定义中可以使用属性(self.something)也可以使用成员变量(\_somthing)来访问，个人比较倾向于使用成员变量以做到代码风格的统一。

</div>

<div>

\

</div>

<div>

在不需要暴露给外部使用的时候可以在@implementation中定义属性或者只定义成员变量。<span
style="line-height: 1.6;"></span>

</div>
