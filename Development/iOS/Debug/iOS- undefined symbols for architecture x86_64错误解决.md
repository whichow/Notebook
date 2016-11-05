先让大家看一下,我报错的截图

![](http://img.blog.csdn.net/20141202143452840?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvenVveW91MTMxNA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center)\

我在网上查了一下,这个错误还是比较常见,原因就是少框架,少静态库了.

所以解决方案就是

![](http://img.blog.csdn.net/20141202143919195?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvenVveW91MTMxNA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center)\

\

如果报的错误不是来自于第三方库,那么用上面的解决方法是解决不了,

那么我们的解决方案是:

![](http://img.blog.csdn.net/20150107110105941?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvenVveW91MTMxNA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center)

我在引用第三方库源码时直接把文件夹拖到Xcode工程中出现了这个错误，解决方法是，在Xcode中新建一个Group，把所有.m和.h文件从文件夹中移到这个Group中。

\

