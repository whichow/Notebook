Unity iOS插件在模拟器中运行
Unity默认是不支持插件在模拟器中运行的，只能使用真机进行测试。

首先需要在Unity中 Player settings &gt; Other settings &gt; SDK version 改成Simulator SDK。

然后在XCode中修改Libraries\\RegisterMonoModules.cpp文件：

将函数

void mono\_dl\_register\_symbol (const char\* name, void \*addr);

移出条件

\#if !(TARGET\_IPHONE\_SIMULATOR)

\#endif // !(TARGET\_IPHONE\_SIMULATOR)

找到函数

void RegisterMonoModules()

将你导出的函数(mono\_dl\_register\_symbol)移出

\#if !(TARGET\_IPHONE\_SIMULATOR)

\#endif // !(TARGET\_IPHONE\_SIMULATOR)

需要注意的是，目标为模拟器的和真机的编译出来的库文件是不一样的，选择模拟器的编译出来的库为i386 x86\_64架构，真机为arm7 arm64架构，不能混用，否则会报错。

在选择为模拟器时，工程导航栏中的Products文件夹下的lib文件显示为红色。这时我们先切换目标到真机，先编译一遍，找到真机的lib文件，然后找到Products文件夹下的模拟器文件夹中的lib文件，这就是我们在模拟中使用的lib文件。

使用lipo -info mylib.a查看库文件架构，使用lipo -create "lib\_x86\_64.a" "lib\_armv7.a" -output "lib.a"将多个架构的库文件合成一个库文件。

要在模拟器中运行编译的库时，一定要在Build Settings-&gt;Build Active Architecture Only选择no，这样在能编译出i386 x86\_64的库文件。


