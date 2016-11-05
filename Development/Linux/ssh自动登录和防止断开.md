ssh自动登录和防止断开
<div>

<div>

**自动登录：**

</div>

<div>

\

</div>

<div>

在客户端上运行命令:

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

\# ssh-keygen -t rsa (连续三次回车,即在本地生成了公钥和私钥,不设置密码)

</div>

<div>

\# scp \~/.ssh/id\_rsa.pub root@xxx.xxx.xxx.xxx:.ssh/id\_rsa.pub
(需要输入密码)

</div>

</div>

</div>

<div>

\

</div>

<div>

在服务端上的命令:

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

\# cat /root/.ssh/id\_rsa.pub &gt;&gt; /root/.ssh/authorized\_keys
(将id\_rsa.pub的内容追加到authorized\_keys 中)

</div>

</div>

</div>

<div>

\

</div>

<div>

回到客户端:\
\# ssh [root@]()xxx.xxx.xxx.xxx(不需要密码, 登录成功) \

</div>

<div>

\

</div>

<div>

**防止断开：**

</div>

<div>

**\
**

</div>

<div>

`在客户端中的/etc/ssh/ssh_config` for Linux and `~/.ssh/config` for
Mac添加:

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

Host \*

</div>

<div>

ServerAliveInterval 120 (表示每隔120秒想服务器发送keepalive消息)

</div>

</div>

<div>

\

</div>

<div>

也可以在服务端中的/etc/ssh/sshd\_config添加ClientAliveInterval

</div>

<div>

\

</div>

</div>
