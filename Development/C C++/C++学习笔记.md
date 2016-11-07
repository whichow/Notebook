# C++学习笔记
struct和class:

c++中结构体和类的唯一区别在于访问属性的不同，结构体中的成员默认为public，而类中的成员默认为private。

c\#中的类为引用类型，而结构体为值类型，且不能为null

默认参数：

使用默认参数的函数相当于定义了两个函数，如：

int add(int a, int b=1)定义了有两个参数的int add(int a, int b)和一个隐含的只有一个参数的int add(int a)并且b的默认值为1。

定义了int add(int a, int b=1)后，不能再定义一个只有一个参数的函数int add(int a)，因为这样会产生歧义。

构造函数的初始化列表：

在构造函数中，初始化列表可以简化代码体中赋值，如：
```cpp
class Person

{

    public:

        Person() { }

        Person(char\* n, int a):name(n), age(a) { }

        Person(const Person& p)

        {

            this-&gt;name = p-&gt;name;

            this-&gt;age = p-&gt;age;

        }

        Person& operator = (const Person& p)

        {

            this-&gt;name = p.name;

            this-&gt;age = p.age;

            return \*this;

        }

    private:

        char\* name;

        int age;

}

class Test

{

    public:

        Test(Person& p)

        {

            tp=p;

        }

    private:

        Person tp;

}
```
对于内置类型，如int, float等，使用初始化类表和在构造函数体内初始化差别不是很大，但是对于类类型来说，最好使用初始化列表，可以不用调用默认构造函数。

以下几种情况时必须使用初始化列表

-   常量成员，因为常量只能初始化不能赋值，所以必须放在初始化列表里面
-   引用类型，引用必须在定义的时候初始化，并且不能重新赋值，所以也要写在初始化列表里面
-   没有默认构造函数的类类型，因为使用初始化列表可以不必调用默认构造函数来初始化，而是直接调用拷贝构造函数初始化。


