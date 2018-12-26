# 在Native层更新纹理

在Unity中实现动态纹理，如果放在C#层，需要每帧进行Texture2D.Apply()操作，而这个方法是非常耗时的，要避免这个操作，我们可以将纹理放到Native层进行处理，直接更新D3D或OpenGL纹理。

如我们对一个纹理在C#层进行操作：

```c#
//对一个RGBA格式的纹理进行操作，如果纹理像素的alpha值大于0.5则设为1，否则设为0
public void ProcessTexture(Texture2D tex)
{
    byte[] texData = tex.GetRawTextureData();
    for(int i = 0; i < texData.length; i+=4)
    {
        if(texData[i+3] > 127)
        {
            texData[i+3] = 255;
        }
        else
        {
            texData[i+3] = 0;
        }
    }
    tex.Apply();
}
```

下面我们来看一下如何在Native层进行上面的操作

## 在D3D11中更新纹理

首先使用VS创建一个UnityNativePlugin的工程，然后在头文件的包含路径中添加Unity安装目录下的Editor\Data\PluginAPI这个路径，然后新建一个TextureProcess.cpp文件

```c++
#include <stdlib.h>
#include <d3d11.h>
#include <assert.h>
#include "IUnityGraphics.h"
#include "IUnityGraphicsD3D11.h"

static IUnityInterfaces* s_UnityInterfaces = NULL;
static IUnityGraphicsD3D11* s_Graphics = NULL;
static ID3D11Device* s_Device = NULL;

//插件加载时调用，在这里获取ID3D11Device
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginLoad(IUnityInterfaces* unityInterfaces)
{
	s_UnityInterfaces = unityInterfaces;
	s_Graphics = unityInterfaces->Get<IUnityGraphicsD3D11>();
	s_Device = s_Graphics->GetDevice();
}

//插件卸载时调用
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginUnload()
{
	return;
}

static void* g_TextureHandler = NULL;
static int g_TextureWidth = 0;
static int g_TextureHeight = 0;
static unsigned char *g_TextureData = NULL;

//获取从C#层传入的纹理地址和宽高
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API InitTexture(void* texPtr, size_t width, size_t height)
{
	g_TextureHandler = texPtr;
	g_TextureWidth = width;
	g_TextureHeight = height;
    g_TextureData = (unsigned char*)malloc(width * height * 4);
}

//获取从C#层传入的纹理数据
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UpdateTexture(unsigned char *texData, size_t length)
{
	unsigned char *data = g_TextureData;
	memcpy(data, texData, length);

	for (size_t i = 0; i < length; i+=4)
	{
		if (data[i+3] > 127)
		{
			data[i+3] = 255;
		}
		else
		{
			data[i+3] = 0;
		}
	}
}

//释放缓存的纹理
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API ReleaseTexture()
{
	free(g_TextureData);
}

//处理渲染事件
static void UNITY_INTERFACE_API OnRenderEvent(int eventID)
{
	ID3D11Texture2D* d3dtex = (ID3D11Texture2D*)g_TextureHandler;
	assert(d3dtex);

	ID3D11DeviceContext* ctx = NULL;
	s_Device->GetImmediateContext(&ctx);
    //更新纹理数据
	ctx->UpdateSubresource(d3dtex, 0, NULL, g_TextureData, g_TextureWidth, 0);
	ctx->Release();
}

//用于在Unity中注册渲染的回调事件
extern "C" UnityRenderingEvent UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API GetRenderEventFunc()
{
	return OnRenderEvent;
}
```

我们还要创建一个UnityNativePlugin.def文件，加上下面的内容，防止VC++编译器对函数名进行处理，出现Unity找不到该函数的情况

```
LIBRARY

EXPORTS
	UnityPluginLoad
	UnityPluginUnload
```

编译成功后，放到Unity的Plugins与平台相应的目录，然后在C#中调用就可以了

