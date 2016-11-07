**Linux下：**

[?](#)

[TABLE]

到这一步，执行完后查看Git目录下的.gitconfig文件，会多了一项：

[?](#)

[TABLE]

**Windows下：**

方法一（本人未使用过）：

在windows中添加一个HOME环境变量，变量名:HOME,变量值：%USERPROFILE%

进入%HOME%目录，新建一个名为"\_netrc"的文件，文件中内容格式如下：

[?](#)

[TABLE]

方法二（测试可行）：

在home文件夹，一般是 C:\\Documents and Settings\\Administrator 下建立文件 .git-credentials

输入以下内容：

[?](#)

[TABLE]

运行以下git配置命令：

[?](#)

[TABLE]

重新打开git bash即可，无需再输入用户名和密码了。


