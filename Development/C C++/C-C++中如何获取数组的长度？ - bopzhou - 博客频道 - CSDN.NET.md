<div id="container">

<div id="body">

<div id="main">

<div class="main">

<div id="article_details" class="details">

<div id="article_content" class="article_content">

<div
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; height: 1996px; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none; width: 708px;">

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">C<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">、C++中没有提供
直接获取数组长度的函数，对于存放字符串的字符数组提供了一个strlen函数获取长度，那么对于其他类型的数组如何获取他们的长度呢？其中一种方法是使
用sizeof(array) / sizeof(array\[0\]),</span> </span><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">在C语言中习惯上在</span> </span><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">使用时都把它定义成一个宏，比如\#define
GET\_ARRAY\_LEN(array,len) {len = (sizeof(array) /
sizeof(array\[0\]));}</span> </span><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">。而在C++中则可以使用模板
技术定义一个函数，比如：</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">template
&lt;class T&gt;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
getArrayLen(T& array)</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">{</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">return
(sizeof(array) / sizeof(array\[0\]));</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">}</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">这样对于不同类型的数
组都可以使用这个宏或者这个函数来获取数组的长度了。以下是两个Demo程序，一个C语言的，一个C++的：</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">P.S<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">：若数组为存储
字符串的字符数组，则所求得的长度还需要减一，即对于宏定义：</span> </span><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">\#define
GET\_ARRAY\_LEN(array,len) {len = (sizeof(array) /
sizeof(array\[0\])</span> <span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">-
1</span> <span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">);}</span> <span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">，对于函数定义：</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">template
&lt;class T&gt;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
getArrayLen(T& array)</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">{</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">return
(sizeof(array) / sizeof(array\[0\]) - 1);</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">}</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">原因为存储字符串的字
符数组末尾有一个'/0'字符，需要去掉它。</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">【C语言】</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">\#include
&lt;stdio.h&gt;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">\#include
&lt;stdlib.h&gt;</span>

 

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">\#define
GET\_ARRAY\_LEN(array,len){len = (sizeof(array) /
sizeof(array\[0\]));}</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">//<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">定义一个带参数的
宏，将数组长度存储在变量len中</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
main()</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">{</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">char
a\[\] = {'1','2','3','4'};</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
len;</span>

 

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">GET\_ARRAY\_LEN(a,len)</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">//<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">调用预定义的宏，取得数组a的长度，并将其存储在变量len中</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">printf("%d/n",len);</span>

 

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">system("pause");</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">return
0;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">}</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;"><span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">【C++】</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">\#include
&lt;iostream&gt;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">using
namespace std;</span>

 

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">template
&lt;class T&gt;</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
getArrayLen(T& array)</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">{//<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 宋体; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">使用模板定义一
个函数getArrayLen,该函数将返回数组array的长度</span></span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">return
(sizeof(array) / sizeof(array\[0\]));</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">}</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">int
main()</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">{</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">char
a\[\] = {'1','2','3'};</span>

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">cout
&lt;&lt; getArrayLen(a) &lt;&lt; endl;</span>

 

<span
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial; line-height: 26px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">return
0;</span>

</div>

</div>

</div>

</div>

</div>

</div>

</div>
