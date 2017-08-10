首先需要下载Android SDK，我们可以在[Android Studio](https://developer.android.com/studio/index.html?hl=zh-cn#downloads)的下载页面，直接下载Android Studio，里面包含了Android SDK。

但是有时候我们不需要Android Studio，或者嫌下载文件太大了，可以选择直接下载命令行工具，找到下载页面的“仅获取命令行工具”，有各个平台的命令行工具。

下载完命令行工具后，解压到指定文件夹，我们可以使用sdkmanager(在tools的bin目录下)来下载SDK软件包

列出已经安装和可用的包
```
sdkmanager --list [options]
```

安装包
```
sdkmanager packages [options]
```
例如，要安装版本号为26的Platforms
```
sdkmanager "platforms;android-26"
```
还可以指定一个包含下载列表的文件
```
sdkmanager --package_file=package_file [options]
```

要卸载的话，可以使用
```
sdkmanager --uninstall packages [options]
```
或者
```
sdkmanager --uninstall --package_file=package_file [options]
```

更新所有包
```
sdkmanager --update [options]
```

其他选项可以查看[sdkmanager](https://developer.android.com/studio/command-line/sdkmanager.html)