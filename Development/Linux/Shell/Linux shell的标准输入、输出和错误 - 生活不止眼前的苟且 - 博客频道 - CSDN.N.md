<div style="-evernote-webclip:true">

<div style="font-size: 16px">

<div>

<div
style="color:rgb(51, 51, 51);text-align:center;font-size:12px;font-family:Arial, Console, Verdana, &quot;Courier New&quot;;background:url(&quot;&quot;) 0px 20px repeat-x;">

<div style="background:url(&quot;&quot;) center top no-repeat;">

<div
style="overflow:hidden;border-radius:8px;text-align:left;background:rgb(255, 255, 255);">

<div style="overflow:hidden;border-radius:4px;">

<div
style="border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:3445px;">

<div
style="padding:20px 0px;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:42px;">

<span
style="font-family: Arial; font-size: 14px; line-height: 26px; background-color: rgba(0, 0, 0, 0);">1.文件描述符</span>

</div>

<div
style="font-family:Arial;margin:20px 0px 0px;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:14px;line-height:26px;font-style:normal;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;width:708px;height:2639px;">

在linux
shell执行命令时，每个进程都和三个打开的文件相联系，并使用文件描述符来引用这些文件。由于文件描述符不容易记忆，shell同时也给出了相应的文件名：

  ----------------------- -----------------------------------------------
  文件                    文件描述符
  输入文件—标准输入       0（缺省是键盘,为0时是文件或者其他命令的输出）
  输出文件—标准输出       1（缺省是屏幕，为1时是文件）
  错误输出文件—标准错误   2（缺省是屏幕，为2时是文件）
  ----------------------- -----------------------------------------------

系统中实际上有12个文件描述符，我们可以任意使用文件描述符3到9.

\

2.文件重定向：改变程序运行的输入来源和输出地点

2.1.输出重定向：

  ---------------------------------- ----------------------------------------------
  Command &gt; filename              把标准输出重定向到一个新文件中
  Command &gt;&gt; filename          把标准输出重定向到一个文件中（追加）
  Command &gt; filename              把标准输出重定向到一个文件中
  Command &gt; filename 2&gt;&1      把标准输出和错误一起重定向到一个文件中
  Command 2 &gt; filename            把标准错误重定向到一个文件中
  Command 2 &gt;&gt; filename        把标准输出重定向到一个文件中（追加）
  Command &gt;&gt; filename2&gt;&1   把标准输出和错误一起重定向到一个文件（追加）
  ---------------------------------- ----------------------------------------------

\

2.2.输入重定向：\

  -------------------------------------- --------------------------------------------------------------------
  Command &lt; filename &gt; filename2   Command命令以filename文件作为标准输入，以filename2文件作为标准输出
  Command &lt; filename                  Command命令以filename文件作为标准输入
  Command &lt;&lt; delimiter             从标准输入中读入，知道遇到delimiter分界符
  -------------------------------------- --------------------------------------------------------------------

\
2.3.绑定重定向

  ----------------- ---------------------------------
  Command &gt;&m    把标准输出重定向到文件描述符m中
  Command &lt; &-   关闭标准输入
  Command 0&gt;&-   同上
  ----------------- ---------------------------------

\
\
3.shell重定向的一些高级用法\

3.1.重定向标准错误\

例子1：\
command 2&gt; /dev/null\
如果command执行出错，将错误的信息重定向到空设备\
例子2：\
command &gt; out.put 2&gt;&1\
将command执行的标准输出和标准错误重定向到out.put（也就是说不管command执行正确还是错误，输出都打印到out.put）。\

\

3.2.exec用法\
exec命令可以用来替代当前shell；换句话说，并没有启动子shell，使用这一条命令时任何现有环境变量将会被清除，并重新启动一个shell（重新输入用户名和密码进入）。\
exec command\
其中，command通常是一个shell脚本。\
对文件描述符操作的时候用（也只有再这时候），它不会覆盖你当前的shell\
\
\
例子1：\
\#!/bin/bash\
\#file\_desc\
\
\
exec 3&lt;&0 0&lt;name.txt\
read line1\
read line2\
exec 0&lt;&3\
echo \$line1\
echo \$line2\
\
\
其中：\
首先，exec 3&lt;&0
0&lt;name.txt的意思是把标准输入重定向到文件描述符3（0表示标准输入），然后把文件name.txt内容重定向到文件描述符0，实际上就是把文件name.txt中的内容重定向到文件描述符3。然后通过exec打开文件描述符3；

然后，通过read命令读取name.txt的第一行内容line1，第二行内容line2，通过Exec
0&lt;&3关闭文件描述符3；

最后，用echo命令输出line1和line2。最好在终端运行一下这个脚本，亲自尝试一下。\
\
\
例子2：\
exec 3&lt;&gt;test.sh;\
\#打开test.sh可读写操作，与文件描述符3绑定\
\
while read line&lt;&3\
 do\
    echo \$line;\
done\
\#循环读取文件描述符3（读取的是test.sh内容）\
exec 3&gt;&-\
exec 3&lt;&-\
\#关闭文件的，输入，输出绑定

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
