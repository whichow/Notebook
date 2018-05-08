NDK安装包中提供了三个调试工具：addr2line、objdump和ndk-stack。

比如说有下面一段代码：

```c++
#include <string.h>  
#include <jni.h>  
// hell-jni.c  
#ifdef __cplusplus  
extern "C" {  
#endif  
    void willCrash()  
    {  
        int i = 10;  
        int y = i / 0;  
    }  
  
    JNIEXPORT jint JNICALL JNI_OnLoad(JavaVM* vm, void* reserved)  
    {  
        willCrash();  
        return JNI_VERSION_1_4;  
    }  
  
    jstring  
    Java_com_example_hellojni_HelloJni_stringFromJNI( JNIEnv* env,  
                                                      jobject thiz )  
    {  
    // 此处省略实现逻辑。。。  
    }  
  
#ifdef __cplusplus  
}  
#endif  
```

闪退日志：

```cmd
01-01 17:59:38.246: D/dalvikvm(20794): Late-enabling CheckJNI  
01-01 17:59:38.246: I/ActivityManager(1185):   
Start proc com.example.hellojni for activity com.example.hellojni/.HelloJni: pid=20794 uid=10351 gids={50351, 1028, 1015}  
01-01 17:59:38.296: I/dalvikvm(20794): Enabling JNI app bug workarounds for target SDK version 3...  
01-01 17:59:38.366: D/dalvikvm(20794): Trying to load lib /data/app-lib/com.example.hellojni-1/libhello-jni.so 0x422a4f58  
01-01 17:59:38.366: D/dalvikvm(20794): Added shared lib /data/app-lib/com.example.hellojni-1/libhello-jni.so 0x422a4f58  
01-01 17:59:38.366: A/libc(20794): Fatal signal 8 (SIGFPE) at 0x0000513a (code=-6), thread 20794 (xample.hellojni)  
01-01 17:59:38.476: I/DEBUG(253): pid: 20794, tid: 20794, name: xample.hellojni  >>> com.example.hellojni <<<  
01-01 17:59:38.476: I/DEBUG(253): signal 8 (SIGFPE), code -6 (SI_TKILL), fault addr 0000513a  
01-01 17:59:38.586: I/DEBUG(253):     r0 00000000  r1 0000513a  r2 00000008  r3 00000000  
01-01 17:59:38.586: I/DEBUG(253):     r4 00000008  r5 0000000d  r6 0000513a  r7 0000010c  
01-01 17:59:38.586: I/DEBUG(253):     r8 75226d08  r9 00000000  sl 417c5c38  fp bedbf134  
01-01 17:59:38.586: I/DEBUG(253):     ip 41705910  sp bedbf0f0  lr 4012e169  pc 4013d10c  cpsr 000f0010  
                                            // 省略部份日志 。。。。。。  
01-01 17:59:38.596: I/DEBUG(253): backtrace:  
01-01 17:59:38.596: I/DEBUG(253):     #00  pc 0002210c  /system/lib/libc.so (tgkill+12)  
01-01 17:59:38.596: I/DEBUG(253):     #01  pc 00013165  /system/lib/libc.so (pthread_kill+48)  
01-01 17:59:38.596: I/DEBUG(253):     #02  pc 00013379  /system/lib/libc.so (raise+10)  
01-01 17:59:38.596: I/DEBUG(253):     #03  pc 00000e80  /data/app-lib/com.example.hellojni-1/libhello-jni.so (__aeabi_idiv0+8)  
01-01 17:59:38.596: I/DEBUG(253):     #04  pc 00000cf4  /data/app-lib/com.example.hellojni-1/libhello-jni.so (willCrash+32)  
01-01 17:59:38.596: I/DEBUG(253):     #05  pc 00000d1c  /data/app-lib/com.example.hellojni-1/libhello-jni.so (JNI_OnLoad+20)  
01-01 17:59:38.596: I/DEBUG(253):     #06  pc 00052eb1  /system/lib/libdvm.so (dvmLoadNativeCode(char const*, Object*, char**)+468)  
01-01 17:59:38.596: I/DEBUG(253):     #07  pc 0006a62d  /system/lib/libdvm.so  
01-01 17:59:38.596: I/DEBUG(253):          // 省略部份日志 。。。。。。  
01-01 17:59:38.596: I/DEBUG(253): stack:  
01-01 17:59:38.596: I/DEBUG(253):          bedbf0b0  71b17034  /system/lib/libsechook.so  
01-01 17:59:38.596: I/DEBUG(253):          bedbf0b4  7521ce28    
01-01 17:59:38.596: I/DEBUG(253):          bedbf0b8  71b17030  /system/lib/libsechook.so  
01-01 17:59:38.596: I/DEBUG(253):          bedbf0bc  4012c3cf  /system/lib/libc.so (dlfree+50)  
01-01 17:59:38.596: I/DEBUG(253):          bedbf0c0  40165000  /system/lib/libc.so  
01-01 17:59:38.596: I/DEBUG(253):          // 省略部份日志 。。。。。。  
01-01 17:59:38.736: W/ActivityManager(1185):   Force finishing activity com.example.hellojni/.HelloJni  
```

这一行可以看到引发异常的原因

```
01-01 17:59:38.476: I/DEBUG(253): signal 8 (SIGFPE), code -6 (SI_TKILL), fault addr 0000513a  
```

这一行的后面都是堆栈信息

```
01-01 17:59:38.596: I/DEBUG(253): backtrace:
```

找到引发异常的地方

```
01-01 17:59:38.596: I/DEBUG(253):     #03  pc 00000e80  /data/app-lib/com.example.hellojni-1/libhello-jni.so (__aeabi_idiv0+8)  
01-01 17:59:38.596: I/DEBUG(253):     #04  pc 00000cf4  /data/app-lib/com.example.hellojni-1/libhello-jni.so (willCrash+32)  
01-01 17:59:38.596: I/DEBUG(253):     #05  pc 00000d1c  /data/app-lib/com.example.hellojni-1/libhello-jni.so (JNI_OnLoad+20)  
```

**使用addr2line  定位出错位置** 

```
addr2line -e libhello-jni.so 00000cf4 00000d1c 
```

**使用objdump  定位出错的函数信息** 

```
objdump -S -D libhello-jni.so > dump.log  
```

**使用ndk-stack 分析Log**

有两种方式使用ndk-stack:

直接输出Log

```
adb logcat | $NDK/ndk-stack -sym $PROJECT_PATH/obj/local/armeabi
```

 使用Log文件

```
adb logcat > /tmp/foo.txt
$NDK/ndk-stack -sym $PROJECT_PATH/obj/local/armeabi -dump foo.txt
```



[Android NDK开发Crash错误定位 ](https://blog.csdn.net/xyang81/article/details/42319789)

[ndk-stack](https://developer.android.com/ndk/guides/ndk-stack?hl=zh-CN)