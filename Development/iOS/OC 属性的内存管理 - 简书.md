
属性的内存管理经常是让人很头疼的一件事，尤其是很多人在面试时经常会被问到，下面我们来讲讲属性的内存管理。

MRC:
----

在MRC下，属性的修饰词有三个，分别是`assign`,`retain`， `copy`三者对应不同的内存管理方式。

### assign

assign:修饰基本数据类型，例如int,float等；他不会对基本数据类型进行内存管理；
参考setter和getter方法：

```
-(void)setAge:(NSInteger)age
{
    _age = age;
}

-(NSInteger)age
{
    return _age;
}
```

### retain

retain:修饰对象类型，对属性进行内存管理； 该属性对象指向一个对象后，对应对象的引用计数+1。
参考setter和getter方法：

```
-(void)setSex:(NSString *)sex
{
    if (_sex != sex) {
        //释放旧对象
        [_sex release];

        //持有新对象
        _sex = [sex retain];
    }
}

-(NSString *)sex
{
    return [[_sex retain] autorelease]; //持有再自动释放
}
```

### copy

copy:修饰对象类型, 对属性进行内存管理. 该属性对象指向一个对象后， 对应对象的引用计数不会改变。属性对象会复制对应对象的内容并生成一个新的对象，然后属性对象指向这个新的对象。
参考setter和getter方法

```
-(void)setHobby:(NSString *)hobby
{
    if (_hobby != hobby) {
        //释放原有对象
        [_hobby release];

        //复制新对象
        _hobby = [hobby copy];
    }
}

-(NSString *)hobby
{
    return [[_hobby retain] autorelease];
}
```

`注意：`利用`copy`修饰的属性被赋值后引用计数为1， 属性和对应对象指向的不是同一块内存空间；

ARC：
-----

在ARC下，属性的修饰词有三个，分别是`strong`,`weak`， `copy`三者对应不同的内存管理方式。

-   strong：相当于MRC下的`retian`, 一般叫做强引用；
-   weak：修饰对象，但不对属性进行内存管理， 属性的引用计数不会改变，用于避免循环引用等问题；注意不能修饰基本数据类型；
-   copy:同MRC下的copy一样

*\*欢迎大家踊跃评论，让我们一起探讨技术！！
如果觉得文章不错，请帮忙点击文章下方的`喜欢`！！
你的支持将是对我最好的鼓励, 谢谢！！！*


