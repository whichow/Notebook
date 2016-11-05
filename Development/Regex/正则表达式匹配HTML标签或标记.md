<div>

<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-243"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | &lt;(\\S\*?)                         |
|                                      | \[\^&gt;\]\*&gt;.\*?&lt;/\\1&gt;|&lt |
|                                      | ;.\*?                                |
|                                      | /&gt;                                |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | &lt;html&gt;hello&lt;/html&gt;|&lt;a |
|                                      | &gt;abcd&lt;/a&gt;                   |
+--------------------------------------+--------------------------------------+
| 不匹配                               | abc|123|&lt;html&gt;ddd              |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-281"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | \^\[\^&lt;&gt;\`\~!/@\\\#}\$%:;)(\_\ |
|                                      | ^{&\*=|'+\]+\$                       |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | This is a test                       |
+--------------------------------------+--------------------------------------+
| 不匹配                               | &lt;href = | &lt;br&gt; | That's it  |
+--------------------------------------+--------------------------------------+

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-319"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | &lt;!--.\*?--&gt;                    |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | &lt;!-- &lt;h1&gt;this text has been |
|                                      | removed&lt;/h1&gt; --&gt; | &lt;!--  |
|                                      | yada --&gt;                          |
+--------------------------------------+--------------------------------------+
| 不匹配                               | &lt;h1&gt;this text has not been     |
|                                      | removed&lt;/h1&gt;                   |
+--------------------------------------+--------------------------------------+

\
<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-357"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | (\\\[(\\w+)\\s\*((\[\\w\]\*)=('|")?( |
|                                      | \[a-zA-Z0-9|:|\\/|=|-|.|\\?|&\]\*)(\ |
|                                      | \5)?)\*\\\])(\[a-zA-Z0-9|:|\\/|=|-|. |
|                                      | |\\?|&|\\s\]+)(\\\[\\/\\2\\\])       |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | \[link                               |
|                                      | url="http://www.domain.com/file.exte |
|                                      | nsion?getvar=value&secondvar=value"\ |
|                                      | ]Link\[/li                           |
+--------------------------------------+--------------------------------------+
| 不匹配                               | \[a\]whatever\[/b\] | \[a            |
|                                      | var1=something                       |
|                                      | var2=somethingelse\]whatever\[/a\] | |
|                                      |  \[a\]whatever\[a\]                  |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-395"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | href=\[\\"\\'\](http:\\/\\/|\\.\\/|\ |
|                                      | \/)?\\w+(\\.\\w+)\*(\\/\\w+(\\.\\w+) |
|                                      | ?)\*(\\/|\\?\\w\*=\\w\*(&\\w\*=\\w\* |
|                                      | )\*)?\[\\"\\'\]                      |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | href="www.yahoo.com" | href="http:// |
|                                      | localhost/blah/" | href="eek"        |
+--------------------------------------+--------------------------------------+
| 不匹配                               | href="" | href=eek | href="bad       |
|                                      | example"                             |
+--------------------------------------+--------------------------------------+

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-433"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | "(\[\^"\](?:\\\\.|\[\^\\\\"\]\*)\*)" |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | "This is a \\"string\\"."            |
+--------------------------------------+--------------------------------------+
| 不匹配                               | "This is a \\"string\\".             |
+--------------------------------------+--------------------------------------+

