git init  初始化一个git仓库，当前目录为工作目录

git init --bare  仅仅创建git仓库，没有工作目录被创建，一般用于远程服务器仓库

git config user.name    配置用户名，作为提交时的用户信息，可以加上--global，配置全局用户

git config user.email    配置用户email

git log 显示详细日志

---

git add  将文件或目录添加到暂存区域

git rm 将文件移出git，并删除该文件，要删除文件夹加上-r

git rm --cached 将文件移出git，但不会删除文件

git checkout --  丢弃文件的修改

git reset HEAD  取消文件暂存(unstage)

git status 可以查看当前状态，包括所在的分支和已修改未提交的文件(staged和unstaged)

git diff 可以比较当前文件和暂存区域(staged和unstaged)文件的差异

git diff --cached或--staged 比较暂存区域和已经提交的文件的差异

git commit -m 'commit message' 提交暂存区域的文件和提交的信息

git commit -a -m 添加并提交

---

git branch 列出所有分支，前面有\*表示当前分支

git branch -v 查看分支版本和最后一次提交的信息

git branch --merged和--no-merged 查看已合并到当前分支的分支和未合并的分支

git branch iss53 新建名称为iss53的分支

git checkout iss53 表示切换到iss53这个分支

git checkout -b iss53 新建并且切换到iss53分支

git merge hotfix 将hotfix合并到当前分支

git branch -d hotfix 删除hotfix分支

---

git clone  克隆一个远程仓库，并创建工作目录

git clone --depth=1 浅(shallow)克隆，只下载最近一次版本

git clone --bare  克隆一个远程仓库，不包含工作目录，仅克隆当前分支

git clone --mirror  在--bare的基础上，包含所有分支

git clone -b &lt;分支名&gt; 克隆一个远程仓库的分支

git remote add origin url 添加远程仓库

git remote remove origin 移除远程仓库

git remote 列出所有远程仓库

git remote -v 显示所有远程仓库信息

git remote show  显示远程仓库信息

git remote set-url origin 修改远程仓库的url

git fetch &lt;远程主机名&gt; 将远程主机的更新全部取回本地

git fetch &lt;远程主机名&gt; &lt;远程分支名&gt; 将远程主机的分支取回本地，取回的更新在本地上用远程"主机名/分支名"形式读取

git pull &lt;远程主机名&gt; &lt;远程分支名&gt;:&lt;本地分支名&gt; 取回远程主机的分支和本地分支合并

git pull &lt;远程主机名&gt; &lt;远程分支名&gt; 取回远程主机的分支和当前分支合并，相当于git fetch再git merge

git push &lt;远程主机名&gt; &lt;本地分支名&gt;:&lt;远程分支名&gt; 将分支推送到远程主机分支，如果远程分支不存在则会被新建

git push &lt;远程主机名&gt; &lt;本地分支名&gt; 将分支推送到远程主机同名的分支，如果远程分支不存在则会被新建

git push origin :master 省略本地分支名，将删除远程分支，相当于推送一个空的分支到远程分支，等同于git push origin --delete master

git push --all origin 将本地所有分支推送到远程主机

git push --force origin 强制推送到远程主机，无论远程主机是否比本地版本更新

---

git clean -df 删除所有unchecked的文件和文件夹，-d表示文件夹，-f表示强制删除

git reset --hard 把checked的文件revert到前一个版本，不影响unchecked的文件

git reset --hard 版本号 退回指定版本，之前的提交都会删除

git revert 版本号 退回到版本号指定的版本，版本号之需要给出前几位，之前的提交都会保留

git合并冲突时可使用

git checkout --theirs -- path

git checkout --ours --path

来简单选择使用需要合并的或是本地的文件，一般二进制的文件可以使用此种方法来解决合并冲突问题

git mergetool 合并工具


