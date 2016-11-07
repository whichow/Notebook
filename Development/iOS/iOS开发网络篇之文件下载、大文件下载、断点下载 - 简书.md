![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150910174721232.gif)
这里写图片描述

> iOS开发中经常会用到文件的下载与上传功能，今天咱们来分享一下文件下载的思路。文件上传下篇再说。

文件下载分为小文件下载与大文件下载

### 小文件下载

小文件可以是一张图片，或者一个文件，这里指在现行的网络状况下基本上不需要等待很久就能下载好的文件。这里以picjumbo里的一张图片为例子。

#### NSData方式

其实我们经常用的`[NSData dataWithContentsOfURL]` 就是一种文件下载方式，猜测这里面应该是发送了Get请求。

```
NSURL *url = [NSURL URLWithString:@"https://picjumbo.imgix.net/HNCK8461.jpg?q=40&w=1650&sharp=30"];
NSData *data = [NSData dataWithContentsOfURL:url];
```

当然下载代码应该放到子线程执行

#### NSURLConnection方式下载

```
NSURL* url = [NSURL URLWithString:@"https://picjumbo.imgix.net/HNCK8461.jpg?q=40&w=1650&sharp=30"];
[NSURLConnection sendAsynchronousRequest:[NSURLRequest requestWithURL:url] queue:[NSOperationQueue mainQueue] completionHandler:^(NSURLResponse *response, NSData *data, NSError *connectionError) {

self.imageView.image = [UIImage imageWithData:data];
    }];
```

就是发送一个异步的Get请求，回调的data就是我们下载到的图片。
这些都很简单，今天主要说的是大文件的下载。

### 大文件下载

#### NSURLConnection下载

通过上面的两个方法去下载大文件是不合理的，因为这两个方法都是一次性返回整个下载到的文件，返回的data在内存中，如果下载一个几百兆的东西，内存肯定会爆的。
其实NSURLConnection还提供了另外一种发送请求的方式

```
// 发送请求去下载 (创建完conn对象后，会自动发起一个异步请求)
[NSURLConnection connectionWithRequest:request delegate:self];
```

这里用到了代理，那肯定要遵守协议了.遵守`NSURLConnectionDataDelegate` 协议.
进去看看有几个代理方法，其实我们能用到的也就三个。

```
/**
 *  请求失败时调用（请求超时、网络异常）
 *
 *  @param error      错误原因
 */
- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error
{

}
/**
 *  1.接收到服务器的响应就会调用
 *
 *  @param response   响应
 */
- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response
{

}
/**
 *  2.当接收到服务器返回的实体数据时调用（具体内容，这个方法可能会被调用多次）
 *
 *  @param data       这次返回的数据
 */
- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data
{

}
/**
 *  3.加载完毕后调用（服务器的数据已经完全返回后）
 */
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{

}
```

通过执行下载操作，分别log上面三个方法，会发现didReceiveData这个方法会被频繁的调用，每次都会传回来一部分data，下面是官方api对这个方法的说明

> is called with a single immutable NSData object to the delegate,
> representing the next portion of the data loaded from the connection. This is the only guaranteed for the delegate to receive the data from the resource load.

由此我们可以知道，这种下载方式是通过这个代理方法每次传回来一部分文件，最终我们把每次传回来的数据合并成一个我们需要的文件。

这时候我们通常想到的方法是定义一个全局的NSMutableData,接受到响应的时候初始化这个MutableData，在didReceiveData方法里面去拼接
\[self.totalData appendData:data\];
最后在完成下载的方法里面吧整个MutableData写入沙盒。
代码如下：

```
@property (weak, nonatomic) IBOutlet UIProgressView *myPregress;

@property (nonatomic,strong) NSMutableData* fileData;

/**
 *  文件的总长度
 */
@property (nonatomic, assign) long long totalLength;
```

```
/**
 *  1.接收到服务器的响应就会调用
 *
 *  @param response   响应
 */
- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response
{
    self.fileData = [NSMutableData data];
    // 获取要下载的文件的大小
    self.totalLength = response.expectedContentLength;
}
/**
 *  2.当接收到服务器返回的实体数据时调用（具体内容，这个方法可能会被调用多次）
 *
 *  @param data       这次返回的数据
 */
- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data
{
    [self.fileData appendData:data];
    self.myPregress.progress = (double)self.fileData.length / self.totalLength;
}
/**
 *  3.加载完毕后调用（服务器的数据已经完全返回后）
 */
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
    // 拼接文件路径
    NSString *cache = [NSSearchPathForDirectoriesInDomains(NSCachesDirectory, NSUserDomainMask, YES) lastObject];
    NSString *file = [cache stringByAppendingPathComponent:response.suggestedFilename];

    // 写到沙盒中
    [self.fileData writeToFile:file atomically:YES];
}
```

