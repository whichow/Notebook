在VS Code下运行python
---------------------

------------------------------------------------------------------------

今天发现了一个编辑代码的神器，叫VS Code(Visual Studio Code)，是在2015年微软Build大会上发布的编辑器，目前还属于preview阶段，可以在[这里下载](https://code.visualstudio.com/)

这里它各种NB的功能我就不介绍了，我就介绍一下它[Task](https://code.visualstudio.com/Docs/tasks)功能，我们可以利用task功能实现执行python的功能。

打开VS Code后，Ctrl+N新建一个文件，将其保存为hello.py。这时你就会发现编辑的代码可以高亮了，接着按Ctrl+Shift+P或者Ctrl+p输入&gt;就可以输入命令了。

在框框中输入`Configure task`，打开`tasks.json`。这时候我们可以看到该文件的内容：

![](在VS%20Code下运行python_files/0.6709023874718696.png)

task runner会调用typescript的编译器（tsc）来编译typescript的程序。

如果你仔细观察了打开项目的目录的话，你会发现目录下多了一个`.setting`的隐藏文件夹，文件夹下面有我们刚刚打开的`tasks.json`文件。也就是说我们执行的`Configure task`命令为我们在目录下配置了编辑环境。你会看到这样的目录结构：

![](在VS%20Code下运行python_files/0.519119773292914.png)

基于这个想法，我们可以个性化我们的`tasks.json`文件，

[TABLE]

保存后在python文件中按Ctrl+Shift+B，就会弹出output的窗口，并输出helloworld

当然我们也可以编辑一下`g++`，windows下的g++，我使用的是MingW配置的，具体的安装过程可以参考百度经验。

两个task脚本似乎不能兼容，我就采用注释的方式，要运行python的时候就打开python的。下面是编译C++的脚本

[TABLE]


