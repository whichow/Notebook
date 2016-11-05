python的url编码函数是在类urllib库中，使用方法是：

> urllib.quote(string\[,
> safe\])，除了三个符号“\_.-”外，将所有符号编码，后面的参数safe是不编码的字符，使用的时候如果不设置的话，会将斜杠，冒号，等号，问号都给编码了。

``` {style="box-sizing: border-box; font-family: Consolas, 'Liberation Mono', Menlo, Courier, monospace; font-size: 13.6px; margin-top: 0px; margin-bottom: 16px; font-stretch: normal; line-height: 1.45; word-wrap: normal; padding: 16px; overflow: auto; border-radius: 3px; color: rgb(51, 51, 51); orphans: 2; widows: 2; background-color: rgb(247, 247, 247);"}
>>> import urllib
>>> urllib.quote("a-b-c")
'a-b-c'
>>> urllib.quote("a+b+c")
'a%2Bb%2Bc'
>>> urllib.quote("http://test.com/a+b+c")
'http%3A//test.com/a%2Bb%2Bc'
>>> urllib.quote("http://test.com/a+b+c", ":/")
'http://test.com/a%2Bb%2Bc'
>>> urllib.quote("http://test.com/?q=a+b+c", ":?=/")
'http://test.com/?q=a%2Bb%2Bc'
```

urllib2.quote 也是一样用法

\

<div style="color:gray">

来源： <https://github.com/mozillazg/my-blog-file/blob/master/2011/12/python-url-quote.md>

</div>
