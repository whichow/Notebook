[简]()
-   [** 首页](http://www.jianshu.com/)
-   [** 专题](http://www.jianshu.com/collections)
-   [** 发钱啦](http://www.jianshu.com/user_invitations)

[** 注册](http://www.jianshu.com/sign_up) [** 登录](http://www.jianshu.com/sign_in) [**]()

[**简****首页](http://www.jianshu.com/) [**专题](http://www.jianshu.com/collections) [**下载手机应用](http://www.jianshu.com/apps)
![114](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/8938d471-57ae-49c6-83e6-df6d87d7a8a7.png)
简书

交流故事，沟通想法

![Download app qrcode](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/6ceb4ca2-fb53-4ba1-aee9-a39329d413c1.png)
[iOS](https://itunes.apple.com/cn/app/jian-shu/id888237539?ls=1&mt=8)· [Android](http://downloads.jianshu.io/apps/haruki/JianShu-1.11.1.apk)

[**显示模式](#view-mode-modal) [**登录](http://www.jianshu.com/sign_in)

[**](#) [**]() [**](http://www.jianshu.com/writer#/)
#### 下载简书移动应用

![Download app qrcode](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/6ceb4ca2-fb53-4ba1-aee9-a39329d413c1.png)

[**]() [**]()

[** 注册](http://www.jianshu.com/sign_up) [** 登录](http://www.jianshu.com/sign_in)

[** 添加关注](http://www.jianshu.com/sign_in)

[![100](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/edcf6c49-6e9d-494a-8fbb-62983d49bf96.jpg)](http://www.jianshu.com/users/dcd8ceb104f8) 作者 [ZYWu](http://www.jianshu.com/users/dcd8ceb104f8) 2016.01.08 13:04
写了6838字，被32人关注，获得了35个喜欢

字数1192 阅读1860 评论1 喜欢4

[**收藏文章](http://www.jianshu.com/sign_in) [** 分享]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/bcda060f-ea44-4085-bad2-c1a4b9c42c08.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/594de9e3-ab17-4de2-996b-cffa2a2b0206.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/7fe7f5ea-9acf-4962-8cfb-4b14daa8521e.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/8c89047e-3f53-48a2-942c-720f652e90e5.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/5c12ae67-1ec6-4ee7-84c5-967ad408bbce.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/f28b42b0-9d55-4645-bf48-13c92f7799de.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/dfde282c-30c2-48b0-b588-af1901f21395.png)]()
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/d08bc407-1ac2-4fc2-825f-87dba770e6fc.png)]()

### 1、模态跳转（Modal）

-   模态：一个普通的视图控制器一般只有模态跳转的功能，这个方法是所有视图控制器对象都可以用的。

``` hljs
- (void)presentViewController:(UIViewController *)viewControllerToPresent animated: (BOOL)flag completion:(void (^)(void))completion
```

-   在官方文档中，建议这两者之间通过`delegate`实现交互。例如使用UIImagePickerController从系统相册选取照片或者拍照，imagePickerController和弹出它的VC之间就通过UIImagePickerControllerDelegate实现交互的。
-   控制器的中的只读属性：presentedViewController和presentingViewController，他们分别就是被present的控制器和正在presenting的控制器。
-   Modal的效果：默认是新控制器从屏幕的最底部往上钻，直到盖住之前的控制器为止。但可以通过自定义转场来改变展现view的动画，大小，位置，是否移除跳转之前的view.这个效果可以用来模拟ipad特有的Popover弹出框。
-   需要注意的是，默认他的实现过程是移除跳转之前的控制器的view，并将新的控制器的view展示，但跳转之前的控制器并没有被释放，而是被强引用这的。区别于导航控制器的push。
-   通过 dismissViewControllerAnimated 来返回前一个界面的。

### 2、通过Segue来跳转

-   Segue：多出现于UIStoryboard中，是不同类之间跳转的一根线。换种说法就是：Storyboard上每一根用来界面跳转的线，都是一个UIStoryboardSegue对象（简称Segue）
    ![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/03b59e29-ff9a-489a-8c7a-52740d60ee06.jpg)
    Segue

-   实现原理
    -   在 `- (void)performSegueWithIdentifier:(NSString *)identifier sender:(id)sender`方法中在创建segue对象，并且设置segue对象里面的属性，来源，目的。具体步骤为：
        1.根据定义好的标识（identifier）去storyboard中查找，有木有这跟线。如果有，就创建segue对象；
        2.设置segue的来源控制器 ：segue. source = self;
        3.创建segue的目的控制器对象，并且设置为segue的目的控制器；
    -   最后，真正在`- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender`方法中具体实现跳转功能。可以在这个方法中获取将要跳转到的控制器`（segue.destinationViewController）`，并进行值传递。
-   一般多在UIStoryboard中会用到这种方式，但如果代码要用这种方式，就要创建一个UIStoryboardSegue对象，再执行跳转方法。创建的具体方法为：

``` hljs
 + (instancetype)segueWithIdentifier:(nullable NSString *)identifier source:(UIViewController *)source destination:(UIViewController *)destination performHandler:(void (^)(void))performHandler NS_AVAILABLE_IOS(6_0);
 - (instancetype)initWithIdentifier:(nullable NSString *)identifier source:(UIViewController *)source destination:(UIViewController *)destination NS_DESIGNATED_INITIALIZER;
```

-   通过 dismissViewControllerAnimated 来返回前一个界面的。

### 3、通过导航控制器UINavigationController

-   导航控制器 ：绝对是最常用的跳转方法，也是大家最熟悉的一种方式。每个控制器对象都有一个NavigationController属性，NavigationController的view的是由导航条，导航条控制的view,和栈顶控制器的view组成的。
-   工作原理：通过栈的方式的来实现的，NavigationController展示永远就是栈顶的控制器的view。当使用push方法的时候，就将需要跳转的控制器压入栈中，成为栈顶控制器；当使用pop方法的时候，就将控制器移出栈，原来跳转之前的控制器重新成为栈顶控制器，被展现；
-   需要注意的是：跳转的时候，跳转前的控制器不会移除；导航栏(UINavigationBar)的属性由栈顶控制器来决定。UINavigationBar支持appearance统一设置,但UINavigationItem不支持；
-   涉及到的类详解：

    -   UINavigationBar :继承至UIView，NavigaitonBar就是导航栏，位于屏幕的上方，管理整个NavigationController的navigationItem，即类似navigationcontroller一样提供了一个栈来管理item。
    -   UINavigationItem : 继承至NSObject，通过这个属性来设置title ，prompt，leftBarButtonItem，titleView，,rightBarButtonItem，backBarButonItem 等。
    -   UIBarButtonItem :继承至UIBarItem，UIBarItem继承至UIButton。专门用来放在UIToolbar 或者 UINavigationBar的特殊button。

    总结：NavigationController直接控制ViewControllers，并包含NavigaitonBar。NavigaitonBar包含整个UINavigationItem的栈，管理整个NavigationController的UINavigationItem（ NSArray \*items 属性）。 UINavigationItem包含了NavigaitonBar视图的全部元素（如title,tileview,backBarButtonItem等），又受当前栈顶控制器管理，即NavigaitonBar形成整个NavigationController的导航视图，然后每个NavigationController页面的导航栏元素由所在页面的UINavigationItem管理。即设置当前页面的左右barbutton。

### 4、UITabBarController

-   tabbar控制器，同样是常用的界面切换方式，一般作为app的根界面的视图控制器。其实与其说UITabBarController的界面跳转，不如说是界面切换，因为UITabBarController的界面跳转其实就是UITabBarController的viewControllers数组中的几个界面切换。只要设置好了UITabBarController的viewControllers数组就可以了。也可以工厂自定义tabbar，通过selectedItem来控制。
-   结构也类似NavigationController
    ![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/0869e1aa-6638-4868-bcc6-c5adcf745e93.jpg)
    TabBar的结构

[** 推荐拓展阅读](http://www.jianshu.com/sign_in)

[** 著作权归作者所有]()

如果觉得我的文章对您有用，请随意打赏。您的支持将鼓励我继续创作！

[¥ 打赏支持](#pay-modal)

[** 喜欢](http://www.jianshu.com/sign_in)

4

[**分享到微博]() [**分享到微信](#share-weixin-modal)
[更多分享**]()
-   [** 下载长微博图片](http://cwb.assets.jianshu.io/notes/images/2790188/weibo/image_0d9ff4ccafd4.jpg)
-   [![Tweibo](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/7fe7f5ea-9acf-4962-8cfb-4b14daa8521e.png) 分享到腾讯微博]()
-   [![Qzone](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/8c89047e-3f53-48a2-942c-720f652e90e5.png) 分享到QQ空间]()
-   [![Twitter](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/5c12ae67-1ec6-4ee7-84c5-967ad408bbce.png) 分享到Twitter]()
-   [![Facebook](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/f28b42b0-9d55-4645-bf48-13c92f7799de.png) 分享到Facebook]()
-   [![Google plus](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/dfde282c-30c2-48b0-b588-af1901f21395.png) 分享到Google+]()
-   [![Douban](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/594de9e3-ab17-4de2-996b-cffa2a2b0206.png) 分享到豆瓣]()

×

##### 打开微信“扫一扫”，打开网页后点击屏幕右上角分享按钮

![](data:image/png;base64,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)

![Tiny](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/tiny.gif)

![Tiny](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/tiny.gif)

×
### 喜欢的用户

-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/854074f2-ee9f-4688-ab5a-5bafd6d883eb.jpg)](http://www.jianshu.com/users/e94387132cd6) [ylgwhyh](http://www.jianshu.com/users/e94387132cd6) 2016.05.12 10:21
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/e15d2497-aad2-4162-bcf8-aa6d0eb61307.jpg)](http://www.jianshu.com/users/a8324d519343) [无语东流](http://www.jianshu.com/users/a8324d519343) 2016.05.06 07:32
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/b4ee8fb2-108f-4c55-85fd-6109e913891d.jpg)](http://www.jianshu.com/users/34322aa36a0a) [叶舞清风](http://www.jianshu.com/users/34322aa36a0a) 2016.04.18 16:09
-   [![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/edcf6c49-6e9d-494a-8fbb-62983d49bf96.jpg)](http://www.jianshu.com/users/dcd8ceb104f8) [ZYWu](http://www.jianshu.com/users/dcd8ceb104f8) 2016.01.08 13:04

1条评论 （ [按时间正序]()· [按时间倒序]()· [按喜欢排序]() ） [**添加新评论](http://www.jianshu.com/sign_in)

[![100](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/10da36b1-ada7-4efe-8877-7b758f5e85aa.jpg)](http://www.jianshu.com/users/bd29234c906e)
[\_我丶为伱专一](http://www.jianshu.com/users/bd29234c906e)

 2 楼 · [2016.07.13 16:02](http://www.jianshu.com/p/ceaf978f9dfe/comments/3103335#comment-3103335)

解除了我的疑惑！~~~

[**喜欢(0)]() [回复]()

[登录后发表评论](http://www.jianshu.com/sign_in)

×

[](http://www.jianshu.com/users/dcd8ceb104f8)
![100](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/edcf6c49-6e9d-494a-8fbb-62983d49bf96.jpg)

**如果觉得我的文章对您有用，请随意打赏。您的支持将鼓励我继续创作！**

打赏金额**

##### 选择支付方式：

微信支付

立即支付

×

### **打赏成功

![Complete pay](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/30018164-4909-48f8-99ca-d9cd4f0051aa.png)

Segue

TabBar的结构

![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/bca2b772-bfb8-474a-9239-435f9587f043.jpg)![](iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/69b04b26-6d47-4383-9b23-b312e756c106.jpg)

[**]() [**]()

[宋体]() [黑体]()

[简]() [繁]()


