<div id="show-note-container"
class="imagebubble-container imagebubble-mode-off">

<div id="flag" class="post-bg">

<div class="container">

<div class="article">

<div class="preview">

<div
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 2728px; line-height: 27.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;">

**前言：**\
处于安全考虑，iOS系统的沙盒机制规定每个应用都只能访问当前沙盒目录下面的文件（也有例外，比如在用户授权情况下访问通讯录，相册等），这个规则展示了iOS系统的封闭性。在开发中常常需要数据存储的功能，比如存取文件，归档解档等。

#### 一、沙盒目录结构 {#一沙盒目录结构 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 20px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 36px; line-height: 36px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

每个APP的沙盒下面都有相似目录结构，如图（[苹果官方文档](https://developer.apple.com/library/mac/documentation/FileManagement/Conceptual/FileSystemProgrammingGuide/FileSystemOverview/FileSystemOverview.html)）：

<div widget="ImageBubble"
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 464px; line-height: 27.2px; margin: 0px 0px 20px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-align: center; text-decoration: none; width: 620px;">

![](iOS%20沙盒目录结构及正确使用%20-%20简书_files/550988-e380ff054e24eb8a.jpg)\
<div
style="color: rgb(153, 153, 153); display: inline-block; font-style: italic; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 22px; line-height: 22.1px; margin: 0px; min-height: 22px; min-width: 20%; outline: rgb(153, 153, 153) none 0px; padding: 10px; text-align: center; text-decoration: none; width: 138.094px;">

Every App Is an Island

</div>

</div>

<div widget="ImageBubble"
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 406px; line-height: 27.2px; margin: 0px 0px 20px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-align: center; text-decoration: none; width: 620px;">

![](iOS%20沙盒目录结构及正确使用%20-%20简书_files/550988-e6d3ef186a8c1d62.jpg)\
<div class="image-caption" style="display: none;">

</div>

</div>

> NSString \*path = NSHomeDirectory();

上面的代码得到的是应用程序目录的路径，在该目录下有三个文件夹：Documents、Library、temp以及一个.app包！该目录下就是应用程序的沙盒，应用程序只能访问该目录下的文件夹！！！

1、Documents
目录：您应该将所有的应用程序数据文件写入到这个目录下。这个目录用于存储用户数据。该路径可通过配置实现iTunes共享文件。可被iTunes备份。

2、AppName.app
目录：这是应用程序的程序包目录，包含应用程序的本身。由于应用程序必须经过签名，所以您在运行时不能对这个目录中的内容进行修改，否则可能会使应用程序无法启动。

3、Library 目录：这个目录下有两个子目录：\
Preferences
目录：包含应用程序的偏好设置文件。您不应该直接创建偏好设置文件，而是应该使用NSUserDefaults类来取得和设置应用程序的偏好.\
Caches
目录：用于存放应用程序专用的支持文件，保存应用程序再次启动过程中需要的信息。\
可创建子文件夹。可以用来放置您希望被备份但不希望被用户看到的数据。该路径下的文件夹，除Caches以外，都会被iTunes备份。

4、tmp
目录：这个目录用于存放临时文件，保存应用程序再次启动过程中不需要的信息。该路径下的文件不会被iTunes备份。

#### 二、获取各种文件目录的路径 {#二获取各种文件目录的路径 style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 20px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 36px; line-height: 36px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

获取目录路径的方法：

``` {style="border: 1px solid rgba(0, 0, 0, 0.14902); color: rgb(101, 123, 131); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; height: 200px; line-height: 20px; margin: 0px 0px 20px; outline: rgb(101, 123, 131) none 0px; overflow: auto; padding: 9.5px; text-decoration: none; white-space: pre; width: 599px; word-break: break-all; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}
// 获取沙盒主目录路径
NSString *homeDir = NSHomeDirectory();
// 获取Documents目录路径
NSString *docDir = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) firstObject];
// 获取Library的目录路径
NSString *libDir = [NSSearchPathForDirectoriesInDomains(NSLibraryDirectory, NSUserDomainMask, YES) lastObject];
// 获取Caches目录路径
NSString *cachesDir = [NSSearchPathForDirectoriesInDomains(NSCachesDirectory, NSUserDomainMask, YES) firstObject];
// 获取tmp目录路径
NSString *tmpDir =  NSTemporaryDirectory();
```

获取应用程序程序包中资源文件路径的方法：

``` {style="border: 1px solid rgba(0, 0, 0, 0.14902); color: rgb(101, 123, 131); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; height: 60px; line-height: 20px; margin: 0px 0px 20px; outline: rgb(101, 123, 131) none 0px; overflow: auto; padding: 9.5px; text-decoration: none; white-space: pre; width: 599px; word-break: break-all; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}
NSLog(@"%@",[[NSBundle mainBundle] bundlePath]);
NSString *imagePath = [[NSBundle mainBundle] pathForResource:@"apple" ofType:@"png"];
UIImage *appleImage = [[UIImage alloc] initWithContentsOfFile:imagePath];
```

#### 三、NSSearchPathForDirectoriesInDomains {#三nssearchpathfordirectoriesindomains style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 20px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 36px; line-height: 36px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

NSSearchPathForDirectoriesInDomains方法用于查找目录，返回指定范围内的指定名称的目录的路径集合。有三个参数：\
***directory***
NSSearchPathDirectory类型的enum值，表明我们要搜索的目录名称，比如这里用NSDocumentDirectory表明我们要搜索的是Documents目录。如果我们将其换成NSCachesDirectory就表示我们搜索的是Library/Caches目录。\
***domainMask***
NSSearchPathDomainMask类型的enum值，指定搜索范围，这里的NSUserDomainMask表示搜索的范围限制于当前应用的沙盒目录。还可以写成NSLocalDomainMask（表示/Library）、NSNetworkDomainMask（表示/Network）等。\
***expandTilde***
BOOL值，表示是否展开波浪线\~。我们知道在iOS中\~的全写形式是/User/userName，该值为YES即表示写成全写形式，为NO就表示直接写成“\~”。

该值为NO:Caches目录路径\~/Library/Caches\
该值为YES:Caches目录路径\
/var/mobile/Containers/Data/Application/E7B438D4-0AB3-49D0-9C2C-B84AF67C752B/Library/Caches

</div>

</div>

</div>

</div>

</div>

</div>
