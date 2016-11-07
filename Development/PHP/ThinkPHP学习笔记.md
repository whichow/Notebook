ThinkPHP学习笔记
**1.配置**

**配置格式：**均采用返回PHP数组的方式

**配置文件：**惯例配置文件（位于系统目录下面的Conf\\convention.php），项目配置文件位于项目的配置文件目录Conf下面，文件名是config.php，分组配置文件位于项目配置目录/分组名称/config.php。

可以通过如下配置启用分组：
1.  `'APP_GROUP_LIST' => 'Home,Admin', //项目分组设定`
2.  `'DEFAULT_GROUP'  => 'Home', //默认分组`

**读取配置：** 使用C(config) 方法

1.  `C('参数名称')//获取已经设置的参数值`

例如，C('APP\_STATUS') 

C方法同样可以用于读取二维配置：
1.  `C('USER_CONFIG.USER_TYPE')//获取用户配置中的用户类型设置`

因为配置参数是全局有效的，因此C方法可以在任何地方读取任何配置。

**动态配置：**

1.  `C('参数名称','新的参数值');`

例如，我们需要动态改变数据缓存的有效期的话，可以使用
1.  `C('DATA_CACHE_TIME','60');`

**2.函数和类库**

**系统函数库：**位于系统的Common目录下面，有三个文件：

common.php是全局必须加载的基础函数库，可直接调用；

functions.php是框架标准模式的公共函数库；

runtime.php是框架运行时文件，不能直接调用；

**项目函数库：** 位于项目的Common目录下面的common.php，自动加载， 如果设置了分组，则该目录下"分组名称/function.php"文件也会自动加载。

**扩展函数库：自定义的函数库，不会自动加载。**

**函数加载：**可以采用下面两种方式调用：

动态载入

在项目配置文件中定义LOAD\_EXT\_FILE参数，例如：

1.  `"LOAD_EXT_FILE"=>"user,db"`

设置后自动载入项目Common目录下面的扩展函数库文件user.php和db.php，可直接使用其中的函数。

手动载入

在需要调用的时候采用load方法手动载入，方式如下：

1.  `load("@.user")`

@.user表示加载当前项目的user函数文件。

**类库：**

ThinkPHP的类库包括基类库和应用类库，系统的类库命名规则如下：

[TABLE]

类名和文件名一致。

**基类库：**

核心基类库目录位于系统的Lib目录，核心基类库也就是Think类库，扩展基类库位于Extend/Library目录，可以扩展ORG 、Com扩展类库。核心基类库包含有：

| 目录         | 调用路径       | 说明               |
|--------------|----------------|--------------------|
| Lib/Core     | Think.Core     | 核心类库包         |
| Lib/Behavior | Think.Behavior | 内置行为类库包     |
| Lib/Driver   | Think.Driver   | 内置驱动类库包     |
| Lib/Template | Think.Template | 内置模板引擎类库包 |

核心类库包下面包含下面核心类库：
| 类名           | 说明             |
|----------------|------------------|
| Action         | 系统基础控制器类 |
| App            | 系统应用类       |
| Behavior       | 系统行为基础类   |
| Cache          | 系统缓存类       |
| Db             | 系统抽象数据库类 |
| Dispatcher     | URL调度类        |
| Log            | 系统日志类       |
| Model          | 系统基础模型类   |
| Think          | 系统入口和静态类 |
| ThinkException | 系统基础异常类   |
| View           | 视图类           |
| Widget         | 系统Widget基础类 |

**应用类库：**

应用类库目录位于项目目录下面的Lib目录，通常包括：

| 目录         | 调用路径              | 说明             |
|--------------|-----------------------|------------------|
| Lib/Action   | @.Action或自动加载    | 控制器类库包     |
| Lib/Model    | @.Model或自动加载     | 模型类库包       |
| Lib/Behavior | 用B方法调用或自动加载 | 应用行为类库包   |
| Lib/Widget   | 用W方法在模板中调用   | 应用Widget类库包 |

可以在项目类库目录下面添加自己的类库包，例如Lib/Common、Lib/Tool等。

**类库导入：**
一、Import显式导入

ThinkPHP统一采用import方法进行类文件的加载， 例如：
1.  `import("Think.Util.Session");`
2.  `import("App.Model.UserModel");`

对于import方法，系统会自动识别导入类库文件的位置，ThinkPHP的约定是Think、ORG、Com包的导入作为基类库导入，否则就认为是项目应用类库导入。
1.  `import("Think.Util.Session");`
2.  `import("ORG.Util.Page");`

上面两个方法分别导入了Think基类库的Util/Session.class.php文件和ORG扩展类库包的Util/Page.class.php文件。

要导入项目的应用类库文件也很简单，使用下面的方式：

1.  `import("MyApp.Action.UserAction");`
2.  `import("MyApp.Model.InfoModel");`

上面的方式分别表示导入MyApp项目下面的Lib/Action/UserAction.class.php和Lib/Model/InfoModel.class.php类文件，可以使用下面的方式来简化代码

1.  `import("@.Action.UserAction");`
2.  `import("@.Model.InfoModel");`

