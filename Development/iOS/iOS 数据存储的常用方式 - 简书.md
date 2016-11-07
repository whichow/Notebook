一、iOS应用数据存储的常用方式
=============================

-   1、XML属性列表（plist）归档
-   2、Preference(偏好设置)
-   3、NSKeyedArchiver归档(NSCoding) // 所谓归档，是一个过程，即用某种格式来保存一个或者多个对象，以便以后还原这些对象
-   4、SQLite3
-   5、Core Data

二、数据存储
============

> **1、 pist文件读与写**

-   特点：只能存储OC常用数据类型(NSString、NSDictionary、NSArray、NSData、NSNumber等类型)而不能直接存储自定义模型对象
    -   如果想存储自定义模型对象 -&gt; 只能将自定义模型对象转换为字典存储；
-   1.1 使用须知：

    -   前提条件:一个对象必须实现了writeToFile方法，因为我们是通过调用对象的writeToFile方法将对象写入到一个plist文件中的

        ```
        // 将数组写入plist文件：(系统提供的类实现的writeToFile方法)
        [array writeToFile:filePath atomically:YES];
        ```

    -   plist只能识别字典,数组

-   1.2 读写数据 - &gt; 实例代码

```
   NSString *docPath =NSSearchPathForDirectoriesInDomains(NSDocumentDirectory,NSUserDomainMask, YES)[0];
    // 拼接要保存的地方的路径
    NSString *filePath = [docPathstringByAppendingPathComponent:@"str.plist"];
    // 1、写入数据
    [array writeToFile:filePath atomically:YES];
    // 2、 读取数据
    NSArray *array = [NSArray arrayWithContentsOfFile:filePath];
```

> **​2、偏好设置:**

-   每个应用都有个NSUserDefaults实例，通过它来存取偏好设置，比如，保存用户名、字体大小、是否自动登录
-   2.1 好处:
    -   1.存储数据不需要关心文件名称
    -   2.快速存储键值对
-   2.2 底层实现:
    -   它其实就是一个字典
-   2.3 用途: 账户或者密码,开关状态

-   2.4 注意：`设置数据时，synchornize方法强制写入`

    -   UserDefaults设置数据时，不是立即写入，而是根据时间戳定时地把缓存中的数据写入本地磁盘。所以调用了set方法之后数据有可能还没有写入磁盘应用程序就终止了。出现以上问题，可以通过调用synchornize方法强制写入
-   2.5 基本使用

    ```
      NSUserDefaults *UserDefaults = [NSUserDefaultsstandardUserDefaults];
      // 1、写入
      [UserDefaults setBool:NO forKey:@"isLogined"];
      // 强制写入
      [defaults synchornize];  

      // 2、读取
      BOOL isVisble = [UserDefaults boolForKey:@"isLogined"];
    ```

> **3、获取临时文件夹路径**

```
//    3.1 获取临时文件夹路径
    NSString *tmp = NSTemporaryDirectory();
//    3.2 定义宏，快速访问临时文件夹中文件
#define FilePath [NSTemporaryDirectory() stringByAppendingPathComponent:@"person.data"]
```

> **4、归档 NSKeyedArchiver**

-   特点：
    -   1.  可以存储自定义模型对象
            -   NSKeyedArchiver归档相对较plist存储而言，它可以直接存储自定义模型对象，而plist文件需要将模型转为字典才可以存储自定义对象模型；
    -   2.归档不能存储大批量数据（相比较Sqlite而言），存储数据到文件是将所有的数据一下子存储到文件中，从文件中读取数据也是一下子读取所有的数据；

-   缺点：

    -   假如你的文件中有100个对象了，然后你想在利用归档添加一个对象，你需要先把所有的数据解档出来，然后再加入你想添加的那个对象，同理，你想删除一个文件中的一个对象也是，需要解档出所有的对象，然后将其删除。性能低这样处理
-   4.1 基本使用：需要归档的模型类必须要`遵守NSCoding协议`，然后模型实现类中必须`实现两个方法`：1&gt;encodeWithCoder -&gt; `归档`；2&gt; initWithCoder: - &gt; `解档`

-   4.2 使用注意：

    -   如果父类也遵守了NSCoding协议，请注意：

        ```
        应该在encodeWithCoder:方法中加上一句

        [super encodeWithCode:encode]; // 确保继承的实例变量也能被编码，即也能被归档

        应该在initWithCoder:方法中加上一句

        self = [super initWithCoder:decoder]; // 确保继承的实例变量也能被解码，即也能被恢复
        ```

-   基本使用

```
// 1. 自定义模型类Person

// 1.1 Person.h文件
#import <Foundation/Foundation.h>

// 只要一个自定义对象想要归档,必须要遵守NSCoding协议,并且要实现协议的方法
@interface Person : NSObject<NSCoding>

@property (nonatomic, assign) int age;

@property (nonatomic, strong) NSString *name;

@end

// 1.2 .m实现文件
#import "Person.h"

#define KName @"name"
#define KAge @"age"

@implementation Person

// 什么时候调用:当一个对象要归档的时候就会调用这个方法归档
// 作用:告诉苹果当前对象中哪些属性需要归档
- (void)encodeWithCoder:(NSCoder *)aCoder
{
    [aCoder encodeObject:_name forKey:KName];
    [aCoder encodeInt:_age forKey:KAge];
}

// 什么时候调用:当一个对象要解档的时候就会调用这个方法解档
// 作用:告诉苹果当前对象中哪些属性需要解档
// initWithCoder什么时候调用:只要解析一个文件的时候就会调用
- (id)initWithCoder:(NSCoder *)aDecoder
{
    #warning  [super initWithCoder]
    if (self = [super init]) {
        // 解档
        // 注意一定要记得给成员属性赋值
      _name = [aDecoder decodeObjectForKey:KName];
      _age = [aDecoder decodeIntForKey:KAge];
    }
    return self;
}

@end

// 2. 实例 -》基本使用：取 / 存 数据 
// 归档
 [NSKeyedArchiver archiveRootObject: self.persons toFile:KFilePath];// 将self.persons模型对象数组 

 // 解档       
 _persons = [NSKeyedUnarchiver unarchiveObjectWithFile:KFilePath];
```

> 5、**SQLite3**

-   它是一款开源的嵌入式关系型数据库，可移植性好、易使用、内存开销小
-   特点：可以存储大量数据
-   详情，请参见 【SQLite3篇】

> 6、**Core Data**

-   Core Data框架提供了`对象-关系映射(ORM)的功能`，
    -   即能够将OC对象转化成数据，保存在SQLite3数据库文件中，也能够将保存在数据库中的数据还原成OC对象。
-   在此数据操作期间，`不需要编写任何SQL语句`。
-   使用此功能，要添加CoreData.framework和导入主头文件&lt;CoreData/CoreData.h&gt;
-   详情，请参见【Core Data篇】


