在C++中如果定义了一个宏
```cpp
#define __USE_SHARESDK__
```
如果使用
```cpp
#ifdef __USE_SHARESDK__

#endif
```
是会编译#ifdef里面的内容的

如果这样定义
```cpp
#define __USE_SHARESDK__ 0
```
使用
```cpp
#ifdef __USE_SHARESDK__

#endif
```
也会编译里面的内容，因为只要定义了`__USE_SHARESDK__`，#ifdef判断就为真，而不管定义的内容是什么。

但是使用
```cpp
#if __USE_SHARESDK__

#endif
```
是不会编译里面的内容，因为`__USE_SHARESDK__`定义的是0，`#if`判断为假，将0改成1就会编译了。