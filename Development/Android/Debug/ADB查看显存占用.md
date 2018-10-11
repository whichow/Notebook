mali的gpu可以使用下面的命令来查看显存相关的情况
```
cat /sys/kernel/debug/mali/gpu_memory
```
如果显示"/sys/kernel/debug/mali/gpu_memory: No such file or directory"，需要先使用这个命令
```
mount -t debugfs debugfs /sys/kernel/debug/
```

[Android内存的相关排查方法](https://www.jianshu.com/p/6893cea51512)