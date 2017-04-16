### 定义和调用扩展方法
1. 定义一个静态类以包含扩展方法。该类必须对客户端代码可见。
2. 将该扩展方法实现为静态方法，并使其至少具有与包含类相同的可见性。
3. 该方法的第一个参数指定方法所操作的类型；该参数必须以 this 修饰符开头。
4. 在调用代码中，添加一条 using 指令以指定包含扩展方法类的命名空间。
5. 按照与调用类型上的实例方法一样的方式调用扩展方法。
> 请注意，第一个参数不是由调用代码指定的，因为它表示正应用运算符的类型，并且编译器已经知道对象的类型。 您只需通过 n 为这两个形参提供实参。


下面的示例在 CustomExtensions.StringExtension 类中实现了一个名为 WordCount 的扩展方法。 该方法对 String 类进行操作，而该类被指定为第一个方法参数。 CustomExtensions 命名空间被导入到应用程序命名空间中，并且该方法是在 Main 方法内调用的。
```csharp
using System.Linq;
using System.Text;
using System;

namespace CustomExtensions
{
    //Extension methods must be defined in a static class
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static int WordCount(this String str)
        {
            return str.Split(new char[] {' ', '.','?'}, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
namespace Extension_Methods_Simple
{
    //Import the extension method namespace.
    using CustomExtensions;
    class Program
    {
        static void Main(string[] args)
        {
            string s = "The quick brown fox jumped over the lazy dog.";
            //  Call the method as if it were an 
            //  instance method on the type. Note that the first
            //  parameter is not specified by the calling code.
            int i = s.WordCount();
            System.Console.WriteLine("Word count of s is {0}", i);
        }
    }
}
```

**参考**

[如何：实现和调用自定义扩展方法（C# 编程指南）](https://msdn.microsoft.com/zh-cn/library/bb311042.aspx)

[C#扩展方法 扩你所需](http://blog.csdn.net/yl2isoft/article/details/9930347)