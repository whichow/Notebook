C\# Attribute在.net编程中的应用 (转） - vivien - 博客园
[C\# Attribute在.net编程中的应用 (转）](http://www.cnblogs.com/sleeping/archive/2008/12/17/1356691.html)
--------------------------------------------------------------------------------------------------------

**Attribute的基本概念**
经常有朋友问，**Attribute**是什么？它有什么用？好像没有这个东东程序也能运行。实际上在.Net中，**Attribute**是一个非常重要的组成部分，为了帮助大家理解和掌握**Attribute**，以及它的使用方法，特地收集了几个**Attribute**使用的例子，提供给大家参考。

在具体的演示之前，我想先大致介绍一下**Attribute**。我们知道在类的成员中有property成员，二者在中文中都做属性解释，那么它们到底是不是同一个东西呢？从代码上看，明显不同，首先就是它们的在代码中的位置不同，其次就是写法不同（**Attribute**必须写在一对方括符中）。

什么是Atrribute
首先，我们肯定**Attribute**是一个类，下面是msdn文档对它的描述：
公共语言运行时允许你添加类似关键字的描述声明，叫做attributes, 它对程序中的元素进行标注，如类型、字段、方法和属性等。Attributes和Microsoft .NET Framework文件的元数据保存在一起，可以用来向运行时描述你的代码，或者在程序运行的时候影响应用程序的行为。

在.NET中,**Attribute**被用来处理多种问题，比如序列化、程序的安全特征、防止即时编译器对程序代码进行优化从而代码容易调试等等。下面，我们先来看几个在.NET中标准的属性的使用，稍后我们再回过头来讨论**Attribute**这个类本身。（文中的代码使用**C\#**编写，但同样适用所有基于.NET的所有语言）

**Attribute**作为编译器的指令
在**C\#**中存在着一定数量的编译器指令，如：\#define DEBUG, \#undefine DEBUG, \#if等。这些指令专属于**C\#**,而且在数量上是固定的。而**Attribute**用作编译器指令则不受数量限制。比如下面的三个**Attribute**:

Conditional：起条件编译的作用，只有满足条件，才允许编译器对它的代码进行编译。一般在程序调试的时候使用。
DllImport：用来标记非.NET的函数，表明该方法在一个外部的DLL中定义。
Obsolete：这个属性用来标记当前的方法已经被废弃，不再使用了。
下面的代码演示了上述三个属性的使用：

\#define DEBUG //这里定义条件
 
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
 
namespace AttributeDemo
{
 class MainProgramClass
 {
 \[DllImport("User32.dll")\]
 public static extern int MessageBox(int hParent, string Message, string Caption, int Type);
 
 static void Main(string\[\] args)
 {
 DisplayRunningMessage();
 DisplayDebugMessage();
 
 MessageBox(0,"Hello","Message",0);
 
 Console.ReadLine();
 }
 
 \[Conditional("DEBUG")\]
 private static void DisplayRunningMessage()
 {
 Console.WriteLine("开始运行Main子程序。当前时间是"+DateTime.Now);
 }
 
 \[Conditional("DEBUG")\]
 \[Obsolete\]
 private static void DisplayDebugMessage()
 {
 Console.WriteLine("开始Main子程序");
 }
 }
}

如果在一个程序元素前面声明一个**Attribute**,那么就表示这个**Attribute**被施加到该元素上，前面的代码，\[DllImport\]施加到MessageBox函数上, \[Conditional\]施加到DisplayRuntimeMessage方法和DisplayDebugMessage方法，\[Obsolete\]施加到DisplayDebugMessage方法上。

根据上面涉及到的三个**Attribute**的说明，我们可以猜到程序运行的时候产生的输出：DllImport **Attribute**表明了MessageBox是User32.DLL中的函数，这样我们就可以像内部方法一样调用这个函数。

重要的一点就是**Attribute**就是一个类，所以DllImport也是一个类，**Attribute**类是在编译的时候被实例化的，而不是像通常的类那样在运行时候才实例化。**Attribute**实例化的时候根据该**Attribute**类的设计可以带参数，也可以不带参数，比如DllImport就带有"User32.dll"的参数。Conditional对满足参数的定义条件的代码进行编译，如果没有定义DEBUG,那么该方法将不被编译，读者可以把\#define DEBUG一行注释掉看看输出的结果（release版本，在Debug版本中Conditional的debug总是成立的）。Obsolete表明了DispalyDebugMessage方法已经过时了，它有一个更好的方法来代替它，当我们的程序调用一个声明了Obsolete的方法时，那么编译器会给出信息，Obsolete还有其他两个重载的版本。大家可以参考msdn中关于的ObsoleteAttribute 类的描述。

**Attribute**类
除了.NET提供的那些**Attribute**派生类之外，我们可以自定义我们自己的**Attribute**，所有自定义的**Attribute**必须从**Attribute**类派生。现在我们来看一下**Attribute** 类的细节：

protected **Attribute**(): 保护的构造器，只能被**Attribute**的派生类调用。

三个静态方法：

static **Attribute** GetCustomAttribute():这个方法有8种重载的版本，它被用来取出施加在类成员上指定类型的**Attribute**。

static **Attribute**\[\] GetCustomAttributes(): 这个方法有16种重载版本，用来取出施加在类成员上指定类型的**Attribute**数组。

static bool IsDefined():由八种重载版本，看是否指定类型的定制**attribute**被施加到类的成员上面。

实例方法：

bool IsDefaultAttribute(): 如果**Attribute**的值是默认的值，那么返回true。

bool Match():表明这个**Attribute**实例是否等于一个指定的对象。

公共属性： TypeId: 得到一个唯一的标识，这个标识被用来区分同一个**Attribute**的不同实例。

我们简单地介绍了**Attribute**类的方法和属性，还有一些是从object继承来的。这里就不列出来了。

下面介绍如何自定义一个**Attribute**: 自定义一个**Attribute**并不需要特别的知识，其实就和编写一个类差不多。自定义的**Attribute**必须直接或者间接地从**Attribute**这个类派生，如：

public MyCustomAttribute : **Attribute** { ... }

这里需要指出的是**Attribute**的命名规范，也就是你的**Attribute**的类名+"**Attribute**",当你的**Attribute**施加到一个程序的元素上的时候，编译器先查找你的**Attribute**的定义，如果没有找到，那么它就会查找“**Attribute**名称"+**Attribute**的定义。如果都没有找到，那么编译器就报错。

对于一个自定义的**Attribute**，你可以通过AttributeUsage的**Attribute**来限定你的**Attribute** 所施加的元素的类型。代码形式如下： \[AttriubteUsage(参数设置)\] public 自定义**Attribute** : **Attribute** { ... }

非常有意思的是，AttributeUsage本身也是一个**Attribute**，这是专门施加在**Attribute**类的**Attribute**. AttributeUsage自然也是从**Attribute**派生，它有一个带参数的构造器，这个参数是AttributeTargets的枚举类型。下面是AttributeTargets 的定义：

public enum AttributeTargets
{
 All=16383,
 Assembly=1,
 Module=2,
 Class=4,
 Struct=8,
 Enum=16,
 Constructor=32,
 Method=64,
 Property=128,
 Field=256,
 Event=512,
 Interface=1024,
 Parameter=2048,
 Delegate=4096,
 ReturnValue=8192
}
 
 
作为参数的AttributeTarges的值允许通过“或”操作来进行多个值得组合，如果你没有指定参数，那么默认参数就是All 。 AttributeUsage除了继承**Attribute** 的方法和属性之外，还定义了以下三个属性：

AllowMultiple: 读取或者设置这个属性，表示是否可以对一个程序元素施加多个**Attribute** 。

Inherited:读取或者设置这个属性，表示是否施加的**Attribute** 可以被派生类继承或者重载。

ValidOn: 读取或者设置这个属性，指明**Attribute** 可以被施加的元素的类型。

AttributeUsage 的使用例子：
using System;
namespace AttTargsCS
{

 // 该**Attribute**只对类有效.
 \[AttributeUsage(AttributeTargets.Class)\]
 public class ClassTargetAttribute : **Attribute**
 {
 }

 // 该**Attribute**只对方法有效.
 \[AttributeUsage(AttributeTargets.Method)\]
 public class MethodTargetAttribute : **Attribute**
 {
 }

 // 该**Attribute**只对构造器有效。
 \[AttributeUsage(AttributeTargets.Constructor)\]
 public class ConstructorTargetAttribute : **Attribute**
 {
 }

 // 该**Attribute**只对字段有效.
 \[AttributeUsage(AttributeTargets.Field)\]
 public class FieldTargetAttribute : **Attribute**
 {
 }

 
 // 该**Attribute**对类或者方法有效（组合）.
 \[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)\]
 public class ClassMethodTargetAttribute : **Attribute**
 {
 }

 // 该**Attribute**对所有的元素有效.
 \[AttributeUsage(AttributeTargets.All)\]
 public class AllTargetsAttribute : **Attribute**
 {
 }

 //上面定义的**Attribute**施加到程序元素上的用法
 \[ClassTarget\] //施加到类
 \[ClassMethodTarget\]//施加到类
 \[AllTargets\] //施加到类
 public class TestClassAttribute
 {
 \[ConstructorTarget\] //施加到构造器
 \[AllTargets\] //施加到构造器
 TestClassAttribute()
 {
 }

 \[MethodTarget\] //施加到方法
 \[ClassMethodTarget\] //施加到方法
 \[AllTargets\] //施加到方法
 public void Method1()
 {
 }
 
 \[FieldTarget\] //施加到字段
 \[AllTargets\] //施加到字段
 public int myInt;

 static void Main(string\[\] args)
 {
 }
 }
}
 
 

 

