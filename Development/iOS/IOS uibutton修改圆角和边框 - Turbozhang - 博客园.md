<div id="home">

<div id="main">

<div id="mainContent">

<div class="forFlow">

<div id="post_detail">

<div id="topics">

<div class="post">

<div class="postBody">

<div
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 2263.6px; line-height: 25.2px; margin: 0px 0px 20px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-decoration: none; width: 848.4px; word-break: break-word;">

<div
style="border: 0.8px solid rgb(204, 204, 204); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 647.6px; line-height: 21.6px; margin: 5px 0px; overflow: auto; padding: 5px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 27.2px; line-height: 21.6px; margin: 5px 0px 0px; padding: 0px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; line-height: 18px; margin: 0px; padding: 0px 5px 0px 0px; text-decoration: none; word-break: break-word;">[![复制代码](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/copycode.gif)]( "复制代码")</span>

</div>

``` {style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: "Courier New"; height: 583.2px; line-height: 21.6px; margin: 0px; padding: 0px; text-decoration: none; white-space: pre-wrap; width: 836.8px; word-break: break-word; word-wrap: break-word;"}
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

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 27.2px; line-height: 21.6px; margin: 5px 0px 0px; padding: 0px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; line-height: 18px; margin: 0px; padding: 0px 5px 0px 0px; text-decoration: none; word-break: break-word;">[![复制代码](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/copycode.gif)]( "复制代码")</span>

</div>

</div>

效果：

![](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/171352504663132.png)

 

<div
style="border: 0.8px solid rgb(204, 204, 204); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 669.2px; line-height: 21.6px; margin: 5px 0px; overflow: auto; padding: 5px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 27.2px; line-height: 21.6px; margin: 5px 0px 0px; padding: 0px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; line-height: 18px; margin: 0px; padding: 0px 5px 0px 0px; text-decoration: none; word-break: break-word;">[![复制代码](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/copycode.gif)]( "复制代码")</span>

</div>

``` {style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: "Courier New"; height: 604.8px; line-height: 21.6px; margin: 0px; padding: 0px; text-decoration: none; white-space: pre-wrap; width: 836.8px; word-break: break-word; word-wrap: break-word;"}
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

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; height: 27.2px; line-height: 21.6px; margin: 5px 0px 0px; padding: 0px; text-decoration: none; width: 836.8px; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(245, 245, 245);">

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: &quot;Courier New&quot;; line-height: 18px; margin: 0px; padding: 0px 5px 0px 0px; text-decoration: none; word-break: break-word;">[![复制代码](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/copycode.gif)]( "复制代码")</span>

</div>

</div>

![](IOS%20uibutton修改圆角和边框%20-%20Turbozhang%20-%20博客园_files/171555168267012.png)

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>
