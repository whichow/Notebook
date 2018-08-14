在`~\.android\ ddms.cfg`文件中添加
```
native=true
```

执行
```
adb shell setprop libc.debug.malloc 1
adb shell stop
adb shell start
```

运行`ddms.bat`找到App进程，切换到Native Heap选项，点击Snapshot Current Native Usage抓取内存快照

[Android native Memory分析](https://my.oschina.net/shaorongjie/blog/200350)
[Android开发————分析Native层内存泄漏](http://blog.csdn.net/u010307119/article/details/53144176)