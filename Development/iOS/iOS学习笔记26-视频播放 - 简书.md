### 一、视频

在iOS中播放视频可以使用两个框架来实现：

> 1.  `MediaPlayer`框架的`MPMoviePlayerController`和`MPMoviePlayerViewController`
> 2.  `AVFoundation`框架中的`AVPlayer`
> 3.  `AVKit`框架的`AVPlayerViewController`【iOS8之后才有】

但在近两年的WWDC上，`MediaPlayer`框架被iOS9标记为`deprcated`，意味着它已经不再被苹果继续维护，而且该框架集成度较高，不如`AVFoundation`灵活性高，所以这里就讲`AVFoundation`的`AVPlayer`来实现播放视频，`AVPlayerViewController`实际上就是对`AVPlayer`的封装。

下面是两个框架的应用所在层：

![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-284b6faa66b54f75.png)

### 二、AVPlayer

`AVPlayer`存在于`AVFoundation`中，它更加接近于底层，所以灵活性极高。
`AVPlayer`本身并不能显示视频，如果`AVPlayer`要显示必须创建一个播放器图层`AVPlayerLayer`用于展示，该播放器图层继承于`CALayer`。

###### AVPlayer视频播放使用步骤：

> 1.  创建视频资源地址URL，可以是网络URL
> 2.  通过URL创建视频内容对象`AVPlayerItem`，一个视频对应一个`AVPlayerItem`
> 3.  创建`AVPlayer`视频播放器对象，需要一个`AVPlayerItem`进行初始化
> 4.  创建`AVPlayerLayer`播放图层对象，添加到显示视图上去
> 5.  播放器播放`play`，播放器暂停`pause`
> 6.  添加通知中心监听视频播放完成，使用KVO监听播放内容的属性变化
> 7.  进度条监听是调用`AVPlayer`的对象方法：
>
>     ```
>     -(id)addPeriodicTimeObserverForInterval:(CMTime)interval/*监听频率*/ 
>                                       queue:(dispatch_queue_t)queue /*监听GCD线程*/
>                                  usingBlock:(void (^)(CMTime time))block;/*监听回调*/
>     ```
>
###### 测试环境搭建：

> 1.  利用终端开启Apache服务，使得手机可以通过网络访问本机资源
>     ![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-7e5f4e9347f93884.png)
>
> 2.  下载视频MP4到Apache的Web资源目录
>     默认的Apache的Web资源目录是`/Library/WebServer/Documents`
>     ![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-ca96be9d5c3387a2.png)
>
> 3.  查看本地服务器的IP
>     ![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-7ed813c426c2c4b2.png)
>
> 4.  别忘了进入info.plist设置HTTP网络解禁
>     ![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-c814b253c10c8bba.png)
>
###### 下面是一个具体的项目：

###### ViewController属性

```
#import "ViewController.h"
#import <AVFoundation/AVFoundation.h>
@interface ViewController ()
@property (strong, nonatomic) AVPlayer *player;//视频播放器
@property (strong, nonatomic) AVPlayerLayer *playerLayer;//视频播放图层
@property (strong, nonatomic) IBOutlet UIView *movieView;//播放容器视图
@property (strong, nonatomic) IBOutlet UIProgressView *progressView;//进度条
@property (strong, nonatomic) IBOutlet UISegmentedControl *segmentView;//选择栏
@property (strong, nonatomic) NSArray *playerItemArray;//视频播放URL列表
@end
```

###### 1. 初始化AVPlayerItem视频内容对象

```
/* 获取播放内容对象，一个AVPlayerItem对应一个视频文件 */
- (AVPlayerItem *)getPlayItemByNum:(NSInteger)num {
    if (num >= self.playerItemArray.count) {
        return nil;
    }
    //创建URL
    NSString *urlStr = self.playerItemArray[num];
    urlStr = [urlStr stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
    NSURL *url = [NSURL URLWithString:urlStr];
    //创建播放内容对象
    AVPlayerItem *item = [AVPlayerItem playerItemWithURL:url];
    return item;
}
```

