# 使用pip和virtualenv

## pip常用命令
```
pip install 下载并安装包

pip install -U, --upgrade 升级包

pip install --upgrade pip 升级pip

pip download 仅下载包

pip uninstall 卸载包

pip freeze 将已安装的包以requirement格式列出

pip list 列出已安装的包

pip show 显示包的信息

pip search 搜索包

pip wheel 以wheel格式打包

pip hash 计算包的hash值

```
## virtualenv使用
```
virtualenv xxx 创建xxx虚拟环境

virtualenv xxx --python=python2.7 用python2.7创建虚拟环境

source xxx/bin/activate 启动xxx虚拟环境

deactivate 取消虚拟环境
```
## 快速搭建和本机相同环境的虚拟环境

将包依赖信息保存在requirements.txt文件中
```
pip freeze > requirements.txt
```
安装`requirements.txt`中的所有包
```
pip install -r requirements.txt
```

## pip配置镜像

编辑`~/.pip/pip.config`

```
[global]
timeout = 6000
index-url = http://mirrors.aliyun.com/pypi/simple
[install]
use-mirrors=true
mirrors= http://mirrors.aliyun.com
trusted-host=mirrors.aliyun.com
```