我这里下载的是javajdk。（度娘的地址）
注意：通常大文件下载是需要给用户展示下载进度的。
这个数值是 已经下载的数据大小/要下载的文件总大小
已经下载的数据我们可以记录，要下载的文件总大小在服务器返回的响应头里面可以拿到，在接受到响应的方法里执行

```
 NSHTTPURLResponse *res = (NSHTTPURLResponse*)response;

    NSDictionary *headerDic = res.allHeaderFields;
    NSLog(@"%@",headerDic);
    self.fileLength = [[headerDic objectForKey:@"Content-Length"] intValue];
```

不得不说苹果太为开发者考虑了，我们不必这么麻烦的去获取文件总大小了，
response.expectedContentLength 这句代码就搞定了。
response.suggestedFilename 这句代表获取下载的文件名

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908141106978.png)
这里写图片描述

题外话扯的有点多，言归正传，这样我们确实可以下载文件，最后拿到的文件也能正常运行

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908141855072.png)
这里写图片描述

但是有个致命的问题，内存！用来接受文件的NSMutableData一直都在内存中，会随着文件的下载一直变大，

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908142050348.png)
这里写图片描述

所有这种处理方式绝对是不合理的。

合理的方式在我们获取一部分data的时候就写入沙盒中，然后释放内存中的data。

这里要用到NSFilehandle这个类，这个类可以实现对文件的读取、写入、更新。
下面总结了一些常用的NSFileHandle的方法，在这个表中，fh是一个NSFileHandle对象，data是一个NSData对象，path是一个NSString 对象，offset是易额Unsigned long long变量。

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908144609499.png)
这里写图片描述

具体关于NSFileHandle的用法各位自行搜索。

在接受到响应的时候就在沙盒中创建一个空的文件，然后每次接收到数据的时候就拼接到这个文件的最后面，通过`- (unsigned long long)seekToEndOfFile;` 这个方法

```
- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response
{
    // 文件路径
    NSString* ceches = [NSSearchPathForDirectoriesInDomains(NSCachesDirectory, NSUserDomainMask, YES) lastObject];
    NSString* filepath = [ceches stringByAppendingPathComponent:response.suggestedFilename];

    // 创建一个空的文件到沙盒中
    NSFileManager* mgr = [NSFileManager defaultManager];
    [mgr createFileAtPath:filepath contents:nil attributes:nil];

    // 创建一个用来写数据的文件句柄对象
    self.writeHandle = [NSFileHandle fileHandleForWritingAtPath:filepath];

    // 获得文件的总大小
    self.totalLength = response.expectedContentLength;

}
/**
 *  2.当接收到服务器返回的实体数据时调用（具体内容，这个方法可能会被调用多次）
 *
 *  @param data       这次返回的数据
 */
- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data
{
    // 移动到文件的最后面
    [self.writeHandle seekToEndOfFile];

    // 将数据写入沙盒
    [self.writeHandle writeData:data];

    // 累计写入文件的长度
    self.currentLength += data.length;

    // 下载进度
    self.myPregress.progress = (double)self.currentLength / self.totalLength;
}
/**
 *  3.加载完毕后调用（服务器的数据已经完全返回后）
 */
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
    self.currentLength = 0;
    self.totalLength = 0;

    // 关闭文件
    [self.writeHandle closeFile];
    self.writeHandle = nil;
}
```

这样在下载过程中内存就会一直很稳定了，并且下载的文件也是没问题的。

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908150738080.png)
这里写图片描述

##### 断点下载

暂停/继续下载也是现在下载中必备的功能了，如果没有暂停功能，用户体验相比会很差，而且如果突然网络不好中断了，没有实现断点下载的话只有重新下了。。。
下面让我们来加入断点下载功能吧。
NSURLConnection 只提供了一个cancel方法，这并不是暂停，而是取消下载任务。如果要实现断点下载必须要了解HTTP协议中请求头的Range。

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150908155815582.png)
这里写图片描述

