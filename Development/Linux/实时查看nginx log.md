
在nginx.conf中可以看到nginx的log文件位置在/var/log/nginx中，我们想要查看其中的error.log，可以使用命令
```shell
tail -f /var/log/nginx/error.log
```
会把error.log里最尾部的内容显示在屏幕上，并且一直刷新，使你看到最新的文件内容。

如果log太多还可以加上 -n 显示最后几行的内容
```shell
tail -f -n 5 /var/log/nginx/error.log
```

**参考**

[centos linux下查看 nginx 默认 日志 位置 实时查看显示日志](http://www.weiruoyu.cn/?p=2424)

[每天一个linux命令（15）：tail 命令](http://www.cnblogs.com/peida/archive/2012/11/07/2758084.html)