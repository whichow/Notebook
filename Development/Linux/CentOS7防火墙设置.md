## 开放端口
```
sudo firewall-cmd --zone=public --add-port=3000/tcp --permanent
sudo firewall-cmd --reload
之后检查新的Rule

firewall-cmd --list-all
```
## 关闭防火墙
```
//临时关闭防火墙,重启后会重新自动打开
systemctl restart firewalld
//检查防火墙状态
firewall-cmd --state
firewall-cmd --list-all
//Disable firewall
systemctl disable firewalld
systemctl stop firewalld
systemctl status firewalld
//Enable firewall
systemctl enable firewalld
systemctl start firewalld
systemctl status firewalld
```

[CentOS 7开放端口和关闭防火墙](https://liangshuai.me/2015/12/29/centos-firewall/)

[CentOS 7 firewalld使用简介](http://blog.csdn.net/spxfzc/article/details/39645133)