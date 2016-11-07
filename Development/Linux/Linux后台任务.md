Linux后台任务
在命令中后加&，将在后台运行

按CTRL+Z将运行中的前台任务挂起

jobs:查看所有任务

bg:n或%n &将挂起的任务转到后台运行

fg:n或%n将任务转到前台运行

kill:%n杀掉一个任务

`nohup /path/to/test.py & 关闭终端后也不会停止运行`


