<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">python中有很多字符串连接方式，今天在写代码，顺便总结一下：</span>\
\

-   最原始的字符串连接方式：str1 + str2
-   python 新字符串连接语法：str1, str2
-   奇怪的字符串方式：str1 str2
-   % 连接字符串：‘name:%s; sex:%s ’ % ('tom', 'male')
-   字符串列表连接：str.join(some\_list)\

\
<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
   第一种，想必只要是有编程经验的人，估计都知道，直接用 “+”
来连接两个字符串：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_Na7" style="word-wrap: break-word;">

1.  'Jim' + 'Green' = 'JimGreen'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
 
第二种比较特殊，如果两个字符串用“逗号”隔开，那么这两个字符串将被连接，但是，字符串之间会多出一个空格：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_ahA" style="word-wrap: break-word;">

1.  'Jim', 'Green' = 'Jim Green'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
 第三种也是 python
独有的，只要把两个字符串放在一起，中间有空白或者没有空白：两个字符串自动连接为一个字符串：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_N01" style="word-wrap: break-word;">

1.  'Jim''Green' = 'JimGreen'\
2.  'Jim'  'Green' = 'JimGreen'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
 第四种功能比较强大，借鉴了C语言中 printf
函数的功能，如果你有C语言基础，看下文档就知道了。这种方式用符号“%”连接一个字符串和一组变量，字符串中的特殊标记会被自动用右边变量组中的变量替换：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_R7C" style="word-wrap: break-word;">

1.  '%s, %s' % ('Jim', 'Green') = 'Jim, Green'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
 第五种就属于技巧了，利用字符串的函数 join
。这个函数接受一个列表，然后用字符串依次连接列表中每一个元素：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_4C3" style="word-wrap: break-word;">

1.  var\_list = \['tom', 'david', 'john'\]\
2.  a = '\#\#\#'\
3.  a.join(var\_list) =  'tom\#\#\#david\#\#\#john'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<span
style="color: rgb(68, 68, 68); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"> 
 其实，python
中还有一种字符串连接方式，不过用的不多，就是字符串乘法，如：</span>\

<div class="blockcode"
style="word-wrap: break-word; overflow: hidden; margin-top: 10px; margin-bottom: 10px; padding: 10px 0px 5px 10px; color: rgb(102, 102, 102); zoom: 1; border: 1px solid rgb(204, 204, 204); font-family: Tahoma, 'Microsoft Yahei', Simsun; font-size: 14px; font-variant-ligatures: normal; orphans: 2; widows: 2; background: url(&quot;&quot;) 0px 0px repeat-y rgb(247, 247, 247);">

<div id="code_NiM" style="word-wrap: break-word;">

1.  a = 'abc'\
2.  a \* 3 = 'abcabcabc'

</div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">复制代码</span>

</div>

<div>

<span
style="word-wrap: break-word; margin-left: 43px; font-size: 12px; cursor: pointer; color: rgb(51, 102, 153) !important;">\
</span>
<div style="color:gray">

来源： <http://www.openstack.org.cn/bbs/forum.php?mod=viewthread&tid=506>

</div>

</div>
