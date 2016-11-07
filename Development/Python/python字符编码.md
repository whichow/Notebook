**源文件编码格式**

源代码文件中，如果有用到非ASCII字符比如汉字，则需要在文件头部进行字符编码的声明，否则会报错：

``` prettyprint
#-*- coding: UTF-8 -*-或# coding: UTF-8
```

utf-8不区分大小写，还可以写成u8，实际上Python只检查\#、coding和编码字符串，其他的字符都是为了美观加上的。声明的编码必须与文件实际保存时用的编码一致

**系统编码格式**

``` prettyprint
import syssys.getdefaultencoding()    #python2默认字符串编码格式为ascii，python3为unicodesys.getfilesystemencoding()    #文件系统编码mbcs(中文系统为gbk)
reload(sys)sys.setdefaultencoding('utf-8')    #这两句可以设置默认编码为utf-8，但是非常不建议这么做，在python3中已经没有这个函数了
```

字符串输出，如果设置了编码格式为utf-8，则默认的字符串编码为utf-8，如果字符串中有中文字符，则需要转换城utf-8编码格式才能正常输出，如果没有中文虽然也能正常输出(英文和数字的unicode和utf-8编码相同)，但是最好统一转换为utf-8格式输出。

在字符串前面加上u可以将字符串的格式设置为unicode，统一将字符串加上u可以减少编码格式问题。

需要将其他编码格式解码为unicode才能编码成另外一种格式，不能再解码unicode字符串，也不能再对其他格式的字符串进行编码。使用repr(text)查看可以字符串的编码。

``` prettyprint
# coding: UTF-8 text1 = "字符串1"    #utf-8text2 = u"字符串2"    #unicodeprint text1    #字符串1print text2    #抛出异常print text2.encode('utf-8')    #字符串2(unicode->utf-8)print text1.decode('utf-8')    #抛出异常(utf-8->unicode)print text1.decode('utf-8').encode('utf-8')    #字符串1(utf-8->unicode->utf-8)print text2.encode('gbk')    #乱码
```

Windows的文件系统格式默认为gbk，所以，如果需要建立文件或文件夹，则需要将utf-8编码转换为unicode或gbk才能正常创建

``` prettyprint
# coding: UTF-8import ostext1 = "文件夹1"text2 = u"文件夹2"os.mkdir(text1)    #乱码或抛出异常os.mkdir(text2)    #正常创建os.mkdir(text1.decode('utf-8'))    #正常创建os.mkdir(text2.encode('gbk'))    #正常创建
```


