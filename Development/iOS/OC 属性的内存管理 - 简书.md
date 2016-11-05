<div id="show-note-container"
class="imagebubble-container imagebubble-mode-off">

<div id="flag" class="post-bg">

<div class="container">

<div class="article">

<div class="preview">

<div
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 2473px; line-height: 27.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;">

<div widget="ImageBubble"
style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 490px; line-height: 27.2px; margin: 0px 0px 20px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-align: center; text-decoration: none; width: 620px;">

![](OC%20属性的内存管理%20-%20简书_files/1196725-851222d6cbec824e.jpg)\
<div
style="color: rgb(153, 153, 153); display: inline-block; font-style: italic; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: &quot;lucida grande&quot;, &quot;lucida sans unicode&quot;, lucida, helvetica, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; height: 22px; line-height: 22.1px; margin: 0px; min-height: 22px; min-width: 20%; outline: rgb(153, 153, 153) none 0px; padding: 10px; text-align: center; text-decoration: none; width: 124px;">

来自星星的星球

</div>

</div>

属性的内存管理经常是让人很头疼的一件事，尤其是很多人在面试时经常会被问到，下面我们来讲讲属性的内存管理。

MRC: {#mrc style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
----

在MRC下，属性的修饰词有三个，分别是`assign`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"},`retain`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}，
`copy`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}三者对应不同的内存管理方式。

### assign {#assign style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 22px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 39px; line-height: 39.6px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

assign:修饰基本数据类型，例如int,float等；他不会对基本数据类型进行内存管理；\
参考setter和getter方法：

``` {style="border: 1px solid rgba(0, 0, 0, 0.14902); color: rgb(101, 123, 131); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; height: 180px; line-height: 20px; margin: 0px 0px 20px; outline: rgb(101, 123, 131) none 0px; overflow: auto; padding: 9.5px; text-decoration: none; white-space: pre; width: 599px; word-break: break-all; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}
-(void)setAge:(NSInteger)age
{
    _age = age;
}

-(NSInteger)age
{
    return _age;
}
```

### retain {#retain style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 22px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 39px; line-height: 39.6px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

retain:修饰对象类型，对属性进行内存管理；
该属性对象指向一个对象后，对应对象的引用计数+1。\
参考setter和getter方法：

``` {style="border: 1px solid rgba(0, 0, 0, 0.14902); color: rgb(101, 123, 131); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; height: 300px; line-height: 20px; margin: 0px 0px 20px; outline: rgb(101, 123, 131) none 0px; overflow: auto; padding: 9.5px; text-decoration: none; white-space: pre; width: 599px; word-break: break-all; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}
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

### copy {#copy style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 22px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 39px; line-height: 39.6px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}

copy:修饰对象类型, 对属性进行内存管理. 该属性对象指向一个对象后，
对应对象的引用计数不会改变。属性对象会复制对应对象的内容并生成一个新的对象，然后属性对象指向这个新的对象。\
参考setter和getter方法

``` {style="border: 1px solid rgba(0, 0, 0, 0.14902); color: rgb(101, 123, 131); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; height: 300px; line-height: 20px; margin: 0px 0px 20px; outline: rgb(101, 123, 131) none 0px; overflow: auto; padding: 9.5px; text-decoration: none; white-space: pre; width: 599px; word-break: break-all; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}
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

`注意：`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}利用`copy`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}修饰的属性被赋值后引用计数为1，
属性和对应对象指向的不是同一块内存空间；

ARC： {#arc style="border: 0px none rgb(47, 47, 47); color: rgb(47, 47, 47); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 24px; font-family: "lucida grande", "lucida sans unicode", lucida, helvetica, "Hiragino Sans GB", "Microsoft YaHei", "WenQuanYi Micro Hei", sans-serif; height: 43px; line-height: 43.2px; margin: 0px; outline: rgb(47, 47, 47) none 0px; padding: 0px; text-decoration: none; width: 620px;"}
-----

在ARC下，属性的修饰词有三个，分别是`strong`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"},`weak`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}，
`copy`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}三者对应不同的内存管理方式。

-   strong：相当于MRC下的`retian`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 30px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"},
    一般叫做强引用；
-   weak：修饰对象，但不对属性进行内存管理，
    属性的引用计数不会改变，用于避免循环引用等问题；注意不能修饰基本数据类型；
-   copy:同MRC下的copy一样

*\*欢迎大家踊跃评论，让我们一起探讨技术！！\
如果觉得文章不错，请帮忙点击文章下方的`喜欢`{style="border: 0px none rgb(101, 123, 131); color: rgb(101, 123, 131); display: inline; font-style: italic; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; font-family: Menlo, Monaco, Consolas, "Courier New", monospace; line-height: 20.4px; margin: 0px; outline: rgb(101, 123, 131) none 0px; padding: 2px 4px; text-align: justify; text-decoration: none; white-space: pre-wrap; word-break: break-word; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(253, 246, 227);"}！！\
你的支持将是对我最好的鼓励, 谢谢！！！*

</div>

</div>

</div>

</div>

</div>

</div>