至此，我们介绍了有关**Attribute**类和它们的代码格式。你一定想知道到底如何在你的应用程序中使用**Attribute**，如果仅仅是前面介绍的内容，还是不足以说明**Attribute**有什么实用价值的话，那么从后面的章节开始我们将介绍几个**Attribute**的不同用法，相信你一定会对**Attribute**有一个新的了解。

.NET Framework中对**Attribute**的支持是一个全新的功能，这种支持来自它的**Attribute**类。在你的程序中适当地使用这个类，或者是灵活巧妙地利用这个类，将使你的程序获得某种在以往编程中很难做到的能力。我们来看一个例子：
假如你是一个项目开发小组中的成员，你想要跟踪项目代码检查的信息，通常你可以把代码的检查信息保存在数据库中以便查询；或者把信息写到代码的注释里面，这样可以阅读代码的同时看到代码被检查的信息。我们知道.NET的组件是自描述的，那么是否可以让代码自己来描述它被检查的信息呢？这样我们既可以将信息和代码保存在一起，又可以通过代码的自我描述得到信息。答案就是使用**Attribute**.
下面的步骤和代码告诉你怎么做：
首先，我们创建一个自定义的**Attribute**,并且事先设定我们的**Attribute**将施加在class的元素上面以获取一个类代码的检查信息。

using System;
using System.Reflection;
\[AttributeUsage(AttributeTargets.Class)\] //还记得上一节的内容吗？
public class CodeReviewAttribute : System.**Attribute** //定义一个CodeReview的**Attribute**
{
private string reviewer; //代码检查人
private string date; //检查日期
private string comment; //检查结果信息

//参数构造器
public CodeReviewAttribute(string reviewer, string date)
{
 this.reviewer=reviewer;
 this.date=date;
}

public string Reviewer
{
 get
 {
 return reviewer;
 }
}

public string Date
{
 get
 {
 return date;
 }
}

public string Comment
{
 get
 {
 return comment;
 }
 set
 {
 comment=value;
 }
}
}

 

