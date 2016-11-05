UIImage 图片处理：截图，缩放，设定大小，存储 - xuhuan\_wh的专栏 -
博客频道 - CSDN.NET
<div>

<div style="-evernote-webclip:true">

\
<div style="font-size: 16px">

<div>

<div
style="color:rgb(51, 51, 51);text-align:center;font-size:12px;font-family:Arial, Console, Verdana, &quot;Courier New&quot;;background:url(&quot;&quot;) 0px 20px repeat-x;">

<div style="background:url(&quot;&quot;) center top no-repeat;">

<div
style="overflow:hidden;border-radius:8px;text-align:left;background:rgb(255, 255, 255);">

<div style="overflow:hidden;border-radius:4px;">

<div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:5479px;">

<div
style="line-height:30px;display:block;color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:20px;margin:5px 0px;font-family:&quot;Microsoft YaHei&quot;;border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:31px;">

<span
style="display:inline-block;width:19px;height:19px;margin:0px 2px 0px 0px;vertical-align:middle;background:url(&quot;&quot;) 0px 0px no-repeat;border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;"></span>
<span style="border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">[UIImage 图片处理：截图，缩放，设定大小，存储](http://blog.csdn.net/xuhuan_wh/article/details/6434055)</span> {#uiimage-图片处理截图缩放设定大小存储 style="font-size:20px;margin:0px;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(0, 0, 0);padding:0px;font-stretch:normal;font-weight:normal;line-height:30px;font-family:"Microsoft YaHei";vertical-align:middle;font-variant:normal;font-style:normal;display:inline;box-shadow:none;"}
=================================================================================================================================================================================================================================

<span
style="color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-size:20px;line-height:30px;font-family:&quot;Microsoft YaHei&quot;;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="border-bottom-width:1px;padding:0px 20px 5px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:12px;line-height:22px;font-family:Arial;text-align:right;display:block;color:rgb(153, 153, 153);border-bottom-style:solid;border-bottom-color:rgb(237, 237, 237);margin:0px -20px;overflow:hidden;border:;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:44px;">

<div
style="width:708px;float:left;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;height:22px;">

<span
style="margin:0px 5px;float:left;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:306.734px;height:22px;">
标签：
[ios](http://www.csdn.net/tag/ios)[iOS](http://www.csdn.net/tag/iOS)[IOS](http://www.csdn.net/tag/IOS)[UIImage](http://www.csdn.net/tag/UIImage)[存储](http://www.csdn.net/tag/%e5%ad%98%e5%82%a8)[截图](http://www.csdn.net/tag/%e6%88%aa%e5%9b%be)[设定大小](http://www.csdn.net/tag/%e8%ae%be%e5%ae%9a%e5%a4%a7%e5%b0%8f)
</span>

</div>

<div
style="border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:44px;">

<span
style="margin:0px 5px 0px 0px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">2011-05-20
11:38</span> <span title="阅读次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) left center no-repeat;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;">55116人阅读</span>
<span title="评论次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) left center no-repeat;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:url(&quot;&quot;);box-shadow:none;">
[评论](http://blog.csdn.net/xuhuan_wh/article/details/6434055#comments)(0)</span>
<span
style="margin:0px 5px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[收藏](# "收藏")</span> <span
style="margin:0px 5px;border:0px none rgb(153, 153, 153);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
[举报](http://blog.csdn.net/xuhuan_wh/article/details/6434055#report "举报")</span>

</div>

<span
style="color:rgb(153, 153, 153);font-style:normal;font-variant:normal;font-weight:normal;font-size:12px;line-height:22px;font-family:Arial;text-align:right;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="height:46px;display:block;border-bottom-width:1px;border-bottom-style:solid;border-bottom-color:rgb(237, 237, 237);padding:0px 20px;margin:0px -20px;border:;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;">

<div
style="display:inline-block;font-size:14px;color:rgb(51, 51, 51);border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:60.8906px;height:17px;">

![](UIImage%20图片处理：截图，缩放，设定大小，存储%20-%20xuhuan_wh的专栏%20-%20博客频道%20-_files/category_icon.jpg){width="15"
height="13"} <span
style="display:inline-block;vertical-align:middle;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:42px;height:16px;">分类：</span>

</div>

<div
style="display:inline-block;font-size:14px;color:rgb(223, 52, 52);border:0px none rgb(223, 52, 52);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:124.594px;height:46px;">

<span
style="border:0px none rgb(223, 52, 52);display:inline-block;cursor:pointer;line-height:46px;position:relative;margin-left:15px;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:109.594px;height:46px;">
<span
style="border:0px none rgb(223, 52, 52);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">IOS开发*（19）*</span>
![](UIImage%20图片处理：截图，缩放，设定大小，存储%20-%20xuhuan_wh的专栏%20-%20博客频道%20-_files/1db119b0089be63f5674c35ec53f1d8f.jpg){width="10"
height="5"} </span>

</div>

<span
style="display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="padding:20px 0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:42px;">

版权声明：本文为博主原创文章，未经博主允许不得转载。

</div>

<div
style="font-family:Arial;margin:20px 0px 0px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:14px;line-height:26px;font-style:normal;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:4678px;">

<span
style="font-size:14px;font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">图片的处理大概分
截图(capture),  缩放(scale), 设定大小(resize),  存储(save)</span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">1.等比率缩放</span>\
<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">-
(UIImage \*)scaleImage:(UIImage \*)image
toScale:(float)scaleSize</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsBeginImageContext(CGSizeMake(image.size.width
\* scaleSize, image.size.height \* scaleSize);\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[image
drawInRect:CGRectMake(0, 0, image.size.width \* scaleSize,
image.size.height \* scaleSize)\];\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage
\*scaledImage = UIGraphicsGetImageFromCurrentImageContext();\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsEndImageContext();</span></span>

<span
style="font-family:mceinline;font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span>return
scaledImage;</span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
<span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">2.自定长宽</span>\
<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">-
(UIImage \*)reSizeImage:(UIImage \*)image
toSize:(CGSize)reSize</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsBeginImageContext(CGSizeMake(reSize.width,
reSize.height));\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[image
drawInRect:CGRectMake(0, 0, reSize.width, reSize.height)\];\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage
\*reSizeImage = UIGraphicsGetImageFromCurrentImageContext();\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsEndImageContext();</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">return
reSizeImage;</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
<span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">3.处理某个特定View</span>\
<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">只要是继承UIView的object
都可以处理</span>\
<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">必须先import
QuzrtzCore.framework</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
-(UIImage\*)captureView:(UIView \*)theView</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGRect
rect = theView.frame;\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsBeginImageContext(rect.size);\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRef
context = UIGraphicsGetCurrentContext();\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[theView.layer
renderInContext:context\];\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage
\*img = UIGraphicsGetImageFromCurrentImageContext();\
</span><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsEndImageContext();</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">return
img;</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
<span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">4.储存图片</span>\
<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">储存图片这里分成储存到app的文件里和储存到手机的图片库里</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">1) 储存到app的文件里\
NSString \*path =
\[\[NSHomeDirectory()stringByAppendingPathComponent:@"Documents"\]stringByAppendingPathComponent:@"image.png"\];\
\[UIImagePNGRepresentation(image) writeToFile:pathatomically:YES\];\
把要处理的图片, 以image.png名称存到app
home下的Documents目录里</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">2)储存到手机的图片库里(<span
style="font-family:mceinline;font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">必须在真机使用，模拟器无法使用</span>)\
CGImageRef screen = UIGetScreenImage();\
UIImage\* image = \[UIImage imageWithCGImage:screen\];\
CGImageRelease(screen);\
UIImageWriteToSavedPhotosAlbum(image, self, nil, nil);\
UIGetScreenImage(); // 原来是private(私有)api, 用来截取整个画面,不过SDK
4.0后apple就开放了</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">//====================================================================================</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">以下代码用到了Quartz
Framework 和 Core Graphics Framework.
在workspace的framework目录里添加这两个framework.在UIKit里，图像类UIImage和CGImageRef的画图操作都是通过Graphics
Context来完成。Graphics
Context封装了变换的参数，使得在不同的坐标系里操作图像非常方便。缺点就是，获取图像的数据不是那么方便。下面会给出获取数据区的代码。</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"> </span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">1.
从UIView中获取图像相当于窗口截屏。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">([iOS](http://lib.csdn.net/base/1 "Swift知识库")提供全局的全屏截屏函数UIGetScreenView().
如果需要特定区域的图像，可以crop一下)</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImageRef
    screen = UIGetScreenImage();\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage\*
    image = \[UIImage imageWithCGImage:screen\];</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">2.
对于特定UIView的截屏。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（可以把当前View的layer，输出到一个ImageContext中，然后利用这个ImageContext得到UIImage）</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">-(UIImage\*)captureView:
    (UIView \*)theView\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{\
    </span></span>
3.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGRect
    rect = theView.frame;\
    </span></span>
4.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsBeginImageContext(rect.size);\
    </span></span>
5.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRef
    context =UIGraphicsGetCurrentContext();\
    </span></span>
6.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[theView.layer
    renderInContext:context\];\
    </span></span>
7.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage
    \*img = UIGraphicsGetImageFromCurrentImageContext();\
    </span></span>
8.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsEndImageContext();\
    </span></span>
9.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
10. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">return
    img;\
    </span></span>
11. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">3.
如果需要裁剪指定区域。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（可以path
&
clip，以下例子是建一个200x200的图像上下文，再截取出左上角）</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsBeginImageContext(CGMakeSize(200,200));\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRefcontext=UIGraphicsGetCurrentContext();\
    </span></span>
3.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsPushContext(context);\
    </span></span>
4.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">//
    ...把图写到context中，省略\[indent\]CGContextBeginPath();\
    </span></span>
5.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextAddRect(CGMakeRect(0,0,100,100));\
    </span></span>
6.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextClosePath();\[/indent\]CGContextDrawPath();\
    </span></span>
7.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextFlush();
    </span><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">//
    强制执行上面定义的操作\
    </span></span>
8.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage\*
    image = UIGraphicGetImageFromCurrentImageContext();\
    </span></span>
9.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIGraphicsPopContext();</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">4.
存储图像。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（分别存储到home目录文件和图片库文件。）</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">存储到目录文件是这样</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">NSString
    \*path = \[\[NSHomeDirectory()
    stringByAppendingPathComponent:@"Documents"\]
    stringByAppendingPathComponent:@"image.png"\];\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[UIImagePNGRepresentation(image)
    writeToFile:path atomically:YES\];</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">若要存储到图片库里面</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImageWriteToSavedPhotosAlbum(image,
    nil, nil, nil);</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
<span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">5.
<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"> 互相转换<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UImage和<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImage。</span></span></span></span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（UImage封装了CGImage,
互相转换很容易）</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage\*
    imUI=nil;\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImageRef
    imCG=nil;\
    </span></span>
3.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">imUI
    = \[UIImage initWithCGImage:imCG\];\
    </span></span>
4.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">imCG
    = imUI.CGImage;</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">6.
从CGImage上获取图像数据区。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（在apple
dev上有QA, 不过好像还不支持ios）</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
下面给出一个在ios上反色的例子</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">-(id)invertContrast:(UIImage\*)img\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{\
    </span></span>
3.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImageRef
    inImage = img.CGImage; \
    </span></span>
4.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRef
    ctx;\
    </span></span>
5.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CFDataRef
    m\_DataRef;\
    </span></span>
6.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">m\_DataRef
    = CGDataProviderCopyData(CGImageGetDataProvider(inImage)); \
    </span></span>
7.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
8.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    width = CGImageGetWidth( inImage );\
    </span></span>
9.  <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    height = CGImageGetHeight( inImage );\
    </span></span>
10. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
11. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    bpc = CGImageGetBitsPerComponent(inImage);\
    </span></span>
12. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    bpp = CGImageGetBitsPerPixel(inImage);\
    </span></span>
13. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    bpl = CGImageGetBytesPerRow(inImage);\
    </span></span>
14. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
15. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UInt8 \*
    m\_PixelBuf = (UInt8 \*) CFDataGetBytePtr(m\_DataRef);\
    </span></span>
16. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">int
    length = CFDataGetLength(m\_DataRef);\
    </span></span>
17. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
18. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">NSLog(@"len
    %d", length);\
    </span></span>
19. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">NSLog(@"width=%d,
    height=%d", width, height);</span></span>
20. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">NSLog(@"1=%d,
    2=%d, 3=%d", bpc, bpp,bpl);</span></span>
21. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
22. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">for
    (int index = 0; index &lt; length; index += 4)</span></span>
23. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">{ </span></span>
24. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">m\_PixelBuf\[index +
    0\] = 255 - m\_PixelBuf\[index + 0\];// b</span></span>
25. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">m\_PixelBuf\[index +
    1\] = 255 - m\_PixelBuf\[index + 1\];// g</span></span>
26. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">m\_PixelBuf\[index +
    2\] = 255 - m\_PixelBuf\[index + 2\];// r</span></span>
27. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>
28. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span></span>
29. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">ctx
    = CGBitmapContextCreate(m\_PixelBuf, width, height, bpb, bpl,
    CGImageGetColorSpace( inImage ), kCGImageAlphaPremultipliedFirst
    );</span></span>
30. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImageRef
    imageRef = CGBitmapContextCreateImage (ctx);</span></span>
31. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage\*
    rawImage = \[UIImage imageWithCGImage:imageRef\];</span></span>
32. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRelease(ctx);</span></span>
33. <span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span></span><span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">return
    rawImage;</span></span>
34. <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">}</span></span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"> </span>

<span
style="font-size:18px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">7. <span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">显示图像数据区。</span></span>

<span
style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">（显示图像数据区，也就是unsigned
char\*转为graphics context或者UIImage或和CGImageRef）</span></span>

1.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRef
    ctx = CGBitmapContextCreate(pixelBuf,width,height,
    bitsPerComponent,bypesPerLine,
    colorSpace,kCGImageAlphaPremultipliedLast );\
    </span></span>
2.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGImageRef
    imageRef = CGBitmapContextCreateImage (ctx);\
    </span></span>
3.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">UIImage\*
    image = \[UIImage imageWithCGImage:imageRef\];\
    </span></span>
4.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">NSString\*
    path = \[\[NSHomeDirectory()
    stringByAppendingPathComponent:@"Documents"\]
    stringByAppendingPathComponent:@"ss.png"\];\
    </span></span>