###### 2. 初始化AVPlayer视频播放器对象

```
/* 初始化视频播放器 */
- (void)initAVPlayer {
    //获取播放内容
    AVPlayerItem *item = [self getPlayItemByNum:0];
    //创建视频播放器
    AVPlayer *player = [AVPlayer playerWithPlayerItem:item];
    self.player = player;
    //添加播放进度监听
    [self addProgressObserver];
    //添加播放内容KVO监听
    [self addObserverToPlayerItem:item];
    //添加通知中心监听播放完成
    [self addNotificationToPlayerItem];
}
```

###### 3. 初始化AVPlayerLayer播放图层对象

```
#pragma mark - 初始化
/* 初始化播放器图层对象 */
- (void)initAVPlayerLayer {
    //创建视频播放器图层对象
    AVPlayerLayer *layer = [AVPlayerLayer playerLayerWithPlayer:self.player];
    layer.frame = self.movieView.bounds;//尺寸大小
    layer.videoGravity = AVLayerVideoGravityResizeAspect;//视频填充模式
    //添加进控件图层
    [self.movieView.layer addSublayer:layer];
    self.playerLayer = layer;
    self.movieView.layer.masksToBounds = YES;
}
```

###### 4. 通知中心监听播放完成

```
#pragma mark - 通知中心
- (void)addNotificationToPlayerItem {
    //添加通知中心监听视频播放完成
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(playerDidFinished:)
                                                 name:AVPlayerItemDidPlayToEndTimeNotification
                                               object:self.player.currentItem];
}
- (void)removeNotificationFromPlayerItem {
    //移除通知中心的通知
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}
/* 播放完成后会调用 */
- (void)playerDidFinished:(NSNotification *)notification {
    //自动播放下一个视频
    NSInteger currentIndex = self.segmentView.selectedSegmentIndex;
    self.segmentView.selectedSegmentIndex = (currentIndex + 1)%self.playerItemArray.count;
    [self segmentValueChange:self.segmentView];
}
```

###### 5. KVO属性监听

```
#pragma mark - KVO监听属性
/* 添加KVO，监听播放状态和缓冲加载状况 */
- (void)addObserverToPlayerItem:(AVPlayerItem *)item {
    //监控状态属性
    [item addObserver:self
           forKeyPath:@"status"
              options:NSKeyValueObservingOptionNew
              context:nil];
    //监控缓冲加载情况属性
    [item addObserver:self
           forKeyPath:@"loadedTimeRanges"
              options:NSKeyValueObservingOptionNew
              context:nil];
}
/* 移除KVO */
- (void)removeObserverFromPlayerItem:(AVPlayerItem *)item {
    [item removeObserver:self forKeyPath:@"status"];
    [item removeObserver:self forKeyPath:@"loadedTimeRanges"];
}
/* 属性发生变化，KVO响应函数 */
- (void)observeValueForKeyPath:(NSString *)keyPath
                      ofObject:(id)object
                        change:(NSDictionary<NSString *,id> *)change
                       context:(void *)context
{
    AVPlayerItem *playerItem = (AVPlayerItem *)object;
    if ([keyPath isEqualToString:@"status"]) {//状态发生改变
        AVPlayerStatus status = [[change objectForKey:@"new"] integerValue];
        if (status == AVPlayerStatusReadyToPlay) {
            NSLog(@"正在播放..，视频总长度为:%.2f",CMTimeGetSeconds(playerItem.duration));
        }
    } else if ( [keyPath isEqualToString:@"loadedTimeRanges"] ) {//缓冲区域变化
        NSArray *array = playerItem.loadedTimeRanges;
        CMTimeRange timeRange = [array.firstObject CMTimeRangeValue];//已缓冲范围
        float startSeconds = CMTimeGetSeconds(timeRange.start);
        float durationSeconds = CMTimeGetSeconds(timeRange.duration);
        NSTimeInterval totalBuffer = startSeconds + durationSeconds;//缓冲总长度
        NSLog(@"共缓冲：%.2f",totalBuffer);
    }
}
```

