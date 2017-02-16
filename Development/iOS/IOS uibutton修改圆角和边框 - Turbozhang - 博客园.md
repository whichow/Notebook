
```
UIButton *testButton = [UIButton buttonWithType:UIButtonTypeSystem];

    [testButton setFrame:CGRectMake(self.view.frame.size.width/2, self.view.frame.size.height/2, 100, 100)];

    [testButton setTitle:@"获取屏幕尺寸" forState:UIControlStateNormal];


    [testButton.layer setMasksToBounds:YES];//设置按钮的圆角半径不会被遮挡

    [testButton.layer setCornerRadius:10];

    [testButton.layer setBorderWidth:2];//设置边界的宽度

    

    //设置按钮的边界颜色

    CGColorSpaceRef colorSpaceRef = CGColorSpaceCreateDeviceRGB();

    CGColorRef color = CGColorCreate(colorSpaceRef, (CGFloat[]){1,0,0,1});

    [testButton.layer setBorderColor:color];

    
    [testButton addTarget:self action:@selector(touch) forControlEvents:UIControlEventTouchUpInside];

    [self.view addSubview:testButton];
```


效果：

![](../../Images/IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/171352504663132.png)

```
UIView的layer属性可以绘制UIView的各种效果。其实我们看到的View的动画实际上也是layer在绘制。

1、绘制圆角
    cornerView.layer.cornerRadius = 20;
    cornerView.layer.masksToBounds = YES;


masksToBounds防止子元素溢出父视图。
如果一个正方形要设置成圆形，代码为:
    cornerView.layer.cornerRadius = cornerView.frame.size.height/2;
    cornerView.layer.masksToBounds = YES;


2、绘制边框
    borderView.layer.borderWidth = 1.0;
    borderView.layer.borderColor = [UIColor blackColor].CGColor;

注意此处使用的是CGColor而不是UIColor.

3、绘制阴影
    shadowView.layer.shadowColor = [UIColor redColor].CGColor;
    shadowView.layer.shadowOffset = CGSizeMake(5.0, 5.0);
    shadowView.layer.shadowOpacity = YES;

offset为偏移量，为正表示向frame x，y坐标增加的方向偏移。
opacity为透明度，默认为0，即表示透明的。所以我们要把opacity设置成1或者YES，表示不透明，也可以设置成0.5或者类似的值呈现半透明。

效果如下：
```

![](../../Images/IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/171555168267012.png)