```c#
[DllImport("UnityNativePlugin")]
private static extern void InitTexture(IntPtr ptr, int width, int height);
[DllImport("UnityNativePlugin")]
private static extern void UpdateTexture(byte[] data, int length);
[DllImport("UnityNativePlugin")]
private static extern void ReleaseTexture();
[DllImport("UnityNativePlugin")]
private static extern IntPtr GetRenderEventFunc();

private void NativeInit(Texture2D tex)
{
    IntPtr texPtr = tex.GetNativeTexturePtr();
    InitTexture(texPtr, width, height);
}

private void NativeUpdate(Texture2D tex)
{
    byte[] texData = tex.GetRawTextureData();
    UpdateTexture(texData, texData.Length);
}

private void NativeRelease()
{
    ReleaseTexture();
}

private IEnumerator WaitForRendering()
{
    while (true)
    {
        yield return new WaitForEndOfFrame();
        //在渲染线程中调用Native函数
        GL.IssuePluginEvent(GetRenderEventFunc(), 1);
    }
}
```

## 在OpenGL中进行纹理更新

下面介绍如何在Android平台的OpenGL ES中实现上面相同的效果

我们需要手动创建工程，这里我们新建一个文件夹作为工程目录

在文件夹中创建一个Application.mk，内容如下

```makefile
#指定平台
APP_ABI := armeabi
#C++运行时库
APP_STL := gnustl_static
#工程目录
APP_PROJECT_PATH := $(call my-dir)
#指定Android.mk文件
APP_BUILD_SCRIPT := Android.mk
#指定Android API level
APP_PLATFORM := android-17
```

然后再创建一个Android.mk，内容如下

```makefile
#指定LOCAL_PATH
LOCAL_PATH := $(call my-dir)
#清理一些变量
include $(CLEAR_VARS)
#模块名
LOCAL_MODULE := UnityNativePlugin
#源文件
LOCAL_SRC_FILES := $(LOCAL_PATH)/src/TextureProcess.cpp
#包含的头文件
LOCAL_C_INCLUDES := $(LOCAL_PATH)/include/PluginAPI
#使用OpenGLES2库					
LOCAL_LDLIBS := -lGLESv2
#编译成动态链接库
include $(BUILD_SHARED_LIBRARY)
```

在工程目录中新建一个include文件夹，把Unity安装目录的Editor\Data\PluginAPI文件夹拷贝进去

然后在工程目录新建一个src文件夹，在里面新建一个TextureProcess.cpp文件

```c++
#include <stdlib.h>
#include <GLES2/gl2.h>
#include <assert.h>
#include "IUnityGraphics.h"

static IUnityInterfaces* s_UnityInterfaces = NULL;

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginLoad(IUnityInterfaces* unityInterfaces)
{
    return;
}

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginUnload()
{
	return;
}

static void* g_TextureHandler = NULL;
static int g_TextureWidth = 0;
static int g_TextureHeight = 0;
static unsigned char *g_TextureData = NULL;

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API InitTexture(void* texPtr, size_t width, size_t height)
{
	g_TextureHandler = texPtr;
	g_TextureWidth = width;
	g_TextureHeight = height;
    g_TextureData = (unsigned char*)malloc(width * height * 4);
}

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UpdateTexture(unsigned char *texData, size_t length)
{
	unsigned char *data = g_TextureData;
	memcpy(data, texData, length);

	for (size_t i = 0; i < length; i+=4)
	{
		if (data[i+3] > 127)
		{
			data[i+3] = 255;
		}
		else
		{
			data[i+3] = 0;
		}
	}
}

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API ReleaseTexture()
{
	free(g_TextureData);
}

static void UNITY_INTERFACE_API OnRenderEvent(int eventID)
{
    GLuint gltex = (GLuint)(size_t)(g_TextureHandler);
    glBindTexture(GL_TEXTURE_2D, gltex);
    //更新纹理数据
    glTexSubImage2D(GL_TEXTURE_2D, 0, 0, 0, g_TextureWidth, g_TextureHeight, GL_RGBA, GL_UNSIGNED_BYTE, data);
}

extern "C" UnityRenderingEvent UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API GetRenderEventFunc()
{
	return OnRenderEvent;
}
```

在工程目录中执行编译命令

```
ndk-build NDK_PROJECT_PATH=. NDK_APPLICATION_MK=Application.mk
```

编译完成后，将so库拷贝到Unity工程的Plugins/Android中相应平台的目录就可以了



[Low-level Native Plugin Interface](https://docs.unity3d.com/Manual/NativePluginInterface.html)

[Android NDK 原生 API](https://developer.android.com/ndk/guides/stable_apis?hl=zh-cn)