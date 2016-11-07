一个计算机专业学生几年的Java编程经验汇总
一个计算机专业学生几年的Java编程经验汇总
========================================

*发表于2014/12/19 21:54:14  102*

1． 关于动态加载机制
学习Java比C++更容易理解OOP的思想，毕竟C++还混合了不少面向过程的成分。很多人都能背出来Java语言的特点，所谓的动态加载机制等等。当然概念往往是先记住而后消化的，可有多少人真正去体会过动态加载的机制，试图去寻找过其中的细节呢? 提供大家一个方法：
在命令行窗口运行Java程序的时候，加上这个很有用的参数：
java -verbose \*.class
这样会清晰的打印出被加载的类文件，大部分是jdk自身运行需要的，最后几行会明显的看到自己用到的那几个类文件被加载进来的顺序。即使你声明了一个类对 象，不实例化也不会加载，说明只有真正用到那个类的实例即对象的时候，才会执行加载。这样是不是大家稍微能明白一点动态加载了呢？^\_^

2． 关于寻找class文件原理
建议大家在入门的时候在命令行窗口编译和运行，不要借助JCreator或者Eclipse等IDE去帮助做那些事情。尝试自己这样做：
javac -classpath yourpath \*.java
java -classpath yourpath \*.class
也许很多人都能看懂，设置classpath的目的就是告诉编译器去哪里寻找你的class文件. 不过至少笔者今日才弄懂JVM去查询类的原理，编译器加载类要依靠classloader， 而classloader有3个级别，从高到低分别是BootClassLoader(名字可能不准确) , ExtClassLoader, AppClassLoader.
这3个加载器分别对应着编译器去寻找类文件的优先级别和不同的路径：BootClassLoader对应jre/classes路径，是编译器最优先寻找class的地方
ExtClassLoader对应jre/lib/ext路径，是编译器次优先寻找class的地方
AppClassLoader对应当前路径，所以也是编译器默认找class的地方
其实大家可以自己写个程序简单的测试，对任何class，例如A, 
调用new A().getClass().getClassLoader().toString() 打印出来就可以看到，把class文件放在不同的路径下再次执行，就会看到区别。特别注意的是如果打印出来是null就表示到了最高级 BootClassLoader, 因为它是C++编写的，不存在Java对应的类加载器的名字。
寻找的顺序是一种向上迂回的思想，即如果本级别找不到，就只能去本级别之上的找，不会向下寻找。不过似乎从Jdk1.4到Jdk1.6这一特点又有改变， 没有找到详细资料。所以就不举例子了。告诉大家设计这种体系的是Sun公司曾经的技术核心宫力先生，一个纯种华人哦！^\_^
这样希望大家不至于迷惑为什么总报错找不到类文件，不管是自己写的还是导入的第三方的jar文件（J2ee中经常需要导入的）。

3． 关于jdk和jre
大家肯定在安装JDK的时候会有选择是否安装单独的jre，一般都会一起安装，我也建议大家这样做。因为这样更能帮助大家弄清楚它们的区别：
Jre 是java runtime environment, 是java程序的运行环境。既然是运行，当然要包含jvm，也就是大家熟悉的虚拟机啦， 还有所有java类库的class文件，都在lib目录下打包成了jar。大家可以自己验证。至于在windows上的虚拟机是哪个文件呢？ 学过MFC的都知道什么是dll文件吧，那么大家看看jre/bin/client里面是不是有一个jvm.dll呢？那就是虚拟机。
Jdk 是java development kit，是java的开发工具包，里面包含了各种类库和工具。当然也包括了另外一个Jre. 那么为什么要包括另外一个Jre呢？而且jdk/jre/bin同时有client和server两个文件夹下都包含一个jvm.dll。 说明是有两个虚拟机的。这一点不知道大家是否注意到了呢？
相信大家都知道jdk的bin下有各种java程序需要用到的命令，与jre的bin目录最明显的区别就是jdk下才有javac，这一点很好理解，因为 jre只是一个运行环境而已。与开发无关，正因为如此，具备开发功能的jdk自己的jre下才会同时有client性质的jvm和server性质的 jvm， 而仅仅作为运行环境的jre下只需要client性质的jvm.dll就够了。
记得在环境变量path中设置jdk/bin路径麽？这应该是大家学习Java的第一步吧， 老师会告诉大家不设置的话javac和java是用不了的。确实jdk/bin目录下包含了所有的命令。可是有没有人想过我们用的java命令并不是 jdk/bin目录下的而是jre/bin目录下的呢？不信可以做一个实验，大家可以把jdk/bin目录下的java.exe剪切到别的地方再运行 java程序，发现了什么？一切OK！
那么有人会问了？我明明没有设置jre/bin目录到环境变量中啊？
试想一下如果java为了提供给大多数人使用，他们是不需要jdk做开发的，只需要jre能让java程序跑起来就可以了，那么每个客户还需要手动去设置 环境变量多麻烦啊？所以安装jre的时候安装程序自动帮你把jre的java.exe添加到了系统变量中，验证的方法很简单，大家看到了系统环境变量的 path最前面有“%SystemRoot%\\system32;%SystemRoot%;”这样的配置，那么再去Windows/system32下 面去看看吧，发现了什么？有一个java.exe。
如果强行能够把jdk/bin挪到system32变量前面，当然也可以迫使使用jdk/jre里面的java，不过除非有必要，我不建议大家这么做。使用单独的jre跑java程序也算是客户环境下的一种测试。
这下大家应该更清楚jdk和jre内部的一些联系和区别了吧？
PS: 其实还有满多感想可以总结的，一次写多了怕大家扔砖头砸死我，怪我太罗唆。大家应该更加踏实更加务实的去做一些研究并互相分享心得，大方向和太前沿的技术讨论是必要的但最好不要太多，毕竟自己基础都还没打好，什么都讲最新版本其实是进步的一大障碍！

Java 学习杂谈（二）

1． 关于集合框架类
相信学过Java的各位对这个名词并不陌生，对 java.util.\*这个package肯定也不陌生。不知道大家查询API的时候怎么去审视或者分析其中的一个package，每个包最重要的两个部 分就是interfaces和classes，接口代表了它能做什么，实现类则代表了它如何去做。关注实现类之前，我们应该先理解清楚它的来源接口，不管 在j2se还是j2ee中，都应该是这样。那么我们先看这三个接口：List、Set、Map。
也许有些人不太熟悉这三个名字，但相信大部分人都熟悉ArrayList，LinkedList，TreeSet，HashSet，HashMap， Hashtable等实现类的名字。它们的区别也是满容易理解的，List放可以重复的对象集合，Set放不可重复的对象组合，而Map则放 &lt;Key,Value &gt; 这样的名值对， Key不可重复，Value可以。这里有几个容易混淆的问题：
到底Vector和ArrayList，Hashtable和HashMap有什么区别？
很多面试官喜欢问这个问题，其实更专业一点应该这样问：新集合框架和旧集合框架有哪些区别？新集合框架大家可以在这些包中找since jdk1.2的，之前的如vector和Hashtable都是旧的集合框架包括的类。那么区别是？
a. 新集合框架的命名更加科学合理。例如List下的ArrayList和LinkedList
b. 新集合框架下全部都是非线程安全的。建议去jdk里面包含的源代码里面自己去亲自看看vector和ArrayList的区别吧。当然如果是jdk5.0之后的会比较难看一点，因为又加入了泛型的语法，类似c++的template语法。
那么大家是否想过为什么要从旧集合框架默认全部加锁防止多线程访问更新到新集合框架全部取消锁，默认方式支持多线程？(当然需要的时候可以使用collections的静态方法加锁达到线程安全)
笔者的观点是任何技术的发展都未必是遵循它们的初衷的，很多重大改变是受到客观环境的影响的。大家知道Java的初衷是为什么而开发的麽？是为嵌入式程序 开发的。记得上一篇讲到classLoader机制麽？那正是为了节约嵌入式开发环境下内存而设计的。而走到今天，Java成了人们心中为互联网诞生的语 言。互联网意味着什么？多线程是必然的趋势。客观环境在变，Java技术也随着飞速发展，导致越来越脱离它的初衷。据说Sun公司其实主打的是J2se， 结果又是由于客观环境影响，J2se几乎遗忘，留在大家谈论焦点的一直是j2ee。
技术的细节这里就不多说了，只有用了才能真正理解。解释这些正是为了帮助大家理解正在学的和将要学的任何技术。之后讲j2ee的时候还会再讨论。
多扯句题外话：几十年前的IT巨人是IBM，Mainframe市场无人可比。微软如何打败IBM？正是由于硬件飞速发展，对个人PC的需求这个客观环 境，让微软通过OS称为了第二个巨人。下一个打败微软的呢？Google。如何做到的？如果微软并不和IBM争大型机，Google借着互联网飞速发展这 个客观环境作为决定性因素，避开跟微软争OS，而是走搜索引擎这条路，称为第3个巨人。那么第4个巨人是谁呢？很多专家预言将在亚洲或者中国出现， Whatever，客观环境变化趋势才是决定大方向的关键。当然笔者也希望会出现在中国，^\_^~~

2． 关于Java设计模式
身边的很多在看GOF的23种设计模式，似乎学习它无论在学校还是在职场，都成了一种流行风气。我不想列举解释这23种Design Pattern， 我写这些的初衷一直都是谈自己的经历和看法，希望能帮助大家理解。
首先我觉得设计模式只是对一类问题的一种通用解决办法，只要是面向对象的编程预言都可以用得上这23种。理解它们最好的方法就是亲自去写每一种，哪怕是一 个简单的应用就足够了。如果代码实现也记不住的话，记忆它们对应的UML图会是一个比较好的办法，当然前提是必须了解UML。
同时最好能利用Java自身的类库帮助记忆，例如比较常用的观察者模式，在java.util.\*有现成的Observer接口和Observable这 个实现类，看看源代码相信就足够理解观察者模式了。再比如装饰器模式，大家只要写几个关于java.io.\*的程序就可以完全理解什么是装饰器模式了。有 很多人觉得刚入门的时候不该接触设计模式，比如图灵设计丛书系列很出名的那本《Java设计模式》，作者: Steven John Metsker，大部分例子老实说令现在的我也很迷惑。但我仍然不同意入门跟学习设计模式有任何冲突，只是我们需要知道每种模式的概念的和典型的应用，这 样我们在第一次编写 FileOutputStream、BufferedReader、PrintWriter的时候就能感觉到原来设计模式离我们如此之近，而且并不是多么 神秘的东西。
另外，在学习某些模式的同时，反而更能帮助我们理解java类库的某些特点。例如当你编写原型(Prototype)模式的时候，你必须了解的是 java.lang.Cloneable这个接口和所有类的基类Object的clone()这个方法。即深copy和浅copy的区别：
Object.clone()默认实现的是浅copy，也就是复制一份对象拷贝，但如果对象包含其他对象的引用，不会复制引用，所以原对象和拷贝共用那个引用的对象。
深copy当然就是包括对象的引用都一起复制啦。这样原对象和拷贝对象，都分别拥有一份引用对象。如果要实现深copy就必须首先实现 java.lang.Cloneable接口，然后重写clone()方法。因为在Object中的clone()方法是protected签名的，而 Cloneable接口的作用就是把protected放大到public，这样clone()才能被重写。
那么又有个问题了？如果引用的对象又引用了其他对象呢？这样一直判断并复制下去，是不是显得很麻烦？曾经有位前辈告诉我的方法是重写clone方法的时候 直接把原对象序列化到磁盘上再反序列化回来，这样不用判断就可以得到一个深copy的结果。如果大家不了解序列化的作法建议看一看 ObjectOutputStream和ObjectInputStream
归根结底，模式只是思想上的东西，把它当成前人总结的经验其实一点都不为过。鼓励大家动手自己去写，例如代理模式，可以简单的写一个Child类， Adult类。Child要买任何东西由Adult来代理实现。简单来说就是Adult里的buy()内部实际调用的是Child的buy()，可是暴露 在main函数的却是Adult.buy()。这样一个简单的程序就足够理解代理模式的基本含义了。

