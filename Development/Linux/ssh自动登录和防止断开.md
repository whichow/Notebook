ssh自动登录和防止断开
**自动登录：**

在客户端上运行命令:

\# ssh-keygen -t rsa (连续三次回车,即在本地生成了公钥和私钥,不设置密码)

\# scp ~/.ssh/id\_rsa.pub root@xxx.xxx.xxx.xxx:.ssh/id\_rsa.pub (需要输入密码)

在服务端上的命令:

\# cat /root/.ssh/id\_rsa.pub &gt;&gt; /root/.ssh/authorized\_keys (将id\_rsa.pub的内容追加到authorized\_keys 中)

回到客户端:
\# ssh [root@]()xxx.xxx.xxx.xxx(不需要密码, 登录成功) 

**防止断开：**

**
**

`在客户端中的/etc/ssh/ssh_config` for Linux and `~/.ssh/config` for Mac添加:

Host \*

ServerAliveInterval 120 (表示每隔120秒想服务器发送keepalive消息)

也可以在服务端中的/etc/ssh/sshd\_config添加ClientAliveInterval


