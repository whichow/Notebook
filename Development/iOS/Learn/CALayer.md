<div>

修改单独的CALayer属性值会触发隐式动画，在UIView中的CALayer不会触发隐式动画

</div>

<div>

\

</div>

self.layer = \[CALayer layer\];
<div>

self.layer.frame = CGRectMake(0, 0, 20, 3);

</div>

<div>

self.layer.background = \[UIColor greenColor\].CGColor;

</div>

<div>

\

</div>

<div>

\[view.layer addSublayer:self.layer\];

</div>
