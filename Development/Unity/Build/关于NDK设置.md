正常打Android包是不需要设置NDK路径的，Unity也无法通过C/C++的源码及Android.mk来编译so库（除非自己写编译命令行加入打包过程中），Unity中设置NDK是为了打IL2CPP的Android包时编译C++源码



[Android environment setup](https://docs.unity3d.com/Manual/android-sdksetup.html)

[Native (C++) plug-ins for Android](https://docs.unity3d.com/Manual/AndroidNativePlugins.html)