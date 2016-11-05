在VS Code下运行python {#在VS_Code下运行python style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin-top: 0.5em; margin-bottom: 0.5em; padding-top: 0.3em; padding-bottom: 0.3em; border: 0px; outline: 0px; font-weight: inherit; font-family: 'Helvetica Neue', Helvetica, 'Microsoft YaHei', 'WenQuanYi Micro Hei', Arial, sans-serif; font-size: 28.8px; vertical-align: baseline; line-height: 1.2em; color: rgb(51, 51, 51); -webkit-font-smoothing: antialiased; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(250, 250, 250);"}
---------------------

------------------------------------------------------------------------

今天发现了一个编辑代码的神器，叫VS Code(Visual Studio
Code)，是在2015年微软Build大会上发布的编辑器，目前还属于preview阶段，可以在[这里下载](https://code.visualstudio.com/)

这里它各种NB的功能我就不介绍了，我就介绍一下它[Task](https://code.visualstudio.com/Docs/tasks)功能，我们可以利用task功能实现执行python的功能。

打开VS
Code后，Ctrl+N新建一个文件，将其保存为hello.py。这时你就会发现编辑的代码可以高亮了，接着按Ctrl+Shift+P或者Ctrl+p输入&gt;就可以输入命令了。

在框框中输入`Configure task`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}，打开`tasks.json`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}。这时候我们可以看到该文件的内容：

![](在VS%20Code下运行python_files/0.6709023874718696.png){.img-shadow
.img-center}

task runner会调用typescript的编译器（tsc）来编译typescript的程序。

如果你仔细观察了打开项目的目录的话，你会发现目录下多了一个`.setting`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}的隐藏文件夹，文件夹下面有我们刚刚打开的`tasks.json`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}文件。也就是说我们执行的`Configure task`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}命令为我们在目录下配置了编辑环境。你会看到这样的目录结构：

![](在VS%20Code下运行python_files/0.519119773292914.png){.img-shadow
.img-center}

基于这个想法，我们可以个性化我们的`tasks.json`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}文件，

+--------------------------------------+--------------------------------------+
| ``` {style="-webkit-margin-before: 0 | ``` {style="-webkit-margin-before: 0 |
| px; -webkit-margin-after: 0px; margi | px; -webkit-margin-after: 0px; margi |
| n-top: 0px; margin-bottom: 0px; padd | n-top: 0px; margin-bottom: 0px; padd |
| ing: 0px 1.5em 0px 0px; border: none | ing: 0px; border: none; outline: 0px |
| ; outline: 0px; font-weight: inherit | ; font-weight: inherit; font-style:  |
| ; font-style: inherit; font-family:  | inherit; font-family: Monaco, Menlo, |
| Monaco, Menlo, Consolas, 'Courier Ne |  Consolas, 'Courier New', monospace; |
| w', monospace; vertical-align: basel |  vertical-align: baseline; overflow: |
| ine; overflow: auto; color: rgb(102, |  auto; line-height: 1.5; background- |
|  102, 102); line-height: 1.5; text-a | image: initial; background-attachmen |
| lign: right; background-image: initi | t: initial; background-size: initial |
| al; background-attachment: initial;  | ; background-origin: initial; backgr |
| background-size: initial; background | ound-clip: initial; background-posit |
| -origin: initial; background-clip: i | ion: initial; background-repeat: ini |
| nitial; background-position: initial | tial;"}                              |
| ; background-repeat: initial;"}      | {    "version": "0.1.0",    "command |
| 12345678                             | ": "python",    "isShellCommand": tr |
| ```                                  | ue,    "args": ["${file}"]    "showO |
|                                      | utput": "always"}                    |
|                                      | ```                                  |
+--------------------------------------+--------------------------------------+

保存后在python文件中按Ctrl+Shift+B，就会弹出output的窗口，并输出helloworld

当然我们也可以编辑一下`g++`{style="-webkit-margin-before: 0px; -webkit-margin-after: 0px; margin: 0px 2px; padding: 0px 5px; border: 1px solid rgb(214, 214, 214); outline: 0px; font-weight: inherit; font-style: inherit; font-family: Monaco, Menlo, Consolas, "Courier New", monospace; font-size: 15.12px; vertical-align: baseline; background: rgb(238, 238, 238); color: rgb(116, 112, 112); white-space: nowrap; text-shadow: rgb(255, 255, 255) 0px 1px;"}，windows下的g++，我使用的是MingW配置的，具体的安装过程可以参考百度经验。

两个task脚本似乎不能兼容，我就采用注释的方式，要运行python的时候就打开python的。下面是编译C++的脚本

+--------------------------------------+--------------------------------------+
| ``` {style="-webkit-margin-before: 0 | ``` {style="-webkit-margin-before: 0 |
| px; -webkit-margin-after: 0px; margi | px; -webkit-margin-after: 0px; margi |
| n-top: 0px; margin-bottom: 0px; padd | n-top: 0px; margin-bottom: 0px; padd |
| ing: 0px 1.5em 0px 0px; border: none | ing: 0px; border: none; outline: 0px |
| ; outline: 0px; font-weight: inherit | ; font-weight: inherit; font-style:  |
| ; font-style: inherit; font-family:  | inherit; font-family: Monaco, Menlo, |
| Monaco, Menlo, Consolas, 'Courier Ne |  Consolas, 'Courier New', monospace; |
| w', monospace; vertical-align: basel |  vertical-align: baseline; overflow: |
| ine; overflow: auto; color: rgb(102, |  auto; line-height: 1.5; background- |
|  102, 102); line-height: 1.5; text-a | image: initial; background-attachmen |
| lign: right; background-image: initi | t: initial; background-size: initial |
| al; background-attachment: initial;  | ; background-origin: initial; backgr |
| background-size: initial; background | ound-clip: initial; background-posit |
| -origin: initial; background-clip: i | ion: initial; background-repeat: ini |
| nitial; background-position: initial | tial;"}                              |
| ; background-repeat: initial;"}      | {    "version": "0.1.0",     "comman |
| 123456                               | d": "g++",    "args": ["-Wall", "-o" |
| ```                                  | ,"test","${file}"], //生成的可执行文件叫test  |
|                                      |    "showOutput": "always"}           |
|                                      | 来源： http://jonathenzc.github.io/2015 |
|                                      | /07/24/%E5%9C%A8VS-Code%E4%B8%8B%E8% |
|                                      | BF%90%E8%A1%8Cpython/                |
|                                      | ```                                  |
+--------------------------------------+--------------------------------------+


