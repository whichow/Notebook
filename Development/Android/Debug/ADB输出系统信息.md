dumpsys可以用来查看所有进程使用系统资源的信息

查看dumpsys命令列表
```
adb shell dumpsys -l
```
输出内存信息
```
adb shell dumpsys meminfo
//查看某个应用的内存使用情况
adb shell dumpsys meminfo $package_name or $pid
```
输出CPU信息
```
adb shell dumpsys cpuinfo
//查看某个应用的CPU使用情况
adb shell dumpsys cpuinfo $package_name or $pid
```