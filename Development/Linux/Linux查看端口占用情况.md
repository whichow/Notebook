Linux查看端口占用情况
查看端口占用情况

lsof -i

查看某一端口占用情况

lsof -i:80

结束占用端口的进程

killall 进程名

也可以使用

netstat -apn | grep &lt;端口号&gt;


