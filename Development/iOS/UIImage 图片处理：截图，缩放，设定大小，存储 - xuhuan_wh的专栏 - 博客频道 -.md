UIImage 图片处理：截图，缩放，设定大小，存储 - xuhuan\_wh的专栏 - 博客频道 - CSDN.NET
[UIImage 图片处理：截图，缩放，设定大小，存储](http://blog.csdn.net/xuhuan_wh/article/details/6434055)
======================================================================================================

.

 标签： [ios](http://www.csdn.net/tag/ios)[iOS](http://www.csdn.net/tag/iOS)[IOS](http://www.csdn.net/tag/IOS)[UIImage](http://www.csdn.net/tag/UIImage)[存储](http://www.csdn.net/tag/%e5%ad%98%e5%82%a8)[截图](http://www.csdn.net/tag/%e6%88%aa%e5%9b%be)[设定大小](http://www.csdn.net/tag/%e8%ae%be%e5%ae%9a%e5%a4%a7%e5%b0%8f)

2011-05-20 11:38 55116人阅读 [评论](http://blog.csdn.net/xuhuan_wh/article/details/6434055#comments)(0) [收藏](# "收藏") [举报](http://blog.csdn.net/xuhuan_wh/article/details/6434055#report "举报")

.

![](UIImage%20图片处理：截图，缩放，设定大小，存储%20-%20xuhuan_wh的专栏%20-%20博客频道%20-_files/category_icon.jpg) 分类：

 IOS开发*（19）* ![](UIImage%20图片处理：截图，缩放，设定大小，存储%20-%20xuhuan_wh的专栏%20-%20博客频道%20-_files/1db119b0089be63f5674c35ec53f1d8f.jpg)

.

版权声明：本文为博主原创文章，未经博主允许不得转载。

图片的处理大概分 截图(capture),  缩放(scale), 设定大小(resize),  存储(save)

1.等比率缩放
- (UIImage \*)scaleImage:(UIImage \*)image toScale:(float)scaleSize

{

UIGraphicsBeginImageContext(CGSizeMake(image.size.width \* scaleSize, image.size.height \* scaleSize);
\[image drawInRect:CGRectMake(0, 0, image.size.width \* scaleSize, image.size.height \* scaleSize)\];
UIImage \*scaledImage = UIGraphicsGetImageFromCurrentImageContext();
UIGraphicsEndImageContext();

return scaledImage;

}

2.自定长宽
- (UIImage \*)reSizeImage:(UIImage \*)image toSize:(CGSize)reSize

{
UIGraphicsBeginImageContext(CGSizeMake(reSize.width, reSize.height));
\[image drawInRect:CGRectMake(0, 0, reSize.width, reSize.height)\];
UIImage \*reSizeImage = UIGraphicsGetImageFromCurrentImageContext();
UIGraphicsEndImageContext();

return reSizeImage;

}

3.处理某个特定View
只要是继承UIView的object 都可以处理
必须先import QuzrtzCore.framework

-(UIImage\*)captureView:(UIView \*)theView

{
CGRect rect = theView.frame;
UIGraphicsBeginImageContext(rect.size);
CGContextRef context = UIGraphicsGetCurrentContext();
\[theView.layer renderInContext:context\];
UIImage \*img = UIGraphicsGetImageFromCurrentImageContext();
UIGraphicsEndImageContext();

return img;

}

4.储存图片
储存图片这里分成储存到app的文件里和储存到手机的图片库里

1) 储存到app的文件里
NSString \*path = \[\[NSHomeDirectory()stringByAppendingPathComponent:@"Documents"\]stringByAppendingPathComponent:@"image.png"\];
\[UIImagePNGRepresentation(image) writeToFile:pathatomically:YES\];
把要处理的图片, 以image.png名称存到app home下的Documents目录里

2)储存到手机的图片库里(必须在真机使用，模拟器无法使用)
CGImageRef screen = UIGetScreenImage();
UIImage\* image = \[UIImage imageWithCGImage:screen\];
CGImageRelease(screen);
UIImageWriteToSavedPhotosAlbum(image, self, nil, nil);
UIGetScreenImage(); // 原来是private(私有)api, 用来截取整个画面,不过SDK 4.0后apple就开放了

//====================================================================================

以下代码用到了Quartz Framework 和 Core Graphics Framework. 在workspace的framework目录里添加这两个framework.在UIKit里，图像类UIImage和CGImageRef的画图操作都是通过Graphics Context来完成。Graphics Context封装了变换的参数，使得在不同的坐标系里操作图像非常方便。缺点就是，获取图像的数据不是那么方便。下面会给出获取数据区的代码。

 

1. 从UIView中获取图像相当于窗口截屏。

([iOS](http://lib.csdn.net/base/1 "Swift知识库")提供全局的全屏截屏函数UIGetScreenView(). 如果需要特定区域的图像，可以crop一下)

1.  CGImageRef screen = UIGetScreenImage();
2.  UIImage\* image = \[UIImage imageWithCGImage:screen\];

2. 对于特定UIView的截屏。

（可以把当前View的layer，输出到一个ImageContext中，然后利用这个ImageContext得到UIImage）

1.  -(UIImage\*)captureView: (UIView \*)theView
2.  {
3.  CGRect rect = theView.frame;
4.  UIGraphicsBeginImageContext(rect.size);
5.  CGContextRef context =UIGraphicsGetCurrentContext();
6.  \[theView.layer renderInContext:context\];
7.  UIImage \*img = UIGraphicsGetImageFromCurrentImageContext();
8.  UIGraphicsEndImageContext();
9.  
10. return img;
11. }

3. 如果需要裁剪指定区域。

（可以path & clip，以下例子是建一个200x200的图像上下文，再截取出左上角）

1.  UIGraphicsBeginImageContext(CGMakeSize(200,200));
2.  CGContextRefcontext=UIGraphicsGetCurrentContext();
3.  UIGraphicsPushContext(context);
4.  // ...把图写到context中，省略\[indent\]CGContextBeginPath();
5.  CGContextAddRect(CGMakeRect(0,0,100,100));
6.  CGContextClosePath();\[/indent\]CGContextDrawPath();
7.  CGContextFlush(); // 强制执行上面定义的操作
8.  UIImage\* image = UIGraphicGetImageFromCurrentImageContext();
9.  UIGraphicsPopContext();

4. 存储图像。

（分别存储到home目录文件和图片库文件。）

存储到目录文件是这样

1.  NSString \*path = \[\[NSHomeDirectory() stringByAppendingPathComponent:@"Documents"\] stringByAppendingPathComponent:@"image.png"\];
2.  \[UIImagePNGRepresentation(image) writeToFile:path atomically:YES\];

若要存储到图片库里面

1.  UIImageWriteToSavedPhotosAlbum(image, nil, nil, nil);

5.  互相转换UImage和CGImage。

（UImage封装了CGImage, 互相转换很容易）

1.  UIImage\* imUI=nil;
2.  CGImageRef imCG=nil;
3.  imUI = \[UIImage initWithCGImage:imCG\];
4.  imCG = imUI.CGImage;

6. 从CGImage上获取图像数据区。

（在apple dev上有QA, 不过好像还不支持ios）

下面给出一个在ios上反色的例子

1.  -(id)invertContrast:(UIImage\*)img
2.  {
3.  CGImageRef inImage = img.CGImage; 
4.  CGContextRef ctx;
5.  CFDataRef m\_DataRef;
6.  m\_DataRef = CGDataProviderCopyData(CGImageGetDataProvider(inImage)); 
7.  
8.  int width = CGImageGetWidth( inImage );
9.  int height = CGImageGetHeight( inImage );
10. 
11. int bpc = CGImageGetBitsPerComponent(inImage);
12. int bpp = CGImageGetBitsPerPixel(inImage);
13. int bpl = CGImageGetBytesPerRow(inImage);
14. 
15. UInt8 \* m\_PixelBuf = (UInt8 \*) CFDataGetBytePtr(m\_DataRef);
16. int length = CFDataGetLength(m\_DataRef);
17. 
18. NSLog(@"len %d", length);
19. NSLog(@"width=%d, height=%d", width, height);
20. NSLog(@"1=%d, 2=%d, 3=%d", bpc, bpp,bpl);
21. 
22. for (int index = 0; index &lt; length; index += 4)
23. { 
24. m\_PixelBuf\[index + 0\] = 255 - m\_PixelBuf\[index + 0\];// b
25. m\_PixelBuf\[index + 1\] = 255 - m\_PixelBuf\[index + 1\];// g
26. m\_PixelBuf\[index + 2\] = 255 - m\_PixelBuf\[index + 2\];// r
27. }
28. 
29. ctx = CGBitmapContextCreate(m\_PixelBuf, width, height, bpb, bpl, CGImageGetColorSpace( inImage ), kCGImageAlphaPremultipliedFirst );
30. CGImageRef imageRef = CGBitmapContextCreateImage (ctx);
31. UIImage\* rawImage = \[UIImage imageWithCGImage:imageRef\];
32. CGContextRelease(ctx);
33. return rawImage;
34. }

 

7. 显示图像数据区。

（显示图像数据区，也就是unsigned char\*转为graphics context或者UIImage或和CGImageRef）

1.  CGContextRef ctx = CGBitmapContextCreate(pixelBuf,width,height, bitsPerComponent,bypesPerLine, colorSpace,kCGImageAlphaPremultipliedLast );
2.  CGImageRef imageRef = CGBitmapContextCreateImage (ctx);
3.  UIImage\* image = \[UIImage imageWithCGImage:imageRef\];
4.  NSString\* path = \[\[NSHomeDirectory() stringByAppendingPathComponent:@"Documents"\] stringByAppendingPathComponent:@"ss.png"\];
5.  \[UIImagePNGRepresentation(self.image) writeToFile:path atomically:YES\];
6.  CGContextRelease(ctx);

得到图像数据区后就可以很方便的实现图像处理的算法。

完，欢迎指正！

 

[](http://blog.csdn.net/xuhuan_wh/article/details/6434055#) [](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到QQ空间") [](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到新浪微博") [](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到腾讯微博") [](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到人人网") [](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到微信") .

顶  
6

&nbsp;
踩  
0

.

[ ](#)

[ ](#)

-   上一篇[IOS4 UITableView详解](http://blog.csdn.net/xuhuan_wh/article/details/6256994)
-   下一篇[IOS -- UIButton 代码创建](http://blog.csdn.net/xuhuan_wh/article/details/6691682)

#### 我的同类文章

 IOS开发*（19）*

-   *•*[Xcode6 模拟器路径](http://blog.csdn.net/xuhuan_wh/article/details/50345641 "Xcode6 模拟器路径")2015-12-17*阅读***343**
-   *•*[IOS：修改NavigationController的后退按钮标题](http://blog.csdn.net/xuhuan_wh/article/details/8538565 "IOS：修改NavigationController的后退按钮标题")2013-01-24*阅读***2500**
-   *•*[IOS－－ UIView中的坐标转换](http://blog.csdn.net/xuhuan_wh/article/details/8486337 "IOS－－ UIView中的坐标转换")2013-01-09*阅读***47979**
-   *•*[IOS6.0 控制器展现方式总结](http://blog.csdn.net/xuhuan_wh/article/details/8474313 "IOS6.0 控制器展现方式总结")2013-01-09*阅读***2258**
-   *•*[IOS App资源路径](http://blog.csdn.net/xuhuan_wh/article/details/7474310 "IOS App资源路径")2012-04-18*阅读***8058**

&nbsp;
-   *•*[NSString+NSMutableString+NSValue+NSAraay用法汇总](http://blog.csdn.net/xuhuan_wh/article/details/8660188 "NSString+NSMutableString+NSValue+NSAraay用法汇总")2013-03-11*阅读***1229**
-   *•*[IOS: iPhone键盘通知与键盘定制](http://blog.csdn.net/xuhuan_wh/article/details/8506754 "IOS: iPhone键盘通知与键盘定制")2013-01-15*阅读***29968**
-   *•*[Xcode调试技巧](http://blog.csdn.net/xuhuan_wh/article/details/8480259 "Xcode调试技巧")2013-01-08*阅读***1883**
-   *•*[IOS6 控件专辑](http://blog.csdn.net/xuhuan_wh/article/details/8286171 "IOS6 控件专辑")2012-12-12*阅读***1237**
-   *•*[IOS -- UIButton 代码创建](http://blog.csdn.net/xuhuan_wh/article/details/6691682 "IOS -- UIButton 代码创建")2011-08-16*阅读***9530**

[更多文章](http://blog.csdn.net/xuhuan_wh/article/category/787880)


