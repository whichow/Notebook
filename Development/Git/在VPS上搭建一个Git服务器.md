我们需要在VPS主机上添加一个git用户来管理我们的git仓库

``` shell
$ sudo useradd git
$ sudo passwd git
```

如果没有安装git，需要

``` shell
$ sudo yum install git
```

切换到git用户

``` shell
$ su git
$ cd ~
```

创建一个git仓库

``` shell
$ git init --bare MyProject.git
```

镜像一个GitHub上的仓库

``` shell
$ git clone --mirror https://github.com/username/MyProject.git
```

现在我们就可以在本地使用git clone来克隆VPS上的git仓库了

``` shell
$ git clone git@120.25.146.126:MyProject.git    //IP改为你VPS主机的IP
git@120.25.146.126's password:    //输入git用户的密码
```

现在有一个问题，我们每次登陆到git服务器操作都需要输入密码，由于git使用的是ssh协议(还有一种是https)，所以我们可以使用ssh的公钥登陆方式。

首先在本地生成一个SSH Key Pair。在Mac或Linux上输入

``` shell
$ ssh-keygen -t rsa -b 4096 -C "your_email@example.com"     //用邮件账户信息生成，并以4096位RSA加密
//或
$ ssh-keygen    //默认以本地的账户信息生成，并以2048位RSA加密
Generating public/private rsa key pair.Enter file in which to save the key (/home/flynn/.ssh/id_rsa):    //直接回车保存在默认路径
Enter passphrase (empty for no passphrase):    //设置口令，可以不设置，安全起见最好设置一下
Enter same passphrase again:    //确认口令
```

运行完后会在本地~/.ssh目录生成两个文件：id\_rsa.pub和id\_rsa，就是你的公钥和私钥。

将公钥传送到VPS主机上

``` shell
$ ssh-copy-id git@120.25.146.126
```

这会将本地用户的公钥保存在git用户的~/.ssh/authorized\_keys文件中，以后就不需要密码登陆了

这里不使用上面的ssh-copy-id命令，改用下面的命令，解释公钥的保存过程：

``` shell
$ ssh user@host 'mkdir -p .ssh && cat >> .ssh/authorized_keys' < ~/.ssh/id_rsa.pub
//或
$ cat ~/.ssh/id_rsa.pub | ssh user@123.45.56.78 "mkdir -p ~/.ssh && cat >>  ~/.ssh/authorized_keys"
```

这条命令由多个语句组成，依次分解开来看：（1）"$ ssh user@host"，表示登录远程主机；（2）单引号中的mkdir .ssh && cat &gt;&gt; .ssh/authorized\_keys，表示登录后在远程shell上执行的命令：（3）"$ mkdir -p .ssh"的作用是，如果用户主目录中的.ssh目录不存在，就创建一个；（4）'cat &gt;&gt; .ssh/authorized\_keys' &lt; ~/.ssh/id\_rsa.pub的作用是，将本地的公钥文件~/.ssh/id\_rsa.pub，重定向追加到远程文件authorized\_keys的末尾。

写入authorized\_keys文件后，公钥登录的设置就完成了。

如果还是不行，打开VPS主机的/etc/ssh/sshd\_config文件，看下这几行是否被注释掉

``` shell
RSAAuthentication yes
PubkeyAuthentication yes
AuthorizedKeysFile .ssh/authorized_keys
```

取消注释，然后重启VPS的ssh服务

``` shell
// ubuntu系统
$ service ssh restart
// debian系统
$ /etc/init.d/ssh restart
```

参考：

[How To Set Up a Private Git Server on a VPS](https://www.digitalocean.com/community/tutorials/how-to-set-up-a-private-git-server-on-a-vps)

[How To Set Up SSH Keys](https://www.digitalocean.com/community/tutorials/how-to-set-up-ssh-keys--2)

[Generating a new SSH key and adding it to the ssh-agent](https://help.github.com/articles/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent/)

[SSH原理与运用（一）：远程登录](http://www.ruanyifeng.com/blog/2011/12/ssh_remote_login.html)


