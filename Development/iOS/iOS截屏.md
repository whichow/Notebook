iOS截屏方法

- 第一种方法 
```objc
UIGraphicsBeginImageContext(view.bounds.size);
[view.layer renderInContext:UIGraphicsGetCurrentContext()];
UIImage *resultingImage = UIGraphicsGetImageFromCurrentImageContext();
UIGraphicsEndImageContext();
```
<!--2. 
```objc
UIView *snapshotView = [UIScreen snapshotViewAfterScreenUpdates:YES];
//或
UIView *snapshotView = [view snapshotViewAfterScreenUpdates:YES];
```-->
- 这种方法可以截到OpenGL绘制的内容
```objc
UIGraphicsBeginImageContextWithOptions(view.bounds.size, NO, [UIScreen mainScreen].scale);
[view drawViewHierarchyInRect:self.bounds afterScreenUpdates:YES];
UIImage *image = UIGraphicsGetImageFromCurrentImageContext();
UIGraphicsEndImageContext();
```
- 使用OpenGL
```objc
NSInteger myDataLength = 1024 * 768 * 4;  
    
// allocate array and read pixels into it.  
GLubyte *buffer = (GLubyte *) malloc(myDataLength);  
glReadPixels(0, 0, 1024, 768, GL_RGBA, GL_UNSIGNED_BYTE, buffer);  
    
// gl renders "upside down" so swap top to bottom into new array.  
// there's gotta be a better way, but this works.  
GLubyte *buffer2 = (GLubyte *) malloc(myDataLength);  
for(int y = 0; y <768; y++)  
{  
    for(int x = 0; x <1024 * 4; x++)  
    {  
        buffer2[(767 - y) * 1024 * 4 + x] = buffer[y * 4 * 1024 + x];  
    }  
}  
    
// make data provider with data.  
CGDataProviderRef provider = CGDataProviderCreateWithData(NULL, buffer2, myDataLength, NULL);  
    
// prep the ingredients  
int bitsPerComponent = 8;  
int bitsPerPixel = 32;  
int bytesPerRow = 4 * 1024;  
CGColorSpaceRef colorSpaceRef = CGColorSpaceCreateDeviceRGB();  
CGBitmapInfo bitmapInfo = kCGBitmapByteOrderDefault;  
CGColorRenderingIntent renderingIntent = kCGRenderingIntentDefault;  
    
// make the cgimage  
CGImageRef imageRef = CGImageCreate(1024, 768, bitsPerComponent, bitsPerPixel, bytesPerRow, colorSpaceRef, bitmapInfo, provider, NULL, NO, renderingIntent);  
    
// then make the uiimage from that  
UIImage *myImage = [UIImage imageWithCGImage:imageRef];  
```
- 私有API，在iOS 64位SDK中已经不能使用了
```objc
UIImageRef imageRef = UIGetScreenImage();
```

**参考**

[Capture UIView and Save as Image](http://stackoverflow.com/questions/17145049/capture-uiview-and-save-as-image)

[How to get UIImage from EAGLView?](http://stackoverflow.com/questions/1352864/how-to-get-uiimage-from-eaglview/1945733)

[Alternative for UIGetScreenImage()](http://stackoverflow.com/questions/23309709/alternative-for-uigetscreenimage)

[iOS: what's the fastest, most performant way to make a screenshot programatically?](http://stackoverflow.com/questions/7964153/ios-whats-the-fastest-most-performant-way-to-make-a-screenshot-programaticall)

[分享iOS中常用的绘图, 截屏方法](http://www.jianshu.com/p/524454440bea)