Java 杂谈（三）

1． 关于Object类理解
大家都知道Object是所有Java类的基类， 意味着所有的Java类都会继承了Object的11个方法。建议大家去看看Object的 11个成员函数的源代码，就会知道默认的实现方式。比如equals方法，默认实现就是用"=="来比较，即直接比较内存地址，返回true 或者 false。而toString()方法，返回的串组成方式是??
"getClass().getName() + "@" + Integer.toHexString(hashCode())"
其实不用我过多的解释，大家都能看懂这个串的组成。接下来再看看hashCode()：
public native int hashCode()；
由于是native方法，跟OS的处理方式相关，源代码里仅仅有一个声明罢了。我们有兴趣的话完全可以去深究它的hashCode到底是由OS怎么样产生 的呢？但笔者建议最重要的还是先记住使用它的几条原则吧！首先如果equals()方法相同的对象具有相通的hashCode，但equals ()对象不相通的时候并不保证hashCode()方法返回不同的整数。而且下一次运行同一个程序，同一个对象未必还是当初的那个hashCode() 哦。
其余的方法呢？nofigy()、notifyAll()、clone()、wait()都是native方法的，说明依赖于操作系统的实现。最后一个有 趣的方法是finalize()，类似C++的析构函数，签名是protected，证明只有继承扩展了才能使用，方法体是空的，默示什么也不做。它的作 用据笔者的了解仅仅是通知JVM此对象不再使用，随时可以被销毁，而实际的销毁权还是在于虚拟机手上。那么它真的什么也不做麽？未必，实际上如果是线程对 象它会导致在一定范围内该线程的优先级别提高，导致更快的被销毁来节约内存提高性能。其实从常理来说，我们也可以大概这样猜测出jvm做法的目的。
2． 关于重载hashCode()与Collection框架的关系
笔者曾经听一位搞Java培训多年的前辈说在他看来hashCode方法没有任何意义，仅仅是为了配合证明具有同样的hashCode会导致equals 方法相等而存在的。连有的前辈都犯这样的错误，其实说明它还是满容易被忽略的。那么hashCode()方法到底做什么用？
学过数据结构的课程大家都会知道有一种结构叫hash table，目的是通过给每个对象分配一个唯一的索引来提高查询的效率。那么Java也不会肆意扭曲改变这个概念，所以hashCode唯一的作用就是为 支持数据结构中的哈希表结构而存在的，换句话说，也就是只有用到集合框架的 Hashtable、HashMap、HashSet的时候，才需要重载hashCode()方法，
这样才能使得我们能人为的去控制在哈希结构中索引是否相等。笔者举一个例子：
曾经为了写一个求解类程序，需要随机列出1,2,3,4组成的不同排列组合，所以笔者写了一个数组类用int\[\]来存组合结果，然后把随机产生的组合加入 一个HashSet中，就是想利用HashSet不包括重复元素的特点。可是HashSet怎么判断是不是重复的元素呢？当然是通过 hashCode()返回的结果是否相等来判断啦，可做一下这个实验：
int\[\] A = {1,2,3,4};
int\[\] B = {1,2,3,4};
System.out.println(A.hashCode());
System.out.println(B.hashCode());
这明明是同一种组合，却是不同的hashCode，加入Set的时候会被当成不同的对象。这个时候我们就需要自己来重写hashCode()方法了，如何 写呢？其实也是基于原始的hashCode()，毕竟那是操作系统的实现， 找到相通对象唯一的标识，实现方式很多，笔者的实现方式是：
首先重写了toString()方法:
return A\[0\]“+” A\[1\]“+” A\[2\]“+” A\[3\]; //显示上比较直观
然后利用toString()来计算hashCode()：
return this.toString().hashCode()；
这样上述A和B返回的就都是”1234”，在测试toString().hashCode()，由于String在内存中的副本是一样的，”1234”.hashCode()返回的一定是相同的结果。
说到这，相信大家能理解得比我更好，今后千万不要再误解hashCode()方法的作用。
3． 关于Class类的成员函数与Java反射机制
很早刚接触Java就听很多老师说过Java的动态运行时机制、反射机制等。确实它们都是Java的显著特点，运行时加载笔者在第一篇介绍过了，现在想讲 讲反射机制。在Java中，主要是通过java.lang包中的Class类和Method类来实现内存反射机制的。
熟悉C++的人一定知道下面这样在C++中是做不到的： 运行时以字符串参数传递一个类名，就可以得到这个类的所有信息，包括它所有的方法，和方法的详细信息。还可以实例化一个对象，并通过查到的方法名来调用该 对象的任何方法。这是因为Java的类在内存中除了C++中也有的静态动态数据区之外，还包括一份对类自身的描述，也正是通过这描述中的信息，才能帮助我 们才运行时读取里面的内容，得到需要加载目标类的所有信息，从而实现反射机制。大家有没有想过当我们需要得到一个JavaBean的实例的时候，怎么知道 它有哪些属性呢？再明显简单不过的例子就是自己写一个JavaBean的解析器：
a. 通过Class.forName(“Bean的类名”)得到Class对象，例如叫ABeanClass
b. 通过ABeanClass的getMethods()方法，得到Method\[\]对象
c. 按照规范所有get方法名后的单词就代表着该Bean的一个属性
d. 当已经知道一个方法名，可以调用newInstance()得到一个实例，然后通过invoke()方法将方法的名字和方法需要用的参数传递进去，就可以动态调用此方法。
当然还有更复杂的应用，这里就不赘述，大家可以参考Class类和Method类的方法。
4． 坦言Synchronize的本质
Synchronize大家都知道是同步、加锁的意思，其实它的本质远没有大家想得那么复杂。声明Synchronize的方法被调用的时候，锁其实是加 载对象上，当然如果是静态类则是加在类上的锁，调用结束锁被解除。它的实现原理很简单，仅仅是不让第二把锁再次被加在同一个对象或类上，仅此而已。一个简 单的例子足以说明问题：
class A{
synchronized void f(){}
void g(){}
当A的一个对象a被第一个线程调用其f()方法的时候，第二个线程不能调用a的synchronized方法例如f()，因为那是在试图在对象上加第二把锁。但调用g()却是可以的，因为并没有在同一对象上加两把锁的行为产生。
这样大家能理解了麽？明白它的原理能更好的帮助大家设计同步机制，不要滥用加锁。
PS：下篇笔者计划开始对J2ee接触到的各个方面来进行总结，谈谈自己的经验和想法。希望大家还能一如既往的支持笔者写下去，指正不足之处。
Java杂谈（四）
不知不觉已经写到第四篇了，论坛里面不断的有朋友鼓励我写下去。坚持自己的作风，把一切迷惑不容易理清楚的知识讲出来，讲到大家都能听懂，那么自己就真的 懂了。最近在公司实习的时候Trainer跟我讲了很多经典事迹，对还未毕业的我来说是笔不小的财富，我自己的信念是：人在逆境中成长的速度要远远快过顺 境中，这样来看一切都能欣然接受了。
好了，闲话不说了，第三篇讲的是反射机制集合框架之类的，这次打算讲讲自己对反序列化和多线程的理解。希望能对大家学习Java起到帮助??
1．关于序列化和反序列化
应该大家都大概知道Java中序列化和反序列化的意思，序列化就是把一个Java对象转换成二进制进行磁盘上传输或者网络流的传输，反序列化的意思就是把 这个接受到的二进制流重新组装成原来的对象逆过程。它们在Java中分别是通过ObjectInputStream和 ObjectInputStream这两个类来实现的（以下分别用ois和oos来简称）。
oos的writeObject()方法用来执行序列化的过程，ois的readObject()用来执行反序列化的过程，在传输二进制流之前，需要讲这 两个高层流对象连接到同一个Channel上，这个Channel可以是磁盘文件，也可以是socket底层流。所以无论用哪种方式，底层流对象都是以构 造函数参数的形式传递进oos和ois这两个高层流，连接完毕了才可以进行二进制数据传输的。例子：
可以是文件流通道
file = new File(“C:/data.dat”);
oos = new ObjectOutputStream(new FileOutputStream(file));
ois = new ObjectInputStream(new FileInputStream(file));
或者网络流通道
oos = new ObjectOutputStream(socket.getOutputStream());
ois = new ObjectInputStream(socket.getInputStream()); 
不知道大家是否注意到oos总是在ois之前定义，这里不希望大家误解这个顺序是固定的么？回答是否定的，那么有顺序要求么？回答是肯定的。原则是什么呢？
原则是互相对接的输入/输出流之间必须是output流先初始化然后再input流初始化，否则就会抛异常。大家肯定会问为什么？只要稍微看一看这两个类 的源代码文件就大概知道了，output流的任务很简单，只要把对象转换成二进制往通道中写就可以了，但input流需要做很多准备工作来接受并最终重组 这个Object，所以ObjectInputStream的构造函数中就需要用到output初始化发送过来的header信息，这个方法叫做 readStreamHeader()，它将会去读两个Short值用于决定用多大的缓存来存放通道发送过来的二进制流，这个缓存的size因jre的版 本不同是不一样的。所以output如果不先初始化，input的构造函数首先就无法正确运行。
对于上面两个例子，第一个顺序是严格的，第二个因为oos和ois连接的已经不是对方了，而是socket另外一端的流，需要严格按照另外一方对接的output流先于对接的input流打开才能顺利运行。
这个writeObject和readObject本身就是线程安全的，传输过程中是不允许被并发访问的。所以对象能一个一个接连不断的传过来，有很多人 在运行的时候会碰到EOFException, 然后百思不得其解，去各种论坛问解决方案。其实笔者这里想说，这个异常不是必须声明的，也就是说它虽然是异常，但其实是正常运行结束的标志。EOF表示读 到了文件尾，发送结束自然连接也就断开了。如果这影响到了你程序的正确性的话，请各位静下心来看看自己程序的业务逻辑，而不要把注意力狭隘的聚集在发送和 接受的方法上。因为笔者也被这样的bug困扰了1整天，被很多论坛的帖子误解了很多次最后得出的教训。如果在while循环中去readObject，本 质上是没有问题的，有对象数据来就会读，没有就自动阻塞。那么抛出EOFException一定是因为连接断了还在继续read，什么原因导致连接断了 呢？一定是业务逻辑哪里存在错误，比如NullPoint、 ClassCaseException、ArrayOutofBound，即使程序较大也没关系，最多只要单步调适一次就能很快发现bug并且解决它。
难怪一位程序大师说过：解决问题90％靠经验，5％靠技术，剩下5％靠运气！真是金玉良言，笔者大概查阅过不下30篇讨论在while循环中使用 readObject抛出EOFExceptionde 的帖子，大家都盲目的去关注解释这个名词、反序列化的行为或反对这样写而没有一个人认为EOF是正确的行为，它其实很老实的在做它的事情。为什么大家都忽 略了真正出错误的地方呢？两个字，经验！

2．关于Java的多线程编程
关于Java的线程，初学或者接触不深的大概也能知道一些基本概念，同时又会很迷惑线程到底是怎么回事？如果有人认为自己已经懂了不妨来回答下面的问题：
a. A对象实现Runnable接口，A.start()运行后所谓的线程对象是谁？是A么？
b. 线程的wait()、notify()方法到底是做什么时候用的，什么时候用？
c. 为什么线程的suspend方法会被标注过时，不推荐再使用，线程还能挂起么？
d. 为了同步我们会对线程方法声明Synchronized来加锁在对象上，那么如果父类的f()方法加了Synchronized，子类重写f()方法必须 也加Synchronized么？如果子类的f()方法重写时声明Synchronized并调用super.f()，那么子类对象上到底有几把锁呢？会 因为竞争产生死锁么？
呵呵，各位能回答上来几道呢？如果这些都能答上来，说明对线程的概念还是满清晰的，虽说还远远不能算精通。笔者这里一一做回答，碍于篇幅的原因，笔者尽量说得简介一点，如果大家有疑惑的欢迎一起讨论。
首先第一点，线程跟对象完全是两回事，虽然我们也常说线程对象。但当你用run()和start()来启动一个线程之后，线程其实跟这个继承了 Thread或实现了Runnable的对象已经没有关系了，对象只能算内存中可用资源而对象的方法只能算内存正文区可以执行的代码段而已。既然是资源和 代码段，另外一个线程当然也可以去访问，main函数执行就至少会启动两个线程，一个我们称之为主线程，还一个是垃圾收集器的线程，主线程结束就意味着程 序结束，可垃圾收集器线程很可能正在工作。
第二点，wait()和sleep()类似，都是让线程处于阻塞状态暂停一段时间，不同之处在于wait会释放当前线程占有的所有的锁，而 sleep不会。我们知道获得锁的唯一方法是进入了Synchronized保护代码段，所以大家会发现只有Synchronized方法中才会出现 wait，直接写会给警告没有获得当前对象的锁。所以notify跟wait配合使用，notify会重新把锁还给阻塞的线程重而使其继续执行，当有多个 对象wait了，notify不能确定唤醒哪一个，必经锁只有一把，所以一般用notifyAll()来让它们自己根据优先级等竞争那唯一的一把锁，竞争 到的线程执行，其他线程只要继续wait。
从前Java允许在一个线程之外把线程挂起，即调用suspend方法，这样的操作是极不安全的。根据面向对象的思想每个对象必须对自己的行为负责，而对 自己的权力进行封装。如果任何外步对象都能使线程被挂起而阻塞的话，程序往往会出现混乱导致崩溃，所以这样的方法自然是被毙掉了啦。
最后一个问题比较有意思，首先回答的是子类重写f()方法可以加Synchronized也可以不加，如果加了而且还内部调用了super.f ()的话理论上是应该对同一对象加两把锁的，因为每次调用Synchronized方法都要加一把，调用子类的f首先就加了一把，进入方法内部调用父类的 f又要加一把，加两把不是互斥的么？那么调父类f加锁不就必须永远等待已经加的锁释放而造成死锁么？实际上是不会的，这个机制叫重进入，当父类的f方法试 图在本对象上再加一把锁的时候，因为当前线程拥有这个对象的锁，也可以理解为开启它的钥匙，所以同一个线程在同一对象上还没释放之前加第二次锁是不会出问 题的，这个锁其实根本就没有加，它有了钥匙，不管加几把还是可以进入锁保护的代码段，畅通无阻，所以叫重进入，我们可以简单认为第二把锁没有加上去。
总而言之，Synchronized的本质是不让其他线程在同一对象上再加一把锁。
Java杂谈（五）
本来预计J2se只讲了第四篇就收尾了，可是版主厚爱把帖子置顶长期让大家浏览让小弟倍感责任重大，务必追求最到更好，所以关于J2se一些没有提到的部 分，决定再写几篇把常用的部分经验全部写出来供大家讨论切磋。这一篇准备讲一讲Xml解析包和Java Swing，然后下一篇再讲java.security包关于Java沙箱安全机制和RMI机制，再进入J2ee的部分，暂时就做这样的计划了。如果由于 实习繁忙更新稍微慢了一些，希望各位见谅！ 
1． Java关于XML的解析 
相信大家对XML都不陌生，含义是可扩展标记语言。本身它也就是一个数据的载体以树状表现形式出现。后来慢慢的数据变成了信息，区别是信息可以包括可变的 状态从而针对程序硬编码的做法变革为针对统一接口硬编码而可变状态作为信息进入了XML中存储。这样改变状态实现扩展的唯一工作是在XML中添加一段文本 信息就可以了，代码不需要改动也不需要重新编译。这个灵活性是XML诞生时候谁也没想到的。 
当然，如果接口要能提取XML中配置的信息就需要程序能解析规范的XML文件，Java中当然要提高包对这个行为进行有利支持。笔者打算讲到的两个包是 org.w3c.dom和javax.xml.parsers和。（大家可以浏览一下这些包中间的接口和类定义） 
Javax.xml.parsers包很简单，没有接口，两个工厂配两个解析器。显然解析XML是有两种方式的：DOM解析和SAX解析。本质上并没有谁好谁不好，只是实现的思想不一样罢了。给一个XML文件的例子： 
&lt;?xml version=”1.0” encoding=”UTF-8” &gt; 
&lt;root &gt; 
&lt;child name=”Kitty” &gt; 
A Cat 
&lt;/child &gt; 
&lt;/root &gt; 
所谓DOM解析的思路是把整个树状图存入内存中，需要那个节点只需要在树上搜索就可以读到节点的属性，内容等，这样的好处是所有节点皆在内存可以反复搜索重复使用，缺点是需要消耗相应的内存空间。 
自然SAX解析的思路就是为了克服DOM的缺点，以事件触发为基本思路，顺序的搜索下来，碰到了Element之前触发什么事件，碰到之后做什么动作。由 于需要自己来写触发事件的处理方案，所以需要借助另外一个自定义的Handler，处于org.xml.sax.helpers包中。它的优点当然是不用 整个包都读入内存，缺点也是只能顺序搜索，走完一遍就得重来。 
大家很容易就能猜到，接触到的J2ee框架用的是哪一种，显然是DOM。因为类似Struts，Hibernate框架配置文件毕竟是很小的一部分配置信 息，而且需要频繁搜索来读取，当然会采用DOM方式（其实SAX内部也是用DOM采用的结构来存储节点信息的）。现在无论用什么框架，还真难发现使用 SAX来解析XML的技术了，如果哪位仁兄知道，请让笔者也学习学习。 
既然解析方式有了，那么就需要有解析的存储位置。不知道大家是否发现org.w3c.dom这个包是没有实现类全部都是接口的。这里笔者想说一下Java 如何对XML解析是Jdk应该考虑的事，是它的责任。而w3c组织是维护定义XML标准的组织，所以一个XML结构是怎么样的由w3c说了算，它不关心 Java如何去实现，于是乎规定了所有XML存储的结构应该遵循的规则，这就是org.w3c.dom里全部的接口目的所在。在笔者看来，简单理解接口的 概念就是实现者必须遵守的原则。 
整个XML对应的结构叫Document、子元素对应的叫做Element、还有节点相关的Node、NodeList、Text、Entity、 CharacterData、CDATASection等接口，它们都可以在XML的语法中间找到相对应的含义。由于这里不是讲解XML基本语法，就不多 介绍了。如果大家感兴趣，笔者也可以专门写一篇关于XML的语法规则帖与大家分享一下。 
2． Java Swing 
Swing是一个让人又爱又恨的东西，可爱之处在于上手很容易，较AWT比起来Swing提供的界面功能更加强大，可恨之处在于编复杂的界面工作量实在是 巨大。笔者写过超过3000行的Swing界面，感觉用户体验还不是那么优秀。最近又写过超过6000行的，由于功能模块多了，整体效果还只是一般般。体 会最深的就一个字：累! 所以大家现在都陆续不怎么用Swing在真正开发的项目上了，太多界面技术可以取代它了。笔者去写也是迫于无奈组里面大家都没写过，我不入地域谁入？ 
尽管Swing慢慢的在被人忽略，特别是随着B/S慢慢的在淹没C/S，笔者倒是很愿意站出来为Swing正身。每一项技术的掌握绝不是为了流行时尚跟 风。真正喜欢Java的朋友们还是应该好好体会一下Swing，相信在校的很多学生也很多在学习它。很可能从Jdk 1.1、1.2走过来的很多大学老师可能是最不熟悉它的。 
Swing提供了一组轻组件统称为JComponent，它们与AWT组件的最大区别是JComponent全部都是Container，而 Container的特点是里面可以装载别的组件。在Swing组件中无论是JButton、JLabel、JPanel、JList等都可以再装入任何 其他组件。好处是程序员可以对Swing组件实现“再开发”，针对特定需求构建自己的按钮、标签、画板、列表之类的特定组件。 
有轻自然就有重，那么轻组件和重组件区别是？重组件表现出来的形态因操作系统不同而异，轻组件是Swing自己提供GUI，在跨平台的时候最大程度的保持一致。 
那么在编程的时候要注意一些什么呢？笔者谈谈自己的几点经验： 
a. 明确一个概念，只有Frame组件才可以单独显示的，也许有人会说JOptionPane里面的静态方法就实现了单独窗口出现，但追寻源代码会发现其实现 实出来的Dialog也需要依托一个Frame窗体，如果没有指定就会默认产生一个然后装载这个Dialog显示出来。 
b. JFrame是由这么几部分组成： 
最底下一层JRootPane，上面是glassPane (一个JPanel)和layeredPane (一个JLayeredPane)，而layeredPane又由contentPane(一个JPanel)和menuBar构成。我们的组件都是加在 contentPane上，而背景图片只能加在layeredPane上面。 至于glassPane是一个透明的覆盖了contentPane的一层，在特定效果中将被利用到来记录鼠标坐标或掩饰组件。 
c. 为了增强用户体验，我们会在一些按钮上添加快捷键，但Swing里面通常只能识别键盘的Alt键，要加入其他的快捷键，必须自己实现一个ActionListener。 
d. 通过setLayout(null)可以使得所有组件以setBounds()的四个参数来精确定位各自的大小、位置，但不推荐使用，因为好的编程风格不 应该在Swing代码中硬编码具体数字，所有的数字应该以常数的形式统一存在一个静态无实例资源类文件中。这个静态无实例类统一负责Swing界面的风 格，包括字体和颜色都应该包括进去。 
e. 好的界面设计有一条Golden Rule: 用户不用任何手册通过少数尝试就能学会使用软件。所以尽量把按钮以菜单的形式（不管是右键菜单还是窗体自带顶部菜单）呈现给顾客，除非是频繁点击的按钮才有必要直接呈现在界面中。 
其实Swing的功能是相当强大的，只是现在应用不广泛，专门去研究大概是要花不少时间的。笔者在各网站论坛浏览关于Swing的技巧文章还是比较可信 的，自己所学非常有限，各人体会对Swing各个组件的掌握就是一个实践积累的过程。笔者只用到过以上这些，所以只能谈谈部分想法，还望大家见谅！
Java杂谈（六）
这篇是笔者打算写的J2se部分的最后一篇了，这篇结束之后，再写J2ee部分，不知道是否还合适写在这个版块？大家可以给点意见，谢谢大家对小弟这么鼓 励一路写完前六篇Java杂谈的J2se部分。最后这篇打算谈一谈Java中的RMI机制和JVM沙箱安全框架。 
1． Java中的RMI机制 
RMI的全称是远程方法调用，相信不少朋友都听说过，基本的思路可以用一个经典比方来解释：A计算机想要计算一个两个数的加法，但A自己做不了，于是叫另 外一台计算机B帮忙，B有计算加法的功能，A调用它就像调用这个功能是自己的一样方便。这个就叫做远程方法调用了。 
远程方法调用是EJB实现的支柱，建立分布式应用的核心思想。这个很好理解，再拿上面的计算加法例子，A只知道去call计算机B的方法，自己并没有B的 那些功能，所以A计算机端就无法看到B执行这段功能的过程和代码，因为看都看不到，所以既没有机会窃取也没有机会去改动方法代码。EJB正式基于这样的思 想来完成它的任务的。当简单的加法变成复杂的数据库操作和电子商务交易应用的时候，这样的安全性和分布式应用的便利性就表现出来优势了。 
好了，回到细节上，要如何实现远程方法调用呢？我希望大家学习任何技术的时候可以试着依赖自己的下意识判断，只要你的想法是合理健壮的，那么很可能实际上 它就是这么做的，毕竟真理都蕴藏在平凡的生活细节中。这样只要带着一些薄弱的Java基础来思考RMI，其实也可以想出个大概来。 
a) 需要有一个服务器角色，它拥有真正的功能代码方法。例如B，它提供加法服务 
b) 如果想远程使用B的功能，需要知道B的IP地址 
c) 如果想远程使用B的功能，还需要知道B中那个特定服务的名字 
我们很自然可以想到这些，虽然不完善，但已经很接近正确的做法了。实际上RMI要得以实现还得意于Java一个很重要的特性，就是Java反射机制。我们需要知道服务的名字，但又必须隐藏实现的代码，如何去做呢？答案就是：接口！ 
举个例子： 
public interface Person(){ 
public void sayHello(); 
} 
Public class PersonImplA implements Person{ 
public PersonImplA(){} 
public void sayHello(){ System.out.println(“Hello!”);} 
} 
Public class PersonImplB implements Person{ 
public PersonImplB(){} 
public void sayHello(){ System.out.println(“Nice to meet you!”);} 
} 
客户端：Person p = Naming.lookup(“PersonService”); 
p.sayHello(); 
就这几段代码就包含了几乎所有的实现技术，大家相信么？客户端请求一个say hello服务，服务器运行时接到这个请求，利用Java反射机制的Class.newInstance()返回一个对象，但客户端不知道服务器返回的是 ImplA还是ImplB，它接受用的参数签名是Person，它知道实现了Person接口的对象一定有sayHello()方法，这就意味着客户端并 不知道服务器真正如何去实现的，但它通过了解Person接口明确了它要用的服务方法名字叫做sayHello()。 
如此类推，服务器只需要暴露自己的接口出来供客户端，所有客户端就可以自己选择需要的服务。这就像餐馆只要拿出自己的菜单出来让客户选择，就可以在后台厨房一道道的按需做出来，它怎么做的通常是不让客户知道的！（祖传菜谱吧，^\_^） 
最后一点是我调用lookup，查找一个叫PersonService名字的对象，服务器只要看到这个名字，在自己的目录（相当于电话簿）中找到对应的对 象名字提供服务就可以了，这个目录就叫做JNDI (Java命名与目录接口），相信大家也听过的。 
有兴趣的朋友不妨自己做个RMI的应用，很多前辈的博客中有简单的例子。提示一下利用Jdk的bin目录中rmi.exe和 rmiregistry.exe两个命令就可以自己建起一个服务器，提供远程服务。因为例子很容易找，我就不自己举例子了！ 
2． JVM沙箱&框架 
RMI罗唆得太多了，实在是尽力想把它说清楚，希望对大家有帮助。最后的最后，给大家简单讲一下JVM框架，我们叫做Java沙箱。Java沙箱的基本组件如下： 
a) 类装载器结构 
b) class文件检验器 
c) 内置于Java虚拟机的安全特性 
d) 安全管理器及Java API 
其中类装载器在3个方面对Java沙箱起作用： 
a. 它防止恶意代码去干涉善意的代码 
b. 它守护了被信任的类库边界 
c. 它将代码归入保护域，确定了代码可以进行哪些操作 
虚拟机为不同的类加载器载入的类提供不同的命名空间，命名空间由一系列唯一的名称组成，每一个被装载的类将有一个名字，这个命名空间是由Java虚拟机为每一个类装载器维护的，它们互相之间甚至不可见。 
我们常说的包（package）是在Java虚拟机第2版的规范第一次出现，正确定义是由同一个类装载器装载的、属于同一个包、多个类型的集合。类装载器 采用的机制是双亲委派模式。具体的加载器框架我在Java杂谈（一）中已经解释过了，当时说最外层的加载器是AppClassLoader，其实算上网络 层的话AppClassLoader也可以作为parent，还有更外层的加载器URLClassLoader。为了防止恶意攻击由URL加载进来的类文 件我们当然需要分不同的访问命名空间，并且制定最安全的加载次序，简单来说就是两点：
a. 从最内层JVM自带类加载器开始加载，外层恶意同名类得不到先加载而无法使用 
b. 由于严格通过包来区分了访问域，外层恶意的类通过内置代码也无法获得权限访问到内层类，破坏代码就自然无法生效。 
附：关于Java的平台无关性，有一个例子可以很明显的说明这个特性： 
一般来说，C或C++中的int占位宽度是根据目标平台的字长来决定的，这就意味着针对不同的平台编译同一个C++程序在运行时会有不同的行为。然而对于 Java中的int都是32位的二进制补码标识的有符号整数，而float都是遵守IEEE 754浮点标准的32位浮点数。 
PS: 这个小弟最近也没时间继续研究下去了，只是想抛砖引玉的提供给大家一个初步认识JVM的印象。有机会了解一下JVM的内部结构对今后做Java开发是很有好处的。
Java杂谈（七）－－接口& 组件、容器
终于又静下来继续写这个主题的续篇，前六篇主要讲了一些J2se方面的经验和感受， 眼下Java应用范围已经被J2ee占据了相当大的一块领域，有些人甚至声称Java被J2ee所取代了。不知道大家如何来理解所谓的J2ee (Java2 Enterprise Edition)，也就是Java企业级应用？ 
笔者的观点是，技术的发展是顺应世界变化的趋势的，从C/S过渡到B/S模式，从客户端的角度考虑企业级应用或者说电子商务领域不在关心客户端维护问题， 这个任务已经交给了任何一台PC都会有的浏览器去维护；从服务器端的角度考虑，以往C/S中的TCP/IP协议实现载体ServerSocket被Web Server Container所取代，例如大家都很熟悉的Tomcat、JBoss、WebLogic等等。总之一切的转变都是为了使得Java技术能更好的为人类 生产生活所服务。 
有人会问，直接去学J2ee跳过J2se行否？笔者是肯定不赞成的，实际上确实有人走这条路，但笔者自身体会是正是由于J2se的基础很牢固，才会导致在J2ee学习的道路上顺风顺水，知识点上不会有什么迷惑的地方。举个简单的例子吧： 
笔者曾经跟大学同学讨论下面这两种写法的区别： 
ArrayList list = new ArrayList(); //笔者不说反对，但至少不赞成 
List list = new ArrayList(); //笔者支持 
曾经笔者跟同学争论了几个小时，他非说第一种写法更科学，第二种完全没有必要。我无法完全说服他，但笔者认为良好的习惯和意识是任何时候都应该针对接口编程，以达到解耦合和可扩展性的目的。下面就以接口开始进入J2ee的世界吧： 
1. J2ee与接口 
每一个版本的J2ee都对应着一个确定版本的JDK，J2ee1.4对应Jdk1.4，现在比较新的是JDK5.0，自然也会有J2EE 5.0。其实笔者一直在用的是J2EE1.4，不过没什么关系，大家可以下任何一个版本的J2ee api来稍微浏览一下。笔者想先声明一个概念，J2ee也是源自Java，所以底层的操作依然调用到很多J2se的库，所以才建议大家先牢牢掌握J2se 的主流技术。 
J2ee api有一个特点，大家比较熟悉的几个包java.jms、javax.servlet.http、javax.ejb等都以interface居多，实 现类较少。其实大家真正在用的时候百分之六十以上都在反复的查着javax.servlet.http这个包下面几个实现类的api函数，其他的包很少问 津。笔者建议在学习一种技术之前，对整体的框架有一个了解是很有必要的，J2ee旨在通过interface的声明来规范实现的行为，任何第三方的厂商想 要提供自己品牌的实现前提也是遵循这些接口定义的规则。如果在从前J2se学习的道路上对接口的理解很好的话，这里的体会将是非常深刻的，举个简单的例 子： 
public interface Mp3{ 
public void play(); 
public void record(); 
public void stop(); 
} 
如果我定义这个简单的接口，发布出去，规定任何第三方的公司想推出自己的名字为Mp3的产品都必须实现这个接口，也就是至少提供接口中方法的具体实现。这 个意义已经远远不止是面向对象的多态了，只有厂商遵循J2ee的接口定义，世界上的J2ee程序员才能针对统一的接口进行程序设计，最终不用改变代码只是 因为使用了不同厂商的实现类而有不同的特性罢了，本质上说，无论哪一种厂商实现都完成了职责范围内的工作。这个就是笔者想一直强调的，针对接口编程的思 想。 
接口到底有什么好处呢？我们这样设想，现在有AppleMp3、SonyMp3、SamsungMp3都实现了这个Mp3的接口，于是都有了play、 record、stop这三个功能。我们将Mp3产品座位一个组件的时候就不需要知道它的具体实现，只要看到接口定义知道这个对象有3个功能就可以使用 了。那么类似下面这样的业务就完全可以在任何时间从3个品牌扩展到任意个品牌，开个玩笑的说，项目经理高高在上的写完10个接口里的方法声明，然后就丢给 手下的程序员去写里面的细节，由于接口已经统一（即每个方法传入和传出的格式已经统一），经理只需关注全局的业务就可以天天端杯咖啡走来走去了，^\_^： 
public Mp3 create(); 
public void copy(Mp3 mp3); 
public Mp3 getMp3(); 
最后用一个简单的例子说明接口：一个5号电池的手电筒，可以装入任何牌子的5号电池，只要它符合5号电池的规范，装入之后任何看不到是什么牌子，只能感受 到手电筒在完成它的功能。那么生产手电筒的厂商和生产5号电池的厂商就可以完全解除依赖关系，可以各自自由开发自己的产品，因为它们都遵守5号电池应有的 形状、正负极位置等约定。这下大家能对接口多一点体会了么？ 
2. 组件和容器 
针对接口是笔者特意强调的J2ee学习之路必备的思想，另外一个就是比较常规的组件和容器的概念了。很多教材和专业网站都说J2EE的核心是一组规范与指 南，强调J2ee的核心概念就是组件+容器，这确实是无可厚非的。随着越来越多的J2ee框架出现，相应的每种框架都一般有与之对应的容器。 
容器，是用来管理组件行为的一个集合工具，组件的行为包括与外部环境的交互、组件的生命周期、组件之间的合作依赖关系等等。J2ee包含的容器种类大约有 Web容器、Application Client容器、EJB容器、Applet客户端容器等。但在笔者看来，现在容器的概念变得有点模糊了，大家耳熟能详是那些功能强大的开源框架，比如 Hibernate、Struts2、Spring、JSF等，其中Hibernate就基于JDBC的基础封装了对事务和会话的管理，大大方便了对数据 库操作的繁琐代码，从这个意义上来说它已经接近容器的概念了，EJB的实体Bean也逐渐被以Hibernate为代表的持久化框架所取代。 
组件，本意是指可以重用的代码单元，一般代表着一个或者一组可以独立出来的功能模块，在J2ee中组件的种类有很多种，比较常见的是EJB组件、DAO组 件、客户端组件或者应用程序组件等，它们有个共同特点是分别会打包成.war，.jar，.jar，.ear，每个组件由特定格式的xml描述符文件进行 描述，而且服务器端的组件都需要被部署到应用服务器上面才能够被使用。 
稍微理解完组件和容器，还有一个重要的概念就是分层模型，最著名的当然是MVC三层模型。在一个大的工程或项目中，为了让前台和后台各个模块的编程人员能 够同时进行工作提高开发效率，最重要的就是实现层与层之间的耦合关系，许多分层模型的宗旨和开源框架所追求的也就是这样的效果。在笔者看来，一个完整的 Web项目大概有以下几个层次： 
a) 表示层（Jsp、Html、Javascript、Ajax、Flash等等技术对其支持） 
b) 控制层（Struts、JSF、WebWork等等框架在基于Servlet的基础上支持，负责把具体的请求数据（有时卸载重新装载）导向适合处理它的模型层对象） 
c) 模型层（笔者认为目前最好的框架是Spring，实质就是处理表示层经由控制层转发过来的数据，包含着大量的业务逻辑） 
d) 数据层（Hibernate、JDBC、EJB等，由模型层处理完了持久化到数据库中） 
当然，这仅仅是笔者个人的观点，仅仅是供大家学习做一个参考，如果要实现这些层之间的完全分离，那么一个大的工程，可以仅仅通过增加人手就来完成任务。虽 然《人月神话》中已经很明确的阐述了增加人手并不能是效率增加，很大程度上是因为彼此做的工作有顺序上的依赖关系或者说难度和工作量上的巨大差距。当然理 想状态在真实世界中是不可能达到的，但我们永远应该朝着这个方向去不断努力。最开始所提倡的针对接口来编程，哪怕是小小的细节，写一条List list= = new ArrayList()语句也能体现着处处皆使用接口的思想在里面。Anyway，这只是个开篇，笔者会就自己用过的J2ee技术和框架再细化谈一些经验.
Java杂谈（八）－－Servlet/Jsp
终于正式进入J2ee的细节部分了，首当其冲的当然是Servlet和Jsp了，上篇曾经提到过J2ee只是一个规范和指南，定义了一组必须要遵循的接 口，核心概念是组件和容器。曾经有的人问笔者Servlet的Class文件是哪里来的？他认为是J2ee官方提供的，我举了一个简单的反例：稍微检查了 一下Tomcat5.0里面的Servlet.jar文件和JBoss里面的Servlet.jar文件大小，很明显是不一样的，至少已经说明了它们不是 源自同根的吧。其实Servlet是由容器根据J2ee的接口定义自己来实现的，实现的方式当然可以不同，只要都遵守J2ee规范和指南。 
上述只是一个常见的误区罢了，告诉我们要编译运行Servlet，是要依赖于实现它的容器的，不然连jar文件都没有，编译都无法进行。那么Jsp呢？ Java Server Page的简称，是为了开发动态网页而诞生的技术，其本质也是Jsp，在编写完毕之后会在容器启动时经过编译成对应的Servlet。只是我们利用Jsp 的很多新特性，可以更加专注于前后台的分离，早期Jsp做前台是满流行的，毕竟里面支持Html代码，这让前台美工人员可以更有效率的去完成自己的工作。 然后Jsp将请求转发到后台的Servlet，由Servlet处理业务逻辑，再转发回另外一个Jsp在前台显示出来。这似乎已经成为一种常用的模式，最 初笔者学习J2ee的时候，大量时间也在编写这样的代码。 
尽管现在做前台的技术越来越多，例如Flash、Ajax等，已经有很多人不再认为Jsp重要了。笔者觉得Jsp带来的不仅仅是前后端分离的设计理念，它 的另外一项技术成就了我们今天用的很多框架，那就是Tag标签技术。所以与其说是在学习Jsp，不如更清醒的告诉自己在不断的理解Tag标签的意义和本 质。 
1． Servlet以及Jsp的生命周期 
Servlet是Jsp的实质，尽管容器对它们的处理有所区别。Servlet有init()方法初始化，service()方法进行Web服务， destroy()方法进行销毁，从生到灭都由容器来掌握，所以这些方法除非你想自己来实现Servlet，否则是很少会接触到的。正是由于很少接触，才 容易被广大初学者所忽略，希望大家至少记住Servlet生命周期方法都是回调方法。回调这个概念简单来说就是把自己注入另外一个类中，由它来调用你的方 法，所谓的另外一个类就是Web容器，它只认识接口和接口的方法，注入进来的是怎样的对象不管，它只会根据所需调用这个对象在接口定义存在的那些方法。由 容器来调用的Servlet对象的初始化、服务和销毁方法，所以叫做回调。这个概念对学习其他J2ee技术相当关键！ 
那么Jsp呢？本事上是Servlet，还是有些区别的，它的生命周期是这样的： 
a) 一个客户端的Request到达服务器 -&gt; 
b) 判断是否第一次调用 -&gt; 是的话编译Jsp成Servlet 
c) 否的话再判断此Jsp是否有改变 -&gt; 是的话也重新编译Jsp成Servlet 
d) 已经编译最近版本的Servlet装载所需的其他Class 
e) 发布Servlet，即调用它的Service()方法 
所以Jsp号称的是第一次Load缓慢，以后都会很快的运行。从它的生命的周期确实不难看出来这个特点，客户端的操作很少会改变Jsp的源码，所以它不需 要编译第二次就一直可以为客户端提供服务。这里稍微解释一下Http的无状态性，因为发现很多人误解，Http的无状态性是指每次一张页面显示出来了，与 服务器的连接其实就已经断开了，当再次有提交动作的时候，才会再次与服务器进行连接请求提供服务。当然还有现在比较流行的是Ajax与服务器异步通过 xml交互的技术，在做前台的领域潜力巨大，笔者不是Ajax的高手，这里无法为大家解释。 
2． Tag标签的本质 
笔者之前说了，Jsp本身初衷是使得Web应用前后台的开发可以脱离耦合分开有效的进行，可惜这个理念的贡献反倒不如它带来的Tag技术对J2ee的贡献 要大。也许已经有很多人开始使用Tag技术了却并不了解它。所以才建议大家在学习J2ee开始的时候一定要认真学习Jsp，其实最重要的就是明白标签的本 质。 
Html标签我们都很熟悉了，有 &lt;html&gt; 、 &lt;head&gt; 、 &lt;body&gt; 、 &lt;title&gt; ，Jsp带来的Tag标签遵循同样的格式，或者说更严格的Xml格式规范，例如 &lt;jsp:include&gt; 、 &lt;jsp:useBean&gt; 、 &lt;c:if&gt; 、 &lt;c:forEach&gt; 等等。它们没有什么神秘的地方，就其源头也还是Java Class而已，Tag标签的实质也就是一段Java代码，或者说一个Class文件。当配置文件设置好去哪里寻找这些Class的路径后，容器负责将页 面中存在的标签对应到相应的Class上，执行那段特定的Java代码，如此而已。 
说得明白一点的话还是举几个简单的例子说明一下吧： 
&lt;jsp:include&gt; 去哪里找执行什么class呢?首先这是个jsp类库的标签，当然要去jsp类库寻找相应的class了，同样它也是由Web容器来提供，例如 Tomcat就应该去安装目录的lib文件夹下面的jsp-api.jar里面找，有兴趣的可以去找一找啊！ 
&lt;c:forEach&gt; 又去哪里找呢？这个是由Jsp2.0版本推荐的和核心标记库的内容，例如 &lt;c:if&gt; 就对应在页面中做if判断的功能的一断Java代码。它的class文件在jstl.jar这个类库里面，往往还需要和一个standard.jar类库 一起导入，放在具体Web项目的WEB-INF的lib目录下面就可以使用了。 
顺便罗唆一句，Web Project的目录结构是相对固定的，因为容器会按照固定的路径去寻找它需要的配置文件和资源，这个任何一本J2ee入门书上都有，这里就不介绍了。了 解Tag的本质还要了解它的工作原理，所以大家去J2ee的API里找到并研究这个包：javax.servlet.jsp.tagext。它有一些接 口，和一些实现类，专门用语开发Tag，只有自己亲自写出几个不同功能的标签，才算是真正理解了标签的原理。别忘记了自己开发的标签要自己去完成配置文 件，容器只是集成了去哪里寻找jsp标签对应class的路径，自己写的标签库当然要告诉容器去哪里找啦。 
说了这么多，我们为什么要用标签呢？完全在Jsp里面来个 &lt;% %&gt; 就可以在里面任意写Java代码了，但是长期实践发现页面代码统一都是与html同风格的标记语言更加有助于美工人员进行开发前台，它不需要懂Java， 只要Java程序员给个列表告诉美工什么标签可以完成什么逻辑功能，他就可以专注于美工，也算是进一步隔离了前后台的工作吧！
3． 成就Web框架 
框架是什么？曾经看过这样的定义：与模式类似，框架也是解决特定问题的可重用方法，框架是一个描述性的构建块和服务集合，开发人员可以用来达成某个目标。 一般来说，框架提供了解决某类问题的基础设施，是用来创建解决方案的工具，而不是问题的解决方案。 
正是由于Tag的出现，成就了以后出现的那么多Web框架，它们都开发了自己成熟实用的一套标签，然后由特定的Xml文件来配置加载信息，力图使得Web 应用的开发变得更加高效。下面这些标签相应对很多人来说相当熟悉了： 
&lt;html:password&gt; 
&lt;logic:equal&gt; 
&lt;bean:write&gt; 
&lt;f:view&gt; 
&lt;h:form&gt; 
&lt;h:message&gt; 
它们分别来自Struts和JSF框架，最强大的功能在于控制转发，就是MVC三层模型中间完成控制器的工作。Struts-1实际上并未做到真正的三层 隔离，这一点在Struts-2上得到了很大的改进。而Jsf向来以比较完善合理的标签库受到人们推崇。 
今天就大概讲这么多吧，再次需要强调的是Servlet/Jsp是学习J2ee必经之路，也是最基础的知识，希望大家给与足够的重视！
Java杂谈（九）－－Struts
J2ee的开源框架很多，笔者只能介绍自己熟悉的几个，其他的目前在中国IT行业应用得不是很多。希望大家对新出的框架不要盲目的推崇，首先一定要熟悉它比旧的到底好在哪里，新的理念和特性是什么？然后再决定是否要使用它。
这期的主题是Struts，直译过来是支架。Struts的第一个版本是在2001年5月发布的，它提供了一个Web应用的解决方案，如何让Jsp和 servlet共存去提供清晰的分离视图和业务应用逻辑的架构。在Struts之前，通常的做法是在Jsp中加入业务逻辑，或者在Servlet中生成视 图转发到前台去。Struts带着MVC的新理念当时退出几乎成为业界公认的Web应用标准，于是当代IT市场上也出现了众多熟悉Struts的程序员。 即使有新的框架再出来不用，而继续用Struts的理由也加上了一条低风险，因为中途如果开发人员变动，很容易的招进新的会Struts的IT民工啊， ^\_^! 
笔者之前说的都是Struts-1，因为新出了Struts-2，使得每次谈到Struts都必须注明它是Struts-1还是2。笔者先谈比较熟悉的 Struts-1，下次再介绍一下与Struts－2的区别： 
1． Struts框架整体结构 
Struts-1的核心功能是前端控制器，程序员需要关注的是后端控制器。前端控制器是是一个Servlet，在Web.xml中间配置所有 Request都必须经过前端控制器，它的名字是ActionServlet，由框架来实现和管理。所有的视图和业务逻辑隔离都是应为这个 ActionServlet， 它就像一个交通警察，所有过往的车辆必须经过它的法眼，然后被送往特定的通道。所有，对它的理解就是分发器，我们也可以叫做Dispatcher，其实了 解Servlet编程的人自己也可以写一个分发器，加上拦截request的Filter，其实自己实现一个struts框架并不是很困难。主要目的就是 让编写视图的和后台逻辑的可以脱离紧耦合，各自同步的完成自己的工作。 
那么有了ActionServlet在中间负责转发，前端的视图比如说是Jsp，只需要把所有的数据Submit，这些数据就会到达适合处理它的后端控制 器Action，然后在里面进行处理，处理完毕之后转发到前台的同一个或者不同的视图Jsp中间，返回前台利用的也是Servlet里面的forward 和redirect两种方式。所以到目前为止，一切都只是借用了Servlet的API搭建起了一个方便的框架而已。这也是Struts最显著的特性?? 控制器。 
那么另外一个特性，可以说也是Struts-1带来的一个比较成功的理念，就是以xml配置代替硬编码配置信息。以往决定Jsp往哪个servlet提 交，是要写进Jsp代码中的，也就是说一旦这个提交路径要改，我们必须改写代码再重新编译。而Struts提出来的思路是，编码的只是一个逻辑名字，它对 应哪个class文件写进了xml配置文件中，这个配置文件记录着所有的映射关系，一旦需要改变路径，改变xml文件比改变代码要容易得多。这个理念可以 说相当成功，以致于后来的框架都延续着这个思路，xml所起的作用也越来越大。 
大致上来说Struts当初给我们带来的新鲜感就这么多了，其他的所有特性都是基于方便的控制转发和可扩展的xml配置的基础之上来完成它们的功能的。 
下面将分别介绍Action和FormBean， 这两个是Struts中最核心的两个组件。 
2． 后端控制器Action 
Action就是我们说的后端控制器，它必须继承自一个Action父类，Struts设计了很多种Action，例如DispatchAction、 DynaValidationAction。它们都有一个处理业务逻辑的方法execute()，传入的request, response, formBean和actionMapping四个对象，返回actionForward对象。到达Action之前先会经过一个 RequestProcessor来初始化配置文件的映射关系，这里需要大家注意几点： 
1) 为了确保线程安全，在一个应用的生命周期中，Struts框架只会为每个Action类创建一个Action实例，所有的客户请求共享同一个Action 实例，并且所有线程可以同时执行它的execute()方法。所以当你继承父类Action，并添加了private成员变量的时候，请记住这个变量可以 被多个线程访问，它的同步必须由程序员负责。(所有我们不推荐这样做)。在使用Action的时候，保证线程安全的重要原则是在Action类中仅仅使用 局部变量，谨慎的使用实例变量。局部变量是对每个线程来说私有的，execute方法结束就被销毁，而实例变量相当于被所有线程共享。 
2) 当ActionServlet实例接收到Http请求后，在doGet()或者doPost()方法中都会调用process()方法来处理请求。 RequestProcessor类包含一个HashMap，作为存放所有Action实例的缓存，每个Action实例在缓存中存放的属性key为 Action类名。在RequestProcessor类的processActionCreate()方法中，首先检查在HashMap中是否存在 Action实例。创建Action实例的代码位于同步代码块中，以保证只有一个线程创建Action实例。一旦线程创建了Action实例并把它存放到 HashMap中，以后所有的线程会直接使用这个缓存中的实例。 
3) &lt;action&gt; 元素的 &lt;roles&gt; 属性指定访问这个Action用户必须具备的安全角色，多个角色之间逗号隔开。RequestProcessor类在预处理请求时会调用自身的 processRoles()方法，检查配置文件中是否为Action配置了安全角色，如果有，就调用HttpServletRequest的 isUserInRole()方法来判断用户是否具备了必要的安全性角色，如果不具备，就直接向客户端返回错误。(返回的视图通过 &lt;input&gt; 属性来指定) 
3． 数据传输对象FormBean 
Struts并没有把模型层的业务对象直接传递到视图层，而是采用DTO（Data Transfer Object）来传输数据，这样可以减少传输数据的冗余，提高传输效率；还有助于实现各层之间的独立，使每个层分工明确。Struts的DTO就是 ActionForm，即formBean。由于模型层应该和Web应用层保持独立。由于ActionForm类中使用了Servlet API， 因此不提倡把ActionForm传递给模型层， 而应该在控制层把ActionForm Bean的数据重新组装到自定义的DTO中， 再把它传递给模型层。它只有两个scope，分别是session和request。（默认是session）一个ActionForm标准的生命周期 是： 
1) 控制器收到请求 -&gt; 
2) 从request或session中取出ActionForm实例，如不存在就创建一个 -&gt; 
3) 调用ActionForm的reset()方法 -&gt; 
4) 把实例放入session或者request中 -&gt; 
5) 将用户输入表达数据组装到ActionForm中 -&gt; 
6) 如眼张方法配置了就调用validate()方法 -&gt; 
7) 如验证错误就转发给 &lt;input&gt; 属性指定的地方，否则调用execute()方法 
validate()方法调用必须满足两个条件： 
1) ActionForm 配置了Action映射而且name属性匹配 
2) &lt;aciton&gt; 元素的validate属性为true 
如果ActionForm在request范围内，那么对于每个新的请求都会创建新的ActionForm实例，属性被初始化为默认值，那么reset ()方法就显得没有必要；但如果ActionForm在session范围内，同一个ActionForm实例会被多个请求共享，reset()方法在这 种情况下极为有用。

