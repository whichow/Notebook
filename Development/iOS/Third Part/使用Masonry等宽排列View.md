# 使用Masonry等宽排列View

```objc
/**
*   @param views         需要排列的View数组
*   @param containerView 容器View
*   @param padding       Views和容器View的边距 
*   @param spacing       Views之间的间距
**/
- (void)makeEqualWidthViews:(NSArray *)views inView:(UIView *)containerView withPadding:(UIEdgeInsets)padding andSpacing:(CGFloat)spacing
{
    UIView *lastView = nil;

    for (UIView *view in views) {
        [containerView addSubview:view];
        if (lastView) {
            [view mas_makeConstraints:^(MASConstraintMaker *make) {
                make.top.equalTo(containerView).offset(padding.top);
                make.bottom.equalTo(containerView).offset(-padding.bottom);
                make.left.equalTo(lastView.mas_right).offset(spacing);
                make.width.equalTo(lastView);
            }];
        }
        else {
            [view mas_makeConstraints:^(MASConstraintMaker *make) {
                make.top.equalTo(containerView).offset(padding.top);
                make.bottom.equalTo(containerView).offset(-padding.bottom);
                make.left.equalTo(containerView).offset(padding.left);
            }];
        }
        lastView = view;
    }
    [lastView mas_makeConstraints:^(MASConstraintMaker *make) {
        make.right.equalTo(containerView).offset(-padding.right);
    }];
}
```

**参考**

[iOS使用masonry快速将一组view在superview中等宽排列](http://www.cnblogs.com/ashamp/p/4481464.html)  
[Masonry使用总结](http://www.jianshu.com/p/99c418cd11f7)  
[Masonry介绍与使用实践(快速上手Autolayout)](http://adad184.com/2014/09/28/use-masonry-to-quick-solve-autolayout/)