如果要在当前项目下面导入其他项目的类库，必须保证两个项目的目录是平级的，否则无法使用
1.  `import("OtherApp.Model.GroupModel");`

的方式来加载其他项目的类库。

对于import方法，系统会自动识别导入类库文件的位置，如果是其它情况的导入，需要指定import方法的第二个参数。例如，要导入当前文件所在目录下面的
RBAC/AccessDecisionManager.class.php 文件，可以使用：
1.  `import("RBAC.AccessDecisionManager",dirname(__FILE__));`

如果你要导入的类库文件名的后缀不是class.php而是php，那么可以使用import方法的第三个参数指定后缀：
1.  `import("RBAC.AccessDecisionManager",dirname(__FILE__),".php");`

建议使用ThinkPHP开发过程保持类库名称采用class.php的后缀规范。

**导入第三方类库：**

第三方类库统一放置在系统扩展目录下的Vendor 目录，并且使用vendor 方法导入，其参数和 import 方法是 一致的，只是默认的值有针对变化。 

例如，我们把 Zend 的 Filter\\Dir.php 放到 Vendor 目录下面，这个时候 Dir 文件的路径就是 
Vendor\\Zend\\Filter\\Dir.php，我们使用vendor 方法导入只需要使用：
1.  `Vendor('Zend.Filter.Dir');`

就可以导入Dir类库了，Vendor方法也可以支持和import方法一样的基础路径和文件名后缀参数。

**自动加载：**

在大多数情况下，我们无需手动导入类库，而是通过配置采用自动加载机制即可，自动加载有三种情况，按照加载优先级从高到低分别是：别名自动加载、系统规则自动加载和自定义路径自动加载。

自定义路径自动加载需要在项目配置文件中添加自动加载的搜索路径，例如：

1.  `'APP_AUTOLOAD_PATH' =>'@.Common,@.Tool',`

表示，在当前项目类库目录下面的Common和Tool目录下面的类库可以自动加载。

**3.控制器：**

ThinkPHP支持四种URL模式，可以通过设置URL\_MODEL参数来定义，包括普通模式、PATHINFO、REWRITE和兼容模式。

**一、普通模式：**设置URL\_MODEL 为0

采用传统癿URL参数模式

http://serverName/appName/?m=module&a=action&id=1

**二、PATHINFO模式（默认模式）：**设置URL\_MODEL 为1

默认情况使用PATHINFO模式，ThinkPHP内置强大的PATHINFO支持，提供灵活和友好URL支持。PATHINFO模式自劢识删模块和操作，例如：

http://serverName/appName/module/action/id/1/或者

http://serverName/appName/module,action,id,1/，

第一个参数会被解析成模块名称（如果启用了分组的话，则依次往后递 推），第二个参数会被解析成操作，后面的参数是显式传递的，而且必须成对出现，例如：

http://serverName/appName/module/action/year/2008/month/09/day/21/

每一个模块就是一个控制器类，通常位亍项目的Lib\\Action目录下面。类名就是模块名加上Action 后缀，例如UserAction类就表示了User模块。控制器类必须继承系统的Action基础类，这样才能确保使用Action类内置的方法。而read操作其实就是IndexAction类的一个公共方法，所以我们在浏览器里面输入URL：

http://localhost/App/index.php/User/read/id/8

其实就是执行了UserAction类的read（公共）方法。  

每个模块的操作并非一定需要有定义操作方法，例 如，我们在UserAction中如果没有定义help方法，但是存在对应的User/help.html 模板文件，那举么下面的URL访问依然可以正常运作：

http://localhost/myApp/index.php/User/help/

因为系统找不到UserAction类的help方法，会自劢定位到User模块的模板目录中查找help.html 模板文件，然后直接渲染输出。

**定义控制器：** Action控制器一般位于项目的Lib/Action目录下，Action控制器的定义非常简单，只要继承Action基础类就可以了，例如： 

Class UserAction extends Action{}

控制器文件的名称是UserAction.class.php。

如果我们要执行下面的URL

http://localhost/App/index.php/User/add

则需要增加一个add操作方法就可以了，例如：

Class UserAction extends Action{

     Public function add(){

          $this-&gt;display();     //输出模板页面

     }

}

操作方法必须定义为Public类型，否则会报错。系统会自动定位当前操作的模板文件Tpl\\User\\add.html

**模块分组：**

模块分组相关的配置参数包括：

[TABLE]

要启用分组模块非常简单，配置下APP\_GROUP\_LIST参数和DEFAULT\_GROUP参数即可。

例如我们把当前的项目分成Home和Admin两个组，分别表示前台和后台功能，那么只需要在项 目配置中添加下面的配置：

     'APP\_GROUP\_LIST'=&gt;'Home,Admin',

     'DEFAULT\_GROUP'=&gt;'Home',

采用了分组模式后，URL地址发成：

http://serverName/index.php/Home/Index/indexHome

http://serverName/index.php/Admin/Index/indexAdmin

如果Home是默认分组的话还可以变成 http://serverName/index.php/Index/index

分组和普通模 块的项目目录区别如下：

[TABLE]

 