不难看出，通过设置请求头的Range我们可以指定下载的位置、大小。
那么我们这样设置`bytes=500-  从500字节以后的所有字节`,
只需要在didReceiveData中记录已经写入沙盒中文件的大小（self.currentLength），
把这个大小设置到请求头中，因为第一次下载肯定是没有执行过didReceive方法，self.currentLength也就为0，也就是从头开始下。

```
上代码：


#pragma mark --按钮点击事件

- (IBAction)btnClicked:(UIButton *)sender {

    // 状态取反
    sender.selected = !sender.isSelected;

    // 断点续传
    // 断点下载

    if (sender.selected) { // 继续（开始）下载
        // 1.URL
        NSURL *url = [NSURL URLWithString:@"http://localhost:8080//term_app/hdgg.zip"];

        // 2.请求
        NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];

        // 设置请求头
        NSString *range = [NSString stringWithFormat:@"bytes=%lld-", self.currentLength];
        [request setValue:range forHTTPHeaderField:@"Range"];

        // 3.下载
        self.connection = [NSURLConnection connectionWithRequest:request delegate:self];
    } else { // 暂停

        [self.connection cancel];
        self.connection = nil;
    }
}
```

在下载过程中，为了提高效率，充分利用cpu性能，通常会执行多线程下载，代码就不贴了，分析一下思路：

> 下载开始，创建一个和要下载的文件大小相同的文件（如果要下载的文件为100M，那么就在沙盒中创建一个100M的文件，然后计算每一段的下载量，开启多条线程下载各段的数据，分别写入对应的文件部分）。

#### NSURLSession下载方式

上面这种下载文件的方式确实比较复杂，要自己去控制内存写入相应的位置，不过在苹果在iOS7推出了一个新的类`NSURLSession`,它具备了NSURLConnection所具备的方法，同时也比它更强大。苹果推出它的目的大有取代NSURLConnection的趋势或者目的。

`NSURLSession` 也可以发送Get/Post请求，实现文件的下载和上传。
在NSURLSesiion中，任何请求都可以被看做是一个任务。其中有三种任务类型

> // NSURLSessionDataTask : 普通的GET\\POST请求
> // NSURLSessionDownloadTask : 文件下载
> // NSURLSessionUploadTask : 文件上传（很少用，一般服务器不支持）

##### NSURLSession 简单使用

NSURLSession发送请求非常简单，与connection不同的是，任务创建后不会自动发送请求，需要手动开始执行任务。

```
 // 1.得到session对象
    NSURLSession* session = [NSURLSession sharedSession];
    NSURL* url = [NSURL URLWithString:@""];

    // 2.创建一个task，任务
    NSURLSessionDataTask* dataTask = [session dataTaskWithURL:url completionHandler:^(NSData *data, NSURLResponse *response, NSError *error) {
        // data 为返回数据
    }];

    // 3.开始任务
    [dataTask resume];
```

```
// 发送post请求 自定义请求头
[session dataTaskWithRequest:<#(NSURLRequest *)#> completionHandler:<#^(NSData *data, NSURLResponse *response, NSError *error)completionHandler#>]
```

##### NSURLSession 下载

使用NSURLSession就非常简单了，不需要去考虑什么边下载边写入沙盒的问题，苹果都帮我们做好了。代码如下

```
 NSURL* url = [NSURL URLWithString:@"http://dlsw.baidu.com/sw-search-sp/soft/9d/25765/sogou_mac_32c_V3.2.0.1437101586.dmg"];

    // 得到session对象
    NSURLSession* session = [NSURLSession sharedSession];

    // 创建任务
    NSURLSessionDownloadTask* downloadTask = [session downloadTaskWithURL:url completionHandler:^(NSURL *location, NSURLResponse *response, NSError *error) {

    }];
    // 开始任务
    [downloadTask resume];
```

是不是跟NSURLConnection很像，但仔细看会发现回调的方法里面并没用NSData传回来，多了一个location，顾名思义，location就是下载好的文件写入沙盒的地址，打印一下发现下载好的文件被自动写入的temp文件夹下面了。

location:file:///Users/yeaodong/Library/Developer/CoreSimulator/Devices/E52B4B95-53E1-46A2-9881-8C969958FBC0/data/Containers/Data/Application/BFB9F0CA-0F50-4682-BBBD-B71B54C39EBE/tmp/CFNetworkDownload\_YNnuIS.tmp

![](iOS开发网络篇之文件下载、大文件下载、断点下载%20-%20简书_files/20150910155745812.png)
这里写图片描述

