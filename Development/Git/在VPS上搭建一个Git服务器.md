<div>

我们需要在VPS主机上添加一个git用户来管理我们的git仓库

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ sudo useradd git$ sudo passwd git
```

</div>

<div>

<span style="line-height: 1.6;">如果没有安装git，需要</span>\

</div>

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ sudo yum install git
```

</div>

<div>

<span style="line-height: 1.6;">切换到git用户</span>\

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ su git$ cd ~
```

</div>

<div>

<span style="line-height: 1.6;">创建一个git仓库</span>\

</div>

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ git init --bare MyProject.git
```

</div>

<div>

<span style="line-height: 1.6;">镜像一个GitHub上的仓库</span>\

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ git clone --mirror https://github.com/username/MyProject.git
```

</div>

<div>

<span style="line-height: 1.6;">现在我们就可以在本地使用git
clone</span><span
style="line-height: 1.6;">来克隆VPS上的git仓库了</span>\

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ git clone git@120.25.146.126:MyProject.git    //IP改为你VPS主机的IPgit@120.25.146.126's password:    //输入git用户的密码
```

</div>

\

</div>

<div>

<span
style="line-height: 1.6;">现在有一个问题，我们每次登陆到git服务器操作都需要输入密码，由于git使用的是ssh协议(还有一种是https)，所以我们可以使用ssh的公钥登陆方式。</span>

</div>

首先在本地生成一个SSH Key Pair。在Mac或Linux上输入

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ ssh-keygen -C "youremail@mailprovider.com"     //用邮件账户信息生成，将邮件地址替换为你自己的或$ ssh-keygen    //以本地的账户信息生成Generating public/private rsa key pair.Enter file in which to save the key (/home/flynn/.ssh/id_rsa):    //直接回车保存在默认路径Enter passphrase (empty for no passphrase):    //设置口令，可以不设置，安全起见最好设置一下Enter same passphrase again:    //确认口令
```

</div>

<div>

运行完后会在本地\~/.ssh目录生成两个文件：id\_rsa.pub和id\_rsa，就是你的公钥和私钥。

</div>

\
<div>

将公钥传送到VPS主机上

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ ssh-copy-id git@120.25.146.126
```

</div>

<div>

<span
style="line-height: 1.6;">这会将本地用户的公钥保存在git用户的\~/.ssh/authorized\_keys文件中，</span><span
style="line-height: 1.6;">以后就不需要密码登陆了</span>\

</div>

<div>

<div>

这里不使用上面的ssh-copy-id命令，改用下面的命令，解释公钥的保存过程：

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ ssh user@host 'mkdir -p .ssh && cat >> .ssh/authorized_keys' < ~/.ssh/id_rsa.pub或$ cat ~/.ssh/id_rsa.pub | ssh user@123.45.56.78 "mkdir -p ~/.ssh && cat >>  ~/.ssh/authorized_keys"
```

</div>

<div>

<span
style="line-height: 1.6;">这条命令由多个语句组成，依次分解开来看：（1）"\$
ssh user@host"，表示登录远程主机；（2）单引号中的mkdir .ssh && cat
&gt;&gt;
.ssh/authorized\_keys，表示登录后在远程shell上执行的命令：（3）"\$ mkdir
-p
.ssh"的作用是，如果用户主目录中的.ssh目录不存在，就创建一个；（4）'cat
&gt;&gt; .ssh/authorized\_keys' &lt;
\~/.ssh/id\_rsa.pub的作用是，将本地的公钥文件\~/.ssh/id\_rsa.pub，重定向追加到远程文件authorized\_keys的末尾。</span>\

</div>

</div>

<div>

写入authorized\_keys文件后，公钥登录的设置就完成了。

</div>

</div>

\
<div>

<div>

如果还是不行，打开VPS主机的/etc/ssh/sshd\_config文件，看下这几行是否被注释掉

</div>

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
RSAAuthentication yesPubkeyAuthentication yesAuthorizedKeysFile .ssh/authorized_keys
```

</div>

<div>

取消注释，然后重启VPS的ssh服务

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
// ubuntu系统service ssh restart// debian系统/etc/init.d/ssh restart
```

</div>

<div>

\
<div>

参考：

</div>

</div>

</div>

<div>

How To Set Up a Private Git Server on a VPS\

</div>

<div>

<https://www.digitalocean.com/community/tutorials/how-to-set-up-a-private-git-server-on-a-vps>

</div>

<div>

How To Set Up SSH Keys\

</div>

<div>

<https://www.digitalocean.com/community/tutorials/how-to-set-up-ssh-keys--2>

</div>

<div>

SSH原理与运用（一）：远程登录\

</div>

<div>

<http://www.ruanyifeng.com/blog/2011/12/ssh_remote_login.html>

</div>

\

\

