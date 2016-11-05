<div>

**实例方法和类方法：**

Objective-C中实例方法用"-"来表示，类方法(静态方法)用"+"来表示，使用self关键字来调用自身实例方法，使用类名来调用类方法。

要使该类的方法能够在外部调用需要在头文件中声明该方法。

**IBOutlet属性：**

IBOutlet用来指明一个变量可以被绑定在一些可视化组件中。

**@property关键字：**

interface中的变量是私有的，我们不能从这个类之外访问。如果要从外部访问这个变量，可以使用@property关键字。@property需要实现getter和setter方法，使用@synthesize关键字可以自动生成getter和setter方法。

**strong和weak：**

strong一般用在自己拥有的Objective-C对象中，weak一般用在引用的对象（如IBOutlet对象）或int,float等类型中。

\
强引用

默认引用方式

@property NSString \*firstName;等同于@property (strong) NSString
\*firstName;

NSString \*localName;等同于\_\_strong NSString \*localName;

强引用表示，只要引用存在，对象就不会销毁。

\

弱引用 -- 避开“强引用环”

@property (weak) id delegate;

NSObject \* \_\_weak weakVariable;

因为弱引用不保持对象处于可用，有可能会出现弱引用仍在使用，但是对应的对象已经销毁。为了避免出现这样的危险指针去访问已经释放的内存，当对应对象被销毁时弱引用自动被设为nil。

<span style="font-size: 17px;">Objective C的重要数据类型</span> {#objective-c的重要数据类型 style="border: 0px; margin-top: 2px; margin-bottom: 2px; font-size: 1.8em; line-height: 1.8em; color: rgb(51, 51, 51); font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, STHeiti, 'Microsoft Yahei', sans-serif; orphans: 2; white-space: normal; widows: 2;"}
---------------------------------------------------------------

  序号   数据类型
  ------ --------------------------
  1      NSString字符串
  2      CGfloat 浮点值的基本类型
  3      NSInteger 整型
  4      BOOL 布尔型

\

NSMutable和NSArray:

NSMutable是可变数组，NSArray是不可变数组

``` {.prettyprint .linenums .prettyprinted style=""}
NSMutableArray *aMutableArray = [[NSMutableArray alloc]init];[anArray addObject:@"firstobject"];NSArray *aImmutableArray = [[NSArray alloc] initWithObjects:@"firstObject",nil];
```

\

NSMutableDictionary和NSDictionary:

NSMutableDictionary可变NSDictionary不可变

``` {.prettyprint .linenums .prettyprinted style=""}
NSMutableDictionary*aMutableDictionary = [[NSMutableArray alloc]init];[aMutableDictionary setObject:@"firstobject" forKey:@"aKey"];NSDictionary*aImmutableDictionary= [[NSDictionary alloc]initWithObjects:[NSArray arrayWithObjects:@"firstObject",nil] forKeys:[ NSArray arrayWithObjects:@"aKey"]];
```

\
\

\

</div>
