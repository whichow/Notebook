# Android SDK命令行环境搭建

有时候我们要使用Android SDK，但是又不想下载Android Studio，这时候我们可以选择只下载SDK的命令行工具，在下载页面找到Command line tools only，然后选择相应平台的命令行工具下载。

下载完成后解压，里面只有一个tools文件夹，打开命令行工具，进入tools/bin目录

执行`sdkmanager --list`，列出所有已安装和可用的包，因为我们暂时还没有下载任何包，所以已安装包列表中只有一个`tools`

要搭建完整的SDK环境，我们还需要下载`build-tools`，`platform-tools`，`platform`。`build-tools`一般下载最新的版本就可以了。`platform-tools`只有一个版本，直接下载就好。`platform`要根据我们的开发环境和目标机器的平台来选择。

如果我们还要进行NDK的开发，还需要下载`ndk-bundle`，但是这里的NDK只有一个版本，所以如果NDK版本不是我们需要的，我们还需要去单独下载NDK。