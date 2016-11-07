我出现这个错误是因为我的自定义控件的名字和项目中一个控制器的名字很像

控制器

DDGuessYourLikeViewController

自定义控件

DDGuessYourLikeView

 

默认的UIViewController init的时候, 系统会自动加载控制器View, 如果发现bundle中有DDGuessYourLikeViewController.xib, DDGuessYourLikeView.xib, 系统就会自动去加载

等同于 initWithNibName:@"DDGuessYourLikeView" bundle:nil

所以会出现这个错误.


