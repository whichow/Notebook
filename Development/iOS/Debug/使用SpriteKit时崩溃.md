<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

按照苹果官方的SpriteKit例子，一运行就崩溃，发现时由于这一行导致的

</div>

<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
SKView *skView = (SKView *)self.view;
```

</div>

</div>

<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

因为self.view并不是一个SKView类，进行强转会出现问题

</div>

<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

需要在InterfaceBuilder中将View的类从UIView改成SKView。

</div>

<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

如果是手写代码的话需要加上

</div>

<div yne-bulb-block="paragraph"
style="white-space: pre-wrap; line-height: 1.5; font-size: 14px;">

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
self.view = [[SKView alloc] initWithFrame:frame];
```

</div>

<div>

\

</div>

</div>

\

