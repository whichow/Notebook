使用Visual Studio可以生成动态库，生成动态库时会生成.h，.lib，和.dll文件，其中.lib不包含具体的执行代码，里面只有关于DLL调用的相关信息。
## 动态库的使用
1. 隐式链接：
隐式链接就是在程序加载时链接动态库。隐式链接需要.h，.lib和.dll三件套，实现起来也很容易，只需要`include` .h文件后使用`pragma comment`指令指示编译器链接.lib文件就可以了。

```cpp
#include "mylib.h"
#pragma commit(lib, "mylib.lib")
```
2. 显式链接：
显示链接可以在程序运行时动态加载和卸载动态库。不需要.h和.lib文件，使用`LoadLibrary`来加载动态库，使用`GetProcAddress`来获取函数地址，调用完后使用`FreeLibrary`函数来卸载动态库。

```cpp
#include <windows.h> 
#include <stdio.h> 

void main(void)
{
    typedef int(*pMax)(int a,int b);
    typedef int(*pMin)(int a,int b);
    HINSTANCE hDLL;
    PMax Max
    HDLL=LoadLibrary("MyDll.dll");//加载动态链接库MyDll.dll文件；
    Max=(pMax)GetProcAddress(hDLL,"Max");
    A=Max(5,8);
    Printf("比较的结果为%d\n"，a);
    FreeLibrary(hDLL);//卸载MyDll.dll文件；
}
```

**参考**

[在C++中调用DLL中的函数](http://blog.sina.com.cn/s/blog_53004b4901009h3b.html)

[Using Load-Time Dynamic Linking](https://msdn.microsoft.com/en-us/library/windows/desktop/ms686923(v=vs.85).aspx)

[Using Run-Time Dynamic Linking](https://msdn.microsoft.com/en-us/library/windows/desktop/ms686944(v=vs.85).aspx)

[使用 __declspec(dllimport) 导入到应用程序中](https://msdn.microsoft.com/zh-cn/library/8fskxacy.aspx)

[Pragma Directives and the __Pragma Keyword](https://msdn.microsoft.com/en-us/library/d9x1s805.aspx)

[comment (C/C++)](https://msdn.microsoft.com/en-us/library/7f0aews7.aspx)