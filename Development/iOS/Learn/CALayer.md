修改单独的CALayer属性值会触发隐式动画，在UIView中的CALayer不会触发隐式动画

self.layer = \[CALayer layer\];
self.layer.frame = CGRectMake(0, 0, 20, 3);

self.layer.background = \[UIColor greenColor\].CGColor;

\[view.layer addSublayer:self.layer\];
