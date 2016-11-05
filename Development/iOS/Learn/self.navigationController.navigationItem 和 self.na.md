在UIViewController和它的navigationController中都有navigationItem这个属性，那么我们到底该使用哪个
<div>

其实navigationItem并不是navigationController的属性，所有继承自UIViewController的子类都有navigationItem，它是用来设置导航栏那个位置的按钮各种设置的。

</div>

<div>

导航栏和工具栏类似，所有视图控制器都可以有导航栏，并不是只有导航控制器才有导航栏。

</div>

<div>

所以要设置视图的navigationItem应该使用self.navigationItem，而self.navigationController.navigationItem仅仅是UINavigationController继承自UIViewController的一个属性，对self.navigationController.navigationItem设置的只是它的navigationController的navigationItem，并不会影响该ViewController的navigationItem。

</div>

<div>

toolbarItem也是类似的情况。

</div>

<div>

\
<div>

\

</div>

</div>
