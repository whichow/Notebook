使用curl测试网站

发送表单信息有GET和POST两种方法。GET方法相对简单，只要把数据附在网址后面就行。

$ curl example.com/form.cgi?data=xxx

POST方法必须把数据和网址分开，curl就要用到--data参数。

$ curl -X POST --data "data=xxx" example.com/form.cgi

如果你的数据没有经过表单编码，还可以让curl为你编码，参数是\`--data-urlencode\`。

$ curl -X POST--data-urlencode "date=April 1" example.com/form.cgi


