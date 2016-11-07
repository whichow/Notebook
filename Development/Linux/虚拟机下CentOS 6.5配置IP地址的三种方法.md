实验软件环境：虚拟机Vmware Workstation10.0 、CentOS 6.5 32位

   

1、自动获取IP地址

虚拟机使用桥接模式，相当于连接到物理机的网络里，物理机网络有DHCP服务器自动分配IP地址。

\#dhclient 自动获取ip地址命令

\#ifconfig 查询系统里网卡信息，ip地址、MAC地址

分配到ip地址后，用物理机进行ping ip地址，检测是否ping通。

2、手动设置ip地址

如果虚拟机不能自动获取IP，只能手动配置，配置方法如下：

输入命令

\#vi /etc/sysconfig/network-scripts/ifcfg-eth0 \[编辑网卡的配置文件\]

输入上述命令后回车，打开配置文件，使用方向键移动光标到最后一行，按字母键“O”，进入编辑模式，输入以下内容：

IPADDR=192.168.4.10

NETMASK=255.255.255.0

GATEWAY=192.168.4.1

另外光标移动到”ONBOOT=no”这一行，更改为ONBOOT=yes

“BOOTPROTO=dhcp”，更改为BOOTPROTO=none

完成后，按一下键盘左上角ESC键，输入:wq 在屏幕的左下方可以看到，输入回车保存配置文件。

之后需要重启一下网络服务，命令为

\#servicenetwork restart

网络重启后，eth0的ip就生效了，使用命令\#ifconfigeth0 查看

接下来检测配置的IP是否可以ping通，在物理机使用快捷键WINDOWS+R 打开运行框，输入命令cmd，输入ping 192.168.4.10 进行检测，ping通说明IP配置正确。

备注：我所在的物理机网段为192.168.4.0 网段。大家做实验的时候根据自己的环境进行设定，保持虚拟机和物理机在同一网段即可。

3、使用NAT模式

虚拟机网络连接使用NAT模式，物理机网络连接使用Vmnet8。

虚拟机设置里面——网络适配器，网络连接选择NAT模式。

虚拟机菜单栏—编辑—虚拟网络编辑器，选择Vmnet8 NAT模式，

1．在最下面子网设置ip为192.168.20.0 子网掩码255.255.255.0

2．NAT设置里面网关IP为192.168.20.2

3．使用本地DHCP服务将IP地址分配给虚拟机不勾选

设置完成后点击应用退出。

![wKiom1RggrzBd5TtAAQn4YGAcIE553.jpg](虚拟机下CentOS%206.5配置IP地址的三种方法_files/0203124b6-0.jpg "QQ截图20141110171713.jpg")

物理机网络连接VMNet8 手动设置ip地址 192.168.20.1 子网掩码255.255.255.0

网关和DNS地址为192.168.20.2（即虚拟机NAT的网关地址）

编辑linux网卡eth0的配置文件

\#vi /etc/sysconfig/network-scripts/ifcfg-eth0

输入上述命令后回车，打开配置文件，使用方向键移动光标到最后一行，按字母键“O”，进入编辑模式，输入以下内容：

IPADDR=192.168.20.3

NETMASK=255.255.255.0

GATEWAY=192.168.20.2

另外光标移动到”ONBOOT=no”这一行，更改为ONBOOT=yes

“BOOTPROTO=dhcp”，更改为BOOTPROTO=none

完成后，按一下键盘左上角ESC键，输入:wq 在屏幕的左下方可以看到，输入回车保存配置文件。

设置DNS地址,运行命令\#vi /etc/resolv.conf

光标移动到空行，按“O”键，输入 nameserver 192.168.20.2 退出按ESC键，输入:wq 回车保存配置文件。

重启网络服务 \#service network restart

重启之后\#ifconfig 查看配置的ip地址，物理机ping这个地址测试是否能通。


