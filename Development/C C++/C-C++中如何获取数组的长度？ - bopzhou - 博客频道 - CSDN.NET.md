C、C++中没有提供 直接获取数组长度的函数，对于存放字符串的字符数组提供了一个strlen函数获取长度，那么对于其他类型的数组如何获取他们的长度呢？其中一种方法是使 用sizeof(array) / sizeof(array\[0\]), 在C语言中习惯上在 使用时都把它定义成一个宏，比如\#define GET\_ARRAY\_LEN(array,len) {len = (sizeof(array) / sizeof(array\[0\]));} 。而在C++中则可以使用模板 技术定义一个函数，比如：

template &lt;class T&gt;

int getArrayLen(T& array)

{

return (sizeof(array) / sizeof(array\[0\]));

}

这样对于不同类型的数 组都可以使用这个宏或者这个函数来获取数组的长度了。以下是两个Demo程序，一个C语言的，一个C++的：

P.S：若数组为存储 字符串的字符数组，则所求得的长度还需要减一，即对于宏定义： \#define GET\_ARRAY\_LEN(array,len) {len = (sizeof(array) / sizeof(array\[0\]) - 1 );} ，对于函数定义：

template &lt;class T&gt;

int getArrayLen(T& array)

{

return (sizeof(array) / sizeof(array\[0\]) - 1);

}

原因为存储字符串的字 符数组末尾有一个'/0'字符，需要去掉它。

【C语言】

\#include &lt;stdio.h&gt;

\#include &lt;stdlib.h&gt;

 

\#define GET\_ARRAY\_LEN(array,len){len = (sizeof(array) / sizeof(array\[0\]));}

//定义一个带参数的 宏，将数组长度存储在变量len中

int main()

{

char a\[\] = {'1','2','3','4'};

int len;

 

GET\_ARRAY\_LEN(a,len)

//调用预定义的宏，取得数组a的长度，并将其存储在变量len中

printf("%d/n",len);

 

system("pause");

return 0;

}

【C++】

\#include &lt;iostream&gt;

using namespace std;

 

template &lt;class T&gt;

int getArrayLen(T& array)

{//使用模板定义一 个函数getArrayLen,该函数将返回数组array的长度

return (sizeof(array) / sizeof(array\[0\]));

}

int main()

{

char a\[\] = {'1','2','3'};

cout &lt;&lt; getArrayLen(a) &lt;&lt; endl;

 

return 0;