我们的自定义CodeReviewAttribute同普通的类没有区别，它从**Attribute**派生，同时通过AttributeUsage表示我们的**Attribute**仅可以施加到类元素上。

第二步就是使用我们的CodeReviewAttribute, 假如我们有一个Jack写的类MyClass，检查人Niwalker，检查日期2003年7月9日，于是我们施加**Attribute**如下：

\[CodeReview("Niwalker","2003-7-9",Comment="Jack的代码")\]
public class MyClass
{
//类的成员定义
}

当这段代码被编译的时候，编译器会调用CodeReviewAttribute的构造器并且把"Niwalker"和"2003-7-9"分别作为构造器的参数。注意到参数表中还有一个Comment属性的赋值，这是**Attribute**特有的方式，这里你可以设置更多的**Attribute**的公共属性（如果有的话），需要指出的是.NET Framework1.0允许向private的属性赋值，但在.NET Framework1.1已经不允许这样做，只能向public的属性赋值。

第三步就是取出我们需要的信息，这是通过.NET的反射来实现的，关于反射的知识，限于篇幅我不打算在这里进行说明，也许我会在以后另外写一篇介绍反射的文章。

class test
{
 static void Main(string\[\] args)
 {
 System.Reflection.MemberInfo info=typeof(MyClass); //通过反射得到MyClass类的信息

//得到施加在MyClass类上的定制**Attribute**
 CodeReviewAttribute att=
 (CodeReviewAttribute)**Attribute**.GetCustomAttribute(info,typeof(CodeReviewAttribute));
 if(att!=null)
 {
 Console.WriteLine("代码检查人:{0}",att.Reviewer);
 Console.WriteLine("检查时间:{0}",att.Date);
 Console.WriteLine("注释:{0}",att.Comment);
 }
 }
}

在上面这个例子中，**Attribute**扮演着向一个类添加额外信息的角色，它并不影响MyClass类的行为。通过这个例子，我们大致可以知道如何写一个自定义的**Attribute**，以及如何在应用程序使用它。下一节，我将介绍如何使用**Attribute**来自动生成ADO.NET的数据访问类的代码。

**用于参数的Attribute**
在编写多层应用程序的时候，你是否为每次要写大量类似的数据访问代码而感到枯燥无味？比如我们需要编写调用存储过程的代码，或者编写T\_SQL代码，这些代码往往需要传递各种参数，有的参数个数比较多，一不小心还容易写错。有没有一种一劳永逸的方法？当然，你可以使用MS的Data Access Application Block，也可以使用自己编写的Block。这里向你提供一种另类方法，那就是使用**Attribute**。

下面的代码是一个调用AddCustomer存储过程的常规方法：

public int AddCustomer(SqlConnection connection,
string customerName,
string country,
string province,
string city,
string address,
string telephone)
{
 SqlCommand command=new SqlCommand("AddCustomer", connection);
 command.CommandType=CommandType.StoredProcedure;

 command.Parameters.Add("@CustomerName",SqlDbType.NVarChar,50).Value=customerName;
 command.Parameters.Add("@country",SqlDbType.NVarChar,20).Value=country;
 command.Parameters.Add("@Province",SqlDbType.NVarChar,20).Value=province;
 command.Parameters.Add("@City",SqlDbType.NVarChar,20).Value=city;
 command.Parameters.Add("@Address",SqlDbType.NVarChar,60).Value=address;
 command.Parameters.Add("@Telephone",SqlDbType.NvarChar,16).Value=telephone;
 command.Parameters.Add("@CustomerId",SqlDbType.Int,4).Direction=ParameterDirection.Output;

 connection.Open();
 command.ExecuteNonQuery();
 connection.Close();

 int custId=(int)command.Parameters\["@CustomerId"\].Value;
 return custId;
}
上面的代码，创建一个Command实例，然后添加存储过程的参数，然后调用ExecuteMonQuery方法执行数据的插入操作，最后返回CustomerId。从代码可以看到参数的添加是一种重复单调的工作。如果一个项目有100多个甚至几百个存储过程，作为开发人员的你会不会要想办法偷懒？（反正我会的:-)）。

下面开始我们的代码自动生成工程：

我们的目的是根据方法的参数以及方法的名称，自动生成一个Command对象实例，第一步我们要做的就是创建一个SqlParameterAttribute, 代码如下：

SqlCommandParameterAttribute.cs

using System;
using System.Data;
using Debug=System.Diagnostics.Debug;

namespace DataAccess
{
 // SqlParemeterAttribute 施加到存储过程参数
 \[ AttributeUsage(AttributeTargets.Parameter) \]
 public class SqlParameterAttribute : **Attribute**
 {
 private string name; //参数名称
 private bool paramTypeDefined; //是否参数的类型已经定义
 private SqlDbType paramType; //参数类型
 private int size; //参数尺寸大小
 private byte precision; //参数精度
 private byte scale; //参数范围
 private bool directionDefined; //是否定义了参数方向
 private ParameterDirection direction; //参数方向
 
 public SqlParameterAttribute()
 {
 }
 
 public string Name
 {
 get { return name == null  string.Empty : name; }
 set { \_name = value; }
 }
 
 public int Size
 {
 get { return size; }
 set { size = value; }
 }
 
 public byte Precision
 {
 get { return precision; }
 set { precision = value; }
 }
 
 public byte Scale
 {
 get { return scale; }
 set { scale = value; }
 }
 
