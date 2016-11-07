系统环境：CentOS6

Python版本：Python2.7

首先添加源

cd /etc/yum.repos.d

wget http://mirrors.163.com/.help/CentOS6-Base-163.repo

重新生成缓存

yum clean all

yum makecache

更新系统程序

yum -y update

安装development tools

yum groupinstall -y development

安装其他需要的包

yum install -y zlib-devel openssl-devel sqlite-devel bzip2-devel

下载python

wget https://www.python.org/ftp/python/2.7.11/Python-2.7.11.tgz

解压

tar -xvf Python-2.7.11.tgz

配置和安装

cd Python-2.7.11

\#默认安装在/usr/local，可以用--prefix更改

./configure

\#编译

make

\#安装，altinstall不覆盖系统python，一般不要覆盖系统自带的python，否则可能会造成系统崩溃

make install或make altinstall

\#编译安装一起

make && make install

添加环境变量，使得默认python为新安装版本

export PATH="/usr/local/bin:$PATH"

安装pip

wget https://bootstrap.pypa.io/get-pip.py

python get-pip.py

安装virtualenv

pip install virtualenv


