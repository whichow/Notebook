**使用代码方式：**

initWithFrame:中添加子控件。

<span style="line-height: 1.6;">layoutSubviews中设置子控件frame。</span>

<span
style="line-height: 1.6;">对外设置数据接口，重写setter方法给子控件设置显示数据。</span>\

<span
style="line-height: 1.6;">使用init/initWithFrame:方法创建自定义类，并且给自定义类的frame赋值。</span>\

<span
style="line-height: 1.6;">对自定义类对外暴露的数据接口进行赋值即可。</span>\

注意：如果要将子控件设置为属性需要将属性设置为弱引用，因为addSubview添加子视图的时候会创建强引用到父视图。一般可以设置为实例变量

\

``` {.prettyprint .linenums .prettyprinted style=""}
SimpleTableCell *cell = [[SimpleTableCell alloc] initWithFrame:frame];cell.labelName = @"Custom Item";
```

\

**使用nib方式：**

创建xib，在xib中拖入需要添加的控件并设置好尺寸。并且要将这个xib的Class设置为我们的自定义类。\

通过IBOutlet的方式，将xib中的控件与自定义类进行关联。

对外设置数据接口，重写setter方法给子控件设置显示数据。

使用mainBundle加载nib文件就可以得到对应的类（这里不需要再设置自定义类的frame，因为xib已经有了整个view的大小。只需要设置位置。），接着就可以对类对外的数据接口赋值。

``` {.prettyprint .linenums .prettyprinted style=""}
SimpleTableCell *cell = [[[NSBundle mainBundle] loadNibNamed:@"SimpleTableCell" owner:self options:nil] objectAtIndex:0];cell.labelName = @"Custom Item";
```

\

通过代码创建\
初始化时一定会调用`initWithFrame:`方法

通过xib\\storyboard创建\
初始化时不会调用`initWithFrame:`方法，只会调用`initWithCoder:`方法，初始化完毕后会调用`awakeFromNib`方法`注意要在在awakeFromNib中初始化子控件`

\
\

\

