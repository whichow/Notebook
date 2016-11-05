<div class="main cbody margintop">

<div class="pleft">

<div class="newsview margintop">

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14.8px; font-family: 'Microsoft Yahei'; height: 10257px; line-height: 23.68px; margin: 0px; overflow: hidden; padding: 0px 14px; text-decoration: none; width: 608px; word-break: break-all;">

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14.8px; font-family: 'Microsoft Yahei'; height: 55px; line-height: 23.68px; margin: 10px 0px 5px; overflow: hidden; padding: 0px; text-align: center; text-decoration: none; width: 610px; word-break: break-all;">

</div>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">很多人喜欢用linux搭建php网页语言运行环境，但由于linux高度自定义化，经常需要root运行命令，略显高端，相对应的微软的windows操作系统，用户体验不错，可以借助windows自带的IIS组件+PHP程序包，搭建一个合适的运行环境。Windows
xp时代是IIS6，win7时代是IIS7.5，win8时代IIS
8.0，同样win8.1的内置IIS组件也升级到8.5，拥有更高的执行效率和不错的用户体验。下面小编就带大家在Win8.1系统下配置搭IIS8.5+PHP5.5.4运行环境。</span>

**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">准备工作：</span>**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">**PHP
5.5.4程序包**，分别根据自己的系统版本下载32位或者64位。\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">官网介绍：[http://windows.php.net/download**\
**](http://windows.php.net/download)</span>

**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">VC11
x86 Thread Safe</span>**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">下载：<http://windows.php.net/downloads/releases/php-5.5.4-nts-Win32-VC11-x86.zip>\
</span>

**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">VC11
x64 Thread Safe</span>**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;"> </span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">下载：<http://windows.php.net/downloads/releases/php-5.5.4-nts-Win32-VC11-x64.zip>\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">Win8.1
9600版本，建议用专业版或者企业版。</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">具体操作步骤：\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">**一、开启，设置win8.1自带的IIS
8.5组件服务器。\
**</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">进入控制面板，选择程序和功能，打开或关闭Windows
功能，找到**Internet information
services**，分别开启FTP服务器、Web管理工具和万维网服务组件，其中万维网服务的子组件也依次开启，”其中最重要的开启应用程序开发功能”，如下图所示。\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611IB-0.png)

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111035-1.jpg)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">安装结束后，重启进行自动功能配置\
</span>

 <span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">在浏览器中打开[http://localhost](http://localhost/)
或者是<http://127.0.0.1/> ，查看是否能显示IIS8.5的多国语言的欢迎页面：\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115V7-2.png)

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 'Microsoft Yahei'; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">**二、下载安装配置PHP环境\
**</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 'Microsoft Yahei'; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">小编下载了是VC11
x64 Thread Safe 版本的压缩包(php-5.5.4-Win32-VC11-x64)</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 'Microsoft Yahei'; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">1、将其解压到C:\\php5目录下（其他盘符也可以）。\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">　![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611C29-3.png)</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">2、选择这台电脑，右键管理，进入计算机管理\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115320-4.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111I7-5.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">选择左侧的服务和应用程序，进入Internet信息服务(IIS)管理器\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">3、选择IIS功能下的”处理程序映射”双击进入，然后最右边选择”添加模块映射”\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114Q7-6.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111208-7.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">4、在请求路径输入”\*.php”，模块选择FastCgiModule模式，可执行文件时，文件格式可以选择exe程序和选择路径：C:\\php5\\php-cgi.exe，名称比如php，最后确定添加模块映射。\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114Z3-8.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114631-9.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611K59-10.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">5.然后手动给网站添加默认文档：default.php和index.php两个文档。\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/23161125R-11.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">6、继续对于php程序包进行下面的配置：进入C:\\php5目录，重命名文件php.ini-development改名为php.ini。\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316113R4-12.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611G92-13.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">7、用记事本打开编辑php.ini文件，使用快捷键ctrl+F快速搜索定位，相关的date.timezone修改为date.timezone=”Asia/Hongkong”即修改当前的系统时区,
同时将前面的分号”;”删除生效。\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316115118-14.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">同时也需要激活相应的扩展选项，即将相应dll语句前的分号”;”删除\
</span>

**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">例如：</span>**<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">;extension=php\_gd2.dll
改为extension=php\_gd2.dll\
;extension=php\_mbstring.dll 改为extension=php\_mbstring.dll\
;extension=php\_mysql.dll 改为extension=php\_mysql.dll\
;extension=php\_mysqli.dll 改为extension=php\_mysqli.dll\
;extension=php\_pdo\_mysql.dll改为extension=php\_pdo\_mysql.dll\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316111332-15.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">然后搜索extension\_dir，修改路径为extension\_dir
= “C:\\php5\\ext\\”
，同时将前面的分号”;”删除生效。修改后保存，然后复制这个php.ini文件到C:\\Windows根目录下即可。\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316113493-16.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">8、php环境配置好了，现在就需要测试一下了，在建立的网站目录wwwroot文件夹下”C:\\inetpub\\wwwroot”新建一个phpinfo.php网页文件。\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/23161125O-17.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">内容为:\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">&lt;?php\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">phpinfo();\
</span><span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">?&gt;\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">然后再在IE浏览器中打开<http://localhost/phpinfo.php>
，即可出现类似如下界面，即成功生效。\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316114220-18.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">PS:(在命令行中进入php安装目录下,比如c:\\php5\\php.exe
-m，输入php -m命令可查看已开启的dll扩展模块):\
</span>![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/231611MA-19.png)<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">\
</span>

<span
style="display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: 宋体; line-height: 25.6px; margin: 0px; padding: 0px; text-decoration: none; word-break: break-all;">至此，Win8.1系统下配置搭建IIS8.5+PHP5.5.4运行环境的教程到此结束，不知道你有没有搭建成功。如果需要数据库可以后期安装Mysql或者SQL
server类的数据库，进行本地测试网站或者论坛。\
</span>

![](Win8.1系统下配置安装配置IIS+PHP运行环境%20-%20共享世纪_files/2316112519-20.jpg)

投稿来源于：[http://news.2ky.cn](http://news.2ky.cn/)，转载需注明。

关键字： [**IIS**](http://www.2ky.cn/tag/IIS-118-1.htm)
[**php**](http://www.2ky.cn/tag/php-795-1.htm)
[**Win8**](http://www.2ky.cn/tag/Win8-951-1.htm)

</div>

</div>

</div>

</div>