 public ParameterDirection Direction
 {
 get
 {
 Debug.Assert(directionDefined);
 return direction;
 }
 set
 {
 direction = value;
 directionDefined = true;
 }
 }
 
 public SqlDbType SqlDbType
 {
 get
 {
 Debug.Assert(paramTypeDefined);
 return paramType;
 }
 set
 {
 paramType = value;
 paramTypeDefined = true;
 }
 }
 
 public bool IsNameDefined
 {
 get { return name != null && name.Length != 0; }
 }
 
 public bool IsSizeDefined
 {
 get { return size != 0; }
 }
 
 public bool IsTypeDefined
 {
 get { return paramTypeDefined; }
 }
 
 public bool IsDirectionDefined
 {
 get { return directionDefined; }
 }
 
 public bool IsScaleDefined
 {
 get { return \_scale != 0; }
 }
 
 public bool IsPrecisionDefined
 {
 get { return \_precision != 0; }
 }
 
 ...
 
以上定义了SqlParameterAttribute的字段和相应的属性，为了方便**Attribute**的使用，我们重载几个构造器，不同的重载构造器用于不用的参数：
 ...

 // 重载构造器，如果方法中对应于存储过程参数名称不同的话，我们用它来设置存储过程的名称
 // 其他构造器的目的类似
 public SqlParameterAttribute(string name)
 {
 Name=name;
 }

 public SqlParameterAttribute(int size)
 {
 Size=size;
 }
 
 public SqlParameterAttribute(SqlDbType paramType)
 {
 SqlDbType=paramType;
 }
 
 public SqlParameterAttribute(string name, SqlDbType paramType)
 {
 Name = name;
 SqlDbType = paramType;
 }
 
 public SqlParameterAttribute(SqlDbType paramType, int size)
 {
 SqlDbType = paramType;
 Size = size;
 }
 
 
 public SqlParameterAttribute(string name, int size)
 {
 Name = name;
 Size = size;
 }
 
 public SqlParameterAttribute(string name, SqlDbType paramType, int size)
 {
 Name = name;
 SqlDbType = paramType;
 Size = size;
 }
 }
}

为了区分方法中不是存储过程参数的那些参数，比如SqlConnection，我们也需要定义一个非存储过程参数的**Attribute**:

//NonCommandParameterAttribute.cs

using System;
namespace DataAccess
{
 \[ AttributeUsage(AttributeTargets.Parameter) \]
 public sealed class NonCommandParameterAttribute : **Attribute**
 {
 }
}

我们已经完成了SQL的参数**Attribute**的定义，在创建Command对象生成器之前，让我们考虑这样的一个事实，那就是如果我们数据访问层调用的不是存储过程，也就是说Command的CommandType不是存储过程，而是带有参数的SQL语句，我们想让我们的方法一样可以适合这种情况，同样我们仍然可以使用**Attribute**，定义一个用于方法的**Attribute**来表明该方法中的生成的Command的CommandType是存储过程还是SQL文本，下面是新定义的**Attribute**的代码：

//SqlCommandMethodAttribute.cs

using System;
using System.Data;

namespace Emisonline.DataAccess
{
 \[AttributeUsage(AttributeTargets.Method)\]
 public sealed class SqlCommandMethodAttribute : **Attribute**
 {
 private string commandText;
 private CommandType commandType;

 public SqlCommandMethodAttribute( CommandType commandType, string commandText)
 {
 commandType=commandType;
 commandText=commandText;
 }

 public SqlCommandMethodAttribute(CommandType commandType) : this(commandType, null){}

 public string CommandText
 {
 get
 {
 return commandText==null  string.Empty : commandText;
 }
 set
 {
 commandText=value;
 }
 }

 public CommandType CommandType
 {
 get
 {
 return commandType;
 }
 set
 {
 commandType=value;
 }
 }
 }
}
 

我们的**Attribute**的定义工作已经全部完成，下一步就是要创建一个用来生成Command对象的类。

SqlCommandGenerator类的设计

SqlCommandGEnerator类的设计思路就是通过反射得到方法的参数，使用被SqlCommandParameterAttribute标记的参数来装配一个Command实例。

引用的命名空间：

//SqlCommandGenerator.cs

using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using Debug = System.Diagnostics.Debug;
using StackTrace = System.Diagnostics.StackTrace;

类代码：
namespace DataAccess
{
 public sealed class SqlCommandGenerator
 {
 //私有构造器，不允许使用无参数的构造器构造一个实例
 private SqlCommandGenerator()
 {
 throw new NotSupportedException();
 }

 //静态只读字段，定义用于返回值的参数名称
 public static readonly string ReturnValueParameterName = "RETURN\_VALUE";
 //静态只读字段，用于不带参数的存储过程
 public static readonly object\[\] NoValues = new object\[\] {};
 
 
 public static SqlCommand GenerateCommand(SqlConnection connection,
 MethodInfo method, object\[\] values)
 {
 //如果没有指定方法名称，从堆栈帧得到方法名称
 if (method == null)
 method = (MethodInfo) (new StackTrace().GetFrame(1).GetMethod());

 // 获取方法传进来的SqlCommandMethodAttribute
 // 为了使用该方法来生成一个Command对象，要求有这个**Attribute**。
 SqlCommandMethodAttribute commandAttribute =
 (SqlCommandMethodAttribute) **Attribute**.GetCustomAttribute(method, typeof(SqlCommandMethodAttribute));

 Debug.Assert(commandAttribute != null);
 Debug.Assert(commandAttribute.CommandType == CommandType.StoredProcedure ||
 commandAttribute.CommandType == CommandType.Text);

 // 创建一个SqlCommand对象，同时通过指定的**attribute**对它进行配置。
 SqlCommand command = new SqlCommand();
 command.Connection = connection;
 command.CommandType = commandAttribute.CommandType;
 
 // 获取command的文本，如果没有指定，那么使用方法的名称作为存储过程名称
 if (commandAttribute.CommandText.Length == 0)
 {
 Debug.Assert(commandAttribute.CommandType == CommandType.StoredProcedure);
 command.CommandText = method.Name;
 }
 else
 {
 command.CommandText = commandAttribute.CommandText;
 }

 // 调用GeneratorCommandParameters方法，生成command参数，同时添加一个返回值参数
 GenerateCommandParameters(command, method, values);
 command.Parameters.Add(ReturnValueParameterName, SqlDbType.Int).Direction
 =ParameterDirection.ReturnValue;

 return command;
 }

