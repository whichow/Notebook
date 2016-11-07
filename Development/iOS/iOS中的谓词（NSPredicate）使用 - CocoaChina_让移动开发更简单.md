![insane\_productivity-730x310.jpg](iOS中的谓词（NSPredicate）使用%20-%20CocoaChina_让移动开发更简单_files/1452223300548565.jpg "1452223300548565.jpg")

本文为投稿文章，作者：[sunny\_zl](http://www.jianshu.com/users/c2f0de304708/latest_articles) 

首先，我们需要知道何谓谓词，让我们看看官方的解释:

The NSPredicate class is used to define logical conditions used to constrain a search either for a fetch or for in-memory filtering.

NSPredicate类是用来定义逻辑条件约束的获取或内存中的过滤搜索。

可以使用谓词来表示逻辑条件，用于描述对象持久性存储在内存中的对象过滤。其实意思就是：我是一个过滤器，不符合条件的都滚开。

**一、NSPredicate的基本语法**

我们使用一门语言，无论是外语还是计算机语言，总是从语法开始的，这样我们才能正确的把握逻辑。所以我们从语法开始说起。在这部分我们仅关心其语法的使用

只要我们使用谓词（NSPredicate）都需要为谓词定义谓词表达式,而这个表达式必须是一个返回BOOL的值。

谓词表达式由表达式、运算符和值构成。

1.比较运算符

比较运算符如下

-   =、==：判断两个表达式是否相等，在谓词中=和==是相同的意思都是判断，而没有赋值这一说

[TABLE]

我们可以看到输出的内容为:

[TABLE]

-   &gt;=，=&gt;：判断左边表达式的值是否大于或等于右边表达式的值

-   &lt;=，=&lt;：判断右边表达式的值是否小于或等于右边表达式的值

-   &gt;：判断左边表达式的值是否大于右边表达式的值

-   &lt;：判断左边表达式的值是否小于右边表达式的值

-   !=、&lt;&gt;：判断两个表达式是否不相等

-   BETWEEN：BETWEEN表达式必须满足表达式 BETWEEN {下限，上限}的格式，要求该表达式必须大于或等于下限，并小于或等于上限

[TABLE]

输出结果为：

[TABLE]

2.逻辑运算符

-   AND、&&：逻辑与，要求两个表达式的值都为YES时，结果才为YES。

[TABLE]

输出结果为:

[TABLE]

-   OR、||：逻辑或，要求其中一个表达式为YES时，结果就是YES

-   NOT、 !：逻辑非，对原有的表达式取反

3.字符串比较运算符

-   BEGINSWITH：检查某个字符串是否以指定的字符串开头（如判断字符串是否以a开头：BEGINSWITH 'a'）

-   ENDSWITH：检查某个字符串是否以指定的字符串结尾

-   CONTAINS：检查某个字符串是否包含指定的字符串

-   LIKE：检查某个字符串是否匹配指定的字符串模板。其之后可以跟?代表一个字符和\*代表任意多个字符两个通配符。比如"name LIKE '\*ac\*'"，这表示name的值中包含ac则返回YES；"name LIKE '?ac\*'"，表示name的第2、3个字符为ac时返回YES。

-   MATCHES：检查某个字符串是否匹配指定的正则表达式。虽然正则表达式的执行效率是最低的，但其功能是最强大的，也是我们最常用的。

注：字符串比较都是区分大小写和重音符号的。如：café和cafe是不一样的，Cafe和cafe也是不一样的。如果希望字符串比较运算不区分大小写和重音符号，请在这些运算符后使用\[c\]，\[d\]选项。其中\[c\]是不区分大小写，\[d\]是不区分重音符号，其写在字符串比较运算符之后，比如：name LIKE\[cd\] 'cafe'，那么不论name是cafe、Cafe还是café上面的表达式都会返回YES。

4.集合运算符

-   ANY、SOME：集合中任意一个元素满足条件，就返回YES。

-   ALL：集合中所有元素都满足条件，才返回YES。

-   NONE：集合中没有任何元素满足条件就返回YES。如:NONE person.age &lt; 18，表示person集合中所有元素的age&gt;=18时，才返回YES。

-   IN：等价于SQL语句中的IN运算符，只有当左边表达式或值出现在右边的集合中才会返回YES。我们通过一个例子来看一下

[TABLE]

代码的作用是将array中和filterArray中相同的元素去除，输出为：

[TABLE]

-   array\[index\]：返回array数组中index索引处的元素

-   array\[FIRST\]：返回array数组中第一个元素

-   array\[LAST\]：返回array数组中最后一个元素

-   array\[SIZE\]：返回array数组中元素的个数

5.直接量

在谓词表达式中可以使用如下直接量

-   FALSE、NO：代表逻辑假

-   TRUE、YES：代表逻辑真

-   NULL、NIL：代表空值

-   SELF：代表正在被判断的对象自身

-   "string"或'string'：代表字符串

-   数组：和c中的写法相同，如：{'one', 'two', 'three'}。

-   数值：包括证书、小数和科学计数法表示的形式

-   十六进制数：0x开头的数字

-   八进制：0o开头的数字

-   二进制：0b开头的数字

6.保留字

下列单词都是保留字（不论大小写）

AND、OR、IN、NOT、ALL、ANY、SOME、NONE、LIKE、CASEINSENSITIVE、CI、MATCHES、CONTAINS、BEGINSWITH、ENDSWITH、BETWEEN、NULL、NIL、SELF、TRUE、YES、FALSE、NO、FIRST、LAST、SIZE、ANYKEY、SUBQUERY、CAST、TRUEPREDICATE、FALSEPREDICATE

注：虽然大小写都可以，但是更推荐使用大写来表示这些保留字

**二、谓词的用法**

1.定义谓词

一般我们使用下列方法来定义一个谓词

[TABLE]

下面我们通过几个简单的例子来看看它该如何使用：

首先我们需要定义一个模型，因为示例中需要用到它

ZLPersonModel.h

[TABLE]

下面让我们进入正题

例一:(最简单的使用)

[TABLE]

看到这里我们会发现evaluateWithObject:方法返回的是一个BOOL值，如果符合条件就返回YES，不符合就返回NO。而即使是最简单的使用也有一些大用处，比如以前我们写判断手机号码、邮编等等，像我就喜欢用John Engelhart大神的RegexKitLite，然而由于年代久远需要导入libicucore.dylib库（xcode7为libicucore.tbd）且由于是mrc又需要添加-fno-objc-arc，至此我们才能使用。然而使用谓词让我们可以用同样简洁的代码实现相同的功能

例二：判断手机号是否正确

[TABLE]

看到这里是不是感觉好爽，感觉以前所有的正则都可以这么匹配，但是谓词匹配正则时也是有缺点的，下面通过一个例子来看一下这个致命的缺点

例三：谓词匹配正则的缺点

（本意：检测字符串中是否有特殊字符）

[TABLE]

我们想要的效果是字符串中有特殊字符时就返回YES，然而梦想是美好的，现实是残酷的

让我们看看这悲催的结局

[TABLE]

看到这里我们心里猛然一喜，这tmd根本没问题嘛

让我们修改下testString的值

[TABLE]

再次修改testString的值

[TABLE]

这总与我们的想法事与愿违，看到这里我们会发现谓词对正则并不像我们使用NSRegularExpression时匹配的那么好，究其原因是为什么呢？我们用NSRegularExpression时会发现匹配到一个结果时就会存入数组，再从匹配到的位置继续向下匹配。

然而NSPredicate并不会做这样的自动操作，我们最终发现在NSPredicate输入\[\`~!@\#$^&\*()=|{}':;',\\\[\\\].&lt;&gt;/?~！@\#￥……&\*（）——|{}【】‘；：”“'。，、？\]正则表达式时和写成^\[\`~!@\#$^&\*()=|{}':;',\\\[\\\].&lt;&gt;/?~！@\#￥……&\*（）——|{}【】‘；：”“'。，、？\]$的效果是一样的。

所以通过这个例子我们总结出来，只有在正则表达式为^表达式$时才使用谓词，而不是所有情况都使用。

那么我们是不是因为这一点就摒弃它了呢，答案是否定的。因为虽然NSPredicate有这么一点瑕疵，但是它总体带给我们的便利其实除了正则表达式匹配时的这个问题外是更多的。

2.使用谓词过滤集合

此部分是我们需要掌握的重点，因为从这里我们就可以看到谓词的真正的强大之处

其实谓词本身就代表了一个逻辑条件，计算谓词之后返回的结果永远为BOOL类型的值。而谓词最常用的功能就是对集合进行过滤。当程序使用谓词对集合元素进行过滤时，程序会自动遍历其元素，并根据集合元素来计算谓词的值，当这个集合中的元素计算谓词并返回YES时，这个元素才会被保留下来。请注意程序会自动遍历其元素，它会将自动遍历过之后返回为YES的值重新组合成一个集合返回。

其实类似于我们使用tableView设置索引时使用的下段代码

[TABLE]

中的\[self.cityGroup valueForKey:@"title"\]。它的作用是遍历所有title并将得到的值组成新的数组。

-   NSArray提供了如下方法使用谓词来过滤集合

- (NSArray\*)filteredArrayUsingPredicate:(NSPredicate \*)predicate:使用指定的谓词过滤NSArray集合，返回符合条件的元素组成的新集合

-   NSMutableArray提供了如下方法使用谓词来过滤集合

- (void)filterUsingPredicate:(NSPredicate \*)predicate：使用指定的谓词过滤NSMutableArray，剔除集合中不符合条件的元素

-   NSSet提供了如下方法使用谓词来过滤集合

- (NSSet\*)filteredSetUsingPredicate:(NSPredicate \*)predicate NS\_AVAILABLE(10\_5, 3\_0)：作用同NSArray中的方法

-   NSMutableSet提供了如下方法使用谓词来过滤集合

- (void)filterUsingPredicate:(NSPredicate \*)predicate NS\_AVAILABLE(10\_5, 3\_0)：作用同NSMutableArray中的方法。

通过上面的描述可以看出，使用谓词过滤不可变集合和可变集合的区别是：过滤不可变集合时，会返回符合条件的集合元素组成的新集合；过滤可变集合时，没有返回值，会直接剔除不符合条件的集合元素

下面让我们来看几个例子：

例一：

[TABLE]

输出为

[TABLE]

从这个例子我们就可以看到NSPredicate有多么强大，如果让我们用其他的方法来实现又是一大堆if...else。

让我们来回顾一下上面的从第二个数组中去除第一个数组中相同的元素

例二：

[TABLE]

输出为：

[TABLE]

如果我们不用NSPredicate的话，肯定又是各种if...else，for循环等等。可以看出NSPredicate的出现为我们节省了大量的时间和精力。

3.在谓词中使用占位符参数

我们上面所有的例子中谓词总是固定的，然而我们在现实中处理变量时决定了谓词应该是可变的。下面我们来看看如果让谓词变化起来。

首先如果我们想在谓词表达式中使用变量，那么我们需要了解下列两种占位符：

-   %K：用于动态传入属性名

-   %@：用于动态设置属性值

其实相当于变量名与变量值

除此之外，还可以在谓词表达式中使用动态改变的属性值，就像环境变量一样

[TABLE]

上述表达式中，$VALUE是一个可以动态变化的值，它其实最后是在字典中的一个key，所以可以根据你的需要写不同的值，但是必须有$开头，随着程序改变$VALUE这个谓词表达式的比较条件就可以动态改变。

下面我们通过一个例子来看看这三个重要的占位符应该如何使用

例一：

[TABLE]

输出为

[TABLE]

从上例中我们主要可以看出来%K和$VALUE的含义。

那么至此NSPredicate就到到此介绍完毕。

因为本人水平有限，如果有什么好的建议请联系我。


