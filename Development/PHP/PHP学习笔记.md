PHP 常量
--------

常量是单个值的标识符（名称）。在脚本中无法改变该值。

有效的常量名以字符或下划线开头（常量名称前面没有 $ 符号）。

注释：与变量不同，常量贯穿整个脚本是自动全局的。

如需设置常量，请使用 define() 函数 - 它使用三个参数：

1.  首个参数定义常量的名称
2.  第二个参数定义常量的值
3.  可选的第三个参数规定常量名是否对大小写敏感。默认是 false。

``` prettyprint
<?phpdefine("GREETING", "Welcome to W3School.com.cn!");echo GREETING;?>
```

defined() 函数检查某常量是否存在。

若常量存在，则返回 true，否则返回 false。

``` prettyprint
<?phpdefine("GREETING","Hello world!");echo defined("GREETING");?>
```

PHP全局变量
-----------

global 关键词用于访问函数内的全局变量。

要做到这一点，请在（函数内部）变量前面使用 global 关键词：

``` prettyprint
<?php$x=5;$y=10;function myTest() {  global $x,$y;  $y=$x+$y;}myTest();echo $y; // 输出 15?>
```

PHP 同时在名为 $GLOBALS\[index\] 的数组中存储了所有的全局变量。下标存有变量名。这个数组在函数内也可以访问，并能够用于直接更新全局变量。

上面的例子可以这样重写：

``` prettyprint
<?php$x=5;$y=10;function myTest() {  $GLOBALS['y']=$GLOBALS['x']+$GLOBALS['y'];} myTest();echo $y; // 输出 15?>
```

PHP static 关键词
-----------------

通常，当函数完成/执行后，会删除所有变量。不过，有时我需要不删除某个局部变量。实现这一点需要更进一步的工作。

要完成这一点，请在您首次声明变量时使用 *static* 关键词：

``` prettyprint
<?phpfunction myTest() {  static $x=0;  echo $x;  $x++;}myTest();myTest();myTest();?>
```

然后，每当函数被调用时，这个变量所存储的信息都是函数最后一次被调用时所包含的信息。

注释：该变量仍然是函数的局部变量。

PHP include 和 require 语句
---------------------------

通过 include 或 require 语句，可以将 PHP 文件的内容插入另一个 PHP 文件（在服务器执行它之前）。

include 和 require 语句是相同的，除了错误处理方面：

-   require 会生成致命错误（E\_COMPILE\_ERROR）并停止脚本
-   include 只生成警告（E\_WARNING），并且脚本会继续

因此，如果您希望继续执行，并向用户输出结果，即使包含文件已丢失，那么请使用 include。否则，在框架、CMS 或者复杂的 PHP 应用程序编程中，请始终使用 require 向执行流引用关键文件。这有助于提高应用程序的安全性和完整性，在某个关键文件意外丢失的情况下。

包含文件省去了大量的工作。这意味着您可以为所有页面创建标准页头、页脚或者菜单文件。然后，在页头需要更新时，您只需更新这个页头包含文件即可。

### 语法

```
include 'filename';
```

或

```
require 'filename';
```


