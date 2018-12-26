在 Android 开发中，程序 Crash 分三种情况：

- 未捕获的异常
- ANR（Application Not Responding）
- 闪退（NDK 程序引发错误）

异常引发的闪退直接查看Log就可以了

出现了ANR，会在/data/anr目录下生成一个traces.txt文件

如果问题出在NDK，也就是C++层，发生闪退时会在/data/tombstones目录下生成tombstone_xx文件。

闪退分析工具 **addr2line**、**objdump**、**ndk-stack**。

[Android NDK Tombstone/Crash 分析](https://woshijpf.github.io/android/2016/06/14/Android-NDK-Tombstone-Crash-%E5%88%86%E6%9E%90.html)