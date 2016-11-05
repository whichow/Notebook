新建一个ViewController继承自UIViewController，声明<span
style="white-space: normal;">UITableViewDataSource</span><span
style="white-space: normal;">和<span
style="white-space: normal;">UITableViewDelegate协议，</span></span>新建一个UITableView，将它的dataSource和delegate指向我们的ViewController。\

在ViewController中必须实现的方法

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
//返回数据源的总数- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section//返回一个UITableViewCell或者自定义的TableViewCell，在其中设置要显示的内容- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
```

</div>

<span style="line-height: 1.6;">可选方法</span>\

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
//在自定义TableViewCell的时候会用到，返回一行的高度- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath//在某一项被选中时调用，在里面处理选中时的操作- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath//在对TableView进行编辑时调用，实现了这个方法iOS会自动添加向左滑动出现删除的功能，但是具体操作还需要在这个方法里实现- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
```

</div>

需要注意的是，在tableView:
cellForRowAtIndexPath中可以使用UITableView的dequeueReusableCellWithIdentifier方法复用TableViewCell，在找不到可用的<span
style="white-space: normal;">TableViewCell的时候才生成新的<span
style="white-space: normal;">TableViewCell。</span></span><span
style="line-height: 1.6;">这样可以达到节省内存的目的和防止数据过多时内存溢出的的问题。</span>

\

\

\

