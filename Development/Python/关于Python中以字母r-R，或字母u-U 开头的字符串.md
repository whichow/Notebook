（1）以r或R开头的python中的字符串表示（非转义的）原始字符串

python里面的字符，如果开头处有个r，比如：

(r’^time/plus/\\d{1,2}/$’, hours\_ahead)

说明字符串r"XXX"中的XXX是普通字符。

有普通字符相比，其他相对特殊的字符，其中可能包含转义字符，即那些，反斜杠加上对应字母，表示对应的特殊含义的，比如最常见的”\\n"表示换行，"\\t"表示Tab等。

而如果是以r开头，那么说明后面的字符，都是普通的字符了，即如果是“\\n”那么表示一个反斜杠字符，一个字母n，而不是表示换行了。

以r开头的字符，常用于正则表达式，对应着re模块。

关于re模块，详情自己google搜索“python re”。

举例：

原始字符串操作符(r/R),能方便处理反斜杠:

[?](http://www.crifan.com/python_string_with_leading_char_r_u/#)

[TABLE]

（2）以u或U开头的字符串表示unicode字符串

Unicode是书写国际文本的标准方法。如果你想要用非英语写文本,那么你需要有一个支持Unicode的编辑器。

类似地,Python允许你处理Unicode文本——你只需要在字符串前加上前缀u或U。

举例：

[TABLE]

来源： <http://www.crifan.com/python_string_with_leading_char_r_u/>