 private static void GenerateCommandParameters(
 SqlCommand command, MethodInfo method, object\[\] values)
 {

 // 得到所有的参数，通过循环一一进行处理。
 
 ParameterInfo\[\] methodParameters = method.GetParameters();
 int paramIndex = 0;

 foreach (ParameterInfo paramInfo in methodParameters)
 {
 // 忽略掉参数被标记为\[NonCommandParameter \]的参数
 
 if (**Attribute**.IsDefined(paramInfo, typeof(NonCommandParameterAttribute)))
 continue;
 
 // 获取参数的SqlParameter **attribute**，如果没有指定，那么就创建一个并使用它的缺省设置。
 SqlParameterAttribute paramAttribute = (SqlParameterAttribute) **Attribute**.GetCustomAttribute(
 paramInfo, typeof(SqlParameterAttribute));
 
 if (paramAttribute == null)
 paramAttribute = new SqlParameterAttribute();
 
 //使用**attribute**的设置来配置一个参数对象。使用那些已经定义的参数值。如果没有定义，那么就从方法
 // 的参数来推断它的参数值。
 SqlParameter sqlParameter = new SqlParameter();
 if (paramAttribute.IsNameDefined)
 sqlParameter.ParameterName = paramAttribute.Name;
 else
 sqlParameter.ParameterName = paramInfo.Name;

 if (!sqlParameter.ParameterName.StartsWith("@"))
 sqlParameter.ParameterName = "@" + sqlParameter.ParameterName;
 
 if (paramAttribute.IsTypeDefined)
 sqlParameter.SqlDbType = paramAttribute.SqlDbType;
 
 if (paramAttribute.IsSizeDefined)
 sqlParameter.Size = paramAttribute.Size;

 if (paramAttribute.IsScaleDefined)
 sqlParameter.Scale = paramAttribute.Scale;
 
 if (paramAttribute.IsPrecisionDefined)
 sqlParameter.Precision = paramAttribute.Precision;
 
 if (paramAttribute.IsDirectionDefined)
 {
 sqlParameter.Direction = paramAttribute.Direction;
 }
 else
 {
 if (paramInfo.ParameterType.IsByRef)
 {
 sqlParameter.Direction = paramInfo.IsOut  
 ParameterDirection.Output :
 ParameterDirection.InputOutput;
 }
 else
 {
 sqlParameter.Direction = ParameterDirection.Input;
 }
 }
 
 // 检测是否提供的足够的参数对象值
 Debug.Assert(paramIndex &lt; values.Length);
 
 //把相应的对象值赋于参数。
 sqlParameter.Value = values\[paramIndex\];
 command.Parameters.Add(sqlParameter);
 
 
 paramIndex++;
 }
 
 //检测是否有多余的参数对象值
 Debug.Assert(paramIndex == values.Length);
 }
 }
}

必要的工作终于完成了。SqlCommandGenerator中的代码都加上了注释，所以并不难读懂。下面我们进入最后的一步，那就是使用新的方法来实现上一节我们一开始显示个那个AddCustomer的方法。

重构新的AddCustomer代码：

\[ SqlCommandMethod(CommandType.StoredProcedure) \]
public void AddCustomer( \[NonCommandParameter\] SqlConnection connection,
 \[SqlParameter(50)\] string customerName,
 \[SqlParameter(20)\] string country,
 \[SqlParameter(20)\] string province,
 \[SqlParameter(20)\] string city,
 \[SqlParameter(60)\] string address,
 \[SqlParameter(16)\] string telephone,
 out int customerId )
{
 customerId=0; //需要初始化输出参数
 //调用Command生成器生成SqlCommand实例
 SqlCommand command = SqlCommandGenerator.GenerateCommand( connection, null, new object\[\]
{customerName,country,province,city,address,telephone,customerId } );
 
 connection.Open();
 command.ExecuteNonQuery();
 connection.Close();

 //必须明确返回输出参数的值
 customerId=(int)command.Parameters\["@CustomerId"\].Value;
}

代码中必须注意的就是out参数，需要事先进行初始化，并在Command执行操作以后，把参数值传回给它。受益于**Attribute**,使我们摆脱了那种编写大量枯燥代码编程生涯。我们甚至还可以使用Sql存储过程来编写生成整个方法的代码，如果那样做的话，可就大大节省了你的时间了，上一节和这一节中所示的代码，你可以把它们单独编译成一个组件，这样就可以在你的项目中不断的重用它们了。从下一节开始，我们将更深层次的介绍**Attribute**的应用，请继续关注。（待续）