5.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\[UIImagePNGRepresentation(self.image)
    writeToFile:path atomically:YES\];\
    </span></span>
6.  <span
    style="font-family:mceinline;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">CGContextRelease(ctx);</span></span>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:26px;">

<span
style="font-family:mceinline;font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
style="font-family:mceinline;font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">得到图像数据区后就可以很方便的实现图像处理的算法。</span>\
</span>

</div>

<span
style="font-family:mceinline;font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">完，欢迎指正！</span>

<span
style="font-size:14px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"> </span>

</div>

<div
style="zoom:1;float:right;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:138px;height:28px;">

[](http://blog.csdn.net/xuhuan_wh/article/details/6434055#)
[](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到QQ空间")
[](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到新浪微博")
[](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到腾讯微博")
[](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到人人网")
[](http://blog.csdn.net/xuhuan_wh/article/details/6434055# "分享到微信")
<span
style="visibility:hidden;display:block;height:0px;clear:both;">.</span>

</div>

<div
style="text-align:center;display:block;width:182px;margin:0px auto;padding:30px 0px 15px;clear:both;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;height:72px;">

顶
:   6

<!-- -->

踩
:   0

<span
style="text-align:center;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:14px;">

[ ](#)

</div>

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:14px;">

[ ](#)

</div>

-   <span
    style="margin-right:7px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);font-size:14px;float:left;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);border:0px none rgb(255, 255, 255);background-repeat:no-repeat;background-position:9px 8px;box-shadow:none;">上一篇</span>[IOS4
    UITableView详解](http://blog.csdn.net/xuhuan_wh/article/details/6256994)
-   <span
    style="margin-right:7px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);font-size:14px;float:left;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);border:0px none rgb(255, 255, 255);background-repeat:no-repeat;background-position:9px -22px;box-shadow:none;">下一篇</span>[IOS
    -- UIButton
    代码创建](http://blog.csdn.net/xuhuan_wh/article/details/6691682)

<div
style="clear:both;height:10px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;">

</div>

<div
style="overflow:hidden;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:296px;">

#### 我的同类文章 {#我的同类文章 style="margin:0px;padding:0px;font-size:16px;color:rgb(51, 51, 51);border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;"}

<div
style="border:1px solid rgb(187, 187, 187);margin:20px 0px 0px 0px;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:706px;height:256px;">

<div
style="height:45px;line-height:45px;border-bottom-width:1px;border-bottom-style:solid;border-bottom-color:rgb(220, 220, 220);border:;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:706px;">

<span
style="border:0px none rgb(102, 102, 102);display:inline-block;font-size:16px;color:rgb(102, 102, 102);width:109.359px;margin-left:25px;background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;font-weight:bold;height:45px;">
<span
style="cursor:pointer;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">IOS开发*（19）*</span>
</span>

</div>

<div
style="max-height:195px;overflow-y:auto;padding:10px 20px;background:rgb(252, 252, 252);border:0px none rgb(51, 51, 51);background-color:rgb(252, 252, 252);background-image:none;box-shadow:none;width:666px;height:190px;">

-   *•*[Xcode6
    模拟器路径](http://blog.csdn.net/xuhuan_wh/article/details/50345641 "Xcode6 模拟器路径")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2015-12-17</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:49.0312px;height:30px;">*阅读***343**</span>
-   *•*[IOS：修改NavigationController的后退按钮标题](http://blog.csdn.net/xuhuan_wh/article/details/8538565 "IOS：修改NavigationController的后退按钮标题")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2013-01-24</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***2500**</span>
-   *•*[IOS－－
    UIView中的坐标转换](http://blog.csdn.net/xuhuan_wh/article/details/8486337 "IOS－－ UIView中的坐标转换")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2013-01-09</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:62.375px;height:30px;">*阅读***47979**</span>
-   *•*[IOS6.0
    控制器展现方式总结](http://blog.csdn.net/xuhuan_wh/article/details/8474313 "IOS6.0 控制器展现方式总结")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2013-01-09</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***2258**</span>
-   *•*[IOS
    App资源路径](http://blog.csdn.net/xuhuan_wh/article/details/7474310 "IOS App资源路径")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2012-04-18</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***8058**</span>

<!-- -->

-   *•*[NSString+NSMutableString+NSValue+NSAraay用法汇总](http://blog.csdn.net/xuhuan_wh/article/details/8660188 "NSString+NSMutableString+NSValue+NSAraay用法汇总")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:60.5px;height:30px;">2013-03-11</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***1229**</span>
-   *•*[IOS:
    iPhone键盘通知与键盘定制](http://blog.csdn.net/xuhuan_wh/article/details/8506754 "IOS: iPhone键盘通知与键盘定制")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2013-01-15</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:62.375px;height:30px;">*阅读***29968**</span>
-   *•*[Xcode调试技巧](http://blog.csdn.net/xuhuan_wh/article/details/8480259 "Xcode调试技巧")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2013-01-08</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***1883**</span>
-   *•*[IOS6
    控件专辑](http://blog.csdn.net/xuhuan_wh/article/details/8286171 "IOS6 控件专辑")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:61.3906px;height:30px;">2012-12-12</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***1237**</span>
-   *•*[IOS -- UIButton
    代码创建](http://blog.csdn.net/xuhuan_wh/article/details/6691682 "IOS -- UIButton 代码创建")<span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:60.5px;height:30px;">2011-08-16</span><span
    style="font-size:12px;color:rgb(187, 187, 187);display:inline-block;margin-left:9px;border:0px none rgb(187, 187, 187);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:55.7031px;height:30px;">*阅读***9530**</span>

[更多文章](http://blog.csdn.net/xuhuan_wh/article/category/787880)

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>

</div>