\
<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-471"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | (?i:on(blur|c(hange|lick)|dblclick|f |
|                                      | ocus|keypress|(key|mouse)(down|up)|( |
|                                      | un)?load|mouse(move|o(ut|ver))|reset |
|                                      | |s(elect|ubmit)))                    |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | +----------------------------------- |
|                                      | ---+-------------------------------- |
|                                      | ------+                              |
|                                      | |                                    |
|                                      |    | <div                            |
|                                      |       |                              |
|                                      | |                                    |
|                                      |    | class="t37 t22 t15 t7 t8 ty-494 |
|                                      | "     |                              |
|                                      | |                                    |
|                                      |    | style="margin: 0px; padding: 0p |
|                                      | x; bo |                              |
|                                      | |                                    |
|                                      |    | rder: 0px; outline: 0px; font-s |
|                                      | ize:  |                              |
|                                      | |                                    |
|                                      |    | 16px !important; vertical-align |
|                                      | : bas |                              |
|                                      | |                                    |
|                                      |    | eline !important; -webkit-text- |
|                                      | size- |                              |
|                                      | |                                    |
|                                      |    | adjust: none; color: rgb(51, 51 |
|                                      | , 51) |                              |
|                                      | |                                    |
|                                      |    |  !important; font-weight: norma |
|                                      | l !im |                              |
|                                      | |                                    |
|                                      |    | portant; opacity: 1 !important; |
|                                      | ">    |                              |
|                                      | |                                    |
|                                      |    |                                 |
|                                      |       |                              |
|                                      | |                                    |
|                                      |    | onclick | onsubmit | onmouseove |
|                                      | r     |                              |
|                                      | |                                    |
|                                      |    |                                 |
|                                      |       |                              |
|                                      | |                                    |
|                                      |    | </div>                          |
|                                      |       |                              |
|                                      | +----------------------------------- |
|                                      | ---+-------------------------------- |
|                                      | ------+                              |
+--------------------------------------+--------------------------------------+
| 不匹配                               | click | onandon | mickeymouse        |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-527"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | (?s)/\\\*.\*\\\*/                    |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | /\* .................... \*/ | /\*   |
|                                      | imagine lots of lines here \*/       |
+--------------------------------------+--------------------------------------+
| 不匹配                               | \*/ malformed opening tag \*/ | /\*  |
|                                      | malformed closing tag /\*            |
+--------------------------------------+--------------------------------------+

\
<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-565"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | &lt;(\\S\*?)                         |
|                                      | \[\^&gt;\]\*&gt;.\*?&lt;/\\1&gt;|&lt |
|                                      | ;.\*?                                |
|                                      | /&gt;                                |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | &lt;html&gt;hello&lt;/html&gt;|&lt;a |
|                                      | &gt;abcd&lt;/a&gt;                   |
+--------------------------------------+--------------------------------------+
| 不匹配                               | abc|123|&lt;html&gt;ddd              |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-603"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | \\xA9                                |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | ©                                    |
+--------------------------------------+--------------------------------------+
| 不匹配                               | anything                             |
+--------------------------------------+--------------------------------------+

\
<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-641"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | src\[\^&gt;\]\*\[\^/\].(?:jpg|bmp|gi |
|                                      | f)(?:\\"|\\')                        |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | src="../images/image.jpg" | src="htt |
|                                      | p://domain.com/images/image.jpg" | s |
|                                      | rc='d:\\w                            |
+--------------------------------------+--------------------------------------+
| 不匹配                               | src="../images/image.tif" | src="cid |
|                                      | :value"                              |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-679"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | /\\\*\[\\d\\D\]\*?\\\*/              |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | /\* my comment \*/ | /\* my          |
|                                      | multiline comment \*/ | /\* my       |
|                                      | nested comment \*/                   |
+--------------------------------------+--------------------------------------+
| 不匹配                               | \*/ anything here /\* | anything     |
|                                      | between 2 seperate comments | \\\*   |
|                                      | \*\\                                 |
+--------------------------------------+--------------------------------------+

\
<div class="wiz-table-container"
style="position: relative; padding: 15px 0px 5px;">

<div class="wiz-table-body">

+--------------------------------------+--------------------------------------+
| 正则表达式                           | <div                                 |
|                                      | class="t37 t22 t15 t7 t8 ty-717"     |
|                                      | style="margin: 0px; padding: 0px; bo |
|                                      | rder: 0px; outline: 0px; font-size:  |
|                                      | 16px !important; vertical-align: bas |
|                                      | eline !important; -webkit-text-size- |
|                                      | adjust: none; color: rgb(51, 51, 51) |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; opacity: 1 !important;">    |
|                                      |                                      |
|                                      | &lt;\[a-zA-Z\]+(\\s+\[a-zA-Z\]+\\s\* |
|                                      | =\\s\*("(\[\^"\]\*)"|'(\[\^'\]\*)')) |
|                                      | \*\\s\*/&gt;                         |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+
| 匹配                                 | &lt;img src="test.gif"/&gt;          |
+--------------------------------------+--------------------------------------+
| 不匹配                               | &lt;img src="test.gif"&gt; | &lt;img |
|                                      | src="test.gif"a/&gt;                 |
+--------------------------------------+--------------------------------------+

</div>

</div>

\

</div>
