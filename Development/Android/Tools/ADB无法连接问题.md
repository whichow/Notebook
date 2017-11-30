有时候连接ADB会出现如"unable to connect to 192.168.1.199:5555"的问题

在android设备上安装 “终端模拟器”等类似shell命令工具，使用下面命令（需root权限）：
```
TCP/IP方式：  
setprop service.adb.tcp.port 5555  
stop adbd  
start adbd  
  
usb方式：  
setprop service.adb.tcp.port -1  
stop adbd  
start adbd  
```
然后再打开命令行运行下面的命令就可以了
```
adb tcpip 5555 （端口号）  
adb connect 192.168.1.199 （Android设备IP地址）  
  
adb usb 使用回usb调试  
```

[Android 网络调试 adb tcpip 开启方法](http://blog.csdn.net/shawnkong/article/details/8923933)