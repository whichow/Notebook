使用curl测试网站
<div>

<div>

\

</div>

<div>

发送表单信息有GET和POST两种方法。GET方法相对简单，只要把数据附在网址后面就行。

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

\$ curl example.com/form.cgi?data=xxx

</div>

</div>

</div>

<div>

\

</div>

<div>

POST方法必须把数据和网址分开，curl就要用到--data参数。

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

\$ curl -X POST --data "data=xxx" example.com/form.cgi

</div>

</div>

</div>

<div>

\

</div>

<div>

如果你的数据没有经过表单编码，还可以让curl为你编码，参数是\`--data-urlencode\`。

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

\$ curl -X POST--data-urlencode "date=April 1" example.com/form.cgi

</div>

</div>

</div>

<div>

\

</div>

</div>
