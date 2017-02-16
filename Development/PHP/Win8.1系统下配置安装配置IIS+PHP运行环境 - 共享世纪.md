很多人喜欢用linux搭建php网页语言运行环境，但由于linux高度自定义化，经常需要root运行命令，略显高端，相对应的微软的windows操作系统，用户体验不错，可以借助windows自带的IIS组件+PHP程序包，搭建一个合适的运行环境。Windows xp时代是IIS6，win7时代是IIS7.5，win8时代IIS 8.0，同样win8.1的内置IIS组件也升级到8.5，拥有更高的执行效率和不错的用户体验。下面小编就带大家在Win8.1系统下配置搭IIS8.5+PHP5.5.4运行环境。

**准备工作：**

**PHP 5.5.4程序包**，分别根据自己的系统版本下载32位或者64位。
官网介绍：[http://windows.php.net/download**
**](http://windows.php.net/download)

**VC11 x86 Thread Safe**
下载：<http://windows.php.net/downloads/releases/php-5.5.4-nts-Win32-VC11-x86.zip>

**VC11 x64 Thread Safe** 
下载：<http://windows.php.net/downloads/releases/php-5.5.4-nts-Win32-VC11-x64.zip>

Win8.1 9600版本，建议用专业版或者企业版。

具体操作步骤：

**一、开启，设置win8.1自带的IIS 8.5组件服务器。
**进入控制面板，选择程序和功能，打开或关闭Windows 功能，找到**Internet information services**，分别开启FTP服务器、Web管理工具和万维网服务组件，其中万维网服务的子组件也依次开启，”其中最重要的开启应用程序开发功能”，如下图所示。
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611IB-0.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111035-1.jpg)
安装结束后，重启进行自动功能配置

 在浏览器中打开[http://localhost](http://localhost/) 或者是<http://127.0.0.1/> ，查看是否能显示IIS8.5的多国语言的欢迎页面：
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115V7-2.png)

**二、下载安装配置PHP环境
**

小编下载了是VC11 x64 Thread Safe 版本的压缩包(php-5.5.4-Win32-VC11-x64)

1、将其解压到C:\\php5目录下（其他盘符也可以）。

　![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611C29-3.png)

2、选择这台电脑，右键管理，进入计算机管理
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115320-4.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111I7-5.png)

选择左侧的服务和应用程序，进入Internet信息服务(IIS)管理器

3、选择IIS功能下的”处理程序映射”双击进入，然后最右边选择”添加模块映射”
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114Q7-6.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111208-7.png)

4、在请求路径输入”\*.php”，模块选择FastCgiModule模式，可执行文件时，文件格式可以选择exe程序和选择路径：C:\\php5\\php-cgi.exe，名称比如php，最后确定添加模块映射。
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114Z3-8.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114631-9.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611K59-10.png)

5.然后手动给网站添加默认文档：default.php和index.php两个文档。

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/23161125R-11.png)

6、继续对于php程序包进行下面的配置：进入C:\\php5目录，重命名文件php.ini-development改名为php.ini。

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316113R4-12.png)

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611G92-13.png)

7、用记事本打开编辑php.ini文件，使用快捷键ctrl+F快速搜索定位，相关的date.timezone修改为date.timezone=”Asia/Hongkong”即修改当前的系统时区, 同时将前面的分号”;”删除生效。
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115118-14.png)

同时也需要激活相应的扩展选项，即将相应dll语句前的分号”;”删除

**例如：**
;extension=php\_gd2.dll 改为extension=php\_gd2.dll
;extension=php\_mbstring.dll 改为extension=php\_mbstring.dll
;extension=php\_mysql.dll 改为extension=php\_mysql.dll
;extension=php\_mysqli.dll 改为extension=php\_mysqli.dll
;extension=php\_pdo\_mysql.dll改为extension=php\_pdo\_mysql.dll

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111332-15.png)

然后搜索extension\_dir，修改路径为extension\_dir = “C:\\php5\\ext\\” ，同时将前面的分号”;”删除生效。修改后保存，然后复制这个php.ini文件到C:\\Windows根目录下即可。

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316113493-16.png)

8、php环境配置好了，现在就需要测试一下了，在建立的网站目录wwwroot文件夹下”C:\\inetpub\\wwwroot”新建一个phpinfo.php网页文件。
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/23161125O-17.png)

内容为:
&lt;?php
phpinfo();
?&gt;

然后再在IE浏览器中打开<http://localhost/phpinfo.php> ，即可出现类似如下界面，即成功生效。
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114220-18.png)

PS:(在命令行中进入php安装目录下,比如c:\\php5\\php.exe -m，输入php -m命令可查看已开启的dll扩展模块):
![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611MA-19.png)

至此，Win8.1系统下配置搭建IIS8.5+PHP5.5.4运行环境的教程到此结束，不知道你有没有搭建成功。如果需要数据库可以后期安装Mysql或者SQL server类的数据库，进行本地测试网站或者论坛。

![](../../Images/Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316112519-20.jpg)
