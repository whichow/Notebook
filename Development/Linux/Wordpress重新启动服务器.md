如果重启了Wordpress服务器，需要将mysql，php，nginx等服务重新启动
```shell
$service mysqld start
$service php-fpm start
$service nginx start
```