MinGW与Cygwin - 技术博客 - ITeye技术网站
<div>

<div style="-evernote-webclip:true">

\
<div style="font-size: 16px">

<div>

<div
style="text-align:center;font-family:Helvetica, Tahoma, Arial, sans-serif;font-size:12px;line-height:1.5;color:black;background:white;">

<div
style="text-align:center;background:white;background-color:rgb(239, 250, 255);">

<div style="text-align:left;">

<div style="overflow:hidden;background-color:white;">

<div style="background-color:white;">

<div style="font-size:14px;line-height:1.8em;">

<div
style="font-size:14px;border:0px none rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:700px;height:1140.8px;">

 

**MingW和cygwin的区别**

-------------------------------------------------------------

首先MingW和cygwin都可以用来跨平台开发。 \
MinGW是Minimalistic GNU for Windows的缩写，也就是Win版的GCC。  \
Cygwin则是全面模拟了Linux的接口，提供给运行在它上面的的程序使用，并提供了大量现成的软件，更像是一个平台。  

\
相对的MingW也有一个叫MSys（Minimal SYStem）的子项目，主要是提供了一个模拟Linux的Shell和一些基本的Linux工具。
因为编译一个大型程序，光靠一个GCC是不够的，还需要有Autoconf等工具来配置项目，所以一般在Windows下编译ffmpeg等Linux下
的大型项目都是通过Msys来完成的，当然Msys只是一个辅助环境，根本的工作还是MingW来做的。 \
\
**用MingW和cygwin编译出来的程序的区别**

-------------------------------------------------------------\
首先MingW和cygwin都不能让Linux下的程序直接运行在Windows上，必需通过源代码重新编译。  \
现代操作系统包括Windows和Linux的基本设计概念像进程线程地址空间虚拟内存这些都是大同小异的，之所以二者上的程序不能兼容，主要是它们对这些
功能具体实现上的差异。

首先是可执行文件的格式，Window使用PE的格式，并且要求以.EXE为后缀名。Linux则使用Elf。

其次操作系统的
API也不一样，如Windows用CreateProcess()创建进程，而Linux使用fork()。  \
所以要移植程序必然要在这些地方进行改变，MingW有专门的W32api头文件，来把代码中Linux方式的系统调用替换为对应的Windows方式。而Cygwin则通过
cygwin1.dll这个文件来实现这种API的转换，并模拟一个Linux系统调用接口给程序，程序依然以Linux的方式调用系统API，只不过这
个API在cygwin1.dll上，cygwin1.dll再调用Windows对应的实现，来把结果返回给程序。  \
可以用查看他们编译好的程序的导入表来验证这点。  \
二者生成的程序都是能在Windows上运行的EXE文件，显然都是PE格式，用一个PE格式查看工具检查一下就能发现，Cygwin生成的程序依然有
fork()这样的Linux系统调用，但目标库是cygwin1。而MingW生成的程序，则全部使用从KERNEL32导出的标准Windows系统
API。  \
这样看来用Mingw编译的程序性能会高一点，而且也不用带着那个接近两兆的cygwin1.dll文件。  \
但Cygwin对Linux的模拟比较完整，甚至有一个Cygwin X的项目，可以直接用Cygwin跑X。  \
另外Cygwin可以设置-mno-cygwin的flag，来使用Mingw编译。  \
而与Cygwin更有可比性的MSys上的工具也是通过Cygwin这种模拟的方式来提供的。  \
\

区别总结：

1.修改编译器,让window下的编译器把诸如fork的调用翻译成等价的形式--这就是mingw的做法. \
2.修改库,让window提供一个类似unix提供的库,他们对程序的接口如同unix一样,而这些库,当然是由win32的API实现的--这就是cygwin的做法.

 

 

 

**如何选择MingW和cygwin**

-------------------------------------------------------------

如果在windows开发linux程序，cygwin是很好的选择。如果你开发的程序不介意有一个cygwin1.dll的话，也是可以选择cygwin的。

如果你是想开发windows下的程序，还要必须用gcc的话，mingw是很好的一个选择。

但是在windows下有太多的编译器了，bc，vc，intel c.....。

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>

</div>
