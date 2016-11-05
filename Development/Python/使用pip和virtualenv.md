使用pip和virtualenv
<div>

<div>

pip install 下载并安装包

</div>

<div>

pip install -U, --upgrade 升级包

</div>

<div>

pip download 仅下载包

</div>

<div>

pip uninstall 卸载包

</div>

<div>

pip freeze 将已安装的包以requirement格式列出

</div>

<div>

pip list 列出已安装的包

</div>

<div>

pip show 显示包的信息

</div>

<div>

pip search 搜索包

</div>

<div>

pip wheel 以wheel格式打包

</div>

<div>

pip hash 计算包的hash值

</div>

<div>

\

</div>

<div>

virtualenv xxx 创建xxx虚拟环境

</div>

<div>

virtualenv xxx --python=/usr/local/bin/python2.7 用python2.7创建虚拟环境

</div>

<div>

. xxx/bin/activate 启动xxx虚拟环境

</div>

<div>

deactivate 取消虚拟环境

</div>

<div>

\

</div>

<div>

**快速搭建和本机相同环境的虚拟环境：**

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

＃将包依赖信息保存在requirements.txt文件中

</div>

<div>

pip freeze &gt; requirements.txt

</div>

<div>

\

</div>

<div>

＃根据requirements.txt中的信息将需要的包打包成wheel格式的包放在wheelhouse目录下

</div>

<div>

pip wheel －w wheelhouse -r requirements.txt
(在阿里云中需要加上--trusted-host mirrors.aliyun.com)

</div>

<div>

\

</div>

<div>

＃创建虚拟环境

</div>

<div>

virtualenv venv --python=/usr/local/bin/python2.7

</div>

<div>

\

</div>

<div>

\#启动虚拟环境

</div>

<div>

. venv/bin/activate

</div>

<div>

\

</div>

<div>

＃使用wheel安装包

</div>

<div>

<div>

pip install --use-wheel --no-index --find-links=wheelhouse -r requirements.txt

</div>

</div>

</div>

<div>

\

</div>

</div>
