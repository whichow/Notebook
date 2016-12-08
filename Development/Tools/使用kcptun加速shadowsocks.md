# 使用kcptun加速shadowsocks

[kcptun项目地址](https://github.com/xtaci/kcptun)

获取kcptun服务端一件安装脚本
```
wget https://raw.githubusercontent.com/kuoruan/kcptun_installer/master/kcptun.sh
```
加上执行权限
```
chmod a+x ./kcptun.sh
```
注意有一项需要加速的端口设置为shadowsocks server的端口号，其他可以都按照默认配置

配置好后会提示**可使用的客户端配置文件为：**
```
{
    "localaddr": ,
    "remoteaddr": ,
    "key": ,
    "crypt": "aes",
    "mode": "fast",
    "conn": 1,
    "autoexpire": 60,
    "mtu": 1350,
    "sndwnd": 1024,
    "rcvwnd": 1024,
    "datashard": 10,
    "parityshard": 3,
    "dscp": 0,
    "nocomp": false,
    "acknodelay": false,
    "nodelay": 0,
    "interval": 20,
    "resend": 2,
    "nc": 1,
    "sockbuf": 4194304,
    "keepalive": 10
}
```
将其复制并保存到本地`client.json`

配置好服务端后，现在需要下载客户端程序，[下载地址](https://github.com/xtaci/kcptun/releases)

选择系统对应的可执行程序，例如OS X系统可以下载`kcptun-darwin-amd64.tar.gz`这个包。下载后解压，里面有服务端和客户端程序，我们只需要客户端程序。将之前保存的`client.json`文件放到和客户端程序同一个文件加，执行
```
sudo ./client_darwin_amd64 -c client.json
```
现在可以在shadowsocks客户端里添配置项，地址填127.0.0.1，端口填kcptun的本地端口，密码为shadowsocks server的密码。

参考：  
[一步一步教你用Kcptun给Shadowsocks加速！看YouTube1080P一点都不卡！](http://www.jianshu.com/p/172c38ba6cee)  
[利用 Surge + KCPTUN 进行完美分流](https://nnya.cat/li-yong-surge-kcptun-jin-xing-wan-mei-fen-liu/)  
[小内存福音，Kcptun Shadowsocks加速方案](https://blog.kuoruan.com/102.html)