原文: [http://www.csdn.net/Develop/Read\_Article.aspId=19591](http://www.bjcan.com/hengxing/)

posted on 2004-03-28 18:42 dudu 阅读(1242) 评论(2) 编辑 收藏 收藏至365Key 所属分类: ASP.NET
FeedBack:
\# re: **Attribute**在.NET编程中的应用（四）2005-05-24 23:38 | wqjch

你好，我看了你的"**Attribute**在.NET编程中的应用"一系列文章，受益菲浅。但还有一个问题就是，我想做一下实验，我在程序怎么样调用下面这个方面。我不知第8个参数要传什么的类型。给我一个例子好吗。谢谢。
\[ SqlCommandMethod(CommandType.StoredProcedure) \]
public void AddCustomer( \[NonCommandParameter\] SqlConnection connection,
\[SqlParameter(50)\] string customerName,
\[SqlParameter(20)\] string country,
\[SqlParameter(20)\] string province,
\[SqlParameter(20)\] string city,
\[SqlParameter(60)\] string address,
\[SqlParameter(16)\] string telephone,
out int customerId )
{
customerId=0; //需要初始化输出参数
//调用Command生成器生成SqlCommand实例
SqlCommand command = SqlCommandGenerator.GenerateCommand( connection, null, new object\[\]
{customerName,country,province,city,address,telephone,customerId } );

connection.Open();
command.ExecuteNonQuery();
connection.Close();

//必须明确返回输出参数的值
customerId=(int)command.Parameters\["@CustomerId"\].Value;
}

 

**Attribute在拦截机制上的应用**

从这一节开始我们讨论**Attribute**的高级应用，为此我准备了一个实际的例子：我们有一个订单处理系统，当一份订单提交的时候，系统检查库存，如果库存存量满足订单的数量，系统记录订单处理记录，然后更新库存，如果库存存量低于订单的数量，系统做相应的记录，同时向库存管理员发送邮件。为了方便演示，我们对例子进行了简化：

//Inventory.cs
using System;
using System.Collections;

namespace NiwalkerDemo
{
 public class Inventory
 {

 private Hashtable inventory=new Hashtable();
 
 public Inventory()
 {
 inventory\["Item1"\]=100;
 inventory\["Item2"\]=200;
 }

 public bool Checkout(string product, int quantity)
 {
 int qty=GetQuantity(product);
  return qty&gt;=quantity;
 }
 
 public int GetQuantity(string product)
 {
 int qty=0;
 if(inventory\[product\]!=null)
 qty = (int)inventory\[product\];
 return qty;
 }
 
 public void Update(string product, int quantity)
 {
 int qty=GetQuantity(product);
 inventory\[product\]=qty-quantity;
 }
 }
}

//Logbook.cs
using System;

namespace NiwalkerDemo
{
 public class Logbook
 {
 public static void Log(string logData)
 {
 Console.WriteLine("log:{0}",logData);
 }
 }
}

//Order.cs
using System;

namespace NiwalkerDemo
{
 public class Order
 {
 private int orderId;
 private string product;
 private int quantity;
 
 public Order(int orderId)
 {
 this.orderId=orderId;
 }
 
 public void Submit()
 {
 Inventory inventory=new Inventory(); //创建库存对象
 
 //检查库存
 if(inventory.Checkout(product,quantity))
 {
 Logbook.Log("Order"+orderId+" available");
 inventory.Update(product,quantity);
 }
 else
 {
 Logbook.Log("Order"+orderId+" unavailable");
 SendEmail();
 }
 }
 
 public string ProductName
 {
 get{ return product; }
 set{ product=value; }
 }
 
 public int OrderId
 {
 get{ return orderId; }
 }
 
 public int Quantity
 {
 get{ return quantity;}
 set{ quantity=value; }
 }
 
 public void SendEmail()
 {
 Console.WriteLine("Send email to manager");
 }
 }
}

 

下面是调用程序：

//AppMain.cs

using System;

namespace NiwalkerDemo
{
 public class AppMain
 {
 static void Main()
 {
 Order order1=new Order(100);
 order1.ProductName="Item1";
 order1.Quantity=150;
 order1.Submit();
 
 Order order2=new Order(101);
 order2.ProductName="Item2";
 order2.Quantity=150;
 order2.Submit();
 }
 }
}

程序看上去还不错，商务对象封装了商务规则，运行的结果也符合要求。但是我好像听到你在抱怨了，没有吗？当你的客户的需求改变的时候（客户总是经常改变他们的需求），比如库存检查的规则不是单一的检查产品的数量，还要检查产品是否被预订的多种情况，那么你需要改变Inventory的代码，同时还要修改Order中的代码，我们的例子只是一个简单的商务逻辑，实际的情况比这个要复杂的多。问题在于Order对象同其他的对象之间是紧耦合的，从OOP的观点出发，这样的设计是有问题的，如果你写出这样的程序，至少不会在我的团队里面被Pass.

你说了：“No problem! 我们可以把商务逻辑抽出来放到一个专门设计的用来处理事务的对象中。”嗯，好主意，如果你是这么想的，或许我还可以给你一个提议，使用Observer Design Pattern（观察者设计模式）：你可以使用delegate，在Order对象中定义一个BeforeSubmit和AfterSubmit事件，然后创建一个对象链表，将相关的对象插入到这个链表中，这样就可以实现对Order提交事件的拦截，在Order提交之前和提交之后自动进行必要的事务处理。如果你感兴趣的话，你可以自己动手来编写这样的一个代码，或许还要考虑在分布式环境中（Order和Inventory不在一个地方）如何处理对象之间的交互问题。

幸运的是，.NET Framework中提供了实现这种技术的支持。在.NET Framework中的对象Remoting和组件服务中，有一个重要的拦截机制，在对象Remoting中，不同的应用程序之间的对象的交互需要穿越他们的域边界，每一个应用域也可以细分为多个Context(上下文环境），每一个应用域也至少有一个默认的Context，即使在同一个应用域，也存在穿越不同Context的问题。NET的组件服务发展了COM+的组件服务，它使用Context **Attribute**来实现象COM+一样的拦截功能。通过对调用对象的拦截，我们可以对一个方法的调用进行前处理和后处理，同时也解决了上述的跨越边界的问题。

需要提醒你，如果你在MSDN文档查ContextAttribute，我可以保证你得不到任何有助于了解ContextAttribute的资料，你看到的将是这么一句话：“This type supports the .NET Framework infrastructure and is not intended to be used directly from your code.”——“本类型支持.NET Framework基础结构，它不打算直接用于你的代码。”不过，在msdn站点，你可以看到一些有关这方面的资料（见文章后面的参考链接）。

下面我们介绍有关的几个类和一些概念，首先是：

ContextAttribute类

ContextAttribute派生自**Attribute**,同时它还实现了IContextAttribute和IContextProperty接口。所有自定义的ContextAttribute必须从这个类派生。
构造器：
ContextAttribute:构造器带有一个参数，用来设置ContextAttribute的名称。

公共属性：
Name:只读属性。返回ContextAttribute的名称

公共方法：
GetPropertiesForNewContext：虚拟方法。向新的Context添加属性集合。
IsContextOK:虚拟方法。查询客户Context中是否存在指定的属性。
IsNewContextOK:虚拟方法。默认返回true。一个对象可能存在多个Context,使用这个方法来检查新的Context中属性是否存在冲突。
Freeze:虚拟方法。该方法用来定位被创建的Context的最后位置。

ContextBoundObject类

实现被拦截的类，需要从ContextBoundObject类派生，这个类的对象通过**Attribute**来指定它所在Context,凡是进入该Context的调用都可以被拦截。该类从MarshalByRefObject派生。

以下是涉及到的接口：

IMessage:定义了被传送的消息的实现。一个消息必须实现这个接口。

IMessageSink:定义了消息接收器的接口，一个消息接收器必须实现这个接口。

还有几个接口，我们将在下一节结合拦截构架的实现原理中进行介绍。

.NET Framework拦截机制的设计中，在客户端和对象之间，存在着多种消息接收器，这些消息接收器组成一个链表，客户端的调用对象的过程以及调用返回实行拦截，你可以定制自己的消息接收器，把它们插入了到链表中，来完成你对一个调用的前处理和后处理。那么调用拦截是如何构架或者说如何实现的呢？
在.NET中有两种调用，一种是跨应用域（App Domain)，一种是跨上下文环境（Context)，两种调用均通过中间的代理（proxy)，代理被分为两个部分：透明代理和实际代理。透明代理暴露同对象一样的公共入口点，当客户调用透明代理的时候，透明代理把堆栈中的帧转换为消息（上一节提到的实现IMessage接口的对象），消息中包含了方法名称和参数等属性集，然后把消息传递给实际代理，接下去分两种情况：在跨应用域的情况下，实际代理使用一个格式化器对消息进行序列化，然后放入远程通道中；在跨上下文环境的情况下，实际代理不必知道格式化器、通道和Context拦截器，它只需要在向前传递消息之前对调用实行拦截，然后它把消息传递给一个消息接收器（实现IMessageSink的对象），每一个接收器都知道自己的下一个接收器，当它们对消息进行处理之后（前处理），都将消息传递给下一个接收器，一直到链表的最后一个接收器，最后一个接收器被称为堆栈创建器，它把消息还原为堆栈帧，然后调用对象，当调用方法结果返回的时候，堆栈创建器把结果转换为消息，传回给调用它的消息接收器，于是消息沿着原来的链表往回传，每个链表上的消息接收器在回传消息之前都对消息进行后处理。一直到链表的第一个接收器，第一个接收器把消息传回给实际代理，实际代理把消息传递给透明代理，后者把消息放回到客户端的堆栈中。从上面的描述我们看到穿越Context的消息不需要格式化，CLR使用一个内部的通道，叫做CrossContextChannel，这个对象也是一种消息接收器。