不过在下载完成之后会自动删除temp中的文件，所有我们需要做的只是在回调中把文件移动(或者复制，反正之后会自动删除)到caches中。

```
NSString *caches = [NSSearchPathForDirectoriesInDomains(NSCachesDirectory, NSUserDomainMask, YES) lastObject];
        // response.suggestedFilename ： 建议使用的文件名，一般跟服务器端的文件名一致
        NSString *file = [caches stringByAppendingPathComponent:response.suggestedFilename];

        // 将临时文件剪切或者复制Caches文件夹
        NSFileManager *mgr = [NSFileManager defaultManager];

        // AtPath : 剪切前的文件路径
        // ToPath : 剪切后的文件路径
        [mgr moveItemAtPath:location.path toPath:file error:nil];
```

不过通过这种方式下载有个缺点就是无法监听下载进度，要监听下载进度，苹果通常的作法是通过delegate，这里也一样。而且NSURLSession的创建方式也有所不同。
首先遵守协议`<NSURLSessionDownloadDelegate>` 注意不要写错
点进去发现协议里面有三个方法。

```
#pragma mark -- NSURLSessionDownloadDelegate
/**
 *  下载完毕会调用
 *
 *  @param location     文件临时地址
 */
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask
didFinishDownloadingToURL:(NSURL *)location
{
}
/**
 *  每次写入沙盒完毕调用
 *  在这里面监听下载进度，totalBytesWritten/totalBytesExpectedToWrite
 *
 *  @param bytesWritten              这次写入的大小
 *  @param totalBytesWritten         已经写入沙盒的大小
 *  @param totalBytesExpectedToWrite 文件总大小
 */
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask
      didWriteData:(int64_t)bytesWritten
 totalBytesWritten:(int64_t)totalBytesWritten
totalBytesExpectedToWrite:(int64_t)totalBytesExpectedToWrite
{
    self.pgLabel.text = [NSString stringWithFormat:@"下载进度:%f",(double)totalBytesWritten/totalBytesExpectedToWrite];
}

/**
 *  恢复下载后调用，
 */
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask
 didResumeAtOffset:(int64_t)fileOffset
expectedTotalBytes:(int64_t)expectedTotalBytes
{

}
```

这上面的注释已经很详细了，相信大家都能看懂吧。

NSURLSession创建方式,这里就不能使用Block回调方式了，如果给下载任务设置了completionHandler这个block，也实现了下载的代理方法，优先执行block，代理方法也就不会执行了。

```
// 得到session对象
    NSURLSessionConfiguration* cfg = [NSURLSessionConfiguration defaultSessionConfiguration]; // 默认配置

    NSURLSession* session = [NSURLSession sessionWithConfiguration:cfg delegate:self delegateQueue:[NSOperationQueue mainQueue]];

    // 创建任务
    NSURLSessionDownloadTask* downloadTask = [session downloadTaskWithURL:url];

    // 开始任务
    [downloadTask resume];
```

相比之前的NSURLConnection方式简单很多吧，用NSURLSessionDownloadTask做断点下载也很简单，我们先了解一下任务的取消方法

```
- (void)cancelByProducingResumeData:(void (^)(NSData *resumeData))completionHandler;
```

取消操作以后会调用一个Block，并传入一个resumeData，该参数包含了继续下载文件的位置信息。也就是说，当你下载了10M得文件数据，暂停了。那么你下次继续下载的时候是从第10M这个位置开始的，而不是从文件最开始的位置开始下载。因而为了保存这些信息，所以才定义了这个NSData类型的这个属性：resumeData。这个data只包含了url跟已经下载了多少数据，不会很大，不用担心内存问题。

另外,session还提供了通过resumeData来创建任务的方法

```
- (NSURLSessionDownloadTask *)downloadTaskWithResumeData:(NSData *)resumeData;
```

我们只需要在取消操作的回调中记录好resumeData，然后在恢复下载的适合通过上面的方法创建任务就好了，相比NSURLconnection简单太多了。
需要注意的是Block中循环引用的问题

```
__weak typeof(self) selfVc = self;
    [self.downloadTask cancelByProducingResumeData:^(NSData *resumeData) {
        selfVc.resumeData = resumeData;
        selfVc.downloadTask = nil;
    }];
```

示例程序下载：<https://github.com/hongfenglt/HFDownLoad>

这篇博客断断续续写了两三天，可能某些地方思路有些乱，欢迎大神指正。


