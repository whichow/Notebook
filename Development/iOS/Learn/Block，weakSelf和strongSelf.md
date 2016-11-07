Block在Objective-C中很强大。但是有一个非常愚蠢的问题叫做循环引用陷阱，block会锁住一个对象使得对象永远不会被释放。

看下面这个例子，在函数中：

``` prettyprint
NSBlockOperation *op = [[[NSBlockOperation alloc] init] autorelease];[ op addExecutionBlock:^ {    [self doSomething];    [self doMoreThing];} ];[someOperationQueue addOperation:op];
```

当block被创建，编译器将捕获block中用到的所有对象并且将引用计数加1.在这里，self将被锁住，因此对象将不能被释放直到block完成。注意循环引用陷阱不仅仅发生在self对象上，但是在99%的情况下都发生在self对象上。

弱化
----

要解决这个问题，我们可以简单的创建一个self的弱引用，并且在block中使用这个弱对象替代原来的对象。当使用了这个弱对象，block将不会增加引用技术，因此self将不会被锁住。我们这样来弱化self。

``` prettyprint
__weak __typeof__(self) weakSelf = self;NSBlockOperation *op = [[[NSBlockOperation alloc] init] autorelease];[ op addExecutionBlock:^ {    [weakSelf doSomething];    [weakSelf doMoreThing];} ];[someOperationQueue addOperation:op];
```

什么时候应该使用弱化
--------------------

block完成后将会释放其中的所有对象。如果这个block是执行完成后将被释放的类型，例如：

-   GCD dispatch block
-   大部分的UIKit block

即使不使用弱化也将是安全的，因为block的生命周期是确定。然而，如果你正在使用的block将会被存为一个变量，例如：

-   NSOperation中的block，AFHTTPRequestOperation
-   事件处理block，像BlocksKit

因为block的生命周期不确定，建议使用弱化来放置循环引用陷阱。

强化
----

但是这又带来了一个新的问题。因为现在self是弱化的，self将被释放，weakSelf随时可能为nil。

要解决这个问题，我们可以在使用之前强化self：

``` prettyprint
__weak __typeof__(self) weakSelf = self;NSBlockOperation *op = [[[NSBlockOperation alloc] init] autorelease];[ op addExecutionBlock:^ {    __strong __typeof__(self) strongSelf = weakSelf;    [strongSelf doSomething];    [strongSelf doMoreThing];} ];[someOperationQueue addOperation:op];
```

什么时候应该使用强化
--------------------

然而，我们是否任何时候都应该在block中使用strongSelf？

当然，因为它任何时候都很安全。

你也可以不这么做，有些时候你可以简单的使用weakSelf当：

-   你并不关心self在block中将变为空值。例如，设置控制的值。注意尽管这过程中weakSelf可能被释放，它将变成空值但是并不会导致程序的崩溃。
-   你很确定self在这过程中将不会被释放。例如，所有的block都在主线程中运行。

语法糖
------

我们可以使用第三方库libextobjc使得你的代码可读性更好就像这样：

``` prettyprint
@weakify(self);NSBlockOperation *op = [[[NSBlockOperation alloc] init] autorelease];[ op addExecutionBlock:^ {    @strongify(self);       [self doSomething];    [self doMoreThing];} ];[someOperationQueue addOperation:op];
```