###### 6. 进度条监听

```
#pragma mark - 进度监听
- (void)addProgressObserver {
    AVPlayerItem *item = self.player.currentItem;
    UIProgressView *progress = self.progressView;
    //进度监听
    [self.player addPeriodicTimeObserverForInterval:CMTimeMake(1.0, 1.0)
                                              queue:dispatch_get_main_queue()
                                         usingBlock:^(CMTime time)
     {
         //CMTime是表示视频时间信息的结构体，包含视频时间点、每秒帧数等信息
         //获取当前播放到的秒数
         float current = CMTimeGetSeconds(time);
         //获取视频总播放秒数
         float total = CMTimeGetSeconds(item.duration);
         if (current) {
             [progress setProgress:(current/total) animated:YES];
         }
     }];
}
```

###### 7. UI点击事件以及视图控制器加载

```
- (void)viewDidLoad {
    [super viewDidLoad];
    //属性初始化
    self.segmentView.selectedSegmentIndex = 0;
    self.progressView.progress = 0;
    self.playerItemArray = @[@"http://192.168.6.147/1.mp4",
                             @"http://192.168.6.147/2.mp4",
                             @"http://192.168.6.147/3.mp4"];
    //视频播放器初始化
    [self initAVPlayer];
    //视频播放器显示图层初始化
    [self initAVPlayerLayer];
    //视频开始播放
    [self.player play];

}
- (void)dealloc {
    //移除监听和通知
    [self removeObserverFromPlayerItem:self.player.currentItem];
    [self removeNotificationFromPlayerItem];
}
#pragma mark UI点击
/* 点击播放按钮 */
- (IBAction)playMovie:(UIButton *)sender {
    sender.enabled = NO;
    if ( self.player.rate == 0 ) {//播放速度为0，表示播放暂停
        sender.titleLabel.text = @"暂停";
        [self.player play];//启动播放
    } else if ( self.player.rate == 1.0 ) {//播放速度为1.0，表示正在播放
        sender.titleLabel.text = @"播放";
        [self.player pause];//暂停播放
    }
    sender.enabled = YES;
}
/* 选择视频播放列表 */
- (IBAction)segmentValueChange:(UISegmentedControl *)sender {
    //先移除对AVPlayerItem的所有监听
    [self removeNotificationFromPlayerItem];
    [self removeObserverFromPlayerItem:self.player.currentItem];
    //获取新的播放内容
    AVPlayerItem *playerItem = [self getPlayItemByNum:sender.selectedSegmentIndex];
    //添加属性监听
    [self addObserverToPlayerItem:playerItem];
    //替换视频内容
    [self.player replaceCurrentItemWithPlayerItem:playerItem];
    //添加播放完成监听
    [self addNotificationToPlayerItem];
}
```

![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-90a9a78e340be3e9.png)
效果图

### 三、AVPlayerViewController

一个简单的视频播放器就这么搞定了，感觉还是好麻烦，而且很多功能还没有实现。
实际上在iOS8.0之后，苹果为我们封装了`AVPlayer`等视频播放相关的类 ，形成了一个直接可以简单使用的播放器控制器类，那就是`AVPlayerViewController`，下面来讲下你就觉得有多爽，上面那一大堆，只需要下面的一小块代码就可以实现了。

###### 使用步骤：

> 1.  导入框架：
>     ![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-cf4de5f8573f8917.png)
>
> 2.  添加头文件：
>
>     ```
>     #import <AVFoundation/AVFoundation.h>
>     #import <AVKit/AVKit.h>
>     ```
>
> 3.  创建`URL`
> 4.  创建`AVPlayer`
> 5.  创建`AVPlayerViewController`

Over，一个功能十分齐全的播放器就好了

###### 下面是全部代码【/(ㄒoㄒ)/~~泪奔】：

