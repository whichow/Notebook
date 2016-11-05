每次遇到这种错误就头痛，不知道要害死多少脑细胞了，就在这里做个总结吧\

可能会遇到这几种错误：\
Undefined symbols for architecture armv7\
Undefined symbols for architecture armv7s\
Undefined symbols for architecture arm64\
Undefined symbols for architecture i386\
Undefined symbols for architecture x86\_64\

<span
style="box-sizing: inherit; -webkit-tap-highlight-color: transparent; color: rgb(0, 112, 192);">错误原因分析</span>\
1、大部分情况下是忘记添加了某个系统framework或dylib吧，比如你在项目中使用了sqlite3，但是没有添加libsqlite3.dylib，就会出现这个问题。解决办法是增加对应的framework或dylib。\
2、如果是在C++里调用C函数，检查是否有添加extern
"C"，这可以通过观察错误提示中的函数名形式来决定，如果是C函数而以C
++的方式调用就需要添加extern "C"。\
3、如果是把其它工程的xcodeproj文件加入到当前项目中，检查Build
Phases中的Target Dependencies有没有添加依赖，以及General中的Linked
Frameworks and Libraries有没有添加相关的.a文件。\
4、如果添加.a文件编译无错而添加xcodeproj文件编译出错可参考3\
5、如果添加.a文件编译出错，首先检查其对应的头文件是否添加正确，或者在Build
Setting中有没有添加对应的Header Search
Path路径；其次检查.a文件的c++编译选项与当前项目的c++编译选项是否一致；最后检查.a文件与当前项目的CPU架构信息是否一致\
6、如果是extern变量报这个错误，要检查extern变量有没有在其它地方声明，如果没有则加上；如果外部变量在静态库中，可根据5检查引用头文件或头文件搜索路径是否正确；如果头文件无问题，就需要检查静态库与与当前项目的CPU架构信息是否一致\
7、如果是使用了静态库，真机Debug测试时正常，而在执行for iOS
Device测试时报这个错误，很可能是因为静态库支持的架构不全。出现这种情况是Build
Setting中的Build Active Architecture
Only在Debug下设为Yes，从而使得真机Debug测试正常。\
\
8、如果只有@interface，没有@implementation也会导致这个错误

<span
style="box-sizing: inherit; -webkit-tap-highlight-color: transparent; color: rgb(0, 112, 192);">检查静态库的CPU架构支持命令</span>：\
lipo -info xxxxx.a \
\
<span
style="box-sizing: inherit; -webkit-tap-highlight-color: transparent; color: rgb(0, 112, 192);">找出不支持arm64的静态库</span> \
find . -name \*.a -exec lipo -info "{}" \\;\
\
<span
style="box-sizing: inherit; -webkit-tap-highlight-color: transparent; color: rgb(0, 112, 192);">在@end处提示expected
}错误解决</span>\
问题很明显是}匹配出现问题了。如果代码少很好找，如果代码很多怎么缩小查找范围呢？一般出现这个问题时伴随另一个错误：在某个函数定义处提示"Use
of undeclared identifire
'someMethod'”，那么就是在此函数定义之前的地方少了一个}，导致编译器误把函数定义当成函数调用了。

\

