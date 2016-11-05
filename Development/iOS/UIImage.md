UIImage管理应用中的图像数据。图像对象是不可变的，所以你总是从现有的图像数据，如一个磁盘中的图像文件或用程序创建的图像文件来创建它们。一个图像对象可以包含一个单独的图像或者一个用来创建动画的图像序列。\

你可以有几种方式使用图像对象：

-   将一个图像分配到一个UIImageView对象来显示图像。

-   使用图像来自定义像按钮，滑块和分段控制之类的系统控件。

-   将一个图像直接直接画在一个视图或者其他图形上下文中。

-   将一个图像传递到其他需要图像数据的API中。

尽管图像对象支持所有平台原生的图像格式，但是推荐在你的app中使用PNG或JPEG格式的文件。图像对象会针对这些格式进行优化，可以比其他图像格式提供更好的性能。因为PNG格式是无损的，所有尤其推荐使用。\

创建一个图像对象
----------------

当使用这个类的方法创建一个图像对象时，你必须有已经存在的图像数据在一个文件或数据结构中。你不能创建一个空的图像然后在里面画上内容。有许多选择来创建图像对象，分别适用于不同的情况：

-   使用 imageNamed:inBundle:compatibleWithTraitCollection: 方法(或
    imageNamed: 方法)来从一个你的app的main
    bundle(或其他已知的bundle)中的图像资源或图像文件创建一个图像。因为这些方法会自动缓存图像数据，特别推荐用在你频繁使用的图像上。\

-   使用 imageWithContentsOfFile: 或 initWithContentsOfFile:
    方法来创建一个初始数据不在bundle中的图像对象。这些方法每次都从磁盘加载图像数据，所以你不应该用来重复相同的图像。

-   使用animatedImageWithImages:duration: 和
    animatedImageNamed:duration:
    方法创建一个由多个序列图像组成的UIImage对象。将结果图像安装在UIImageView对象来在你的界面中创建动画。

其他UIImage类的方法让你从专门的数据类型创建动画，如Core
Graphics图像或你自己创建的图像数据。UIKit也提供了UIGraphicsGetImageFromCurrentImageContext函数从你自己绘制的内容创建图像。你使用这个函数关联一个位图图形上下文，用来捕获你的绘图命令。\

\

