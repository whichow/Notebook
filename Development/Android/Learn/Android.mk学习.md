假设有一个工程`apps/hello-jni/project`

在这个工程中：
  - 'src'目录包含Java源文件
  - 'jni'目录包含native源文件，如'jni/hello-jni.c'


'jni/Android.mk'文件描述了NDK怎样构建共享库，
```
   LOCAL_PATH := $(call my-dir)

   include $(CLEAR_VARS)

   LOCAL_MODULE    := hello-jni
   LOCAL_SRC_FILES := hello-jni.c

   include $(BUILD_SHARED_LIBRARY)
```

`LOCAL_PATH := $(call my-dir)`

Android.mk文件必须在开头定义LOCAL_PATH变量，用于查找源文件，由于Android.mk和源文件是放在同一个目录下，所以宏方法`call my-dir`返回的是当前目录，即Android.mk所在的目录

`include $(CLEAR_VARS)`

CLEAR_VARS表示清理除LOCAL_PATH外的所有LOCAL_XXX变量，这是因为所有工程都是使用同一个GNU Make执行上下文，所以这些变量都是全局的

`LOCAL_MODULE := hello-jni`

LOCAL_MODULE变量表示编译的共享库模块，编译系统会自动添加前后缀，如'foo'模块编译后生成'libfoo.so'

`LOCAL_SRC_FILES := hello-jni.c`

LOCAL_SRC_FILES包含一组C/C++的源文件，这些文件将被编译并装配到一个模块中。注意不要将头文件包含进来，因为构建系统会自动计算依赖关系

`include $(BUILD_SHARED_LIBRARY)`

BUILD_XXX变量表示要编译成哪种库
- include $(BUILD_STATIC_LIBRARY)表示编译成静态库
- include $(BUILD_SHARED_LIBRARY)表示编译成动态库
- include $(BUILD_EXECUTABLE)表示编译成可执行程序

`LOCAL_SHARED_LIBRARIES`、`LOCAL_STATIC_LIBRARIES`表示需要引用的共享库和静态库，如
```
LOCAL_SHARED_LIBRARIES := \
    libcutils \
    libutils \
    libbinder \
    libmedia \
```

[Android.mk](https://developer.android.com/ndk/guides/android_mk?hl=zh-cn)