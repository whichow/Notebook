
以一张图片为例 fakeXcode.png

下面以3种目录结构的方式引用这张图片：

 

1。直接拖进工程＋copy

image ＝ \[UIImage imageNamed: @"fakeXcode.png"\];

NSString \*path = \[\[NSBundle mainBundle\] pathForResource:@"fakeXcode" ofType:@"png"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

2.把文件夹拖进工程目录，然后拖进工程，create folder references for any added folder，（蓝色文件夹res）

image ＝ \[UIImage imageNamed: @"res/fakeXcode.png"\];

NSString \*path = \[\[NSBundle mainBundle\] pathForResource:@"fakeXcode.png" ofType:nil inDirectory:@"res"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

3.创建bundle，把资源放进bundle（白色bundle，res.bundle）

image ＝ \[UIImage imageNamed: @"es.bundle/fakeXcode.png"\];

NSString \*path = \[\[\[NSBundle mainBundle\] resourcePath\] stringByAppendingPathComponent:@"res.bundle/fakeXcode.png"\];

image ＝ \[\[UIImage alloc\]initWithContentsOfFile:path\];

 

个人认为第二种最方便, 可以创建蓝色文件夹. 达到资源分组的目的!

