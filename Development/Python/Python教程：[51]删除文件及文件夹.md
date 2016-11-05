<div class="exp-title no-thumbs clearfix"
style="zoom: 1; position: relative; padding-top: 21px; padding-bottom: 23px; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(239, 239, 239); font-family: 'Microsoft Yahei', 微软雅黑, arial, 宋体, sans-serif; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

<span style="text-align: justify; font-size: 16px; line-height: 28px;">假如有一个txt文件，我想要使用python命令删除它，怎么弄？这里用到了Python的os模块，我们使用例子来说明如何如何删除文件及目录。</span>\
 {#假如有一个txt文件我想要使用python命令删除它怎么弄这里用到了python的os模块我们使用例子来说明如何如何删除文件及目录 title="Python教程：[51]删除文件及文件夹" style="margin-top: 0px; margin-bottom: 0px; font-size: 30px; color: rgb(51, 51, 51); font-weight: 400;"}
==========================================================================================================================================================================================================

</div>

<div id="no-format-exp" class="exp-content no-format-exp"
alog-group="exp-content"
style="font-family: 'Microsoft Yahei', 微软雅黑, arial, 宋体, sans-serif; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

<div class="exp-content-block"
style="color: rgb(51, 51, 51); font-size: 16px; line-height: 28px; margin-top: 40px;">

<div class="exp-content-body exp-content-blog-body"
style="text-align: justify; margin-top: 40px;">

<div class="exp-content-listblock" style="position: relative;">

<div
class="content-listblock-text __reader_view_article_wrap_7807647035044827__">

1.  在d盘下有一个tt文本文件，我们来删除它

    ![](Python教程：%5B51%5D删除文件及文件夹_files/0.9591990481130779.png){.pic-cursor-pointer
    width="500" height="174"}

2.  首先引入os模块![](Python教程：%5B51%5D删除文件及文件夹_files/0.5372823807410896.png){.pic-cursor-pointer
    width="372" height="73"}

3.  使用os下的remove命令来删除该文件，参数是r'd:/tt.txt’，通常路径字符串都是用r字符串![](Python教程：%5B51%5D删除文件及文件夹_files/0.3721987116150558.png){.pic-cursor-pointer
    width="281" height="16"}

4.  现在改文件已经被删除，现在我们再运行一下该命令，看看有什么提示错误![](Python教程：%5B51%5D删除文件及文件夹_files/0.7764833981636912.png){.pic-cursor-pointer
    width="382" height="123"}

5.  这就是提示的错误，为了写出更见健壮的程序，我们通常要在删除文件前，先检验该文件是否存在。![](Python教程：%5B51%5D删除文件及文件夹_files/0.9285961086861789.png){.pic-cursor-pointer
    width="465" height="202"}

6.  使用path.exists命令来检验文件是否存在，参数仍然是路径字符串![](Python教程：%5B51%5D删除文件及文件夹_files/0.6708839912898839.png){.pic-cursor-pointer
    width="325" height="77"}

7.  配合if语句，我们就可以写出一个健壮的删除文件的命令。![](Python教程：%5B51%5D删除文件及文件夹_files/0.2791898238938302.png){.pic-cursor-pointer
    width="500" height="75.87548638132296"}

删除文件夹 {#删除文件夹 style="margin-top: 40px; margin-bottom: 0px; padding-bottom: 7px; font-size: 22px; font-weight: 400; font-stretch: normal; line-height: 24px; font-family: 微软雅黑; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(214, 214, 216);"}
----------

1.  上面讲到了如何删除文件，下面说一下如何删除文件夹。我们用到了rmdir方法，它可以直接删除空文件夹![](Python教程：%5B51%5D删除文件及文件夹_files/0.7063075087498873.png){.pic-cursor-pointer
    width="325" height="83"}

2.  假如文件夹非空，会提示这样的错误：

    Traceback (most recent call last):

      File "&lt;pyshell\#8&gt;", line 1, in &lt;module&gt;

        os.rmdir(r'd:/tt/')

    WindowsError: \[Error 145\] : 'd:/tt/'

    ![](Python教程：%5B51%5D删除文件及文件夹_files/0.6446834800299257.png){.pic-cursor-pointer
    width="390" height="135"}

3.  假如文件夹不存在，会提示这样的错误：

    Traceback (most recent call last):

      File "&lt;pyshell\#16&gt;", line 1, in &lt;module&gt;

        os.rmdir(r'd:/tt/')

    WindowsError: \[Error 2\] : 'd:/tt/'

    ![](Python教程：%5B51%5D删除文件及文件夹_files/0.5687911356799304.png){.pic-cursor-pointer
    width="372" height="124"}

4.  怎么删除非空文件夹？我们用到了shutil模块![](Python教程：%5B51%5D删除文件及文件夹_files/0.4001387329772115.png){.pic-cursor-pointer
    width="273" height="56"}

5.  用rmtree命令可以直接删除文件夹，包括内部文件![](Python教程：%5B51%5D删除文件及文件夹_files/0.5224773767404258.png){.pic-cursor-pointer
    width="315" height="95"}

</div>

</div>

</div>

</div>

<div id="auto-app-placehold">

</div>

<div class="origin-author f12"
style="text-align: right; padding-left: 20px;">

\

</div>

<div class="origin-author f12"
style="text-align: right; padding-left: 20px;">

\

</div>

</div>
