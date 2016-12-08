# UIView坐标转换

CGRect转换
```objc
//从secondView转换到firstView
CGRect frame = [firstView convertRect:buttons.frame fromView:secondView];
//从firstView转换到secondView
CGRect frame = [firstView convertRect:buttons.frame toView:secondView];
```
CGPoint转换
```objc
//从secondView转换到firstView
CGRect frame = [firstView convertPoint:buttons.center fromView:secondView];
//从firstView转换到secondView
CGRect frame = [firstView convertPoint:buttons.center toView:secondView];
```