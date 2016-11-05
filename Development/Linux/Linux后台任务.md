Linux后台任务
<div>

<div>

在命令中后加&，将在后台运行

</div>

<div>

按CTRL+Z将运行中的前台任务挂起

</div>

<div>

jobs:查看所有任务

</div>

<div>

bg:n或%n &将挂起的任务转到后台运行

</div>

<div>

fg:n或%n将任务转到前台运行\

</div>

<div>

kill:%n杀掉一个任务

</div>

<div>

\

</div>

<div>

<div
style="margin: 0px 0px 1em; padding: 5px; border: 0px; font-size: 13px; width: auto; max-height: 600px; overflow: auto; font-family: Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif; color: rgb(17, 17, 17); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(239, 240, 241);">

<div>

`nohup /path/to/test.py & 关闭终端后也不会停止运行`{style="margin: 0px; padding: 0px; border: 0px; font-size: 13px; font-family: Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif; background-color: rgb(239, 240, 241);"}

</div>

</div>

</div>

</div>
