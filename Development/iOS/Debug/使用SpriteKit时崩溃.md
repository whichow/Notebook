按照苹果官方的SpriteKit例子，一运行就崩溃，发现时由于这一行导致的

``` prettyprint
SKView *skView = (SKView *)self.view;
```

因为self.view并不是一个SKView类，进行强转会出现问题

需要在InterfaceBuilder中将View的类从UIView改成SKView。

如果是手写代码的话需要加上

``` prettyprint
self.view = [[SKView alloc] initWithFrame:frame];
```