```
#import "ViewController.h"
#import <AVFoundation/AVFoundation.h>
#import <AVKit/AVKit.h>
@interface ViewController ()
@property (strong, nonatomic) AVPlayerViewController *playerVC;
@end
@implementation ViewController
- (void)viewDidLoad {
    [super viewDidLoad];
    //创建URL
    NSURL *url = [NSURL URLWithString:@"http://192.168.6.147/1.mp4"];
    //直接创建AVPlayer，它内部也是先创建AVPlayerItem，这个只是快捷方法
    AVPlayer *player = [AVPlayer playerWithURL:url];
    //创建AVPlayerViewController控制器
    AVPlayerViewController *playerVC = [[AVPlayerViewController alloc] init];
    playerVC.player = player;
    playerVC.view.frame = self.view.frame;
    [self.view addSubview:playerVC.view];
    self.playerVC = playerVC;
    //调用控制器的属性player的开始播放方法
    [self.playerVC.player play];
}
@end
```

![](../../Images/iOS学习笔记26-视频播放%20-%20简书_files/1795722-2bde9146db8bed59.png)

这酸爽不敢相信，不过这个是iOS9才有的，就是为了替代
`MediaPlayer`框架的`MPMoviePlayerViewController`而定制的非常方便的视频播放器
我用`AVPlayer`写的视频播放器被甩了好几十条街，/(ㄒoㄒ)/~~。

### 四、扩展--生成视频缩略图

`AVFoundation`框架还提供了一个类`AVAssetImageGenerator`，用于获取视频截图。

###### 应用场景：

> -   播放视频时，拖动进度条时，可以显示视频缩略图，查看视频播放到哪个画面了
> -   选择某个视频播放的时候，可以使用视频缩略图，点击视频缩放图，进入真正的播放视频界面
> -   一些有意思的视频场景需要截屏留念的时候，可以使用视频缩略图

###### 具体使用步骤：

> 1.  创建`AVURLAsset`对象，该对象主要用于获取媒体信息，包括视频、声音。
> 2.  根据`AVURLAsset`创建`AVAssetImageGenerator`对象
> 3.  使用对象方法`copyCGImageAtTime:`获得指定时间点的截图
>
>     ```
>     -(CGImageRef)copyCGImageAtTime:(CMTime)requestedTime /* 要在视频的哪个时间点生成缩略图 */
>                         actualTime:(CMTime *)actualTime /* 实际生成缩略图的媒体时间 */
>                              error:(NSError **)outError;/* 错误信息 */
>     ```
>
###### 下面是实际代码：

```
/* 获取视频缩略图 */
- (UIImage *)getThumbailImageRequestAtTimeSecond:(CGFloat)timeBySecond {
    //视频文件URL地址
    NSURL *url = [NSURL URLWithString:@"http://192.168.6.147/2.mp4"];
    //创建媒体信息对象AVURLAsset
    AVURLAsset *urlAsset = [AVURLAsset assetWithURL:url];
    //创建视频缩略图生成器对象AVAssetImageGenerator
    AVAssetImageGenerator *imageGenerator = [AVAssetImageGenerator assetImageGeneratorWithAsset:urlAsset];
    //创建视频缩略图的时间，第一个参数是视频第几秒，第二个参数是每秒帧数
    CMTime time = CMTimeMake(timeBySecond, 10);
    CMTime actualTime;//实际生成视频缩略图的时间
    NSError *error = nil;//错误信息
    //使用对象方法，生成视频缩略图，注意生成的是CGImageRef类型，如果要在UIImageView上显示，需要转为UIImage
    CGImageRef cgImage = [imageGenerator copyCGImageAtTime:time
                                                actualTime:&actualTime
                                                     error:&error];
    if (error) {
        NSLog(@"截取视频缩略图发生错误，错误信息：%@",error.localizedDescription);
        return nil;
    }
    //CGImageRef转UIImage对象
    UIImage *image = [UIImage imageWithCGImage:cgImage];
    //记得释放CGImageRef
    CGImageRelease(cgImage);
    return image;
}
```

代码Demo点这里：[LearnDemo里面的MovieDemo](https://github.com/liutingluhe/learnDemo)

##### 如果有什么问题可以在下方评论区中提出！O(∩\_∩)O哈！


