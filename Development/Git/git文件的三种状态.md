git中的文件分为三种状态：
1. 工作区或工作目录(Working Copy, Working Directory)
2. 暂存区(Index, Stage)
3. 当前分支(HEAD)

创建一个git仓库后，把一个文件放到.git所在的目录，这个文件所在的就叫做工作目录，对文件的修改都在工作目录中进行。使用git checkout --可以丢弃工作目录中的文件修改。

使用git add或git rm之后会变为staged状态。

使用git add将文件添加到暂存区(stage)，并且告诉git开始跟踪(track)该文件的改变，使用git diff可以看到该文件修改之后和之前的变化，使用git reset HEAD可以将文件移出暂存区(unstage)。

使用git rm --cached将文件移出git跟踪(untrack)，并且变为staged状态，提交之后，当前分支就没有该文件了。注意，不使用--cached会将文件移出git并删除工作目录的文件。

使用git commit将暂存区中(staged)的文件的增加(第一次提交)修改或者删除提交到当前分支。
