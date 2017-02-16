
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
    ![](../../Images/iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/03b59e29-ff9a-489a-8c7a-52740d60ee06.jpg)
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
    ![](../../Images/iOS%20ViewController跳转界面的几种方法简单总结%20-%20简书_files/0869e1aa-6638-4868-bcc6-c5adcf745e93.jpg)
    TabBar的结构
