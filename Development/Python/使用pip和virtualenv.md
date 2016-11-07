使用pip和virtualenv
pip install 下载并安装包

pip install -U, --upgrade 升级包

pip download 仅下载包

pip uninstall 卸载包

pip freeze 将已安装的包以requirement格式列出

pip list 列出已安装的包

pip show 显示包的信息

pip search 搜索包

pip wheel 以wheel格式打包

pip hash 计算包的hash值

virtualenv xxx 创建xxx虚拟环境

virtualenv xxx --python=/usr/local/bin/python2.7 用python2.7创建虚拟环境

. xxx/bin/activate 启动xxx虚拟环境

deactivate 取消虚拟环境

**快速搭建和本机相同环境的虚拟环境：**

＃将包依赖信息保存在requirements.txt文件中

pip freeze &gt; requirements.txt

＃根据requirements.txt中的信息将需要的包打包成wheel格式的包放在wheelhouse目录下

pip wheel －w wheelhouse -r requirements.txt (在阿里云中需要加上--trusted-host mirrors.aliyun.com)

＃创建虚拟环境

virtualenv venv --python=/usr/local/bin/python2.7

\#启动虚拟环境

. venv/bin/activate

＃使用wheel安装包

pip install --use-wheel --no-index --find-links=wheelhouse -r requirements.txt


