
`==`和`Equals`从本质上来说，一个是语言本身的运算符，一个是对象的一个多态方法，它们用来作为比较没有什么区别，除了在String类型上。

在值类型的比较上，`==`和`Equals`都是比较内容，在对象的比较上都是比较引用，除了String。

String虽然是一个引用类型，但是很多时候看起来并不像一个引用类型。

string interning - 字符串驻留，是为了优化内存而采取的一种机制，在需要相同值的字符串时，直接从驻留池里拿来用，避免频繁创建和销毁。相同值的字符串保存了对同一内容的引用，所以字符串是不可变对象，可以改变它引用的对象，不能改变它引用对象的内容。

在比较String类型时，`==`是基于引用的比较，而`Equals`是基于值的比较，可以看到在string interning的时候，字符串的内容和地址都是相同的
```cs
string s1 = "test";
string s2 = "test";

s1 == s2;   //true
s1.Equals(s2);  //true

//内容和引用地址都一样
Object o1 = s1;
Object o2 = s2;
o1 == o2;   //true
o1.Equals(o2);  //true
```

但是有时候破坏了string interning机制，这时候`==`和`Equals`就表现出了不一致
```cs
Object str = new string(new char[] { 't', 'e', 's', 't' });
Object str1 = new string(new char[] { 't', 'e', 's', 't' });
//内容相同但是引用地址不同
str == str1;    //false
str.Equals(str1);   //true
```

再看一个例子
```cs
Object x = "hello";
Object y = "he" + "llo";

x == y;   //true
x.Equals(y);  //true
```
两个字符串指向了相同的地址，这是因为y是一个编译时常量，在编译的时候就已经确定了并且等于"hello"

[== VS Equals in C#](https://www.codeproject.com/Articles/1111680/equalsequals-VS-Equals-in-Csharp)

[Python中的字符串驻留](http://cnn237111.blog.51cto.com/2359144/1615356)

[What's the difference between “.equals” and “==”?](https://stackoverflow.com/questions/1643067/whats-the-difference-between-equals-and)