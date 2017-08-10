使用Unity打包Android应用的时候经常会出现SDK不兼容问题

之前的Android SDK Tools使用的是android，而在新的SDK Tools被中被弃用了，取而代之的是sdkmanager

老版本的Unity识别不了新的sdkmanager工具，所以在Build的时候会出现SDK版本问题，我们需要下载老版本的Android SDK，要下载相应版本的SDK，可以使用下面的链接

http://dl-ssl.google.com/android/repository/tools_r[rev]-windows.zip
http://dl-ssl.google.com/android/repository/tools_r[rev]-linux.zip
http://dl-ssl.google.com/android/repository/tools_r[rev]-macosx.zip

例如，版本号为25的Mac平台的API SDK的下载链接为
http://dl-ssl.google.com/android/repository/tools_r25-macosx.zip

解压后只有一个tools文件夹，有了这个SDK Tools我们并不能构建Android应用，还需要下载相应的Build-tools，Platform-tools，Platform

使用下面的命令可以查看所有可用的SDK
```
android list sdk --all
```
更新SDK
```
android update sdk -u -a -t <package no.>
```
下载多个SDK
```
android update sdk -u -a -t 1,2,3,4,..,n
```

如果使用命令下载SDK遇到问题，还可以手动下载相应的包，直接解压到tools同级目录就可以了

[Where can I download an older version of the Android SDK?](https://stackoverflow.com/questions/27043522/where-can-i-download-an-older-version-of-the-android-sdk)

[SDK Tools Release Notes](https://developer.android.com/studio/releases/sdk-tools.html)

[更新 IDE 和 SDK 工具](https://developer.android.com/studio/intro/update.html?hl=zh-cn)

[How to install Android SDK Build Tools on the command line?](https://stackoverflow.com/questions/17963508/how-to-install-android-sdk-build-tools-on-the-command-line)

[ANDROID SDK下载地址列表](http://pro.sr1.me/post/android-sdk-download-links)

[Unity编译时找不到AndroidSDK的问题 | Unable to list target platforms](http://www.jianshu.com/p/fe4c334ee9fe)

[unity3d 5.5.0fx Unable to list target platforms error](https://forum.unity3d.com/threads/unity3d-5-5-0fx-unable-to-list-target-platforms-error.446096/)