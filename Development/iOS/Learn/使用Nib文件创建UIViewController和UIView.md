//创建UIViewController

ViewController \*vc = \[\[ViewController alloc\] initWithNibName:@"ViewController" bundle:nil\];

//创建UIView

MyView \*view = \[\[\[NSBundle mainBundle\] loadNibNamed:@"MyView" owner:self options:nil\] firstObject\];
