在跳转前会执行prepareForSegue，可以在这个方法里传递信息给另一个ViewController

``` prettyprint
//通过segue.destinationViewController获取目标ViewController，通过sender获取从哪个控件跳转的- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {    static NSString *identifier = @"RecipeDetail";    if ([segue.identifier isEqualToString:identifier]) {        UICollectionViewCell *currentCell = (UICollectionViewCell*)sender;        RecipeDetailViewController *destViewController = segue.destinationViewController;        if (currentCell) {            UIImageView* imageView = (UIImageView*)[currentCell viewWithTag:100];            destViewController.detailImage = imageView.image;        }    }}
```