有几种消息接收器的类型，一个调用拦截可以在服务器端进行也可以在客户端进行，服务器端接收器拦截所有对服务器上下文环境中对象的调用，同时作一些前处理和后处理。客户端的接收器拦截所有外出客户端上下文环境的调用，同时也做一些前处理和后处理。服务器负责服务器端接收器的安装，拦截对服务器端上下文环境访问的接收器称为服务器上下文环境接收器，那些拦截调用实际对象的接收器是对象接收器。通过客户安装的客户端接收器称为客户端上下文环境接受器，通过对象安装的客户端接收器则称为特使（Envoy）接收器，特使接收器仅拦截那些和它相关的对象。客户端的最后一个接收器和服务器端的第一个接收器是CrossContextChannel类型的实例。不同类型的接收器组成不同的段，每个段的端点都装上称为终结器的接收器，终结器起着把本段的消息传给下一个段的作用。在服务器上下文环境段的最后一个终结器是ServerContextTerminatorSink。如果你在终结器调用NextSink，它将返回一个null，它们的行为就像是死端头，但是在它们内部保存有下一个接收器对象的私有字段。

我们大致介绍了.NET Framework的对象调用拦截的实现机制，目的是让大家对这种机制有一个认识，现在是实现我们代码的时候了，通过代码的实现，你可以看到消息如何被处理的过程。首先是为我们的程序定义一个接收器CallTraceSink:

 

//TraceContext.cs

using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;

namespace NiwalkerDemo
{
 public class CallTraceSink : IMessageSink //实现IMessageSink
 {
 private IMessageSink nextSink; //保存下一个接收器
 
 //在构造器中初始化下一个接收器
 public CallTraceSink(IMessageSink next)
 {
 nextSink=next;
 }
 
 //必须实现的IMessageSink接口属性
 public IMessageSink NextSink
 {
 get
 {
 return nextSink;
 }
 }
 
