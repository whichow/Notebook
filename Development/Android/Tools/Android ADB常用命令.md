## 启动adb
```
adb start-server
```
## 终止adb
```
adb kill-server
```
## 查看已连接的设备
```
adb devices
```
会列出连接设备的ID，使用adb -s DEVICE_ID可以指定特定的设备
## 安装应用
```
adb install
```
如果设备上已经安装了应用，可以使用可选参数-r重新进行安装并保留所有数据
```
adb install -r APK_FILE
```
## 卸载应用
```
adb uninstall PACKAGE_NAME
```
## 清除应用数据
```
adb shell pm clear PACKAGE_NAME
```
## 启动Activity
```
adb shell am strat PACKAGE_NAME/ACTIVITY_IN_PACKAGE
```
## 进入设备命令行
```
adb shell
```
## 上传文件
```
adb push <本地目录/文件> <设备端目录>
```
## 下载文件
```
adb pull <设备端目录/文件> <本机目录>
```
## 连接远程设备
```
adb connect <IP>:<端口号>
```
端口号可以省略，会自动扫描端口号
## 断开连接
```
adb disconnect <IP>:<端口号>
```
端口号可以省略
## 截取屏幕
```
adb shell screencap -p | perl -pe 's/\x0D\x0A/\x0A/g' > screen.png
```
## 解锁屏幕
```
adb shell input keyevent 82
```
## 日志
用来在命令行中显示日志流
```
adb logcat
```
按标签过滤
```
adb logcat -s TAG_NAME1 TAG_NAME2
```
按优先级过滤
```
adb logcat "*:PRIORITY"
#  example
adb logcat "*:W"
```
优先级设置如下：
V:Verbose(最低优先级)
D:Debug
I:Info
W:Warning
E:Error
F:Fatal
S:Slient(最高优先级，在这个级别上不会打印任何信息)
按优先级和标签名过滤
```
adb logcat -s TAG_NAME_1:PRIORITY TAG_NAME_2:PRIORITY
```
使用grep过滤
```
adb logcat | grep "SEARCH_TERM"
adb logcat | grep "SEARCH_TERM_1\|SEARCH_TERM_2"
```
清除logcat缓冲区
```
adb logcat -c
```

### 导出日志
adb logcat ><导出路径>

[Android 调试桥](https://developer.android.com/studio/command-line/adb.html?hl=zh-cn)