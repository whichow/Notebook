新家一个plist结构如下

![](../../../Images/从plist中加载配置文件_files/12201882.png)

读取plist中的数据

``` prettyprint
NSString *path = [[NSBundle mainBundle] pathForResource:@"recipes" ofType:@"plist"];
NSDictionary *dict = [[NSDictionary alloc] initWithContentsOfFile:path];
tableData = [dict objectForKey:@"RecipeName"];
prepTime = [dict objectForKey:@"PrepTime"];
```