4． 验证框架和国际化 
Struts有许多自己的特性，但是基本上大家还是不太常用，说白了它们也是基于JDK中间的很多Java基础包来完成工作。例如国际化、验证框架、插件 自扩展功能、与其他框架的集成、因为各大框架基本都有提供这样的特性，Struts也并不是做得最好的一个，这里也不想多说。Struts的验证框架，是 通过一个validator.xml的配置文件读入验证规则，然后在validation-rules.xml里面找到验证实现通过自动为Jsp插入 Javascript来实现，可以说做得相当简陋。弹出来的JavaScript框不但难看还很多冗余信息，笔者宁愿用formBean验证或者 Action的saveErrors()，验证逻辑虽然要自己写，但页面隐藏/浮现的警告提示更加人性化和美观一些。 
至于Struts的国际化，其实无论哪个框架的国际化，java.util.Locale类是最重要的Java I18N类。在Java语言中，几乎所有的对国际化和本地化的支持都依赖于这个类。如果Java类库中的某个类在运行的时候需要根据Locale对象来调 整其功能，那么就称这个类是本地敏感的(Locale-Sensitive)， 例如java.text.DateFormat类就是，依赖于特定Locale。 
创建Locale对象的时候，需要明确的指定其语言和国家的代码，语言代码遵从的是ISO-639规范，国家代码遵从ISO-3166规范，可以从 
<http://www.unicode.org/unicode/onlinedat/languages.html> 
<http://www.unicode.org/unicode/onlinedat/countries.htm> 
Struts的国际化是基于properties的message/key对应来实现的，笔者曾写过一个程序，所有Jsp页面上没有任何Text文本串， 全部都用的是 &lt;bean:message&gt; 去Properties文件里面读，这个时候其实只要指定不同的语言区域读不同的Properties文件就实现了国际化。需要注意的是不同语言的字符写 进Properties文件的时候需要转化成Unicode码，JDK已经带有转换的功能。JDK的bin目录中有native2ascii这个命令，可 以完成对\*.txt和\*.properties的Unicode码转换。 
OK，今天就说到这里，本文中的很多内容也不是笔者的手笔，是笔者一路学习过来自己抄下来的笔记，希望对大家有帮助！Java杂谈一路走来，感谢大家持续的关注，大概再有个2到3篇续篇就改完结了！笔者尽快整理完成后续的写作吧……^\_^
Java杂谈（九）－－Struts2
最近业余时间笔者一直Java Virtual Machine的研究，由于实习分配到项目组里面，不想从前那么闲了，好不容易才抽出时间来继续这个话题的帖子。我打算把J2ee的部分结束之后，再谈谈 JVM和JavaScript，只要笔者有最新的学习笔记总结出来，一定会拿来及时和大家分享的。衷心希望与热爱Java的关大同仁共同进步…… 
这次准备继续上次的话题先讲讲Struts-2，手下简短回顾一段历史：随着时间的推移，Web应用框架经常变化的需求，产生了几个下一代 Struts的解决方案。其中的Struts Ti 继续坚持 MVC模式的基础上改进，继续Struts的成功经验。 WebWork项目是在2002年3月发布的，它对Struts式框架进行了革命性改进，引进了不少新的思想，概念和功能，但和原Struts代码并不兼 容。WebWork是一个成熟的框架，经过了好几次重大的改进与发布。在2005年12月，WebWork与Struts Ti决定合拼， 再此同时， Struts Ti 改名为 Struts Action Framework 2.0,成为Struts真正的下一代。 
看看Struts-2的处理流程： 
1) Browser产生一个请求并提交框架来处理：根据配置决定使用哪些拦截器、action类和结果等。 
2) 请求经过一系列拦截器：根据请求的级别不同拦截器做不同的处理。这和Struts-1的RequestProcessor类很相似。 
3) 调用Action: 产生一个新的action实例，调用业务逻辑方法。 
4) 调用产生结果：匹配result class并调用产生实例。 
5) 请求再次经过一系列拦截器返回：过程也可配置减少拦截器数量 
6) 请求返回用户：从control返回servlet，生成Html。 
这里很明显的一点是不存在FormBean的作用域封装，直接可以从Action中取得数据。 这里有一个Strut-2配置的web.xml文件：
&lt;filter&gt; 
&lt;filter-name&gt; controller &lt;/filter-name&gt; 
&lt;filter-class&gt; org.apache.struts.action2.dispatcher.FilterDispatcher &lt;/filter-class&gt; 
&lt;/filter&gt; 
&lt;filter-mapping&gt; 
&lt;filter-name&gt; cotroller &lt;/filter-name&gt; 
&lt;url-pattern&gt; /\* &lt;/url-pattern&gt; 
&lt;/filter-mapping&gt; 
注意到以往的servlet变成了filter，ActionServlet变成了FilterDispatcher，\*.do变成了/\*。filter 配置定义了名称(供关联)和filter的类。filter mapping让URI匹配成功的的请求调用该filter。默认情况下，扩展名为 ".action "。这个是在default.properties文件里的 "struts.action.extension "属性定义的。 
default.properties是属性定义文件，通过在项目classpath路径中包含一个名为“struts.properties”的文件来 设置不同的属性值。而Struts-2的默认配置文件名为struts.xml。由于1和2的action扩展名分别为.do和.action，所以很方 便能共存。我们再来看一个Struts-2的action代码： 
public class MyAction { 
public String execute() throws Exception { 
//do the work 
return "success "; 
} 
} 
很明显的区别是不用再继承任何类和接口，返回的只是一个String，无参数。实际上在Struts-2中任何返回String的无参数方法都可以通过配 置来调用action。所有的参数从哪里来获得呢？答案就是Inversion of Control技术（控制反转）。笔者尽量以最通俗的方式来解释，我们先试图让这个Action获得reuqest对象，这样可以提取页面提交的任何参 数。那么我们把request设为一个成员变量，然后需要一个对它的set方法。由于大部分的action都需要这么做，我们把这个set方法作为接口来 实现。 
public interface ServletRequestAware { 
public void setServletRequest(HttpServletRequest request); 
} 
public class MyAction implements ServletRequestAware { 
private HttpServletRequest request; 
public void setServletRequest(HttpServletRequest request) { 
this.request = request; 
} 
public String execute() throws Exception { 
// do the work directly using the request 
return Action.SUCCESS; 
} 
} 
那么谁来调用这个set方法呢？也就是说谁来控制这个action的行为，以往我们都是自己在适当的地方写上一句 action.setServletRequest(…)，也就是控制权在程序员这边。然而控制反转的思想是在哪里调用交给正在运行的容器来决定，只要利 用Java反射机制来获得Method对象然后调用它的invoke方法传入参数就能做到，这样控制权就从程序员这边转移到了容器那边。程序员可以减轻很 多繁琐的工作更多的关注业务逻辑。Request可以这样注入到action中，其他任何对象也都可以。为了保证action的成员变量线程安全， Struts-2的action不是单例的，每一个新的请求都会产生一个新的action实例。 
那么有人会问，到底谁来做这个对象的注入工作呢？答案就是拦截器。拦截器又是什么东西？笔者再来尽量通俗的解释拦截器的概念。大家要理解拦截器的话，首先一定要理解GOF23种设计模式中的Proxy模式。 
A对象要调用f()，它希望代理给B来做，那么B就要获得A对象的引用，然后在B的f()中通过A对象引用调用A对象的f()方法，最终达到A的f()被 调用的目的。有没有人会觉得这样很麻烦，为什么明明只要A.f()就可以完成的一定要封装到B的f()方法中去？有哪些好处呢？ 
1) 这里我们只有一个A，当我们有很多个A的时候，只需要监视B一个对象的f()方法就可以从全局上控制所有被调用的f()方法。 
2) 另外，既然代理人B能获得A对象的引用，那么B可以决定在真正调A对象的f()方法之前可以做哪些前置工作，调完返回前可有做哪些后置工作。 
讲到这里，大家看出来一点拦截器的概念了么？它拦截下一调f()方法的请求，然后统一的做处理（处理每个的方式还可以不同，解析A对象就可以辨别），处理 完毕再放行。这样像不像对流动的河水横切了一刀，对所有想通过的水分子进行搜身，然后再放行？这也就是AOP（Aspect of Programming面向切面编程）的思想。 
Anyway，Struts-2只是利用了AOP和IoC技术来减轻action和框架的耦合关系，力图到最大程度重用action的目的。在这样的技术 促动下，Struts-2的action成了一个简单被框架使用的POJO（Plain Old Java Object）罢了。实事上AOP和IoC的思想已经遍布新出来的每一个框架上，他们并不是多么新的技术，利用的也都是JDK早已可以最到的事情，它们代 表的是更加面向接口编程，提高重用，增加扩展性的一种思想。Struts-2只是部分的使用这两种思想来设计完成的，另外一个最近很火的框架 Spring，更大程度上代表了这两种设计思想，笔者将于下一篇来进一步探讨Spring的结构。 
PS: 关于Struts-2笔者也没真正怎么用过，这里是看了网上一些前辈的帖子之后写下自己的学习体验，不足之处请见谅！
Java杂谈（十）－－Spring
笔者最近比较忙，一边在实习一边在寻找明年毕业更好的工作，不过论坛里的朋友非常支持小弟继续写，今天是周末，泡上一杯咖啡，继续与大家分享J2ee部分的学习经验。今天的主题是目前很流行也很好的一个开源框架－Spring。 
引用《Spring2.0技术手册》上的一段话： 
Spring的核心是个轻量级容器，它是实现IoC容器和非侵入性的框架，并提供AOP概念的实现方式；提供对持久层、事务的支持；提供MVC Web框架的实现，并对于一些常用的企业服务API提供一致的模型封装，是一个全方位的应用程序框架，除此之外，对于现存的各种框架，Spring也提供 了与它们相整合的方案。 
接下来笔者先谈谈自己的一些理解吧，Spring框架的发起者之前一本很著名的书名字大概是《J2ee Development without EJB》，他提倡用轻量级的组件代替重量级的EJB。笔者还没有看完那本著作，只阅读了部分章节。其中有一点分析觉得是很有道理的： 
EJB里在服务器端有Web Container和EJB Container，从前的观点是各层之间应该在物理上隔离，Web Container处理视图功能、在EJB Container中处理业务逻辑功能、然后也是EBJ Container控制数据库持久化。这样的层次是很清晰，但是一个很严重的问题是Web Container和EJB Container毕竟是两个不同的容器，它们之间要通信就得用的是RMI机制和JNDI服务，同样都在服务端，却物理上隔离，而且每次业务请求都要远程 调用，有没有必要呢？看来并非隔离都是好的。 
再看看轻量级和重量级的区别，笔者看过很多种说法，觉得最有道理的是轻量级代表是POJO + IoC，重量级的代表是Container + Factory。（EJB2.0是典型的重量级组件的技术）我们尽量使用轻量级的Pojo很好理解，意义就在于兼容性和可适应性，移植不需要改变原来的代 码。而Ioc与Factory比起来，Ioc的优点是更大的灵活性，通过配置可以控制很多注入的细节，而Factory模式，行为是相对比较封闭固定的， 生产一个对象就必须接受它全部的特点，不管是否需要。其实轻量级和重量级都是相对的概念，使用资源更少、运行负载更小的自然就算轻量。 
话题扯远了，因为Spring框架带来了太多可以探讨的地方。比如它的非侵入性：指的是它提供的框架实现可以让程序员编程却感觉不到框架的存在，这样所写 的代码并没有和框架绑定在一起，可以随时抽离出来，这也是Spring设计的目标。Spring是唯一可以做到真正的针对接口编程，处处都是接口，不依赖 绑定任何实现类。同时，Spring还设计了自己的事务管理、对象管理和Model2 的MVC框架，还封装了其他J2ee的服务在里面，在实现上基本都在使用依赖注入和AOP的思想。由此我们大概可以看到Spring是一个什么概念上的框 架，代表了很多优秀思想，值得深入学习。笔者强调，学习并不是框架，而是框架代表的思想，就像我们当初学Struts一样…… 
1．Spring MVC 
关于IoC和AOP笔者在上篇已经稍微解释过了，这里先通过Spring的MVC框架来给大家探讨一下Spring的特点吧。（毕竟大部分人已经很熟悉Struts了，对比一下吧） 
众所周知MVC的核心是控制器。类似Struts中的ActionServlet，Spring里面前端控制器叫做DispatcherServlet。 里面充当Action的组件叫做Controller，返回的视图层对象叫做ModelAndView，提交和返回都可能要经过过滤的组件叫做 Interceptor。 
让我们看看一个从请求到返回的流程吧： 
(1) 前台Jsp或Html通过点击submit，将数据装入了request域 
(2) 请求被Interceptor拦截下来，执行preHandler()方法出前置判断 
(3) 请求到达DispathcerServlet 
(4) DispathcerServlet通过Handler Mapping来决定每个reuqest应该转发给哪个后端控制器Controller
Java杂谈（十一）ORM
这是最后一篇Java杂谈了，以ORM框架的谈论收尾，也算是把J2ee的最后一方面给涵盖到了，之所以这么晚才总结出ORM这方面，一是笔者这两周比较忙，另一方面也想善始善终，仔细的先自己好好研究一下ORM框架技术，不想草率的敷衍了事。 
其实J2ee的规范指南里面就已经包括了一些对象持久化技术，例如JDO（Java Data Object）就是Java对象持久化的新规范，一个用于存取某种数据仓库中的对象的标准化API，提供了透明的对象存储，对开发人员来说，存储数据对象 完全不需要额外的代码（如JDBC API的使用）。这些繁琐的工作已经转移到JDO产品提供商身上，使开发人员解脱出来，从而集中时间和精力在业务逻辑上。另外，JDO很灵活，因为它可以 在任何数据底层上运行。JDBC只是面向关系数据库（RDBMS）JDO更通用，提供到任何数据底层的存储功能，比如关系数据库、文件、XML以及对象数 据库（ODBMS）等等，使得应用可移植性更强。我们如果要理解对象持久化技术，首先要问自己一个问题：为什么传统的JDBC来持久化不再能满足大家的需 求了呢？ 
笔者认为最好是能用JDBC真正编写过程序了才能真正体会ORM的好处，同样的道理，真正拿Servlet/Jsp做过项目了才能体会到Struts、 Spring等框架的方便之处。很幸运的是笔者这两者都曾经经历过，用混乱的内嵌Java代码的Jsp加Servlet转发写过完整的Web项目，也用 JDBC搭建过一个完整C/S项目的后台。所以现在接触到新框架才更能体会它们思想和实现的优越之处，回顾从前的代码，真是丑陋不堪啊。^\_^ 
回到正题，我们来研究一下为什么要从JDBC发展到ORM。简单来说，传统的JDBC要花大量的重复代码在初始化数据库连接上，每次增删改查都要获得 Connection对象，初始化Statement，执行得到ResultSet再封装成自己的List或者Object，这样造成了在每个数据访问方 法中都含有大量冗余重复的代码，考虑到安全性的话，还要加上大量的事务控制和log记录。虽然我们学习了设计模式之后，可以自己定义Factory来帮助 减少一部分重复的代码，但是仍然无法避免冗余的问题。其次，随着OO思想深入人心，连典型的过程化语言Perl等都冠冕堂皇的加上了OO的外壳，何况是 Java中繁杂的数据库访问持久化技术呢？强调面向对象编程的结果就是找到一个桥梁，使得关系型数据库存储的数据能准确的映射到Java的对象上，然后针 对Java对象来设计对象和方法，如果我们把数据库的Table当作Class，Record当作Instance的话，就可以完全用面向对象的思想来编 写数据层的代码。于是乎，Object Relationship Mapping的概念开始普遍受到重视，尽管很早很早就已经有人提出来了。 
缺点我们已经大概清楚了，那么如何改进呢？对症下药，首先我们要解决的是如何从Data Schema准备完美的映射到Object Schema，另外要提供对数据库连接对象生命周期的管理，对事务不同粒度的控制和考虑到扩展性后提供对XML、Properties等可配置化的文件的 支持。到目前为止，有很多框架和技术在尝试着这样做。例如似乎是封装管理得过了头的EJB、很早就出现目前已经不在开发和升级了的Apache OJB、首先支持Manual SQL的iBATIS，还有公认非常优秀的Hibernate等等。在分别介绍它们之前，我还想反复强调这些框架都在试图做什么： 
毕竟Java Object和数据库的每一条Record还是有很大的区别，就是类型上来说，DB是没有Boolean类型的。而Java也不得不用封装类 （Integer、Double等）为了能映射上数据库中为null的情况，毕竟Primitive类型是没有null值的。还有一个比较明显的问题是， 数据库有主键和外键，而Java中仍然只能通过基本类型来对应字段值而已，无法规定Unique等特征，更别提外键约束、事务控制和级联操作了。另外，通 过Java Object预设某Field值去取数据库记录，是否在这样的记录也是不能保证的。真的要设计到完全映射的话，Java的Static被所有对象共享的变 量怎么办？在数据库中如何表现出来…… 
我们能看到大量的问题像一座座大山横在那些框架设计者们面前，他们并不是没有解决办法，而是从不同的角度去考虑，会得到很多不同的解决方案，问题是应该采 取哪一种呢？甚至只有等到真正设计出来了投入生产使用了，才能印证出当初的设想是否真的能为项目开发带来更多的益处。笔者引用一份文档中提到一个健壮的持 久化框架应该具有的特点： 
A robust persistence layer should support---- 
1. Several types of persistence mechanism 
2. Full encapsulation of the persistence mechanism. 
3. Multi-object actions 
4. Transactions Control 
5. Extensibility 
6. Object identifiers 
7. Cursors: logical connection to the persistence mechanism 
8. Proxies: commonly used when the results of a query are to be displayed in a list 
9. Records: avoid the overhead of converting database records to objects and then back to records 
10. Multi architecture 
11. Various database version and/or vendors 
12. Multiple connections 
13. Native and non-native drivers 
14. Structured query language queries(SQL)
Java杂谈（十一） ORM
现在来简短的介绍一下笔者用过的一些持久化框架和技术，之所以前面强调那么多共通的知识，是希望大家不要盲从流行框架，一定要把握它的本质和卓越的思想好在哪里。 
1． Apache OJB 
OJB代表Apache Object Relational Bridge，是Apache开发的一个数据库持久型框架。它是基于J2ee规范指南下的持久型框架技术而设计开发的，例如实现了ODMG 3.0规范的API，实现了JDO规范的API， 核心实现是Persistence Broker API。OJB使用XML文件来实现映射并动态的在Metadata layer听过一个Meta-Object-Protocol(MOP)来改变底层数据的行为。更高级的特点包括对象缓存机制、锁管理机制、 Virtual 代理、事务隔离性级别等等。举个OJB Mapping的简单例子ojb-repository.xml： 
&lt;class-descriptor class=”com.ant.Employee” table=”EMPLOYEE”&gt; 
&lt;field-descriptor name=”id” column=”ID” 
jdbc-type=”INTEGER” primarykey=”true” autoincrement=”true”/&gt; 
&lt;field-descriptor name=”name” column=”NAME” jdbc-type=”VARCHAR”/&gt; 
&lt;/class-descrptor&gt; 
&lt;class-descriptor class=”com.ant.Executive” table=”EXECUTIVE”&gt; 
&lt;field-descriptor name=”id” column=”ID” 
jdbc-type=”INTEGER” primarykey=”true” autoincrement=”true”/&gt; 
&lt;field-descriptor name=”department” column=”DEPARTMENT” jdbc-type=”VARCHAR”/&gt; 
&lt;reference-descriptor name=”super” class-ref=”com.ant.Employee”&gt; 
&lt;foreignkey field-ref=”id”/&gt; 
&lt;/reference-descriptor&gt; 
&lt;/class-descrptor&gt; 
2． iBATIS 
iBATIS最大的特点就是允许用户自己定义SQL来组配Bean的属性。因为它的SQL语句是直接写入XML文件中去的，所以可以最大程度上利用到 SQL语法本身能控制的全部特性，同时也能允许你使用特定数据库服务器的额外特性，并不局限于类似SQL92这样的标准，它最大的缺点是不支持枚举类型的 持久化，即把枚举类型的几个对象属性拼成与数据库一个字段例如VARCHAR对应的行为。这里也举一个Mapping文件的例子sqlMap.xml： 
&lt;sqlMap&gt; 
&lt;typeAlias type=”com.ant.Test” alias=”test”/&gt; 
&lt;resultMap class=”test” id=”result”&gt; 
&lt;result property=”testId” column=”TestId”/&gt; 
&lt;result property=”name” column=”Name”/&gt; 
&lt;result property=”date” column=”Date”/&gt; 
&lt;/resultMap&gt; 
&lt;select id=”getTestById” resultMap=”result” parameterClass=”int”&gt; 
select \* from Test where TestId=\#value\# 
&lt;/select&gt; 
&lt;update id=”updateTest” parameterClass=”test”&gt; 
Update Tests set Name=\#name\#, Date=”date” where TestId=\#testId\# 
&lt;/update&gt; 
&lt;/sqlMap&gt; 
3． Hibernate 
Hibernate无疑是应用最广泛最受欢迎的持久型框架，它生成的SQL语句是非常优秀。虽然一度因为不能支持手工SQL而性能受到局限，但随着新一代 Hibernate 3.x推出，很多缺点都被改进，Hibernate也因此变得更加通用而时尚。同样先看一个Mapping文件的例子customer.hbm.xml来 有一个大概印象： 
&lt;hibernate-mapping&gt; 
&lt;class name=”com.ant.Customer” table=”Customers”&gt; 
&lt;id name=”customerId” column=”CustomerId” type=”int” unsaved-value=”0”&gt; 
&lt;generator class=”sequence”&gt; 
&lt;param name=”sequence”&gt; Customers\_CustomerId\_Seq &lt;/param&gt; 
&lt;/generator&gt; 
&lt;/id&gt; 
&lt;property name=”firstName” column=”FirstName”/&gt; 
&lt;property name=”lastName” column=”LastName”/&gt; 
&lt;set name=”addresses” outer-join=”true”&gt; 
&lt;key column=”Customer”/&gt; 
&lt;one-to-many class=”com.ant.Address”/&gt; 
&lt;/set&gt; 
&lt;/class&gt;
&lt;/hibernate-mapping&gt; 
Hibernate有很多显著的特性，最突出的就是它有自己的查询语言叫做HQL，在HQL中select from的不是Table而是类名，一方面更加面向对象，另外一方面通过在hibernate.cfg.xml中配置Dialect为HQL可以使得整个 后台与数据库脱离耦合，因为不管用那种数据库我都是基于HQL来查询，Hibernate框架负责帮我最终转换成特定数据库里的SQL语句。另外 Hibernate在Object-Caching这方面也做得相当出色，它同时管理两个级别的缓存，当数据被第一次取出后，真正使用的时候对象被放在一 级缓存管理，这个时候任何改动都会影响到数据库；而空闲时候会把对象放在二级缓存管理，虽然这个时候与数据库字段能对应上但未绑定在一起，改动不会影响到 数据库的记录，主要目的是为了在重复读取的时候更快的拿到数据而不用再次请求连接对象。其实关于这种缓存的设计建议大家研究一下Oracle的存储机制 （原理是相通的），Oracle牺牲了空间换来时间依赖于很健壮的缓存算法来保证最优的企业级数据库访问速率。 
以上是一些Mapping的例子，真正在Java代码中使用多半是继承各个框架中默认的Dao实现类，然后可以通过Id来查找对象，或者通过 Example来查找，更流行的是更具Criteria查找对象。Criteria是完全封装了SQL条件查询语法的一个工具类，任何一个查询条件都可以 在Criteria中找到方法与之对应，这样可以在Java代码级别实现SQL的完全控制。另外，现在许多ORM框架的最新版本随着JDk 5.0加入Annotation特性都开始支持用XDoclet来自动根据Annotation来生成XML配置文件了。 
笔者不可能详细的讲解每一个框架，也许更多的人在用Hibernate，笔者是从OJB开始接触ORM技术的，它很原始却更容易让人理解从JDBC到 ORM的过渡。更多的细节是可以从官方文档和书籍中学到的，但我们应该更加看中它们设计思想的来源和闪光点，不是盲从它们的使用方法。


