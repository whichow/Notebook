# Git diff 比较不同版本的差异

Git 比较不同版本文件差异的常用命令格式：

```shell
git diff    查看尚未暂存的文件更新了哪些部分

git diff filename    查看尚未暂存的某个文件更新了哪些

git diff –cached    查看已经暂存起来的文件和上次提交的版本之间的差异

git diff –cached filename    查看已经暂存起来的某个文件和上次提交的版本之间的差异

git diff ffd98b291e0caa6c33575c1ef465eae661ce40c9 b8e7b00c02b95b320f14b625663fdecf2d63e74c   查看某两个版本之间的差异

git diff ffd98b291e0caa6c33575c1ef465eae661ce40c9:filename b8e7b00c02b95b320f14b625663fdecf2d63e74c:filename    查看某两个版本的某个文件之间的差异
```