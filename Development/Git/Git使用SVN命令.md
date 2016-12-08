# Git使用SVN命令

可以在Git中使用SVN的命令，这样就不用再另外下一个SVN工具了，方法很简单，只要在git后加上svn就可以了
```shell
git svn <command> [options] [arguments]
```
## 一些常用命令
从SVN服务器获取代码
```shell
$ git svn clone http://svnserver/project/trunk
```
本地修改代码后提交
```shell
git commit -a -m ""
```
同步远程svn 服务器
```shell
git svn rebase
```
推送到远程svn服务器
```shell
git svn dcommit
```

**参考**
[git-svn - Bidirectional operation between a Subversion repository and Git](https://git-scm.com/docs/git-svn)

[git与SVN协同的工作流程](http://hufeng825.github.io/2013/09/03/git9/)