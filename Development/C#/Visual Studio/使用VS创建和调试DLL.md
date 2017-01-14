1 将DLL工程设置为启动工程
（只有这样调试器才会挂接到DLL工程上）
2 右键单击DLL工程，选择属性（Properties)进入属性设置页面。在左边Congifure Properties下面选择Debugging
3 在右边Debuggers to launch选择Local Windows Debugger
4 在下面Command一览中点击右边的箭头，按浏览，之后选择会调用你代码的应用程序。
5 在Debugger Type里面选择Mixed
（这是最重要的一步，一般来说默认的Auto。但是是Auto不出来的。如果是托管代码调用你的DLL，比如一个C#应用程序调用DLL，那么你就选Managed Only，如果是一个本地代码掉用你的DLL，比如C++应用程序，那么就选Native Only。很明显Mixed包含了这两类，选择果断选Mixed）


是自己调试时候用的，还是很好用的，留下来记住。如下是步骤：

1、在“Solution Explorer”中找到要调试的dll项目，点击右键，选择Set as StartUp Project，将dll设置为调试启动项目；然后选择dll项目，点击右键，选择Properties，打开属性页设置页面;

2、在Properties 页面的中，选择Configuration Properties下拉菜单，然后选择Debugging；

3、在Debugging的页面中，在第一行Debugger to launch的下拉菜单中，如果是本地调试选择Local Windows Debugger，远程调试选择Remote Windows Debugger；

4、在Debugging的页面中，Command中选择下拉菜单，找到引用该dll的应用程序；在Command Arguments中输入$(TargetFileName)，或者自己从下拉框中选择，然后在此字符串后面 输入dll文件导出的函数名：

如我有两个导出函数：CreatePlugObj（）和 ReleasePlugObj() ,则应该写为：

$(TargetFileName) CreatePlugObj; ReleasePlugObj

5、在Debugging的页面中，Working Directory下拉菜单，选择当前工作目录，如Debug。

如此在dll项目要调试的代码段中设置断点，开始调试，就可以跳转到dll中的断点了

**参考**

[VS2010编写动态链接库DLL及单元测试用例，调用DLL测试正确性](http://blog.csdn.net/testcs_dn/article/details/27237509)

[利用VS生成.lib及.dll文件](http://wangzi6147.github.io/2015/05/05/DLL.html)

[用 Microsoft 适用于 C++ 的单元测试框架编写 C/C++ 单元测试](https://msdn.microsoft.com/zh-cn/library/hh598953.aspx)

[C#换机器后调用dll失败提示无法加载DLL找不到指定的模块](http://blog.csdn.net/mmhh3000/article/details/51083704)