 //实现IMessageSink的接口方法，当消息传递的时候，该方法被调用
 public IMessage SyncProcessMessage(IMessage msg)
 {
 //拦截消息，做前处理
 Preprocess(msg);
 //传递消息给下一个接收器
 IMessage retMsg=nextSink.SyncProcessMessage(msg);
 //调用返回时进行拦截，并进行后处理
 Postprocess(msg,retMsg);
 return retMsg;
 }
 
 //IMessageSink接口方法，用于异步处理，我们不实现异步处理，所以简单返回null,
 //不管是同步还是异步，这个方法都需要定义
 public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
 {
 return null;
 }
 
 //我们的前处理方法，用于检查库存，出于简化的目的，我们把检查库存和发送邮件都写在一起了，
 //在实际的实现中，可能也需要把Inventory对象绑定到一个上下文环境，
 //另外，可以将发送邮件设计为另外一个接收器，然后通过NextSink进行安装
 private void Preprocess(IMessage msg)
 {
 //检查是否是方法调用，我们只拦截Order的Submit方法。
 IMethodCallMessage call=msg as IMethodCallMessage;
 
 if(call==null)
 return;
 
 if(call.MethodName=="Submit")
 {
 string product=call.GetArg(0).ToString(); //获取Submit方法的第一个参数
 int qty=(int)call.GetArg(1); //获取Submit方法的第二个参数
 
 //调用Inventory检查库存存量
 if(new Inventory().Checkout(product,qty))
 Console.WriteLine("Order availible");
 else
 {
 Console.WriteLine("Order unvailible");
 SendEmail();
 }
 }
 }
 
 //后处理方法，用于记录订单提交信息，同样可以将记录作为一个接收器
 //我们在这里处理，仅仅是为了演示
 private void Postprocess(IMessage msg,IMessage retMsg)
 {
 IMethodCallMessage call=msg as IMethodCallMessage;
 
 if(call==null)
 return;
 Console.WriteLine("Log order information");
 }
 
 private void SendEmail()
 {
 Console.WriteLine("Send email to manager");
 }
 }
 ...

接下来我们定义上下文环境的属性，上下文环境属性必须根据你要创建的接收器类型来实现相应的接口，比如：如果创建的是服务器上下文环境接收器，那么必须实现IContributeServerContextSink接口。

 ...
public class CallTraceProperty : IContextProperty, IContributeObjectSink
{
 public CallTraceProperty()
 {
 }
 
 //IContributeObjectSink的接口方法，实例化消息接收器
 public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
 {
 return new CallTraceSink(next);
 }
 
 //IContextProperty接口方法，如果该方法返回ture,在新的上下文环境中激活对象
 public bool IsNewContextOK(Context newCtx)
 {
 return true;
 }
 
 //IContextProperty接口方法，提供高级使用
 public void Freeze(Context newCtx)
 {
 }
 
 //IContextProperty接口属性
 public string Name
 {
 get { return "OrderTrace";}
 }
}
 ...

最后是ContextAttribute
 ...
 \[AttributeUsage(AttributeTargets.Class)\]
 public class CallTraceAttribute : ContextAttribute
 {
 public CallTraceAttribute():base("CallTrace")
 {
 }
 
 //重载ContextAttribute方法，创建一个上下文环境属性
 public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
 {
 ctorMsg.ContextProperties.Add(new CallTraceProperty());
 }
 }
}

为了看清楚调用Order对象的Submit方法如何被拦截，我们稍微修改一下Order类，同时把它设计为ContextBoundObject的派生类：

//Inventory.cs

//Order.cs
using System;

namespace NiwalkerDemo
{
 \[CallTrace\]
 public class Order : ContextBoundObject
 {
 ...
 public void Submit(string product, int quantity)
 {
 this.product=product;
 this.quantity=quantity;
 }
 ...
 }
}

 

客户端调用代码：

...
public class AppMain
{
 static void Main()
 {
 Order order1=new Order(100);
 order1.Submit("Item1",150);
 
 Order order2=new Order(101);
 order2.Submit("Item2",150);
 }
}
...

运行结果表明了我们对Order的Sbumit成功地进行了拦截。需要说明的是，这里的代码仅仅是作为对ContextAttribute应用的演示，它是粗线条的。在具体的实践中，大家可以设计的更精妙。

 

[好文要顶](#) [关注我](#) [收藏该文](#) [![](C#%20Attribute在.net编程中的应用%20(转）%20-%20vivien%20-%20博客园_files/d5aea86bdec32a66be1446dacc4efd84.png)](# "分享至新浪微博") [![](C#%20Attribute在.net编程中的应用%20(转）%20-%20vivien%20-%20博客园_files/0d5b76b4ae98cefd7c2d4300c27b1c69.png)](# "分享至微信")

[](http://home.cnblogs.com/u/sleeping/)
[vivien](http://home.cnblogs.com/u/sleeping/)
[关注 - 0](http://home.cnblogs.com/u/sleeping/followees)
[粉丝 - 6](http://home.cnblogs.com/u/sleeping/followers)

[+加关注](#)

1

0

(请您对文章做出评价)

[«](http://www.cnblogs.com/sleeping/archive/2008/05/21/1204097.html) 上一篇：[A Single Instance Application which Minimizes to the System Tray](http://www.cnblogs.com/sleeping/archive/2008/05/21/1204097.html "发布于2008-05-21 15:28")
[»](http://www.cnblogs.com/sleeping/archive/2009/02/13/1390186.html) 下一篇：[TextChanged Event of ComboBox](http://www.cnblogs.com/sleeping/archive/2009/02/13/1390186.html "发布于2009-02-13 16:58")

posted on 2008-12-17 12:22 [vivien](http://www.cnblogs.com/sleeping/) 阅读(2899) 评论(1) [编辑](http://i.cnblogs.com/EditPosts.aspx?postid=1356691) [收藏](http://www.cnblogs.com/sleeping/archive/2008/12/17/1356691.html#)


